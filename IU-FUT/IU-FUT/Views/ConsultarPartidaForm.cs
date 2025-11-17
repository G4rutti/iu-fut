using IU_FUT.Controllers;
using IU_FUT.Models;

namespace IU_FUT.Views
{
    public partial class ConsultarPartidaForm : Form
    {
        private readonly PartidaController _controller;
        private readonly TimeController _timeController;
        private readonly JogadorController _jogadorController;
        private readonly Jogador _jogadorLogado;

        public ConsultarPartidaForm(Jogador jogador)
        {
            _controller = new PartidaController();
            _timeController = new TimeController();
            _jogadorController = new JogadorController();
            _jogadorLogado = jogador;
            InitializeComponent();
            // Conforme diagrama: 1: O ator acessa a tela de consulta de partidas()
            CarregarGrid();
        }

        /// <summary>
        /// Carrega a grade de dados com a lista de partidas.
        /// Conforme diagrama de sequência: 1.1: carregarGrid()
        /// </summary>
        private void CarregarGrid()
        {
            lstPartidas.Items.Clear();
            // 1.1.1: listarPartidas() : List<Partidas>
            var partidas = _controller.ListarPartidas(null);

            foreach (var partida in partidas)
            {
                var item = new ListViewItem(partida.Id.ToString());
                item.SubItems.Add(partida.DataInicio?.ToString("dd/MM/yyyy") ?? "Não definida");
                item.SubItems.Add(partida.DataFim?.ToString("dd/MM/yyyy") ?? "Não definida");
                item.SubItems.Add(partida.Campo?.Nome ?? "N/A");
                item.SubItems.Add(partida.Campo?.Endereco ?? "N/A");
                item.SubItems.Add(partida.Descricao ?? "");
                item.Tag = partida;
                lstPartidas.Items.Add(item);
            }
        }

        private void lstPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPartidas.SelectedItems.Count > 0)
            {
                var partida = lstPartidas.SelectedItems[0].Tag as Partidum;
                if (partida != null)
                {
                    ExibirDetalhes(partida);
                }
            }
        }

        private void ExibirDetalhes(Partidum partida)
        {
            var detalhes = $"ID: {partida.Id}\r\n";
            detalhes += $"Data Início: {partida.DataInicio?.ToString("dd/MM/yyyy") ?? "Não definida"}\r\n";
            detalhes += $"Data Fim: {partida.DataFim?.ToString("dd/MM/yyyy") ?? "Não definida"}\r\n";
            detalhes += $"Descrição: {partida.Descricao ?? "N/A"}\r\n\r\n";
            detalhes += $"Campo: {partida.Campo?.Nome ?? "N/A"}\r\n";
            detalhes += $"Endereço: {partida.Campo?.Endereco ?? "N/A"}\r\n";
            detalhes += $"Cidade: {partida.Campo?.Cidade ?? "N/A"}\r\n\r\n";
            detalhes += $"Times Participantes: {partida.TimePartida.Count}\r\n";
            
            foreach (var tp in partida.TimePartida)
            {
                detalhes += $"  - {tp.Time?.Nome}\r\n";
            }

            txtDetalhes.Text = detalhes;
        }

        /// <summary>
        /// Processa a solicitação de participação conforme diagrama de sequência.
        /// Fluxo Alternativo (4): Solicitar Participação
        /// </summary>
        private void btnSolicitarParticipacao_Click(object sender, EventArgs e)
        {
            if (lstPartidas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione uma partida para participar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var partida = lstPartidas.SelectedItems[0].Tag as Partidum;
            if (partida == null)
            {
                MessageBox.Show("Partida inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // RN03: Só permitir solicitar participação se jogador autenticado
            if (_jogadorLogado == null)
            {
                MessageBox.Show("Você precisa estar autenticado para solicitar participação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Recarregar o jogador do banco para obter dados atualizados (incluindo IdTime)
            var jogadorAtualizado = _jogadorController.ObterJogador(_jogadorLogado.Id);
            if (jogadorAtualizado == null)
            {
                MessageBox.Show("Erro ao carregar dados do jogador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar se o jogador está em um time
            if (jogadorAtualizado.IdTime == null)
            {
                MessageBox.Show("Você precisa estar em um time para participar de uma partida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1.1: verificarVagas() : boolean
                bool verificarVagas = VerificarVagas(partida.Id);

                // 1.2: verificaInscricao() : boolean
                bool verificaInscricao = VerificaInscricao(partida.Id, jogadorAtualizado.IdTime.Value);

                // alt [verificarVagas == true && verificaInscricao == false]
                if (verificarVagas && !verificaInscricao)
                {
                    // 2: criarInscricao()
                    CriarInscricao(partida.Id, jogadorAtualizado.IdTime.Value);

                    // 3: notificarOrganizador()
                    NotificarOrganizador(partida.Id);

                    MessageBox.Show("Seu time participou da partida!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarGrid();
                }
                else if (!verificarVagas)
                {
                    // RN02: Violação - vagas esgotadas
                    MessageBox.Show("Não há vagas disponíveis para esta partida. Deseja entrar na lista de espera?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                else if (verificaInscricao)
                {
                    // RN03: Violação - usuário já inscrito
                    MessageBox.Show("Seu time já está inscrito nesta partida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                TratarExcecao(ex);
            }
        }

        /// <summary>
        /// Verifica se há vagas disponíveis na partida.
        /// Conforme diagrama de sequência: 1.1: verificarVagas() : boolean
        /// RN02: Registro de inscrição só se houver vagas (ou possibilidade de lista de espera).
        /// </summary>
        private bool VerificarVagas(int partidaId)
        {
            // 1.1.1: listarPartidas() : List<Partidas>Vagas
            var partidas = _controller.ListarPartidas(null);

            // 1.1.1.1: existeVaga() : List<Partidas>
            var partida = _controller.ExisteVaga(partidaId);
            return partida;
        }

        /// <summary>
        /// Verifica se o time já está inscrito na partida.
        /// Conforme diagrama de sequência: 1.2: verificaInscricao() : boolean
        /// RN03: Só permitir solicitar participação se jogador autenticado.
        /// </summary>
        private bool VerificaInscricao(int partidaId, int timeId)
        {
            // 1.2.1: listarInscricaoPartida() : List<Partidas>
            var inscricoes = _controller.ListarInscricaoPartida(partidaId);

            // 1.2.1.1: existeInscricao() : List<Partidas>
            return _controller.ExisteInscricao(partidaId, timeId);
        }

        /// <summary>
        /// Cria a inscrição do time na partida.
        /// Conforme diagrama de sequência: 2: criarInscricao()
        /// </summary>
        private void CriarInscricao(int partidaId, int timeId)
        {
            // 2.1: listarInscricaoPartida() : List<Partidas>
            _controller.ListarInscricaoPartida(partidaId);

            // 2.1.1: selecionarPartidas() : List<Partidas>
            _controller.SelecionarPartidas();

            // Criar a inscrição
            _controller.SolicitarParticipacao(partidaId, timeId);
        }

        /// <summary>
        /// Notifica o organizador sobre a nova inscrição.
        /// Conforme diagrama de sequência: 3: notificarOrganizador()
        /// </summary>
        private void NotificarOrganizador(int partidaId)
        {
            // Implementação de notificação (pode ser log, email, etc.)
            // Por enquanto, apenas registra no log do sistema
            System.Diagnostics.Debug.WriteLine($"Notificação: Nova inscrição na partida {partidaId}");
        }

        /// <summary>
        /// Trata exceções conforme especificação dos fluxos de exceção.
        /// </summary>
        private void TratarExcecao(Exception ex)
        {
            // Violação RN01 (filtros inválidos): ex.: data final anterior à data inicial → avisar
            if (ex.Message.Contains("data") && (ex.Message.Contains("anterior") || ex.Message.Contains("inválida")))
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Violação RN02 (vagas esgotadas): informar e sugerir lista de espera
            if (ex.Message.Contains("vagas") || ex.Message.Contains("esgotadas") || ex.Message.Contains("cheia"))
            {
                MessageBox.Show(ex.Message + "\n\nDeseja entrar na lista de espera?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }

            // Violação RN03 (usuário já inscrito): avisar e impedir duplicidade
            if (ex.Message.Contains("já está") || ex.Message.Contains("inscrito") || ex.Message.Contains("participando"))
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Outras exceções
            MessageBox.Show(
                $"Erro ao processar a operação:\n\n{ex.Message}\n\nTipo: {ex.GetType().Name}",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}

