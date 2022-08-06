using System;
using System.Collections.Generic;

namespace Arifarma.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleCompraMedicamen = new HashSet<DetalleCompraMedicaman>();
            DetalleFacts = new HashSet<DetalleFact>();
        }

        public string CodProducto { get; set; } = null!;
        public string CodCategoria { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int PrecioCompra { get; set; }
        public int PrecioVenta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Impuesto { get; set; } = null!;

        public virtual Categorium CodCategoriaNavigation { get; set; } = null!;
        public virtual ICollection<DetalleCompraMedicaman> DetalleCompraMedicamen { get; set; }
        public virtual ICollection<DetalleFact> DetalleFacts { get; set; }
    }
}
