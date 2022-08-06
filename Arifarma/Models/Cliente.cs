using System;
using System.Collections.Generic;

namespace Arifarma.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public string CodCliente { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Dirección { get; set; } = null!;
        public string? Email { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
