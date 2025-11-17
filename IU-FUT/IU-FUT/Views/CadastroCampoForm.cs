using System.Linq;
using IU_FUT.Controllers;
using IU_FUT.Models;

namespace IU_FUT.Views
{
    public partial class CadastroCampoForm : Form
    {
        private readonly CampoController _controller;
        private int? _campoSelecionadoId;

        public CadastroCampoForm()
        {
            _controller = new CampoController();
            InitializeComponent();
            // Conforme diagrama: 1.0: ator solicita cadastrar campo()
            CarregarGrid();
        }

        /// <summary>
        /// Carrega a grade de dados com a lista de locais.
        /// Conforme diagrama de sequência: 1.1: carregarGrid()
        /// </summary>
        private void CarregarGrid()
        {
            lstCampos.Items.Clear();
            // 1.1.1: listarLocais() : List<Locais>
            var locais = _controller.ListarLocais();
            foreach (var campo in locais)
            {
                lstCampos.Items.Add($"{campo.Id} - {campo.Nome} - {campo.Endereco}");
            }
        }

        private void lstCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCampos.SelectedIndex >= 0)
            {
                var item = lstCampos.SelectedItem?.ToString();
                if (item != null && int.TryParse(item.Split('-')[0].Trim(), out var id))
                {
                    _campoSelecionadoId = id;
                    CarregarDados(id);
                }
            }
        }

        private void CarregarDados(int id)
        {
            var campo = _controller.ObterCampo(id);
            if (campo != null)
            {
                txtNome.Text = campo.Nome;
                txtEndereco.Text = campo.Endereco;
                txtCidade.Text = campo.Cidade;
                txtDescricao.Text = campo.Descricao;
                // ID bloqueado na alteração (conforme especificação)
                txtNome.ReadOnly = false; // Será bloqueado apenas visualmente se necessário
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            _campoSelecionadoId = null;
        }

        /// <summary>
        /// Verifica se o nome está preenchido.
        /// Conforme diagrama de sequência: 1.1: verificaNome(dados) : boolean
        /// RN01: Nome do local é obrigatório.
        /// </summary>
        private bool VerificaNome(string nome)
        {
            return !string.IsNullOrWhiteSpace(nome);
        }

        /// <summary>
        /// Verifica duplicidade através do controller.
        /// Conforme diagrama de sequência: 2: verificarDuplicidade(dados) : boolean
        /// </summary>
        private bool VerificarDuplicidade(string nome, string endereco)
        {
            return _controller.VerificarDuplicidade(nome, endereco, _campoSelecionadoId);
        }

        /// <summary>
        /// Confirma a exclusão com o usuário.
        /// Conforme diagrama de sequência: 2: confirmaExcluir() : boolean
        /// </summary>
        private bool ConfirmaExcluir()
        {
            return MessageBox.Show(
                "Tem certeza que deseja excluir este campo?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var nome = txtNome.Text.Trim();
                var endereco = txtEndereco.Text.Trim();
                var cidade = txtCidade.Text.Trim();
                var descricao = txtDescricao.Text.Trim();

                if (_campoSelecionadoId.HasValue)
                {
                    // FLUXO ALTERNATIVO: Alterar campo
                    ProcessarAlteracao(nome, endereco, cidade, descricao);
                }
                else
                {
                    // FLUXO ALTERNATIVO: Incluir campo
                    ProcessarInclusao(nome, endereco, cidade, descricao);
                }
            }
            catch (Exception ex)
            {
                TratarExcecao(ex);
            }
        }

        /// <summary>
        /// Processa a inclusão de um novo campo conforme diagrama de sequência.
        /// Fluxo Alternativo (3): Incluir campo
        /// </summary>
        private void ProcessarInclusao(string nome, string endereco, string cidade, string descricao)
        {
            // 1.1: verificaNome(dados) : boolean
            bool verificaNome = VerificaNome(nome);
            
            // RN01: Violação - nome obrigatório
            if (!verificaNome)
            {
                MessageBox.Show("O campo Nome é obrigatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            // 2: verificarDuplicidade(dados) : boolean
            bool verificarDuplicidade = VerificarDuplicidade(nome, endereco);

            // RN02: Violação - duplicidade
            if (verificarDuplicidade)
            {
                var resultado = MessageBox.Show(
                    "Já existe um local com mesmo nome e endereço. Deseja visualizar o existente?",
                    "Duplicidade",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Buscar e mostrar o campo existente
                    var campos = _controller.ListarLocais();
                    var campoExistente = campos.FirstOrDefault(c => c.Nome == nome && c.Endereco == endereco);
                    if (campoExistente != null)
                    {
                        _campoSelecionadoId = campoExistente.Id;
                        CarregarDados(campoExistente.Id);
                        lstCampos.SelectedIndex = lstCampos.Items.IndexOf($"{campoExistente.Id} - {campoExistente.Nome} - {campoExistente.Endereco}");
                    }
                }
                return;
            }

            // alt [verificaNome == true && verificaDuplicidade == false]
            if (verificaNome && !verificarDuplicidade)
            {
                // 1.2: incluir(oCampo:Campo) : Campo
                var novoCampo = new Campo
                {
                    Nome = nome,
                    Endereco = endereco,
                    Cidade = cidade,
                    Descricao = descricao
                };
                _controller.Incluir(novoCampo);

                MessageBox.Show("Campo cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 1.3: carregarGrid()
                LimparCampos();
                CarregarGrid();
            }
        }

        /// <summary>
        /// Processa a alteração de um campo existente conforme diagrama de sequência.
        /// Fluxo Alternativo (3): Alterar campo
        /// </summary>
        private void ProcessarAlteracao(string nome, string endereco, string cidade, string descricao)
        {
            // 1.1: carregarGrid() - já foi carregado ao selecionar
            // (O diagrama mostra carregarGrid antes, mas assumimos que já está carregado)

            // 1.2: verificarDuplicidade(dados) : boolean
            bool verificarDuplicidade = VerificarDuplicidade(nome, endereco);

            // 1.3: verificaNome(dados) : boolean
            bool verificaNome = VerificaNome(nome);

            // RN01: Violação - nome obrigatório
            if (!verificaNome)
            {
                MessageBox.Show("O campo Nome é obrigatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            // RN02: Violação - duplicidade
            if (verificarDuplicidade)
            {
                MessageBox.Show("Já existe um local com mesmo nome e endereço.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // alt [verificaNome == true && verificaDuplicidade == false]
            if (verificaNome && !verificarDuplicidade)
            {
                // 1.4: salvarCampo(dados) : List<Locais>
                _controller.SalvarCampo(_campoSelecionadoId, nome, endereco, cidade, descricao);

                MessageBox.Show("Campo atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 1.5: carregarGrid()
                CarregarGrid();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!_campoSelecionadoId.HasValue)
            {
                MessageBox.Show("Selecione um campo para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // FLUXO ALTERNATIVO: Excluir campo
                ProcessarExclusao();
            }
            catch (Exception ex)
            {
                TratarExcecao(ex);
            }
        }

        /// <summary>
        /// Processa a exclusão de um campo conforme diagrama de sequência.
        /// Fluxo Alternativo (3): Excluir campo
        /// </summary>
        private void ProcessarExclusao()
        {
            if (!_campoSelecionadoId.HasValue)
                return;

            // 1.1: verificaAgenda(Partida) : boolean
            bool verificaAgenda = _controller.VerificaAgenda(_campoSelecionadoId.Value);

            // RN03: Violação - dependência (partidas agendadas)
            if (verificaAgenda)
            {
                int quantidadePartidas = _controller.ObterQuantidadePartidasAgendadas(_campoSelecionadoId.Value);
                MessageBox.Show(
                    $"Não é possível excluir o local. Existem {quantidadePartidas} partida(s) agendada(s). É necessário reatribuir ou cancelar as partidas primeiro.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // alt [verificaAgenda == false]
            if (!verificaAgenda)
            {
                // 2: confirmaExcluir() : boolean
                bool confirmaExcluir = ConfirmaExcluir();

                // alt [confirmaExcluir == true]
                if (confirmaExcluir)
                {
                    _controller.ExcluirCampo(_campoSelecionadoId.Value);
                    MessageBox.Show("Campo excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3: carregarGrid()
                    LimparCampos();
                    CarregarGrid();
                }
            }
        }

        /// <summary>
        /// Trata exceções conforme especificação dos fluxos de exceção.
        /// </summary>
        private void TratarExcecao(Exception ex)
        {
            // Violação RN01 (nome obrigatório): avisar e focar no campo Nome
            if (ex.Message.Contains("Nome é obrigatório") || ex.Message.Contains("campo Nome"))
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            // Violação RN02 (duplicidade): informar que já existe um local com mesmo nome+endereço
            if (ex.Message.Contains("duplicado") || ex.Message.Contains("mesmo nome"))
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Violação RN03 (dependência): se o local possui partidas agendadas
            if (ex.Message.Contains("partida") && ex.Message.Contains("agendada"))
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Outras exceções
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEndereco.Clear();
            txtCidade.Clear();
            txtDescricao.Clear();
            _campoSelecionadoId = null;
            lstCampos.ClearSelected();
            txtNome.ReadOnly = false;
        }
    }
}
