using System;
using System.Collections.Generic;

namespace Arifarma.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public string CodCategoria { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Descripción { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
