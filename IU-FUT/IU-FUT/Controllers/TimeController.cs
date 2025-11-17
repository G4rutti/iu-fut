using System.Linq;
using IU_FUT.Models;
using Microsoft.EntityFrameworkCore;

namespace IU_FUT.Controllers;

public class TimeController
{
    private readonly iufutContext _context;

    public TimeController()
    {
        _context = new iufutContext();
    }

    /// <summary>
    /// Lista todos os times cadastrados.
    /// Conforme diagrama de sequência: 1.1.1: listarTime() : List<Time>
    /// </summary>
    public List<Time> ListarTime(object? dados = null)
    {
        return SelecionaTodosTimes();
    }

    /// <summary>
    /// Lista times baseado em jogadores.
    /// Conforme diagrama de sequência: 1.2.1: listarTime(jogadores) : List<Time>
    /// </summary>
    public List<Time> ListarTime(List<int>? jogadoresIds = null)
    {
        if (jogadoresIds == null || !jogadoresIds.Any())
        {
            return SelecionaTodosTimes();
        }

        return _context.Times
            .Include(t => t.Jogadors)
            .Where(t => t.Jogadors.Any(j => jogadoresIds.Contains(j.Id)))
            .ToList();
    }

    /// <summary>
    /// Seleciona todos os times do banco de dados.
    /// Conforme diagrama de sequência: 1.1.1.1: selecionaTodosTimes() : List<Time>
    /// </summary>
    public List<Time> SelecionaTodosTimes()
    {
        return _context.Times
            .Include(t => t.Jogadors)
            .ToList();
    }

    /// <summary>
    /// Seleciona jogadores cadastrados.
    /// Conforme diagrama de sequência: 1.2.1.1.1: selecionarJogadores() : List<Jogador>
    /// </summary>
    public List<Jogador> SelecionarJogadores()
    {
        return _context.Jogadors.ToList();
    }

    /// <summary>
    /// Verifica a qual time um jogador pertence.
    /// Conforme diagrama de sequência: 1.3.1.1: pertenceTime() : List<Time>Jogador
    /// 2.1.1: pertenceTime() : List<Time>Jogador
    /// </summary>
    public List<Time> PertenceTime(List<int> jogadoresIds)
    {
        return _context.Times
            .Include(t => t.Jogadors)
            .Where(t => t.Jogadors.Any(j => jogadoresIds.Contains(j.Id)))
            .ToList();
    }

    /// <summary>
    /// Salva os dados do time (cria ou atualiza).
    /// Conforme diagrama de sequência: 2: salvarDados()
    /// </summary>
    public List<Time> SalvarDados(int? id, string nome, string? descricao, List<int>? jogadoresIds = null)
    {
        // RN01: Nome obrigatório
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new Exception("O campo Nome é obrigatório.");
        }

        // RN02: Validar que todos os jogadores estão cadastrados
        if (jogadoresIds != null && jogadoresIds.Any())
        {
            var jogadoresCadastrados = _context.Jogadors
                .Where(j => jogadoresIds.Contains(j.Id))
                .Select(j => j.Id)
                .ToList();

            var jogadoresNaoCadastrados = jogadoresIds.Except(jogadoresCadastrados).ToList();
            if (jogadoresNaoCadastrados.Any())
            {
                throw new Exception($"Os seguintes jogadores não estão cadastrados: {string.Join(", ", jogadoresNaoCadastrados)}");
            }

            // RN03: Verificar conflito de participação (jogador em mais de um time da mesma partida)
            VerificarConflitoParticipacao(jogadoresIds, id);
        }

        if (id.HasValue)
        {
            // Atualizar
            return AtualizarTimeInternal(id.Value, nome, descricao, jogadoresIds);
        }
        else
        {
            // Criar
            return CriarTimeInternal(nome, descricao, jogadoresIds);
        }
    }

    /// <summary>
    /// Cria um novo time e retorna a lista atualizada.
    /// </summary>
    private List<Time> CriarTimeInternal(string nome, string? descricao, List<int>? jogadoresIds = null)
    {
        var time = new Time
        {
            Nome = nome,
            Descricao = descricao
        };

        _context.Times.Add(time);
        _context.SaveChanges();

        // Adicionar jogadores se fornecidos
        if (jogadoresIds != null && jogadoresIds.Any())
        {
            var jogadores = _context.Jogadors
                .Where(j => jogadoresIds.Contains(j.Id))
                .ToList();

            foreach (var jogador in jogadores)
            {
                jogador.IdTime = time.Id;
            }

            _context.SaveChanges();
        }

        return SelecionaTodosTimes();
    }

    /// <summary>
    /// Atualiza um time existente e retorna a lista atualizada.
    /// </summary>
    private List<Time> AtualizarTimeInternal(int id, string nome, string? descricao, List<int>? jogadoresIds = null)
    {
        var time = _context.Times
            .Include(t => t.Jogadors)
            .FirstOrDefault(t => t.Id == id);
        
        if (time == null)
            throw new Exception("Time não encontrado.");

        time.Nome = nome;
        time.Descricao = descricao;

        // Atualizar jogadores se fornecido
        if (jogadoresIds != null)
        {
            // Remover jogadores que não estão mais na lista
            foreach (var jogador in time.Jogadors.ToList())
            {
                if (!jogadoresIds.Contains(jogador.Id))
                {
                    jogador.IdTime = null;
                }
            }

            // Adicionar novos jogadores
            var novosJogadores = _context.Jogadors
                .Where(j => jogadoresIds.Contains(j.Id) && j.IdTime != id)
                .ToList();

            foreach (var jogador in novosJogadores)
            {
                jogador.IdTime = id;
            }
        }

        _context.SaveChanges();
        return SelecionaTodosTimes();
    }

    /// <summary>
    /// Verifica conflito de participação (RN03).
    /// Um jogador não pode pertencer a mais de um time da mesma partida.
    /// </summary>
    private void VerificarConflitoParticipacao(List<int> jogadoresIds, int? timeIdExcluir = null)
    {
        if (!timeIdExcluir.HasValue)
        {
            // Para novo time: verificar se algum jogador já está em outro time que participa de partidas futuras
            // Isso previne conflitos futuros quando o time for inscrito em partidas
            var partidasComJogadores = _context.TimePartida
                .Include(tp => tp.Partida)
                .Include(tp => tp.Time)
                    .ThenInclude(t => t!.Jogadors)
                .Where(tp => tp.Time!.Jogadors.Any(j => jogadoresIds.Contains(j.Id)) &&
                            tp.Partida.DataInicio.HasValue &&
                            tp.Partida.DataInicio.Value >= DateOnly.FromDateTime(DateTime.Now))
                .ToList();

            if (partidasComJogadores.Any())
            {
                var partidasConflito = partidasComJogadores
                    .Select(tp => tp.Partida.Id)
                    .Distinct()
                    .ToList();

                throw new Exception(
                    $"Conflito de participação detectado. Os jogadores selecionados já estão em times que participam das partidas: {string.Join(", ", partidasConflito)}. " +
                    "Um jogador não pode pertencer a mais de um time da mesma partida.");
            }
        }
        else
        {
            // Para time existente: verificar conflito apenas nas partidas onde este time já está inscrito
            var partidasDoTime = _context.TimePartida
                .Include(tp => tp.Partida)
                .Where(tp => tp.Time_Id == timeIdExcluir.Value &&
                            tp.Partida.DataInicio.HasValue &&
                            tp.Partida.DataInicio.Value >= DateOnly.FromDateTime(DateTime.Now))
                .Select(tp => tp.Partida.Id)
                .ToList();

            if (partidasDoTime.Any())
            {
                // Para cada partida do time, verificar se algum jogador selecionado já está em outro time da mesma partida
                foreach (var partidaId in partidasDoTime)
                {
                    var outrosTimesNaPartida = _context.TimePartida
                        .Include(tp => tp.Time)
                            .ThenInclude(t => t!.Jogadors)
                        .Where(tp => tp.Partida_Id == partidaId && tp.Time_Id != timeIdExcluir.Value)
                        .Select(tp => tp.Time)
                        .ToList();

                    foreach (var outroTime in outrosTimesNaPartida)
                    {
                        if (outroTime != null && outroTime.Jogadors.Any(j => jogadoresIds.Contains(j.Id)))
                        {
                            throw new Exception(
                                $"Conflito de participação detectado. Um ou mais jogadores selecionados já estão em outro time que participa da partida {partidaId}. " +
                                "Um jogador não pode pertencer a mais de um time da mesma partida.");
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Exclui um time e retorna a lista atualizada.
    /// Conforme diagrama de sequência: 3: excluirTime()
    /// </summary>
    public List<Time> ExcluirTime(int id)
    {
        var time = _context.Times
            .Include(t => t.Jogadors)
            .Include(t => t.TimePartida)
            .FirstOrDefault(t => t.Id == id);
        
        if (time == null)
            throw new Exception("Time não encontrado.");

        // Verificar se há partidas agendadas
        var partidasAgendadas = time.TimePartida
            .Where(tp => tp.Partida.DataInicio.HasValue &&
                       tp.Partida.DataInicio.Value >= DateOnly.FromDateTime(DateTime.Now))
            .ToList();

        if (partidasAgendadas.Any())
        {
            throw new Exception(
                $"Não é possível excluir o time. Existem {partidasAgendadas.Count} partida(s) agendada(s) com este time. " +
                "É necessário cancelar as inscrições primeiro.");
        }

        // Remover relacionamento com jogadores
        foreach (var jogador in time.Jogadors)
        {
            jogador.IdTime = null;
        }

        // Remover relacionamentos com partidas
        _context.TimePartida.RemoveRange(time.TimePartida);
        _context.Times.Remove(time);
        _context.SaveChanges();

        return SelecionaTodosTimes();
    }

    /// <summary>
    /// Obtém um time por ID.
    /// </summary>
    public Time? ObterTime(int id)
    {
        return _context.Times
            .Include(t => t.Jogadors)
            .FirstOrDefault(t => t.Id == id);
    }

    /// <summary>
    /// Adiciona um jogador a um time (solicitar participação).
    /// </summary>
    public bool SolicitarParticipacao(int timeId, int jogadorId)
    {
        var time = _context.Times
            .Include(t => t.Jogadors)
            .FirstOrDefault(t => t.Id == timeId);
        
        if (time == null)
        {
            throw new Exception("Time não encontrado.");
        }

        var jogador = _context.Jogadors.FirstOrDefault(j => j.Id == jogadorId);
        if (jogador == null)
        {
            throw new Exception("Jogador não encontrado.");
        }

        // Verificar se já está no time
        if (jogador.IdTime == timeId)
        {
            throw new Exception("Você já está neste time.");
        }

        // Verificar conflito de participação se o jogador já está em outro time
        if (jogador.IdTime.HasValue)
        {
            // Verificar se o time atual do jogador e o novo time participam da mesma partida
            var partidasTimeAtual = _context.TimePartida
                .Include(tp => tp.Partida)
                .Where(tp => tp.Time_Id == jogador.IdTime.Value &&
                            tp.Partida.DataInicio.HasValue &&
                            tp.Partida.DataInicio.Value >= DateOnly.FromDateTime(DateTime.Now))
                .Select(tp => tp.Partida_Id)
                .ToList();

            var partidasNovoTime = _context.TimePartida
                .Include(tp => tp.Partida)
                .Where(tp => tp.Time_Id == timeId &&
                            tp.Partida.DataInicio.HasValue &&
                            tp.Partida.DataInicio.Value >= DateOnly.FromDateTime(DateTime.Now))
                .Select(tp => tp.Partida_Id)
                .ToList();

            var partidasConflito = partidasTimeAtual.Intersect(partidasNovoTime).ToList();
            if (partidasConflito.Any())
            {
                throw new Exception(
                    $"Conflito de participação detectado. Você não pode entrar neste time porque seu time atual e este time participam das mesmas partidas: {string.Join(", ", partidasConflito)}. " +
                    "Um jogador não pode pertencer a mais de um time da mesma partida.");
            }
        }

        // Adicionar jogador ao time
        jogador.IdTime = timeId;
        _context.SaveChanges();
        
        return true;
    }

    // Métodos legados mantidos para compatibilidade
    public Time CriarTime(string nome, string? descricao, List<int>? jogadoresIds = null)
    {
        var times = SalvarDados(null, nome, descricao, jogadoresIds);
        return times.FirstOrDefault(t => t.Nome == nome) ?? throw new Exception("Erro ao criar time.");
    }

    public Time? AtualizarTime(int id, string nome, string? descricao, List<int>? jogadoresIds = null)
    {
        var times = SalvarDados(id, nome, descricao, jogadoresIds);
        return times.FirstOrDefault(t => t.Id == id);
    }

    public bool ExcluirTimeBool(int id)
    {
        try
        {
            ExcluirTime(id);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public List<Time> ListarTimes()
    {
        return SelecionaTodosTimes();
    }
}
