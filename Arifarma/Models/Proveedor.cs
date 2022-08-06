using System;
using System.Collections.Generic;

namespace Arifarma.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            CompraMedicamentos = new HashSet<CompraMedicamento>();
        }

        public string CodProveedor { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Dirección { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<CompraMedicamento> CompraMedicamentos { get; set; }
    }
}
