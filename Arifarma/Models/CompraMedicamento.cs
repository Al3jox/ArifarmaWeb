using System;
using System.Collections.Generic;

namespace Arifarma.Models
{
    public partial class CompraMedicamento
    {
        public CompraMedicamento()
        {
            DetalleCompraMedicamen = new HashSet<DetalleCompraMedicaman>();
        }

        public string CodCompraMedicamentos { get; set; } = null!;
        public string CodProveedor { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public int ValorCompra { get; set; }

        public virtual Proveedor CodProveedorNavigation { get; set; } = null!;
        public virtual ICollection<DetalleCompraMedicaman> DetalleCompraMedicamen { get; set; }
    }
}
