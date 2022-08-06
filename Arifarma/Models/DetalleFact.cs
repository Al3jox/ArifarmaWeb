using System;
using System.Collections.Generic;

namespace Arifarma.Models
{
    public partial class DetalleFact
    {
        public string CodDetalleFactura { get; set; } = null!;
        public string CodFactura { get; set; } = null!;
        public string CodProducto { get; set; } = null!;
        public string Cantidad { get; set; } = null!;
        public int SubtotalVenta { get; set; }

        public virtual Factura CodFacturaNavigation { get; set; } = null!;
        public virtual Producto CodProductoNavigation { get; set; } = null!;
    }
}
