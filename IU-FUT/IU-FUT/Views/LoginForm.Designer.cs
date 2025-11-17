using System.Windows.Forms;

namespace IU_FUT.Views
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblEmail;
        private Label lblSenha;
        private TextBox txtEmail;
        private TextBox txtSenha;
        private Button btnLogin;
        private Button btnCriarConta;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblEmail = new Label();
            this.lblSenha = new Label();
            this.txtEmail = new TextBox();
            this.txtSenha = new TextBox();
            this.btnLogin = new Button();
            this.btnCriarConta = new Button();
            this.SuspendLayout();

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(30, 30);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.Text = "E-mail:";

            // lblSenha
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(30, 70);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(42, 15);
            this.lblSenha.Text = "Senha:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(90, 27);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 23);
            this.txtEmail.TabIndex = 0;

            // txtSenha
            this.txtSenha.Location = new System.Drawing.Point(90, 67);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(250, 23);
            this.txtSenha.TabIndex = 1;

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(90, 110);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(120, 35);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Entrar";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnCriarConta
            this.btnCriarConta.Location = new System.Drawing.Point(220, 110);
            this.btnCriarConta.Name = "btnCriarConta";
            this.btnCriarConta.Size = new System.Drawing.Size(120, 35);
            this.btnCriarConta.TabIndex = 3;
            this.btnCriarConta.Text = "Criar Conta";
            this.btnCriarConta.UseVisualStyleBackColor = true;
            this.btnCriarConta.Click += new System.EventHandler(this.btnCriarConta_Click);

            // LoginForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 180);
            this.Controls.Add(this.btnCriarConta);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - IU-FUT";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

