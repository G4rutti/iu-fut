using System.Windows.Forms;

namespace IU_FUT.Views
{
    partial class CadastroCampoForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblNome;
        private Label lblEndereco;
        private Label lblCidade;
        private Label lblDescricao;
        private TextBox txtNome;
        private TextBox txtEndereco;
        private TextBox txtCidade;
        private TextBox txtDescricao;
        private Button btnNovo;
        private Button btnSalvar;
        private Button btnExcluir;
        private ListBox lstCampos;

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
            this.lblEndereco = new Label();
            this.lblCidade = new Label();
            this.lblDescricao = new Label();
            this.txtNome = new TextBox();
            this.txtEndereco = new TextBox();
            this.txtCidade = new TextBox();
            this.txtDescricao = new TextBox();
            this.btnNovo = new Button();
            this.btnSalvar = new Button();
            this.btnExcluir = new Button();
            this.lstCampos = new ListBox();
            this.SuspendLayout();

            // lstCampos
            this.lstCampos.FormattingEnabled = true;
            this.lstCampos.ItemHeight = 15;
            this.lstCampos.Location = new System.Drawing.Point(20, 20);
            this.lstCampos.Name = "lstCampos";
            this.lstCampos.Size = new System.Drawing.Size(300, 304);
            this.lstCampos.TabIndex = 0;
            this.lstCampos.SelectedIndexChanged += new System.EventHandler(this.lstCampos_SelectedIndexChanged);

            // lblNome
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(340, 20);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(43, 15);
            this.lblNome.Text = "Nome*:";

            // lblEndereco
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Location = new System.Drawing.Point(340, 60);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(59, 15);
            this.lblEndereco.Text = "Endereço:";

            // lblCidade
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(340, 100);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(47, 15);
            this.lblCidade.Text = "Cidade:";

            // lblDescricao
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(340, 140);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(61, 15);
            this.lblDescricao.Text = "Descrição:";

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(410, 17);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(300, 23);
            this.txtNome.TabIndex = 1;

            // txtEndereco
            this.txtEndereco.Location = new System.Drawing.Point(410, 57);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(300, 23);
            this.txtEndereco.TabIndex = 2;

            // txtCidade
            this.txtCidade.Location = new System.Drawing.Point(410, 97);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(200, 23);
            this.txtCidade.TabIndex = 3;

            // txtDescricao
            this.txtDescricao.Location = new System.Drawing.Point(410, 137);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(300, 23);
            this.txtDescricao.TabIndex = 4;

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

            // CadastroCampoForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 250);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblCidade);
            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lstCampos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CadastroCampoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Campo";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

