using System.Windows.Forms;

namespace IU_FUT.Views
{
    partial class ConsultarPartidaForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListView lstPartidas;
        private TextBox txtDetalhes;
        private Button btnSolicitarParticipacao;
        private ColumnHeader colId;
        private ColumnHeader colDataInicio;
        private ColumnHeader colDataFim;
        private ColumnHeader colCampo;
        private ColumnHeader colEndereco;
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
            this.lstPartidas = new ListView();
            this.colId = new ColumnHeader();
            this.colDataInicio = new ColumnHeader();
            this.colDataFim = new ColumnHeader();
            this.colCampo = new ColumnHeader();
            this.colEndereco = new ColumnHeader();
            this.colDescricao = new ColumnHeader();
            this.txtDetalhes = new TextBox();
            this.btnSolicitarParticipacao = new Button();
            this.SuspendLayout();

            // lstPartidas
            this.lstPartidas.Columns.AddRange(new ColumnHeader[] {
                this.colId,
                this.colDataInicio,
                this.colDataFim,
                this.colCampo,
                this.colEndereco,
                this.colDescricao
            });
            this.lstPartidas.FullRowSelect = true;
            this.lstPartidas.GridLines = true;
            this.lstPartidas.Location = new System.Drawing.Point(20, 20);
            this.lstPartidas.Name = "lstPartidas";
            this.lstPartidas.Size = new System.Drawing.Size(700, 250);
            this.lstPartidas.TabIndex = 0;
            this.lstPartidas.UseCompatibleStateImageBehavior = false;
            this.lstPartidas.View = System.Windows.Forms.View.Details;
            this.lstPartidas.SelectedIndexChanged += new System.EventHandler(this.lstPartidas_SelectedIndexChanged);

            // colId
            this.colId.Text = "ID";
            this.colId.Width = 50;

            // colDataInicio
            this.colDataInicio.Text = "Data Início";
            this.colDataInicio.Width = 100;

            // colDataFim
            this.colDataFim.Text = "Data Fim";
            this.colDataFim.Width = 100;

            // colCampo
            this.colCampo.Text = "Campo";
            this.colCampo.Width = 150;

            // colEndereco
            this.colEndereco.Text = "Endereço";
            this.colEndereco.Width = 150;

            // colDescricao
            this.colDescricao.Text = "Descrição";
            this.colDescricao.Width = 200;

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
            this.btnSolicitarParticipacao.Text = "Participar da Partida";
            this.btnSolicitarParticipacao.UseVisualStyleBackColor = true;
            this.btnSolicitarParticipacao.Click += new System.EventHandler(this.btnSolicitarParticipacao_Click);

            // ConsultarPartidaForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 450);
            this.Controls.Add(this.btnSolicitarParticipacao);
            this.Controls.Add(this.txtDetalhes);
            this.Controls.Add(this.lstPartidas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ConsultarPartidaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Partidas";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

