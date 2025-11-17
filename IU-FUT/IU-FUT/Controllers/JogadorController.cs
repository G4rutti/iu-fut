using IU_FUT.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace IU_FUT.Controllers;

public class JogadorController
{
    private readonly iufutContext _context;

    public JogadorController()
    {
        _context = new iufutContext();
    }

    public Jogador? Autenticar(string email, string senha)
    {
        var senhaHash = HashSenha(senha);
        return _context.Jogadors
            .FirstOrDefault(j => j.Email == email && j.Senha == senhaHash);
    }

    public Jogador? CriarJogador(string nome, int idade, string email, string posicao, string senha)
    {
        // RN01: Nome obrigatório
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new Exception("O campo Nome é obrigatório.");
        }

        // RN02: E-mail único
        if (_context.Jogadors.Any(j => j.Email == email))
        {
            throw new Exception("Este e-mail já possui cadastro. Deseja recuperar a senha?");
        }

        var jogador = new Jogador
        {
            Nome = nome,
            Idade = idade,
            Email = email,
            Posicao = posicao,
            Senha = HashSenha(senha)
        };

        _context.Jogadors.Add(jogador);
        _context.SaveChanges();
        return jogador;
    }

    public Jogador? AtualizarJogador(int id, string nome, int idade, string email, string posicao, string? senha = null)
    {
        var jogador = _context.Jogadors.Find(id);
        if (jogador == null) return null;

        // RN01: Nome obrigatório
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new Exception("O campo Nome é obrigatório.");
        }

        // RN02: E-mail único (se mudou)
        if (jogador.Email != email && _context.Jogadors.Any(j => j.Email == email))
        {
            throw new Exception("Este e-mail já possui cadastro.");
        }

        jogador.Nome = nome;
        jogador.Idade = idade;
        jogador.Email = email;
        jogador.Posicao = posicao;
        if (!string.IsNullOrWhiteSpace(senha))
        {
            jogador.Senha = HashSenha(senha);
        }

        _context.SaveChanges();
        return jogador;
    }

    public bool ExcluirJogador(int id)
    {
        var jogador = _context.Jogadors
            .Include(j => j.IdTimeNavigation)
            .FirstOrDefault(j => j.Id == id);
        
        if (jogador == null) return false;

        // RN03: Verificar se há partidas ativas
        var temPartidasAtivas = _context.TimePartida
            .Include(tp => tp.Partida)
            .Include(tp => tp.Time)
            .ThenInclude(t => t!.Jogadors)
            .Any(tp => tp.Time!.Jogadors.Any(j => j.Id == id) && 
                       tp.Partida.DataInicio.HasValue &&
                       tp.Partida.DataInicio.Value >= DateOnly.FromDateTime(DateTime.Now));

        if (temPartidasAtivas)
        {
            throw new Exception("Não é possível excluir sua conta enquanto houver inscrições ativas.");
        }

        _context.Jogadors.Remove(jogador);
        _context.SaveChanges();
        return true;
    }

    public Jogador? ObterJogador(int id)
    {
        return _context.Jogadors.Find(id);
    }

    public List<Jogador> ListarJogadores()
    {
        return _context.Jogadors.ToList();
    }

    private string HashSenha(string senha)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(senha);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
