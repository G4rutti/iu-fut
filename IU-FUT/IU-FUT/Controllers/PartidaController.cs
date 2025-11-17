using System.Linq;
using IU_FUT.Models;
using Microsoft.EntityFrameworkCore;

namespace IU_FUT.Controllers;

public class PartidaController
{
    private readonly iufutContext _context;

    public PartidaController()
    {
        _context = new iufutContext();
    }

    /// <summary>
    /// Lista todas as partidas cadastradas.
    /// Conforme diagrama de sequência: 1.1.1: listarPartidas(dados) : List<Partidas>
    /// </summary>
    public List<Partidum> ListarPartidas(object? dados = null)
    {
        return SelecionarPartidas();
    }

    /// <summary>
    /// Seleciona todas as partidas do banco de dados.
    /// Conforme diagrama de sequência: 1.1.1.1: selecionarPartidas() : List<Partidas>
    /// </summary>
    public List<Partidum> SelecionarPartidas()
    {
        return _context.Partida
            .Include(p => p.Campo)
            .Include(p => p.TimePartida)
                .ThenInclude(tp => tp.Time)
            .OrderBy(p => p.DataInicio)
            .ToList();
    }

    /// <summary>
    /// Lista os locais (campos) cadastrados.
    /// Conforme diagrama de sequência: 1.2.1: listarLocais() : List<Locais>
    /// 1.2.1.1: campocadastrado() ou selecionarLocais(Campo) : List<Locais>
    /// </summary>
    public List<Campo> ListarLocais()
    {
        return _context.Campos.ToList();
    }

    /// <summary>
    /// Seleciona locais baseado em um campo.
    /// Conforme diagrama de sequência: 1.2.1.1: selecionarLocais(Campo) : List<Locais>
    /// </summary>
    public List<Campo> SelecionarLocais(Campo? campo = null)
    {
        if (campo != null)
        {
            return _context.Campos
                .Where(c => c.Id == campo.Id)
                .ToList();
        }
        return _context.Campos.ToList();
    }

    /// <summary>
    /// Cria uma nova partida.
    /// Conforme diagrama de sequência: 1.5: criarPartida()
    /// </summary>
    public Partidum CriarPartida(int campoId, string? descricao, DateOnly? dataInicio = null, DateOnly? dataFim = null)
    {
        // RN01: Data/Hora deve ser futura (permite data de hoje)
        var hoje = DateOnly.FromDateTime(DateTime.Now);
        if (dataInicio.HasValue && dataInicio.Value < hoje)
        {
            throw new Exception("A data/hora de início deve ser futura.");
        }

        var campo = _context.Campos.Find(campoId);
        if (campo == null)
        {
            throw new Exception("Campo não encontrado.");
        }

        var partida = new Partidum
        {
            Campo_Id = campoId,
            Descricao = descricao,
            DataInicio = dataInicio,
            DataFim = dataFim
        };

        _context.Partida.Add(partida);
        _context.SaveChanges();
        return partida;
    }

    /// <summary>
    /// Exclui uma partida e retorna a lista atualizada.
    /// Conforme diagrama de sequência: 3: excluirPartida()
    /// </summary>
    public List<Partidum> ExcluirPartida(int id)
    {
        var partida = _context.Partida
            .Include(p => p.TimePartida)
            .FirstOrDefault(p => p.Id == id);
        
        if (partida == null)
            throw new Exception("Partida não encontrada.");

        // Remover relacionamentos com times
        _context.TimePartida.RemoveRange(partida.TimePartida);
        _context.Partida.Remove(partida);
        _context.SaveChanges();

        return SelecionarPartidas();
    }

    /// <summary>
    /// Seleciona partidas relacionadas a jogadores.
    /// Conforme diagrama de sequência: 4.1.1: selecionarPartidas(Jogadores) : List<Partidas>
    /// </summary>
    public List<Partidum> SelecionarPartidasPorJogadores()
    {
        // Retorna partidas que têm times inscritos (que têm jogadores)
        return _context.Partida
            .Include(p => p.Campo)
            .Include(p => p.TimePartida)
                .ThenInclude(tp => tp.Time)
            .Where(p => p.TimePartida.Any())
            .OrderBy(p => p.DataInicio)
            .ToList();
    }

    /// <summary>
    /// Atualiza uma partida existente.
    /// </summary>
    public Partidum? AtualizarPartida(int id, int campoId, string? descricao, DateOnly? dataInicio = null, DateOnly? dataFim = null)
    {
        var partida = _context.Partida.Find(id);
        if (partida == null) return null;

        // RN01: Data/Hora deve ser futura (se estiver alterando)
        if (dataInicio.HasValue && dataInicio.Value < DateOnly.FromDateTime(DateTime.Now))
        {
            throw new Exception("A data/hora de início deve ser futura.");
        }

        var campo = _context.Campos.Find(campoId);
        if (campo == null)
        {
            throw new Exception("Campo não encontrado.");
        }

        partida.Campo_Id = campoId;
        partida.Descricao = descricao;
        partida.DataInicio = dataInicio;
        partida.DataFim = dataFim;

        _context.SaveChanges();
        return partida;
    }

    /// <summary>
    /// Obtém uma partida por ID.
    /// </summary>
    public Partidum? ObterPartida(int id)
    {
        return _context.Partida
            .Include(p => p.Campo)
            .Include(p => p.TimePartida)
                .ThenInclude(tp => tp.Time)
            .FirstOrDefault(p => p.Id == id);
    }

    public List<Partidum> ListarPartidasDisponiveis()
    {
        var hoje = DateOnly.FromDateTime(DateTime.Now);
        return _context.Partida
            .Include(p => p.Campo)
            .Include(p => p.TimePartida)
                .ThenInclude(tp => tp.Time)
            .Where(p => p.DataInicio.HasValue && p.DataInicio.Value >= hoje)
            .OrderBy(p => p.DataInicio)
            .ToList();
    }

    public bool SolicitarParticipacao(int partidaId, int timeId)
    {
        // Verificar se já existe solicitação
        if (_context.TimePartida.Any(tp => tp.Partida_Id == partidaId && tp.Time_Id == timeId))
        {
            throw new Exception("Este time já está participando desta partida.");
        }

        var timePartida = new TimePartidum
        {
            Partida_Id = partidaId,
            Time_Id = timeId
        };

        _context.TimePartida.Add(timePartida);
        _context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Verifica se existe vaga disponível na partida.
    /// Conforme diagrama de sequência: 1.1.1.1: existeVaga() : List<Partidas>
    /// RN02: Registro de inscrição só se houver vagas (ou possibilidade de lista de espera).
    /// Limite padrão: 2 times por partida (comum em futebol).
    /// </summary>
    public bool ExisteVaga(int partidaId)
    {
        const int LIMITE_TIMES_POR_PARTIDA = 2;
        
        var quantidadeInscritos = _context.TimePartida
            .Count(tp => tp.Partida_Id == partidaId);

        return quantidadeInscritos < LIMITE_TIMES_POR_PARTIDA;
    }

    /// <summary>
    /// Lista as inscrições de uma partida.
    /// Conforme diagrama de sequência: 1.2.1: listarInscricaoPartida() : List<Partidas>
    /// 2.1: listarInscricaoPartida() : List<Partidas>
    /// </summary>
    public List<TimePartidum> ListarInscricaoPartida(int partidaId)
    {
        return _context.TimePartida
            .Include(tp => tp.Time)
            .Include(tp => tp.Partida)
            .Where(tp => tp.Partida_Id == partidaId)
            .ToList();
    }

    /// <summary>
    /// Verifica se existe inscrição do time na partida.
    /// Conforme diagrama de sequência: 1.2.1.1: existeInscricao() : List<Partidas>
    /// RN03: Só permitir solicitar participação se jogador autenticado.
    /// </summary>
    public bool ExisteInscricao(int partidaId, int timeId)
    {
        return _context.TimePartida
            .Any(tp => tp.Partida_Id == partidaId && tp.Time_Id == timeId);
    }
}
