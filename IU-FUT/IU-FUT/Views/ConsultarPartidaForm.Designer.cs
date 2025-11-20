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
        private GroupBox grpFiltros;
        private Label lblDataInicio;
        private DateTimePicker dtpDataInicio;
        private Label lblDataFim;
        private DateTimePicker dtpDataFim;
        private Label lblCampo;
        private ComboBox cmbCampo;
        private Label lblCidade;
        private ComboBox cmbCidade;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Label lblBusca;
        private TextBox txtBusca;
        private Button btnFiltrar;
        private Button btnLimparFiltros;

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
            this.grpFiltros = new GroupBox();
            this.btnLimparFiltros = new Button();
            this.btnFiltrar = new Button();
            this.txtBusca = new TextBox();
            this.lblBusca = new Label();
            this.cmbStatus = new ComboBox();
            this.lblStatus = new Label();
            this.cmbCidade = new ComboBox();
            this.lblCidade = new Label();
            this.cmbCampo = new ComboBox();
            this.lblCampo = new Label();
            this.dtpDataFim = new DateTimePicker();
            this.lblDataFim = new Label();
            this.dtpDataInicio = new DateTimePicker();
            this.lblDataInicio = new Label();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();

            // grpFiltros
            this.grpFiltros.Controls.Add(this.btnLimparFiltros);
            this.grpFiltros.Controls.Add(this.btnFiltrar);
            this.grpFiltros.Controls.Add(this.txtBusca);
            this.grpFiltros.Controls.Add(this.lblBusca);
            this.grpFiltros.Controls.Add(this.cmbStatus);
            this.grpFiltros.Controls.Add(this.lblStatus);
            this.grpFiltros.Controls.Add(this.cmbCidade);
            this.grpFiltros.Controls.Add(this.lblCidade);
            this.grpFiltros.Controls.Add(this.cmbCampo);
            this.grpFiltros.Controls.Add(this.lblCampo);
            this.grpFiltros.Controls.Add(this.dtpDataFim);
            this.grpFiltros.Controls.Add(this.lblDataFim);
            this.grpFiltros.Controls.Add(this.dtpDataInicio);
            this.grpFiltros.Controls.Add(this.lblDataInicio);
            this.grpFiltros.Location = new System.Drawing.Point(12, 12);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(720, 140);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros de Busca";

            // lblDataInicio
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Location = new System.Drawing.Point(15, 25);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(68, 15);
            this.lblDataInicio.TabIndex = 0;
            this.lblDataInicio.Text = "Data Início:";

            // dtpDataInicio
            this.dtpDataInicio.Format = DateTimePickerFormat.Short;
            this.dtpDataInicio.Location = new System.Drawing.Point(15, 43);
            this.dtpDataInicio.Name = "dtpDataInicio";
            this.dtpDataInicio.Size = new System.Drawing.Size(120, 23);
            this.dtpDataInicio.TabIndex = 1;
            this.dtpDataInicio.Value = DateTime.Now;

            // lblDataFim
            this.lblDataFim.AutoSize = true;
            this.lblDataFim.Location = new System.Drawing.Point(150, 25);
            this.lblDataFim.Name = "lblDataFim";
            this.lblDataFim.Size = new System.Drawing.Size(60, 15);
            this.lblDataFim.TabIndex = 2;
            this.lblDataFim.Text = "Data Fim:";

            // dtpDataFim
            this.dtpDataFim.Format = DateTimePickerFormat.Short;
            this.dtpDataFim.Location = new System.Drawing.Point(150, 43);
            this.dtpDataFim.Name = "dtpDataFim";
            this.dtpDataFim.Size = new System.Drawing.Size(120, 23);
            this.dtpDataFim.TabIndex = 3;
            this.dtpDataFim.Value = DateTime.Now.AddMonths(1);

            // lblCampo
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(285, 25);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(50, 15);
            this.lblCampo.TabIndex = 4;
            this.lblCampo.Text = "Campo:";

            // cmbCampo
            this.cmbCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCampo.FormattingEnabled = true;
            this.cmbCampo.Location = new System.Drawing.Point(285, 43);
            this.cmbCampo.Name = "cmbCampo";
            this.cmbCampo.Size = new System.Drawing.Size(150, 23);
            this.cmbCampo.TabIndex = 5;

            // lblCidade
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(450, 25);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(47, 15);
            this.lblCidade.TabIndex = 6;
            this.lblCidade.Text = "Cidade:";

            // cmbCidade
            this.cmbCidade.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCidade.FormattingEnabled = true;
            this.cmbCidade.Location = new System.Drawing.Point(450, 43);
            this.cmbCidade.Name = "cmbCidade";
            this.cmbCidade.Size = new System.Drawing.Size(150, 23);
            this.cmbCidade.TabIndex = 7;

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(15, 80);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status:";

            // cmbStatus
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
                "Todos",
                "Disponíveis (com vagas)",
                "Sem vagas",
                "Futuras",
                "Passadas"
            });
            this.cmbStatus.Location = new System.Drawing.Point(15, 98);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(180, 23);
            this.cmbStatus.TabIndex = 9;
            this.cmbStatus.SelectedIndex = 0;

            // lblBusca
            this.lblBusca.AutoSize = true;
            this.lblBusca.Location = new System.Drawing.Point(210, 80);
            this.lblBusca.Name = "lblBusca";
            this.lblBusca.Size = new System.Drawing.Size(95, 15);
            this.lblBusca.TabIndex = 10;
            this.lblBusca.Text = "Busca Geral:";

            // txtBusca
            this.txtBusca.Location = new System.Drawing.Point(210, 98);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.PlaceholderText = "Buscar por descrição, campo, endereço...";
            this.txtBusca.Size = new System.Drawing.Size(300, 23);
            this.txtBusca.TabIndex = 11;

            // btnFiltrar
            this.btnFiltrar.Location = new System.Drawing.Point(530, 98);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(80, 23);
            this.btnFiltrar.TabIndex = 12;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // btnLimparFiltros
            this.btnLimparFiltros.Location = new System.Drawing.Point(620, 98);
            this.btnLimparFiltros.Name = "btnLimparFiltros";
            this.btnLimparFiltros.Size = new System.Drawing.Size(80, 23);
            this.btnLimparFiltros.TabIndex = 13;
            this.btnLimparFiltros.Text = "Limpar";
            this.btnLimparFiltros.UseVisualStyleBackColor = true;
            this.btnLimparFiltros.Click += new System.EventHandler(this.btnLimparFiltros_Click);

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
            this.lstPartidas.Location = new System.Drawing.Point(12, 158);
            this.lstPartidas.Name = "lstPartidas";
            this.lstPartidas.Size = new System.Drawing.Size(720, 200);
            this.lstPartidas.TabIndex = 1;
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
            this.txtDetalhes.Location = new System.Drawing.Point(12, 364);
            this.txtDetalhes.Multiline = true;
            this.txtDetalhes.Name = "txtDetalhes";
            this.txtDetalhes.ReadOnly = true;
            this.txtDetalhes.ScrollBars = ScrollBars.Vertical;
            this.txtDetalhes.Size = new System.Drawing.Size(500, 120);
            this.txtDetalhes.TabIndex = 2;

            // btnSolicitarParticipacao
            this.btnSolicitarParticipacao.Location = new System.Drawing.Point(530, 364);
            this.btnSolicitarParticipacao.Name = "btnSolicitarParticipacao";
            this.btnSolicitarParticipacao.Size = new System.Drawing.Size(200, 50);
            this.btnSolicitarParticipacao.TabIndex = 3;
            this.btnSolicitarParticipacao.Text = "Participar da Partida";
            this.btnSolicitarParticipacao.UseVisualStyleBackColor = true;
            this.btnSolicitarParticipacao.Click += new System.EventHandler(this.btnSolicitarParticipacao_Click);

            // ConsultarPartidaForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 496);
            this.Controls.Add(this.btnSolicitarParticipacao);
            this.Controls.Add(this.txtDetalhes);
            this.Controls.Add(this.lstPartidas);
            this.Controls.Add(this.grpFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ConsultarPartidaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Partidas";
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

