using System.Linq;
using IU_FUT.Controllers;
using IU_FUT.Models;

namespace IU_FUT.Views
{
    public partial class CadastroPartidaForm : Form
    {
        private readonly PartidaController _controller;
        private readonly CampoController _campoController;
        private int? _partidaSelecionadaId;

        public CadastroPartidaForm()
        {
            _controller = new PartidaController();
            _campoController = new CampoController();
            InitializeComponent();
            // Conforme diagrama: 1.0: ator solicita cadastrar partida()
            CarregarCampos();
            CarregarGrid();
        }

        /// <summary>
        /// Carrega a grade de dados com a lista de partidas.
        /// Conforme diagrama de sequência: 1.1: carregarGrid()
        /// </summary>
        private void CarregarGrid()
        {
            lstPartidas.Items.Clear();
            // 1.1.1: listarPartidas(dados) : List<Partidas>
            var partidas = _controller.ListarPartidas(null);
            foreach (var partida in partidas)
            {
                var campo = partida.Campo;
                var dataInicio = partida.DataInicio?.ToString("dd/MM/yyyy") ?? "Não definida";
                lstPartidas.Items.Add($"{partida.Id} - {dataInicio} - {campo?.Nome}");
            }
        }

        /// <summary>
        /// Carrega os campos do formulário.
        /// Conforme diagrama de sequência: 1.1: carregarCampos()
        /// </summary>
        private void CarregarCampos()
        {
            // 1.1.1: listarPartidas(dados) : List<Partidas>
            _controller.ListarPartidas(null);

            // Carregar combo de campos
            cmbCampo.Items.Clear();
            // 1.2.1: listarLocais() : List<Locais>
            var locais = _controller.ListarLocais();
            foreach (var campo in locais)
            {
                cmbCampo.Items.Add($"{campo.Id} - {campo.Nome}");
            }
        }

        private void lstPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPartidas.SelectedIndex >= 0)
            {
                var item = lstPartidas.SelectedItem?.ToString();
                if (item != null && int.TryParse(item.Split('-')[0].Trim(), out var id))
                {
                    _partidaSelecionadaId = id;
                    CarregarDados(id);
                }
            }
        }

        private void CarregarDados(int id)
        {
            var partida = _controller.ObterPartida(id);
            if (partida != null)
            {
                txtDescricao.Text = partida.Descricao ?? "";
                dtpDataInicio.Value = partida.DataInicio?.ToDateTime(TimeOnly.MinValue) ?? DateTime.Now;
                dtpDataFim.Value = partida.DataFim?.ToDateTime(TimeOnly.MinValue) ?? DateTime.Now;

                // Selecionar campo no combo
                for (int i = 0; i < cmbCampo.Items.Count; i++)
                {
                    var item = cmbCampo.Items[i]?.ToString();
                    if (item != null && item.StartsWith($"{partida.Campo_Id} -"))
                    {
                        cmbCampo.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            _partidaSelecionadaId = null;
        }

        /// <summary>
        /// Verifica se o local (campo) está selecionado.
        /// Conforme diagrama de sequência: 1.2: verificaLocal() : boolean
        /// </summary>
        private bool VerificaLocal()
        {
            return cmbCampo.SelectedIndex >= 0;
        }

        /// <summary>
        /// Verifica se o time está válido (para futuras implementações).
        /// Conforme diagrama de sequência: 1.3: verificaTime() : boolean
        /// </summary>
        private bool VerificaTime()
        {
            // Por enquanto, sempre retorna true
            // Futuramente pode validar se há times suficientes, etc.
            return true;
        }

        /// <summary>
        /// Verifica se a data é futura.
        /// Conforme diagrama de sequência: 1.4: verificaDataFutura() : boolean
        /// RN01: Partida deve ter DataHoraInicio no futuro.
        /// </summary>
        private bool VerificaDataFutura()
        {
            var dataInicio = DateOnly.FromDateTime(dtpDataInicio.Value);
            var hoje = DateOnly.FromDateTime(DateTime.Now);
            // Permite data de hoje ou futura (considerando apenas a data, não a hora)
            return dataInicio >= hoje;
        }

        /// <summary>
        /// Confirma a exclusão com o usuário.
        /// Conforme diagrama de sequência: 2: confirmaExcluir() : boolean
        /// </summary>
        private bool ConfirmaExcluir()
        {
            return MessageBox.Show(
                "Tem certeza que deseja excluir esta partida?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_partidaSelecionadaId.HasValue)
                {
                    // FLUXO ALTERNATIVO: Alterar partida
                    ProcessarAlteracao();
                }
                else
                {
                    // FLUXO ALTERNATIVO: Incluir partida
                    ProcessarInclusao();
                }
            }
            catch (Exception ex)
            {
                TratarExcecao(ex);
            }
        }

        /// <summary>
        /// Processa a inclusão de uma nova partida conforme diagrama de sequência.
        /// Fluxo Alternativo (3): Incluir partida
        /// </summary>
        private void ProcessarInclusao()
        {
            // 1.1: carregarCampos() - apenas carrega dados, não limpa seleção
            // (Não chamamos CarregarCampos() aqui para não perder a seleção do usuário)
            // Os campos já foram carregados no construtor

            // 1.2: verificaLocal() : boolean
            bool verificaLocal = VerificaLocal();

            // 1.2.1: listarLocais() : List<Locais> (consulta para validação)
            _controller.ListarLocais();

            // 1.3: verificaTime() : boolean
            bool verificaTime = VerificaTime();

            // 1.4: verificaDataFutura() : boolean
            bool verificaDataFutura = VerificaDataFutura();

            // RN01: Violação - data inválida
            if (!verificaDataFutura)
            {
                MessageBox.Show("A data/hora de início deve ser futura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDataInicio.Focus();
                return;
            }

            // RN01: Violação - local não selecionado
            if (!verificaLocal)
            {
                MessageBox.Show("Selecione um campo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCampo.Focus();
                return;
            }

            // alt [verificaLocal == true && verificaTime == true && verificaDataFutura == true]
            if (verificaLocal && verificaTime && verificaDataFutura)
            {
                // Obter dados
                var campoItem = cmbCampo.SelectedItem?.ToString();
                if (campoItem == null || !int.TryParse(campoItem.Split('-')[0].Trim(), out var campoId))
                {
                    MessageBox.Show("Campo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var descricao = txtDescricao.Text.Trim();
                var dataInicio = DateOnly.FromDateTime(dtpDataInicio.Value);
                var dataFim = DateOnly.FromDateTime(dtpDataFim.Value);

                // 1.5: criarPartida()
                _controller.CriarPartida(campoId, descricao, dataInicio, dataFim);

                MessageBox.Show("Partida cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 1.5.1: listarPartidas(dados) : List<Partidas> (atualizar grid)
                CarregarGrid();

                // 1.5.2: limparCampos()
                LimparCampos();
            }
        }

        /// <summary>
        /// Processa a alteração de uma partida existente conforme diagrama de sequência.
        /// Fluxo Alternativo (3): Alterar partida
        /// </summary>
        private void ProcessarAlteracao()
        {
            // 1.1: carregarCampos() - os dados já estão carregados na seleção
            // (Não chamamos CarregarCampos() aqui para não perder a seleção do usuário)

            // 1.1.1: listarPartidas(dados) : List<Partidas> (consulta para validação)
            _controller.ListarPartidas(null);

            // 1.2: verificaLocal() : boolean
            bool verificaLocal = VerificaLocal();

            // 1.2.1: listarLocais() : List<Locais>
            _controller.ListarLocais();

            // 1.3: verificaTime() : boolean
            bool verificaTime = VerificaTime();

            // 1.4: verificaDataFutura() : boolean
            bool verificaDataFutura = VerificaDataFutura();

            // RN01: Violação - data inválida
            if (!verificaDataFutura)
            {
                MessageBox.Show("A data/hora de início deve ser futura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDataInicio.Focus();
                return;
            }

            // RN01: Violação - local não selecionado
            if (!verificaLocal)
            {
                MessageBox.Show("Selecione um campo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCampo.Focus();
                return;
            }

            // alt [verificaLocal == true && verificaTime == true && verificaDataFutura == true]
            if (verificaLocal && verificaTime && verificaDataFutura)
            {
                // Obter dados
                var campoItem = cmbCampo.SelectedItem?.ToString();
                if (campoItem == null || !int.TryParse(campoItem.Split('-')[0].Trim(), out var campoId))
                {
                    MessageBox.Show("Campo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var descricao = txtDescricao.Text.Trim();
                var dataInicio = DateOnly.FromDateTime(dtpDataInicio.Value);
                var dataFim = DateOnly.FromDateTime(dtpDataFim.Value);

                // 1.5: criarPartida() (no diagrama está assim, mas na prática é atualizar)
                _controller.AtualizarPartida(_partidaSelecionadaId.Value, campoId, descricao, dataInicio, dataFim);

                MessageBox.Show("Partida atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 1.5.1: listarPartidas(dados) : List<Partidas> (atualizar grid)
                CarregarGrid();

                // 1.5.2: limparCampos()
                LimparCampos();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!_partidaSelecionadaId.HasValue)
            {
                MessageBox.Show("Selecione uma partida para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // FLUXO ALTERNATIVO: Excluir partida
                ProcessarExclusao();
            }
            catch (Exception ex)
            {
                TratarExcecao(ex);
            }
        }

        /// <summary>
        /// Processa a exclusão de uma partida conforme diagrama de sequência.
        /// Fluxo Alternativo (3): Excluir partida
        /// </summary>
        private void ProcessarExclusao()
        {
            if (!_partidaSelecionadaId.HasValue)
                return;

            // 2: confirmaExcluir() : boolean
            bool confirmaExcluir = ConfirmaExcluir();

            // alt [confirmaExcluir == true]
            if (confirmaExcluir)
            {
                // 3: excluirPartida()
                var partidas = _controller.ExcluirPartida(_partidaSelecionadaId.Value);

                // 3.1: listarPartidas() : List<Partidas> (atualizar grid)
                CarregarGrid();

                // 4: notificaInscritos()
                NotificaInscritos();
            }
        }

        /// <summary>
        /// Notifica os inscritos sobre a exclusão.
        /// Conforme diagrama de sequência: 4: notificaInscritos()
        /// </summary>
        private void NotificaInscritos()
        {
            // 4.1: listarPartidas() : List<Partidas>
            var partidas = _controller.ListarPartidas(null);

            // 4.1.1: selecionarPartidas(Jogadores) : List<Partidas>
            var partidasComJogadores = _controller.SelecionarPartidasPorJogadores();

            // Exibir mensagem de notificação
            if (partidasComJogadores.Any())
            {
                MessageBox.Show(
                    $"Partida excluída. {partidasComJogadores.Count} partida(s) com inscritos foram atualizadas.",
                    "Notificação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Trata exceções conforme especificação dos fluxos de exceção.
        /// </summary>
        private void TratarExcecao(Exception ex)
        {
            // Violação RN01 (data inválida): informar que data/hora deve ser futura
            if (ex.Message.Contains("data") && (ex.Message.Contains("futura") || ex.Message.Contains("início")))
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDataInicio.Focus();
                return;
            }

            // Violação RN02 (vagas insuficientes): número de vagas deve ser >= mínimo
            if (ex.Message.Contains("vagas") || ex.Message.Contains("insuficiente"))
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Erros de banco de dados
            if (ex.Message.Contains("connection") || ex.Message.Contains("timeout") || ex.Message.Contains("SQL"))
            {
                MessageBox.Show(
                    "Erro ao conectar com o banco de dados. Verifique a conexão e tente novamente.\n\nDetalhes: " + ex.Message,
                    "Erro de Conexão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Campo não encontrado
            if (ex.Message.Contains("Campo não encontrado"))
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCampo.Focus();
                return;
            }

            // Outras exceções - mostrar mensagem completa para debug
            MessageBox.Show(
                $"Erro ao processar a operação:\n\n{ex.Message}\n\nTipo: {ex.GetType().Name}",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void LimparCampos()
        {
            txtDescricao.Clear();
            dtpDataInicio.Value = DateTime.Now;
            dtpDataFim.Value = DateTime.Now;
            cmbCampo.SelectedIndex = -1;
            _partidaSelecionadaId = null;
            lstPartidas.ClearSelected();
        }
    }
}
