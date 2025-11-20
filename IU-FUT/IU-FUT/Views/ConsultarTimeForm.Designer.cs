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
        private GroupBox grpFiltros;
        private Label lblNome;
        private TextBox txtNome;
        private Label lblJogadoresMin;
        private NumericUpDown numJogadoresMin;
        private Label lblJogadoresMax;
        private NumericUpDown numJogadoresMax;
        private Label lblDescricao;
        private TextBox txtDescricao;
        private Label lblJogador;
        private ComboBox cmbJogador;
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
            this.lstTimes = new ListView();
            this.colId = new ColumnHeader();
            this.colNome = new ColumnHeader();
            this.colJogadores = new ColumnHeader();
            this.colDescricao = new ColumnHeader();
            this.txtDetalhes = new TextBox();
            this.btnSolicitarParticipacao = new Button();
            this.grpFiltros = new GroupBox();
            this.btnLimparFiltros = new Button();
            this.btnFiltrar = new Button();
            this.cmbJogador = new ComboBox();
            this.lblJogador = new Label();
            this.txtDescricao = new TextBox();
            this.lblDescricao = new Label();
            this.numJogadoresMax = new NumericUpDown();
            this.lblJogadoresMax = new Label();
            this.numJogadoresMin = new NumericUpDown();
            this.lblJogadoresMin = new Label();
            this.txtNome = new TextBox();
            this.lblNome = new Label();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJogadoresMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJogadoresMax)).BeginInit();
            this.SuspendLayout();

            // grpFiltros
            this.grpFiltros.Controls.Add(this.btnLimparFiltros);
            this.grpFiltros.Controls.Add(this.btnFiltrar);
            this.grpFiltros.Controls.Add(this.cmbJogador);
            this.grpFiltros.Controls.Add(this.lblJogador);
            this.grpFiltros.Controls.Add(this.txtDescricao);
            this.grpFiltros.Controls.Add(this.lblDescricao);
            this.grpFiltros.Controls.Add(this.numJogadoresMax);
            this.grpFiltros.Controls.Add(this.lblJogadoresMax);
            this.grpFiltros.Controls.Add(this.numJogadoresMin);
            this.grpFiltros.Controls.Add(this.lblJogadoresMin);
            this.grpFiltros.Controls.Add(this.txtNome);
            this.grpFiltros.Controls.Add(this.lblNome);
            this.grpFiltros.Location = new System.Drawing.Point(12, 12);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(720, 140);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros de Busca";

            // lblNome
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(15, 25);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(43, 15);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome:";

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(15, 43);
            this.txtNome.Name = "txtNome";
            this.txtNome.PlaceholderText = "Buscar por nome do time...";
            this.txtNome.Size = new System.Drawing.Size(200, 23);
            this.txtNome.TabIndex = 1;

            // lblJogadoresMin
            this.lblJogadoresMin.AutoSize = true;
            this.lblJogadoresMin.Location = new System.Drawing.Point(230, 25);
            this.lblJogadoresMin.Name = "lblJogadoresMin";
            this.lblJogadoresMin.Size = new System.Drawing.Size(90, 15);
            this.lblJogadoresMin.TabIndex = 2;
            this.lblJogadoresMin.Text = "Jogadores (Min):";

            // numJogadoresMin
            this.numJogadoresMin.Location = new System.Drawing.Point(230, 43);
            this.numJogadoresMin.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numJogadoresMin.Name = "numJogadoresMin";
            this.numJogadoresMin.Size = new System.Drawing.Size(90, 23);
            this.numJogadoresMin.TabIndex = 3;

            // lblJogadoresMax
            this.lblJogadoresMax.AutoSize = true;
            this.lblJogadoresMax.Location = new System.Drawing.Point(330, 25);
            this.lblJogadoresMax.Name = "lblJogadoresMax";
            this.lblJogadoresMax.Size = new System.Drawing.Size(92, 15);
            this.lblJogadoresMax.TabIndex = 4;
            this.lblJogadoresMax.Text = "Jogadores (Max):";

            // numJogadoresMax
            this.numJogadoresMax.Location = new System.Drawing.Point(330, 43);
            this.numJogadoresMax.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numJogadoresMax.Name = "numJogadoresMax";
            this.numJogadoresMax.Size = new System.Drawing.Size(90, 23);
            this.numJogadoresMax.TabIndex = 5;
            this.numJogadoresMax.Value = new decimal(new int[] { 100, 0, 0, 0 });

            // lblDescricao
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(15, 80);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(61, 15);
            this.lblDescricao.TabIndex = 6;
            this.lblDescricao.Text = "Descrição:";

            // txtDescricao
            this.txtDescricao.Location = new System.Drawing.Point(15, 98);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.PlaceholderText = "Buscar na descrição...";
            this.txtDescricao.Size = new System.Drawing.Size(250, 23);
            this.txtDescricao.TabIndex = 7;

            // lblJogador
            this.lblJogador.AutoSize = true;
            this.lblJogador.Location = new System.Drawing.Point(280, 80);
            this.lblJogador.Name = "lblJogador";
            this.lblJogador.Size = new System.Drawing.Size(54, 15);
            this.lblJogador.TabIndex = 8;
            this.lblJogador.Text = "Jogador:";

            // cmbJogador
            this.cmbJogador.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbJogador.FormattingEnabled = true;
            this.cmbJogador.Location = new System.Drawing.Point(280, 98);
            this.cmbJogador.Name = "cmbJogador";
            this.cmbJogador.Size = new System.Drawing.Size(200, 23);
            this.cmbJogador.TabIndex = 9;

            // btnFiltrar
            this.btnFiltrar.Location = new System.Drawing.Point(500, 98);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(80, 23);
            this.btnFiltrar.TabIndex = 10;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // btnLimparFiltros
            this.btnLimparFiltros.Location = new System.Drawing.Point(590, 98);
            this.btnLimparFiltros.Name = "btnLimparFiltros";
            this.btnLimparFiltros.Size = new System.Drawing.Size(80, 23);
            this.btnLimparFiltros.TabIndex = 11;
            this.btnLimparFiltros.Text = "Limpar";
            this.btnLimparFiltros.UseVisualStyleBackColor = true;
            this.btnLimparFiltros.Click += new System.EventHandler(this.btnLimparFiltros_Click);

            // lstTimes
            this.lstTimes.Columns.AddRange(new ColumnHeader[] {
                this.colId,
                this.colNome,
                this.colJogadores,
                this.colDescricao
            });
            this.lstTimes.FullRowSelect = true;
            this.lstTimes.GridLines = true;
            this.lstTimes.Location = new System.Drawing.Point(12, 158);
            this.lstTimes.Name = "lstTimes";
            this.lstTimes.Size = new System.Drawing.Size(720, 200);
            this.lstTimes.TabIndex = 1;
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
            this.btnSolicitarParticipacao.Text = "Entrar no Time";
            this.btnSolicitarParticipacao.UseVisualStyleBackColor = true;
            this.btnSolicitarParticipacao.Click += new System.EventHandler(this.btnSolicitarParticipacao_Click);

            // ConsultarTimeForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 496);
            this.Controls.Add(this.btnSolicitarParticipacao);
            this.Controls.Add(this.txtDetalhes);
            this.Controls.Add(this.lstTimes);
            this.Controls.Add(this.grpFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ConsultarTimeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Times";
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJogadoresMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJogadoresMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

