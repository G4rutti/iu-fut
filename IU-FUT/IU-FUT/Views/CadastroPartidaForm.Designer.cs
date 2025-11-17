using System.Windows.Forms;

namespace IU_FUT.Views
{
    partial class CadastroPartidaForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblCampo;
        private Label lblDescricao;
        private Label lblDataInicio;
        private Label lblDataFim;
        private ComboBox cmbCampo;
        private TextBox txtDescricao;
        private DateTimePicker dtpDataInicio;
        private DateTimePicker dtpDataFim;
        private Button btnNovo;
        private Button btnSalvar;
        private Button btnExcluir;
        private ListBox lstPartidas;

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
            this.lblCampo = new Label();
            this.lblDescricao = new Label();
            this.lblDataInicio = new Label();
            this.lblDataFim = new Label();
            this.cmbCampo = new ComboBox();
            this.txtDescricao = new TextBox();
            this.dtpDataInicio = new DateTimePicker();
            this.dtpDataFim = new DateTimePicker();
            this.btnNovo = new Button();
            this.btnSalvar = new Button();
            this.btnExcluir = new Button();
            this.lstPartidas = new ListBox();
            this.SuspendLayout();

            // lstPartidas
            this.lstPartidas.FormattingEnabled = true;
            this.lstPartidas.ItemHeight = 15;
            this.lstPartidas.Location = new System.Drawing.Point(20, 20);
            this.lstPartidas.Name = "lstPartidas";
            this.lstPartidas.Size = new System.Drawing.Size(300, 304);
            this.lstPartidas.TabIndex = 0;
            this.lstPartidas.SelectedIndexChanged += new System.EventHandler(this.lstPartidas_SelectedIndexChanged);

            // lblCampo
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(340, 20);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(48, 15);
            this.lblCampo.Text = "Campo*:";

            // lblDescricao
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(340, 60);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(61, 15);
            this.lblDescricao.Text = "Descrição:";

            // lblDataInicio
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Location = new System.Drawing.Point(340, 100);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(70, 15);
            this.lblDataInicio.Text = "Data Início:";

            // lblDataFim
            this.lblDataFim.AutoSize = true;
            this.lblDataFim.Location = new System.Drawing.Point(340, 140);
            this.lblDataFim.Name = "lblDataFim";
            this.lblDataFim.Size = new System.Drawing.Size(60, 15);
            this.lblDataFim.Text = "Data Fim:";

            // cmbCampo
            this.cmbCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCampo.FormattingEnabled = true;
            this.cmbCampo.Location = new System.Drawing.Point(410, 17);
            this.cmbCampo.Name = "cmbCampo";
            this.cmbCampo.Size = new System.Drawing.Size(300, 23);
            this.cmbCampo.TabIndex = 1;

            // txtDescricao
            this.txtDescricao.Location = new System.Drawing.Point(410, 57);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(300, 23);
            this.txtDescricao.TabIndex = 2;

            // dtpDataInicio
            this.dtpDataInicio.Format = DateTimePickerFormat.Short;
            this.dtpDataInicio.Location = new System.Drawing.Point(410, 97);
            this.dtpDataInicio.Name = "dtpDataInicio";
            this.dtpDataInicio.Size = new System.Drawing.Size(150, 23);
            this.dtpDataInicio.TabIndex = 3;

            // dtpDataFim
            this.dtpDataFim.Format = DateTimePickerFormat.Short;
            this.dtpDataFim.Location = new System.Drawing.Point(410, 137);
            this.dtpDataFim.Name = "dtpDataFim";
            this.dtpDataFim.Size = new System.Drawing.Size(150, 23);
            this.dtpDataFim.TabIndex = 4;

            // btnNovo
            this.btnNovo.Location = new System.Drawing.Point(410, 180);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(90, 35);
            this.btnNovo.TabIndex = 5;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);

            // btnSalvar
            this.btnSalvar.Location = new System.Drawing.Point(510, 180);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 35);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // btnExcluir
            this.btnExcluir.Location = new System.Drawing.Point(610, 180);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(90, 35);
            this.btnExcluir.TabIndex = 7;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            // CadastroPartidaForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 350);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.dtpDataFim);
            this.Controls.Add(this.dtpDataInicio);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.cmbCampo);
            this.Controls.Add(this.lblDataFim);
            this.Controls.Add(this.lblDataInicio);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.lstPartidas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CadastroPartidaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Partida";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

