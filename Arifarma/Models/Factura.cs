using System;
using System.Collections.Generic;

namespace Arifarma.Models
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFacts = new HashSet<DetalleFact>();
        }

        public string CodFactura { get; set; } = null!;
        public string CodCliente { get; set; } = null!;
        public string CodEmpleado { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string Cantidad { get; set; } = null!;
        public int CostoTotal { get; set; }

        public virtual Cliente CodClienteNavigation { get; set; } = null!;
        public virtual Empleado CodEmpleadoNavigation { get; set; } = null!;
        public virtual ICollection<DetalleFact> DetalleFacts { get; set; }
    }
}
