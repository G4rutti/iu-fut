using System;
using System.Collections.Generic;

namespace IU_FUT.Models;

public partial class Jogador
{
    public int Id { get; set; }

    public int? IdTime { get; set; }

    public string Nome { get; set; } = null!;

    public int Idade { get; set; }

    public string Email { get; set; } = null!;

    public string Posicao { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public virtual Time? IdTimeNavigation { get; set; }
}
