using System;
using System.Collections.Generic;

namespace IU_FUT.Models;

public partial class TimePartidum
{
    public int Id { get; set; }

    public int Partida_Id { get; set; }

    public int Time_Id { get; set; }

    public virtual Partidum Partida { get; set; } = null!;

    public virtual Time Time { get; set; } = null!;
}
