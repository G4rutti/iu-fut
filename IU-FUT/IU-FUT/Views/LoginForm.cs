using IU_FUT.Controllers;
using IU_FUT.Models;

namespace IU_FUT.Views
{
    public partial class LoginForm : Form
    {
        public Jogador? JogadorLogado { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var email = txtEmail.Text.Trim();
                var senha = txtSenha.Text;

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                {
                    MessageBox.Show("Por favor, preencha e-mail e senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var controller = new JogadorController();
                JogadorLogado = controller.Autenticar(email, senha);

                if (JogadorLogado != null)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("E-mail ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao fazer login: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            var formCadastro = new CadastroJogadorForm();
            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Cadastro realizado com sucesso! Faça login para continuar.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

