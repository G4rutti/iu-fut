using System.Windows.Forms;

namespace IU_FUT.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblBemVindo;
        private Button btnCadastrarJogador;
        private Button btnCadastrarCampo;
        private Button btnCadastrarPartida;
        private Button btnCadastrarTime;
        private Button btnConsultarPartida;
        private Button btnConsultarTime;
        private Button btnSair;

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
            lblBemVindo = new Label();
            btnCadastrarJogador = new Button();
            btnCadastrarCampo = new Button();
            btnCadastrarPartida = new Button();
            btnCadastrarTime = new Button();
            btnConsultarPartida = new Button();
            btnConsultarTime = new Button();
            btnSair = new Button();
            SuspendLayout();
            // 
            // lblBemVindo
            // 
            lblBemVindo.AutoSize = true;
            lblBemVindo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBemVindo.Location = new Point(20, 20);
            lblBemVindo.Name = "lblBemVindo";
            lblBemVindo.Size = new Size(99, 21);
            lblBemVindo.TabIndex = 7;
            lblBemVindo.Text = "Bem-vindo!";
            // 
            // btnCadastrarJogador
            // 
            btnCadastrarJogador.Location = new Point(20, 60);
            btnCadastrarJogador.Name = "btnCadastrarJogador";
            btnCadastrarJogador.Size = new Size(200, 40);
            btnCadastrarJogador.TabIndex = 0;
            btnCadastrarJogador.Text = "Editar Perfil";
            btnCadastrarJogador.UseVisualStyleBackColor = true;
            btnCadastrarJogador.Click += btnCadastrarJogador_Click;
            // 
            // btnCadastrarCampo
            // 
            btnCadastrarCampo.Location = new Point(240, 60);
            btnCadastrarCampo.Name = "btnCadastrarCampo";
            btnCadastrarCampo.Size = new Size(200, 40);
            btnCadastrarCampo.TabIndex = 1;
            btnCadastrarCampo.Text = "Cadastrar Campo";
            btnCadastrarCampo.UseVisualStyleBackColor = true;
            btnCadastrarCampo.Click += btnCadastrarCampo_Click;
            // 
            // btnCadastrarPartida
            // 
            btnCadastrarPartida.Location = new Point(20, 120);
            btnCadastrarPartida.Name = "btnCadastrarPartida";
            btnCadastrarPartida.Size = new Size(200, 40);
            btnCadastrarPartida.TabIndex = 2;
            btnCadastrarPartida.Text = "Cadastrar Partida";
            btnCadastrarPartida.UseVisualStyleBackColor = true;
            btnCadastrarPartida.Click += btnCadastrarPartida_Click;
            // 
            // btnCadastrarTime
            // 
            btnCadastrarTime.Location = new Point(240, 120);
            btnCadastrarTime.Name = "btnCadastrarTime";
            btnCadastrarTime.Size = new Size(200, 40);
            btnCadastrarTime.TabIndex = 3;
            btnCadastrarTime.Text = "Cadastrar Time";
            btnCadastrarTime.UseVisualStyleBackColor = true;
            btnCadastrarTime.Click += btnCadastrarTime_Click;
            // 
            // btnConsultarPartida
            // 
            btnConsultarPartida.Location = new Point(20, 180);
            btnConsultarPartida.Name = "btnConsultarPartida";
            btnConsultarPartida.Size = new Size(200, 40);
            btnConsultarPartida.TabIndex = 4;
            btnConsultarPartida.Text = "Consultar Partidas";
            btnConsultarPartida.UseVisualStyleBackColor = true;
            btnConsultarPartida.Click += btnConsultarPartida_Click;
            // 
            // btnConsultarTime
            // 
            btnConsultarTime.Location = new Point(240, 180);
            btnConsultarTime.Name = "btnConsultarTime";
            btnConsultarTime.Size = new Size(200, 40);
            btnConsultarTime.TabIndex = 5;
            btnConsultarTime.Text = "Consultar Times";
            btnConsultarTime.UseVisualStyleBackColor = true;
            btnConsultarTime.Click += btnConsultarTime_Click;
            // 
            // btnSair
            // 
            btnSair.Location = new Point(130, 240);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(200, 40);
            btnSair.TabIndex = 6;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 300);
            Controls.Add(btnSair);
            Controls.Add(btnConsultarTime);
            Controls.Add(btnConsultarPartida);
            Controls.Add(btnCadastrarTime);
            Controls.Add(btnCadastrarPartida);
            Controls.Add(btnCadastrarCampo);
            Controls.Add(btnCadastrarJogador);
            Controls.Add(lblBemVindo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IU-FUT - Sistema de Gestão de Futebol";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

