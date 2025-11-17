using System;
using System.Collections.Generic;

namespace IU_FUT.Models;

public partial class Partidum
{
    public int Id { get; set; }

    public int Campo_Id { get; set; }

    public string? Descricao { get; set; }

    public DateOnly? DataInicio { get; set; }

    public DateOnly? DataFim { get; set; }

    public virtual Campo Campo { get; set; } = null!;

    public virtual ICollection<TimePartidum> TimePartida { get; set; } = new List<TimePartidum>();
}
