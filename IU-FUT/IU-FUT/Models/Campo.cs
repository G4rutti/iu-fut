using System;
using System.Collections.Generic;

namespace IU_FUT.Models;

public partial class Campo
{
    public int Id { get; set; }

    public string Endereco { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public virtual ICollection<Partidum> Partida { get; set; } = new List<Partidum>();
}
