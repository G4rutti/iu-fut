using IU_FUT.Controllers;
using IU_FUT.Models;
using System.Linq;

namespace IU_FUT.Views
{
    public partial class ConsultarTimeForm : Form
    {
        private readonly TimeController _controller;
        private readonly Jogador _jogadorLogado;

        public ConsultarTimeForm(Jogador jogador)
        {
            _controller = new TimeController();
            _jogadorLogado = jogador;
            InitializeComponent();
            // Conforme diagrama: 1: O ator seleciona consultar times()
            CarregarComboBoxJogadores();
            CarregarGrid();
        }

        /// <summary>
        /// Carrega o combobox de jogadores para filtro
        /// </summary>
        private void CarregarComboBoxJogadores()
        {
            var jogadorController = new JogadorController();
            var jogadores = jogadorController.ListarJogadores();
            
            cmbJogador.Items.Clear();
            cmbJogador.Items.Add("Todos");
            foreach (var jogador in jogadores.OrderBy(j => j.Nome))
            {
                cmbJogador.Items.Add($"{jogador.Nome} (ID: {jogador.Id})");
            }
            cmbJogador.SelectedIndex = 0;
        }

        /// <summary>
        /// Carrega a grade de dados com a lista de times.
        /// Conforme diagrama de sequência: 1.1: carregarGrid()
        /// </summary>
        private void CarregarGrid()
        {
            lstTimes.Items.Clear();
            // 1.1.1: listarTimes() : List<Time>
            var times = _controller.ListarTime(null);
            
            // Aplicar filtros
            times = AplicarFiltros(times);

            foreach (var time in times)
            {
                var item = new ListViewItem(time.Id.ToString());
                item.SubItems.Add(time.Nome);
                item.SubItems.Add(time.Jogadors.Count.ToString());
                item.SubItems.Add(time.Descricao ?? "");
                item.Tag = time;
                lstTimes.Items.Add(item);
            }
        }

        /// <summary>
        /// Aplica os filtros selecionados na lista de times
        /// </summary>
        private List<Time> AplicarFiltros(List<Time> times)
        {
            var resultado = times.AsEnumerable();

            // Filtro por nome
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                var nome = txtNome.Text.ToLower();
                resultado = resultado.Where(t => t.Nome.ToLower().Contains(nome));
            }

            // Filtro por quantidade mínima de jogadores
            if (numJogadoresMin.Value > 0)
            {
                var min = (int)numJogadoresMin.Value;
                resultado = resultado.Where(t => t.Jogadors.Count >= min);
            }

            // Filtro por quantidade máxima de jogadores
            if (numJogadoresMax.Value > 0 && numJogadoresMax.Value < 100)
            {
                var max = (int)numJogadoresMax.Value;
                resultado = resultado.Where(t => t.Jogadors.Count <= max);
            }

            // Filtro por descrição
            if (!string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                var descricao = txtDescricao.Text.ToLower();
                resultado = resultado.Where(t => t.Descricao != null && t.Descricao.ToLower().Contains(descricao));
            }

            // Filtro por jogador específico
            if (cmbJogador.SelectedIndex > 0 && cmbJogador.SelectedItem != null)
            {
                var itemSelecionado = cmbJogador.SelectedItem.ToString();
                if (itemSelecionado != null && itemSelecionado.Contains("ID:"))
                {
                    var idStr = itemSelecionado.Split(new[] { "ID:" }, StringSplitOptions.None)[1].Trim().TrimEnd(')');
                    if (int.TryParse(idStr, out int jogadorId))
                    {
                        resultado = resultado.Where(t => t.Jogadors.Any(j => j.Id == jogadorId));
                    }
                }
            }

            return resultado.ToList();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void btnLimparFiltros_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            numJogadoresMin.Value = 0;
            numJogadoresMax.Value = 100;
            txtDescricao.Clear();
            cmbJogador.SelectedIndex = 0;
            CarregarGrid();
        }

        private void lstTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTimes.SelectedItems.Count > 0)
            {
                var time = lstTimes.SelectedItems[0].Tag as Time;
                if (time != null)
                {
                    ExibirDetalhes(time);
                }
            }
        }

        private void ExibirDetalhes(Time time)
        {
            var detalhes = $"ID: {time.Id}\r\n";
            detalhes += $"Nome: {time.Nome}\r\n";
            detalhes += $"Descrição: {time.Descricao ?? "N/A"}\r\n\r\n";
            detalhes += $"Jogadores ({time.Jogadors.Count}):\r\n";
            
            foreach (var jogador in time.Jogadors)
            {
                detalhes += $"  - {jogador.Nome} ({jogador.Posicao}) - {jogador.Idade} anos\r\n";
            }

            txtDetalhes.Text = detalhes;
        }

        /// <summary>
        /// Processa a solicitação de participação conforme diagrama de sequência.
        /// Fluxo Alternativo (4): Solicitar Participação
        /// </summary>
        private void btnSolicitarParticipacao_Click(object sender, EventArgs e)
        {
            if (lstTimes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um time para entrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var time = lstTimes.SelectedItems[0].Tag as Time;
            if (time == null)
            {
                MessageBox.Show("Time inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // RN03: Só permitir solicitar participação se jogador autenticado
            if (_jogadorLogado == null)
            {
                MessageBox.Show("Você precisa estar autenticado para solicitar participação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1.1: verificaTime() : boolean
                bool verificaTime = VerificaTime(time.Id);

                // alt [verificaTime == false]
                if (!verificaTime)
                {
                    // 2: solicitaIngresso()
                    SolicitaIngresso(time.Id);

                    MessageBox.Show("Solicitação de ingresso enviada! Aguarde aprovação do capitão/organizador.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarGrid();
                }
                else
                {
                    // RN01: Violação - já em time
                    MessageBox.Show("Você já pertence a este time.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                TratarExcecao(ex);
            }
        }

        /// <summary>
        /// Verifica se o jogador já pertence ao time.
        /// Conforme diagrama de sequência: 1.1: verificaTime() : boolean
        /// RN01: Jogador deve estar cadastrado para solicitar ingresso.
        /// </summary>
        private bool VerificaTime(int timeId)
        {
            // 1.1.1: listarTimes() : List<Time>
            var times = _controller.ListarTime(null);

            // 1.1.1.1: pertenceTime() : List<Time>Jogador
            var timesDoJogador = _controller.PertenceTime(new List<int> { _jogadorLogado.Id });
            
            return timesDoJogador.Any(t => t.Id == timeId);
        }

        /// <summary>
        /// Solicita ingresso no time.
        /// Conforme diagrama de sequência: 2: solicitaIngresso()
        /// RN02: Um jogador não pode estar em mais de um time da mesma partida.
        /// RN03: Solicitações ficam pendentes até aceitação do capitão ou organizador.
        /// </summary>
        private void SolicitaIngresso(int timeId)
        {
            // 2.1: listarTimes() : List<Time>
            _controller.ListarTime(null);

            // 2.1.1: selecionaTodosTimes() : List<Time>
            _controller.SelecionaTodosTimes();

            // Criar a solicitação (por enquanto, aceita automaticamente)
            // Em uma implementação completa, isso criaria uma solicitação pendente
            _controller.SolicitarParticipacao(timeId, _jogadorLogado.Id);
        }

        /// <summary>
        /// Trata exceções conforme especificação dos fluxos de exceção.
        /// </summary>
        private void TratarExcecao(Exception ex)
        {
            // Violação RN01 (já em time): impedir se jogador já pertence a outro time na mesma partida
            if (ex.Message.Contains("já está") || ex.Message.Contains("pertence") || ex.Message.Contains("time"))
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Violação RN02 (vagas do time): se time estiver com limite de membros, informar cheio
            if (ex.Message.Contains("cheio") || ex.Message.Contains("limite") || ex.Message.Contains("vagas"))
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Violação RN03 (autenticação): só permitir solicitar participação se jogador autenticado
            if (ex.Message.Contains("autenticado") || ex.Message.Contains("login"))
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Violação RN02 (conflito de participação)
            if (ex.Message.Contains("Conflito de participação") || ex.Message.Contains("mesma partida"))
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Outras exceções
            MessageBox.Show(
                $"Erro ao processar a operação:\n\n{ex.Message}\n\nTipo: {ex.GetType().Name}",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}

