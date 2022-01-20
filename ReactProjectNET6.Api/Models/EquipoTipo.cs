using System;
using System.Collections.Generic;

namespace ReactProjectNET6.Api.Models
{
    public partial class EquipoTipo
    {
        public EquipoTipo()
        {
            Equipos = new HashSet<Equipo>();
        }

        public int IdEquipoTipo { get; set; }
        public string? CodigoEquipoTipo { get; set; }
        public string DescripcionEquipoTipo { get; set; } = null!;
        public bool? PorDefecto { get; set; }

        public virtual ICollection<Equipo> Equipos { get; set; }
    }
}
