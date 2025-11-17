using System;
using System.Collections.Generic;

namespace IU_FUT.Models;

public partial class Time
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public virtual ICollection<Jogador> Jogadors { get; set; } = new List<Jogador>();

    public virtual ICollection<TimePartidum> TimePartida { get; set; } = new List<TimePartidum>();
}
