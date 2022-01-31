using System;
using System.Collections.Generic;

namespace ReactProjectNET6.Api.Models
{
    public partial class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string Placa { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
    }
}
