using System.Windows.Forms;

namespace IU_FUT.Views
{
    partial class CadastroJogadorForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblNome;
        private Label lblIdade;
        private Label lblEmail;
        private Label lblPosicao;
        private Label lblSenha;
        private TextBox txtNome;
        private TextBox txtIdade;
        private TextBox txtEmail;
        private TextBox txtPosicao;
        private TextBox txtSenha;
        private Button btnSalvar;
        private Button btnCancelar;
        private Button btnExcluir;

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
            this.lblNome = new Label();
            this.lblIdade = new Label();
            this.lblEmail = new Label();
            this.lblPosicao = new Label();
            this.lblSenha = new Label();
            this.txtNome = new TextBox();
            this.txtIdade = new TextBox();
            this.txtEmail = new TextBox();
            this.txtPosicao = new TextBox();
            this.txtSenha = new TextBox();
            this.btnSalvar = new Button();
            this.btnCancelar = new Button();
            this.btnExcluir = new Button();
            this.SuspendLayout();

            // lblNome
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(20, 20);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(43, 15);
            this.lblNome.Text = "Nome*:";

            // lblIdade
            this.lblIdade.AutoSize = true;
            this.lblIdade.Location = new System.Drawing.Point(20, 60);
            this.lblIdade.Name = "lblIdade";
            this.lblIdade.Size = new System.Drawing.Size(40, 15);
            this.lblIdade.Text = "Idade:";

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 100);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 15);
            this.lblEmail.Text = "E-mail*:";

            // lblPosicao
            this.lblPosicao.AutoSize = true;
            this.lblPosicao.Location = new System.Drawing.Point(20, 140);
            this.lblPosicao.Name = "lblPosicao";
            this.lblPosicao.Size = new System.Drawing.Size(95, 15);
            this.lblPosicao.Text = "Posição Preferida:";

            // lblSenha
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(20, 180);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(45, 15);
            this.lblSenha.Text = "Senha*:";

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(120, 17);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(300, 23);
            this.txtNome.TabIndex = 0;

            // txtIdade
            this.txtIdade.Location = new System.Drawing.Point(120, 57);
            this.txtIdade.Name = "txtIdade";
            this.txtIdade.Size = new System.Drawing.Size(100, 23);
            this.txtIdade.TabIndex = 1;

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(120, 97);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 23);
            this.txtEmail.TabIndex = 2;

            // txtPosicao
            this.txtPosicao.Location = new System.Drawing.Point(120, 137);
            this.txtPosicao.Name = "txtPosicao";
            this.txtPosicao.Size = new System.Drawing.Size(200, 23);
            this.txtPosicao.TabIndex = 3;

            // txtSenha
            this.txtSenha.Location = new System.Drawing.Point(120, 177);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(200, 23);
            this.txtSenha.TabIndex = 4;

            // btnSalvar
            this.btnSalvar.Location = new System.Drawing.Point(120, 220);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 35);
            this.btnSalvar.TabIndex = 5;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(230, 220);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // btnExcluir
            this.btnExcluir.Location = new System.Drawing.Point(340, 220);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(100, 35);
            this.btnExcluir.TabIndex = 7;
            this.btnExcluir.Text = "Excluir Conta";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            // CadastroJogadorForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 280);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtPosicao);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtIdade);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblPosicao);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblIdade);
            this.Controls.Add(this.lblNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CadastroJogadorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Jogador";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

