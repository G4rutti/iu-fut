using System.Linq;
using IU_FUT.Controllers;
using IU_FUT.Models;

namespace IU_FUT.Views
{
    public partial class CadastroTimeForm : Form
    {
        private readonly TimeController _controller;
        private readonly JogadorController _jogadorController;
        private int? _timeSelecionadoId;

        public CadastroTimeForm()
        {
            _controller = new TimeController();
            _jogadorController = new JogadorController();
            InitializeComponent();
            // Conforme diagrama: 1: O ator solicita cadastrar time()
            CarregarCampos();
            CarregaGrid();
        }

        /// <summary>
        /// Carrega a grade de dados com a lista de times.
        /// Conforme diagrama de sequência: 1.1: carregaGrid()
        /// </summary>
        private void CarregaGrid()
        {
            lstTimes.Items.Clear();
            // 1.1.1: listarTime() : List<Time>
            var times = _controller.ListarTime(null);
            foreach (var time in times)
            {
                lstTimes.Items.Add($"{time.Id} - {time.Nome} ({time.Jogadors.Count} jogadores)");
            }
        }

        /// <summary>
        /// Carrega os campos do formulário.
        /// Conforme diagrama de sequência: 1.1: carregarCampos()
        /// </summary>
        private void CarregarCampos()
        {
            // 1.1.1: listarTime(dados) : List<Time>
            _controller.ListarTime(null);

            // Carregar jogadores disponíveis
            // 1.2.1.1.1: selecionarJogadores() : List<Jogador>
            CarregarJogadoresDisponiveis();
        }

        private void CarregarJogadoresDisponiveis()
        {
            lstJogadoresDisponiveis.Items.Clear();
            var jogadores = _jogadorController.ListarJogadores();
            foreach (var jogador in jogadores)
            {
                lstJogadoresDisponiveis.Items.Add($"{jogador.Id} - {jogador.Nome} ({jogador.Posicao})");
            }
        }

        private void lstTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTimes.SelectedIndex >= 0)
            {
                var item = lstTimes.SelectedItem?.ToString();
                if (item != null && int.TryParse(item.Split('-')[0].Trim(), out var id))
                {
                    _timeSelecionadoId = id;
                    CarregarDados(id);
                }
            }
        }

        private void CarregarDados(int id)
        {
            var time = _controller.ObterTime(id);
            if (time != null)
            {
                txtNome.Text = time.Nome;
                txtDescricao.Text = time.Descricao ?? "";

                lstJogadoresTime.Items.Clear();
                foreach (var jogador in time.Jogadors)
                {
                    lstJogadoresTime.Items.Add($"{jogador.Id} - {jogador.Nome} ({jogador.Posicao})");
                }
            }
        }

        private void btnAdicionarJogador_Click(object sender, EventArgs e)
        {
            if (lstJogadoresDisponiveis.SelectedIndex < 0) return;

            var item = lstJogadoresDisponiveis.SelectedItem?.ToString();
            if (item != null && int.TryParse(item.Split('-')[0].Trim(), out var jogadorId))
            {
                // Verificar se já está no time
                bool jaExiste = false;
                foreach (var itemTime in lstJogadoresTime.Items)
                {
                    var itemStr = itemTime?.ToString();
                    if (itemStr != null && itemStr.StartsWith($"{jogadorId} -"))
                    {
                        jaExiste = true;
                        break;
                    }
                }

                if (!jaExiste)
                {
                    lstJogadoresTime.Items.Add(item);
                }
            }
        }

        private void btnRemoverJogador_Click(object sender, EventArgs e)
        {
            if (lstJogadoresTime.SelectedIndex >= 0)
            {
                lstJogadoresTime.Items.RemoveAt(lstJogadoresTime.SelectedIndex);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            _timeSelecionadoId = null;
        }

        /// <summary>
        /// Verifica se o nome está preenchido.
        /// Conforme diagrama de sequência: 1.1: verificaNome() : boolean
        /// RN01: Nome do time é obrigatório.
        /// </summary>
        private bool VerificaNome()
        {
            return !string.IsNullOrWhiteSpace(txtNome.Text.Trim());
        }

        /// <summary>
        /// Verifica se os jogadores são válidos.
        /// Conforme diagrama de sequência: 1.2: verificaJogadores() : boolean
        /// RN02: Todos os jogadores do time devem estar previamente cadastrados.
        /// </summary>
        private bool VerificaJogadores()
        {
            var jogadoresIds = new List<int>();
            foreach (var item in lstJogadoresTime.Items)
            {
                var itemStr = item?.ToString();
                if (itemStr != null && int.TryParse(itemStr.Split('-')[0].Trim(), out var id))
                {
                    jogadoresIds.Add(id);
                }
            }

            if (!jogadoresIds.Any())
            {
                return true; // Time pode não ter jogadores
            }

            // 1.2.1: listarTime(jogadores) : List<Time>
            var times = _controller.ListarTime(jogadoresIds);

            // 1.2.1.1: selecionaTodosTimes() : List<Time>
            _controller.SelecionaTodosTimes();

            // 1.2.1.1.1: selecionarJogadores() : List<Jogador>
            var todosJogadores = _controller.SelecionarJogadores();
            var jogadoresCadastrados = todosJogadores.Select(j => j.Id).ToList();
            var jogadoresNaoCadastrados = jogadoresIds.Except(jogadoresCadastrados).ToList();

            return !jogadoresNaoCadastrados.Any();
        }

        /// <summary>
        /// Confirma a exclusão com o usuário.
        /// Conforme diagrama de sequência: 2: confirmaExcluir() : boolean
        /// </summary>
        private bool ConfirmaExcluir()
        {
            return MessageBox.Show(
                "Tem certeza que deseja excluir este time?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_timeSelecionadoId.HasValue)
                {
                    // FLUXO ALTERNATIVO: Alterar time
                    ProcessarAlteracao();
                }
                else
                {
                    // FLUXO ALTERNATIVO: Incluir time
                    ProcessarInclusao();
                }
            }
            catch (Exception ex)
            {
                TratarExcecao(ex);
            }
        }

        /// <summary>
        /// Processa a inclusão de um novo time conforme diagrama de sequência.
        /// Fluxo Alternativo (3): Incluir time
        /// </summary>
        private void ProcessarInclusao()
        {
            // 1.1: verificaNome() : boolean
            bool verificaNome = VerificaNome();

            // 1.2: verificaJogadores() : boolean
            bool verificaJogadores = VerificaJogadores();

            // RN01: Violação - nome obrigatório
            if (!verificaNome)
            {
                MessageBox.Show("O campo Nome é obrigatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            // RN02: Violação - membros válidos
            if (!verificaJogadores)
            {
                MessageBox.Show("Um ou mais jogadores selecionados não estão cadastrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // alt [verificaNome == true && verificaJogadores == true]
            if (verificaNome && verificaJogadores)
            {
                // Obter dados
                var nome = txtNome.Text.Trim();
                var descricao = txtDescricao.Text.Trim();

                var jogadoresIds = new List<int>();
                foreach (var item in lstJogadoresTime.Items)
                {
                    var itemStr = item?.ToString();
                    if (itemStr != null && int.TryParse(itemStr.Split('-')[0].Trim(), out var id))
                    {
                        jogadoresIds.Add(id);
                    }
                }

                // 2: salvarDados()
                _controller.SalvarDados(null, nome, descricao, jogadoresIds);

                MessageBox.Show("Time cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 2.1: listarTime() : List<Time> (atualizar grid)
                CarregaGrid();

                // Limpar campos
                LimparCampos();
            }
        }

        /// <summary>
        /// Processa a alteração de um time existente conforme diagrama de sequência.
        /// Fluxo Alternativo (3): Alterar time
        /// </summary>
        private void ProcessarAlteracao()
        {
            if (!_timeSelecionadoId.HasValue)
                return;

            // 1.1: carregarCampos() - os dados já estão carregados na seleção
            // (Não chamamos CarregarCampos() aqui para não perder a seleção do usuário)

            // 1.1.1: listarTime(dados) : List<Time> (consulta para validação)
            _controller.ListarTime(null);

            // 1.2: verificaNome() : boolean
            bool verificaNome = VerificaNome();

            // 1.3: verificaJogadores() : boolean
            bool verificaJogadores = VerificaJogadores();

            // 1.3.1: listarTime(jogadores) : List<Time>
            var jogadoresIds = new List<int>();
            foreach (var item in lstJogadoresTime.Items)
            {
                var itemStr = item?.ToString();
                if (itemStr != null && int.TryParse(itemStr.Split('-')[0].Trim(), out var id))
                {
                    jogadoresIds.Add(id);
                }
            }
            _controller.ListarTime(jogadoresIds);

            // 1.3.1.1: pertenceTime() : List<Time>Jogador
            _controller.PertenceTime(jogadoresIds);

            // RN01: Violação - nome obrigatório
            if (!verificaNome)
            {
                MessageBox.Show("O campo Nome é obrigatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            // RN02: Violação - membros válidos
            if (!verificaJogadores)
            {
                MessageBox.Show("Um ou mais jogadores selecionados não estão cadastrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // alt [verificaNome == true && verificaJogadores == true]
            if (verificaNome && verificaJogadores)
            {
                // Obter dados
                var nome = txtNome.Text.Trim();
                var descricao = txtDescricao.Text.Trim();

                // 2: salvarDados()
                _controller.SalvarDados(_timeSelecionadoId, nome, descricao, jogadoresIds);

                MessageBox.Show("Time atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 2.1: listarTime() : List<Time> (atualizar grid)
                CarregaGrid();

                // Limpar campos
                LimparCampos();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!_timeSelecionadoId.HasValue)
            {
                MessageBox.Show("Selecione um time para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // FLUXO ALTERNATIVO: Excluir time
                ProcessarExclusao();
            }
            catch (Exception ex)
            {
                TratarExcecao(ex);
            }
        }

        /// <summary>
        /// Processa a exclusão de um time conforme diagrama de sequência.
        /// Fluxo Alternativo (3): Excluir time
        /// </summary>
        private void ProcessarExclusao()
        {
            if (!_timeSelecionadoId.HasValue)
                return;

            // 2: confirmaExcluir() : boolean
            bool confirmaExcluir = ConfirmaExcluir();

            // alt [confirmaExcluir == true]
            if (confirmaExcluir)
            {
                // 3: excluirTime()
                var times = _controller.ExcluirTime(_timeSelecionadoId.Value);

                MessageBox.Show("Time excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 3.1: listarTime() : List<Time> (atualizar grid)
                CarregaGrid();

                // Limpar campos
                LimparCampos();
            }
        }

        /// <summary>
        /// Trata exceções conforme especificação dos fluxos de exceção.
        /// </summary>
        private void TratarExcecao(Exception ex)
        {
            // Violação RN01 (nome obrigatório): alertar
            if (ex.Message.Contains("Nome é obrigatório") || ex.Message.Contains("campo Nome"))
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            // Violação RN02 (membros válidos): se membro não cadastrado, bloquear salvamento
            if (ex.Message.Contains("não estão cadastrados") || ex.Message.Contains("jogadores não"))
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Violação RN03 (conflito de participação): impedir que jogador esteja em mais de um time na mesma partida
            if (ex.Message.Contains("Conflito de participação") || ex.Message.Contains("mesma partida"))
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

            // Time não encontrado
            if (ex.Message.Contains("Time não encontrado"))
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Partidas agendadas
            if (ex.Message.Contains("partida") && ex.Message.Contains("agendada"))
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

        private void LimparCampos()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            lstJogadoresTime.Items.Clear();
            _timeSelecionadoId = null;
            lstTimes.ClearSelected();
        }
    }
}
