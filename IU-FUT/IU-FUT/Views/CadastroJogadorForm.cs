using IU_FUT.Controllers;
using IU_FUT.Models;

namespace IU_FUT.Views
{
    public partial class CadastroJogadorForm : Form
    {
        private readonly JogadorController _controller;
        private int? _jogadorId;
        private bool _modoEdicao;

        public CadastroJogadorForm(int? jogadorId = null)
        {
            _controller = new JogadorController();
            _jogadorId = jogadorId;
            _modoEdicao = jogadorId.HasValue;
            InitializeComponent();
            
            if (_modoEdicao)
            {
                CarregarDados();
                btnExcluir.Visible = true;
                this.Text = "Editar Meu Perfil";
            }
            else
            {
                btnExcluir.Visible = false;
                this.Text = "Criar Conta / Registrar Jogador";
            }
        }

        private void CarregarDados()
        {
            if (!_jogadorId.HasValue) return;

            var jogador = _controller.ObterJogador(_jogadorId.Value);
            if (jogador != null)
            {
                txtNome.Text = jogador.Nome;
                txtIdade.Text = jogador.Idade.ToString();
                txtEmail.Text = jogador.Email;
                txtPosicao.Text = jogador.Posicao;
                txtSenha.Enabled = false;
                txtSenha.Text = "********";
                lblSenha.Text = "Senha (deixe em branco para manter):";
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var nome = txtNome.Text.Trim();
                var idade = int.TryParse(txtIdade.Text, out var idadeVal) ? idadeVal : 0;
                var email = txtEmail.Text.Trim();
                var posicao = txtPosicao.Text.Trim();
                var senha = txtSenha.Text;

                if (_modoEdicao && _jogadorId.HasValue)
                {
                    var senhaParaAtualizar = (txtSenha.Enabled && !string.IsNullOrWhiteSpace(senha)) ? senha : null;
                    _controller.AtualizarJogador(_jogadorId.Value, nome, idade, email, posicao, senhaParaAtualizar);
                    MessageBox.Show("Dados atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(senha))
                    {
                        MessageBox.Show("A senha é obrigatória para novo cadastro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    _controller.CriarJogador(nome, idade, email, posicao, senha);
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!_jogadorId.HasValue) return;

            if (MessageBox.Show(
                "Tem certeza que deseja excluir sua conta? Esta ação é permanente e não pode ser desfeita.",
                "Confirmação de Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _controller.ExcluirJogador(_jogadorId.Value);
                    MessageBox.Show("Conta excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

