using System;
using System.Collections.Generic;

namespace ReactProjectNET6.Api.Models
{
    public partial class Equipo
    {
        public int IdEquipo { get; set; }
        public int? IdEquipoTipo { get; set; }
        public string CodigoEquipo { get; set; } = null!;
        public string DescripcionEquipo { get; set; } = null!;
        public int? Modelo { get; set; }
        public string? Serial { get; set; }
        public string ColorPrincipal { get; set; } = null!;
        public decimal? Ancho { get; set; }
        public decimal? Largo { get; set; }
        public decimal? Alto { get; set; }

        public virtual EquipoTipo? IdEquipoTipoNavigation { get; set; }
    }
}
