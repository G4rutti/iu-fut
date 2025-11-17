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
            this.lblBemVindo = new Label();
            this.btnCadastrarJogador = new Button();
            this.btnCadastrarCampo = new Button();
            this.btnCadastrarPartida = new Button();
            this.btnCadastrarTime = new Button();
            this.btnConsultarPartida = new Button();
            this.btnConsultarTime = new Button();
            this.btnSair = new Button();
            this.SuspendLayout();

            // lblBemVindo
            this.lblBemVindo.AutoSize = true;
            this.lblBemVindo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBemVindo.Location = new System.Drawing.Point(20, 20);
            this.lblBemVindo.Name = "lblBemVindo";
            this.lblBemVindo.Size = new System.Drawing.Size(100, 21);
            this.lblBemVindo.Text = "Bem-vindo!";

            // btnCadastrarJogador
            this.btnCadastrarJogador.Location = new System.Drawing.Point(20, 60);
            this.btnCadastrarJogador.Name = "btnCadastrarJogador";
            this.btnCadastrarJogador.Size = new System.Drawing.Size(200, 40);
            this.btnCadastrarJogador.TabIndex = 0;
            this.btnCadastrarJogador.Text = "Cadastrar Jogador";
            this.btnCadastrarJogador.UseVisualStyleBackColor = true;
            this.btnCadastrarJogador.Click += new System.EventHandler(this.btnCadastrarJogador_Click);

            // btnCadastrarCampo
            this.btnCadastrarCampo.Location = new System.Drawing.Point(240, 60);
            this.btnCadastrarCampo.Name = "btnCadastrarCampo";
            this.btnCadastrarCampo.Size = new System.Drawing.Size(200, 40);
            this.btnCadastrarCampo.TabIndex = 1;
            this.btnCadastrarCampo.Text = "Cadastrar Campo";
            this.btnCadastrarCampo.UseVisualStyleBackColor = true;
            this.btnCadastrarCampo.Click += new System.EventHandler(this.btnCadastrarCampo_Click);

            // btnCadastrarPartida
            this.btnCadastrarPartida.Location = new System.Drawing.Point(20, 120);
            this.btnCadastrarPartida.Name = "btnCadastrarPartida";
            this.btnCadastrarPartida.Size = new System.Drawing.Size(200, 40);
            this.btnCadastrarPartida.TabIndex = 2;
            this.btnCadastrarPartida.Text = "Cadastrar Partida";
            this.btnCadastrarPartida.UseVisualStyleBackColor = true;
            this.btnCadastrarPartida.Click += new System.EventHandler(this.btnCadastrarPartida_Click);

            // btnCadastrarTime
            this.btnCadastrarTime.Location = new System.Drawing.Point(240, 120);
            this.btnCadastrarTime.Name = "btnCadastrarTime";
            this.btnCadastrarTime.Size = new System.Drawing.Size(200, 40);
            this.btnCadastrarTime.TabIndex = 3;
            this.btnCadastrarTime.Text = "Cadastrar Time";
            this.btnCadastrarTime.UseVisualStyleBackColor = true;
            this.btnCadastrarTime.Click += new System.EventHandler(this.btnCadastrarTime_Click);

            // btnConsultarPartida
            this.btnConsultarPartida.Location = new System.Drawing.Point(20, 180);
            this.btnConsultarPartida.Name = "btnConsultarPartida";
            this.btnConsultarPartida.Size = new System.Drawing.Size(200, 40);
            this.btnConsultarPartida.TabIndex = 4;
            this.btnConsultarPartida.Text = "Consultar Partidas";
            this.btnConsultarPartida.UseVisualStyleBackColor = true;
            this.btnConsultarPartida.Click += new System.EventHandler(this.btnConsultarPartida_Click);

            // btnConsultarTime
            this.btnConsultarTime.Location = new System.Drawing.Point(240, 180);
            this.btnConsultarTime.Name = "btnConsultarTime";
            this.btnConsultarTime.Size = new System.Drawing.Size(200, 40);
            this.btnConsultarTime.TabIndex = 5;
            this.btnConsultarTime.Text = "Consultar Times";
            this.btnConsultarTime.UseVisualStyleBackColor = true;
            this.btnConsultarTime.Click += new System.EventHandler(this.btnConsultarTime_Click);

            // btnSair
            this.btnSair.Location = new System.Drawing.Point(130, 240);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(200, 40);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 300);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnConsultarTime);
            this.Controls.Add(this.btnConsultarPartida);
            this.Controls.Add(this.btnCadastrarTime);
            this.Controls.Add(this.btnCadastrarPartida);
            this.Controls.Add(this.btnCadastrarCampo);
            this.Controls.Add(this.btnCadastrarJogador);
            this.Controls.Add(this.lblBemVindo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IU-FUT - Sistema de Gestão de Futebol";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

