using System;
using System.Collections.Generic;

namespace Arifarma.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Facturas = new HashSet<Factura>();
        }

        public string CodEmpleado { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Dirección { get; set; } = null!;

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
