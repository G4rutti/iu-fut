using System.Windows.Forms;

namespace IU_FUT.Views
{
    partial class CadastroTimeForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblNome;
        private Label lblDescricao;
        private Label lblJogadoresDisponiveis;
        private Label lblJogadoresTime;
        private TextBox txtNome;
        private TextBox txtDescricao;
        private ListBox lstTimes;
        private ListBox lstJogadoresDisponiveis;
        private ListBox lstJogadoresTime;
        private Button btnAdicionarJogador;
        private Button btnRemoverJogador;
        private Button btnNovo;
        private Button btnSalvar;
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
            this.lblDescricao = new Label();
            this.lblJogadoresDisponiveis = new Label();
            this.lblJogadoresTime = new Label();
            this.txtNome = new TextBox();
            this.txtDescricao = new TextBox();
            this.lstTimes = new ListBox();
            this.lstJogadoresDisponiveis = new ListBox();
            this.lstJogadoresTime = new ListBox();
            this.btnAdicionarJogador = new Button();
            this.btnRemoverJogador = new Button();
            this.btnNovo = new Button();
            this.btnSalvar = new Button();
            this.btnExcluir = new Button();
            this.SuspendLayout();

            // lstTimes
            this.lstTimes.FormattingEnabled = true;
            this.lstTimes.ItemHeight = 15;
            this.lstTimes.Location = new System.Drawing.Point(20, 20);
            this.lstTimes.Name = "lstTimes";
            this.lstTimes.Size = new System.Drawing.Size(250, 304);
            this.lstTimes.TabIndex = 0;
            this.lstTimes.SelectedIndexChanged += new System.EventHandler(this.lstTimes_SelectedIndexChanged);

            // lblNome
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(290, 20);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(43, 15);
            this.lblNome.Text = "Nome*:";

            // lblDescricao
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(290, 60);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(61, 15);
            this.lblDescricao.Text = "Descrição:";

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(360, 17);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(300, 23);
            this.txtNome.TabIndex = 1;

            // txtDescricao
            this.txtDescricao.Location = new System.Drawing.Point(360, 57);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(300, 23);
            this.txtDescricao.TabIndex = 2;

            // lblJogadoresDisponiveis
            this.lblJogadoresDisponiveis.AutoSize = true;
            this.lblJogadoresDisponiveis.Location = new System.Drawing.Point(290, 100);
            this.lblJogadoresDisponiveis.Name = "lblJogadoresDisponiveis";
            this.lblJogadoresDisponiveis.Size = new System.Drawing.Size(130, 15);
            this.lblJogadoresDisponiveis.Text = "Jogadores Disponíveis:";

            // lstJogadoresDisponiveis
            this.lstJogadoresDisponiveis.FormattingEnabled = true;
            this.lstJogadoresDisponiveis.ItemHeight = 15;
            this.lstJogadoresDisponiveis.Location = new System.Drawing.Point(290, 120);
            this.lstJogadoresDisponiveis.Name = "lstJogadoresDisponiveis";
            this.lstJogadoresDisponiveis.Size = new System.Drawing.Size(180, 124);
            this.lstJogadoresDisponiveis.TabIndex = 3;

            // btnAdicionarJogador
            this.btnAdicionarJogador.Location = new System.Drawing.Point(480, 150);
            this.btnAdicionarJogador.Name = "btnAdicionarJogador";
            this.btnAdicionarJogador.Size = new System.Drawing.Size(80, 30);
            this.btnAdicionarJogador.TabIndex = 4;
            this.btnAdicionarJogador.Text = ">>";
            this.btnAdicionarJogador.UseVisualStyleBackColor = true;
            this.btnAdicionarJogador.Click += new System.EventHandler(this.btnAdicionarJogador_Click);

            // lblJogadoresTime
            this.lblJogadoresTime.AutoSize = true;
            this.lblJogadoresTime.Location = new System.Drawing.Point(570, 100);
            this.lblJogadoresTime.Name = "lblJogadoresTime";
            this.lblJogadoresTime.Size = new System.Drawing.Size(100, 15);
            this.lblJogadoresTime.Text = "Jogadores do Time:";

            // lstJogadoresTime
            this.lstJogadoresTime.FormattingEnabled = true;
            this.lstJogadoresTime.ItemHeight = 15;
            this.lstJogadoresTime.Location = new System.Drawing.Point(570, 120);
            this.lstJogadoresTime.Name = "lstJogadoresTime";
            this.lstJogadoresTime.Size = new System.Drawing.Size(180, 124);
            this.lstJogadoresTime.TabIndex = 5;

            // btnRemoverJogador
            this.btnRemoverJogador.Location = new System.Drawing.Point(480, 190);
            this.btnRemoverJogador.Name = "btnRemoverJogador";
            this.btnRemoverJogador.Size = new System.Drawing.Size(80, 30);
            this.btnRemoverJogador.TabIndex = 6;
            this.btnRemoverJogador.Text = "<<";
            this.btnRemoverJogador.UseVisualStyleBackColor = true;
            this.btnRemoverJogador.Click += new System.EventHandler(this.btnRemoverJogador_Click);

            // btnNovo
            this.btnNovo.Location = new System.Drawing.Point(290, 260);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(90, 35);
            this.btnNovo.TabIndex = 7;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);

            // btnSalvar
            this.btnSalvar.Location = new System.Drawing.Point(390, 260);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 35);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // btnExcluir
            this.btnExcluir.Location = new System.Drawing.Point(490, 260);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(90, 35);
            this.btnExcluir.TabIndex = 9;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            // CadastroTimeForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 350);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnRemoverJogador);
            this.Controls.Add(this.lstJogadoresTime);
            this.Controls.Add(this.lblJogadoresTime);
            this.Controls.Add(this.btnAdicionarJogador);
            this.Controls.Add(this.lstJogadoresDisponiveis);
            this.Controls.Add(this.lblJogadoresDisponiveis);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lstTimes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CadastroTimeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Time";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

