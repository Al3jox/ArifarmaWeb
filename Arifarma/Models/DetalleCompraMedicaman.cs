using System;
using System.Collections.Generic;

namespace Arifarma.Models
{
    public partial class DetalleCompraMedicaman
    {
        public string CodDetalleCompraMedicamentos { get; set; } = null!;
        public string CodProducto { get; set; } = null!;
        public string CodCompraMedicamentos { get; set; } = null!;
        public string Cantidad { get; set; } = null!;
        public int Precio { get; set; }

        public virtual CompraMedicamento CodCompraMedicamentosNavigation { get; set; } = null!;
        public virtual Producto CodProductoNavigation { get; set; } = null!;
    }
}
