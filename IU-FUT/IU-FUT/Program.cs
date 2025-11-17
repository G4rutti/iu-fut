using IU_FUT.Views;

namespace IU_FUT
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            // Exibir tela de login
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK && loginForm.JogadorLogado != null)
            {
                // Se login bem-sucedido, abrir tela principal
                Application.Run(new MainForm(loginForm.JogadorLogado));
            }
        }
    }
}