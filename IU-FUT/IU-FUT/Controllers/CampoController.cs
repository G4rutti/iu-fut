using System.Linq;
using IU_FUT.Models;
using Microsoft.EntityFrameworkCore;

namespace IU_FUT.Controllers;

public class CampoController
{
    private readonly iufutContext _context;

    public CampoController()
    {
        _context = new iufutContext();
    }

    /// <summary>
    /// Lista todos os locais (campos) cadastrados.
    /// Conforme diagrama de sequência: 1.1.1: listarLocais() : List<Locais>
    /// 1.1.1.1: selecionarTodos() - Campo consulta banco
    /// </summary>
    public List<Campo> ListarLocais()
    {
        return _context.Campos.ToList();
    }

    /// <summary>
    /// Verifica se existe duplicidade de nome e endereço.
    /// Conforme diagrama de sequência: 2: verificarDuplicidade(dados) : boolean
    /// 2.1: existeNome(dados) - Campo consulta banco
    /// </summary>
    public bool VerificarDuplicidade(string nome, string endereco, int? idExcluir = null)
    {
        var query = _context.Campos.Where(c => c.Nome == nome && c.Endereco == endereco);
        
        if (idExcluir.HasValue)
        {
            query = query.Where(c => c.Id != idExcluir.Value);
        }
        
        return query.Any();
    }

    /// <summary>
    /// Inclui um novo campo.
    /// Conforme diagrama de sequência: 1.2: incluir(oCampo:Campo) : Campo
    /// 1.2.1: incluir() - Campo persiste no banco
    /// </summary>
    public Campo Incluir(Campo campo)
    {
        _context.Campos.Add(campo);
        _context.SaveChanges();
        return campo;
    }

    /// <summary>
    /// Salva/atualiza um campo e retorna a lista atualizada de locais.
    /// Conforme diagrama de sequência: 1.4: salvarCampo(dados) : List<Locais>
    /// </summary>
    public List<Campo> SalvarCampo(int? id, string nome, string endereco, string cidade, string descricao)
    {
        if (id.HasValue)
        {
            // Atualizar
            var campo = _context.Campos.Find(id.Value);
            if (campo == null)
                throw new Exception("Campo não encontrado.");

            campo.Nome = nome;
            campo.Endereco = endereco;
            campo.Cidade = cidade;
            campo.Descricao = descricao;
            _context.SaveChanges();
        }
        else
        {
            // Incluir
            var campo = new Campo
            {
                Nome = nome,
                Endereco = endereco,
                Cidade = cidade,
                Descricao = descricao
            };
            _context.Campos.Add(campo);
            _context.SaveChanges();
        }

        return _context.Campos.ToList();
    }

    /// <summary>
    /// Verifica se há partidas agendadas para o campo.
    /// Conforme diagrama de sequência: 1.1: verificaAgenda(Partida) : boolean
    /// 1.1.1: selecionarPartidas() - Campo consulta Partida
    /// </summary>
    public bool VerificaAgenda(int campoId)
    {
        var campo = _context.Campos
            .Include(c => c.Partida)
            .FirstOrDefault(c => c.Id == campoId);

        if (campo == null)
            return false;

        // 1.1.1: selecionarPartidas() - Campo consulta Partida através do relacionamento
        var partidas = _context.Partida
            .Where(p => p.Campo_Id == campoId)
            .ToList();
        
        var partidasAgendadas = partidas
            .Where(p => p.DataInicio.HasValue && 
                       p.DataInicio.Value >= DateOnly.FromDateTime(DateTime.Now))
            .ToList();

        return partidasAgendadas.Any();
    }

    /// <summary>
    /// Retorna a quantidade de partidas agendadas para o campo.
    /// </summary>
    public int ObterQuantidadePartidasAgendadas(int campoId)
    {
        var campo = _context.Campos
            .Include(c => c.Partida)
            .FirstOrDefault(c => c.Id == campoId);

        if (campo == null)
            return 0;

        var partidas = _context.Partida
            .Where(p => p.Campo_Id == campoId)
            .ToList();
            
        return partidas
            .Where(p => p.DataInicio.HasValue && 
                       p.DataInicio.Value >= DateOnly.FromDateTime(DateTime.Now))
            .Count();
    }

    public Campo CriarCampo(string nome, string endereco, string cidade, string descricao)
    {
        // RN01: Nome obrigatório
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new Exception("O campo Nome é obrigatório.");
        }

        // RN02: Não permitir duplicados (Nome + Endereço)
        if (_context.Campos.Any(c => c.Nome == nome && c.Endereco == endereco))
        {
            throw new Exception("Já existe um local com mesmo nome e endereço. Deseja visualizar o existente?");
        }

        var campo = new Campo
        {
            Nome = nome,
            Endereco = endereco,
            Cidade = cidade,
            Descricao = descricao
        };

        _context.Campos.Add(campo);
        _context.SaveChanges();
        return campo;
    }

    public Campo? AtualizarCampo(int id, string nome, string endereco, string cidade, string descricao)
    {
        var campo = _context.Campos.Find(id);
        if (campo == null) return null;

        // RN01: Nome obrigatório
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new Exception("O campo Nome é obrigatório.");
        }

        // RN02: Não permitir duplicados (se mudou nome ou endereço)
        if ((campo.Nome != nome || campo.Endereco != endereco) &&
            _context.Campos.Any(c => c.Id != id && c.Nome == nome && c.Endereco == endereco))
        {
            throw new Exception("Já existe um local com mesmo nome e endereço.");
        }

        campo.Nome = nome;
        campo.Endereco = endereco;
        campo.Cidade = cidade;
        campo.Descricao = descricao;

        _context.SaveChanges();
        return campo;
    }

    public bool ExcluirCampo(int id)
    {
        var campo = _context.Campos
            .Include(c => c.Partida)
            .FirstOrDefault(c => c.Id == id);
        
        if (campo == null) return false;

        // RN03: Não permitir exclusão se houver partidas agendadas
        var partidasAgendadas = campo.Partida
            .Where(p => p.DataInicio.HasValue && 
                       p.DataInicio.Value >= DateOnly.FromDateTime(DateTime.Now))
            .ToList();

        if (partidasAgendadas.Any())
        {
            throw new Exception($"Não é possível excluir o local. Existem {partidasAgendadas.Count} partida(s) agendada(s). É necessário reatribuir ou cancelar as partidas primeiro.");
        }

        _context.Campos.Remove(campo);
        _context.SaveChanges();
        return true;
    }

    public Campo? ObterCampo(int id)
    {
        return _context.Campos.Find(id);
    }

    public List<Campo> ListarCampos()
    {
        return _context.Campos.ToList();
    }
}
