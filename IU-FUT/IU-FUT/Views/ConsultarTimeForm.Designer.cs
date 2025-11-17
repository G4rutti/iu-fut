using System.Windows.Forms;

namespace IU_FUT.Views
{
    partial class ConsultarTimeForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListView lstTimes;
        private TextBox txtDetalhes;
        private Button btnSolicitarParticipacao;
        private ColumnHeader colId;
        private ColumnHeader colNome;
        private ColumnHeader colJogadores;
        private ColumnHeader colDescricao;

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
            this.lstTimes = new ListView();
            this.colId = new ColumnHeader();
            this.colNome = new ColumnHeader();
            this.colJogadores = new ColumnHeader();
            this.colDescricao = new ColumnHeader();
            this.txtDetalhes = new TextBox();
            this.btnSolicitarParticipacao = new Button();
            this.SuspendLayout();

            // lstTimes
            this.lstTimes.Columns.AddRange(new ColumnHeader[] {
                this.colId,
                this.colNome,
                this.colJogadores,
                this.colDescricao
            });
            this.lstTimes.FullRowSelect = true;
            this.lstTimes.GridLines = true;
            this.lstTimes.Location = new System.Drawing.Point(20, 20);
            this.lstTimes.Name = "lstTimes";
            this.lstTimes.Size = new System.Drawing.Size(700, 250);
            this.lstTimes.TabIndex = 0;
            this.lstTimes.UseCompatibleStateImageBehavior = false;
            this.lstTimes.View = System.Windows.Forms.View.Details;
            this.lstTimes.SelectedIndexChanged += new System.EventHandler(this.lstTimes_SelectedIndexChanged);

            // colId
            this.colId.Text = "ID";
            this.colId.Width = 50;

            // colNome
            this.colNome.Text = "Nome";
            this.colNome.Width = 200;

            // colJogadores
            this.colJogadores.Text = "Jogadores";
            this.colJogadores.Width = 100;

            // colDescricao
            this.colDescricao.Text = "Descrição";
            this.colDescricao.Width = 350;

            // txtDetalhes
            this.txtDetalhes.Location = new System.Drawing.Point(20, 280);
            this.txtDetalhes.Multiline = true;
            this.txtDetalhes.Name = "txtDetalhes";
            this.txtDetalhes.ReadOnly = true;
            this.txtDetalhes.ScrollBars = ScrollBars.Vertical;
            this.txtDetalhes.Size = new System.Drawing.Size(500, 150);
            this.txtDetalhes.TabIndex = 1;

            // btnSolicitarParticipacao
            this.btnSolicitarParticipacao.Location = new System.Drawing.Point(540, 280);
            this.btnSolicitarParticipacao.Name = "btnSolicitarParticipacao";
            this.btnSolicitarParticipacao.Size = new System.Drawing.Size(180, 50);
            this.btnSolicitarParticipacao.TabIndex = 2;
            this.btnSolicitarParticipacao.Text = "Entrar no Time";
            this.btnSolicitarParticipacao.UseVisualStyleBackColor = true;
            this.btnSolicitarParticipacao.Click += new System.EventHandler(this.btnSolicitarParticipacao_Click);

            // ConsultarTimeForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 450);
            this.Controls.Add(this.btnSolicitarParticipacao);
            this.Controls.Add(this.txtDetalhes);
            this.Controls.Add(this.lstTimes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ConsultarTimeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Times";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

