using IU_FUT.Models;

namespace IU_FUT.Views
{
    public partial class MainForm : Form
    {
        public Jogador JogadorLogado { get; set; }

        public MainForm(Jogador jogador)
        {
            JogadorLogado = jogador;
            InitializeComponent();
            lblBemVindo.Text = $"Bem-vindo, {jogador.Nome}!";
        }

        private void btnCadastrarJogador_Click(object sender, EventArgs e)
        {
            var form = new CadastroJogadorForm(JogadorLogado.Id);
            form.ShowDialog();
        }

        private void btnCadastrarCampo_Click(object sender, EventArgs e)
        {
            var form = new CadastroCampoForm();
            form.ShowDialog();
        }

        private void btnCadastrarPartida_Click(object sender, EventArgs e)
        {
            var form = new CadastroPartidaForm();
            form.ShowDialog();
        }

        private void btnCadastrarTime_Click(object sender, EventArgs e)
        {
            var form = new CadastroTimeForm();
            form.ShowDialog();
        }

        private void btnConsultarPartida_Click(object sender, EventArgs e)
        {
            var form = new ConsultarPartidaForm(JogadorLogado);
            form.ShowDialog();
        }

        private void btnConsultarTime_Click(object sender, EventArgs e)
        {
            var form = new ConsultarTimeForm(JogadorLogado);
            form.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

