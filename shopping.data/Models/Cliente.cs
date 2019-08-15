using shopping.data.Core;
using System;
using System.Collections.Generic;

namespace shopping.data.Models
{
    public partial class Cliente:ModelBase<int>
    {
        public Cliente()
        {
            Factura = new HashSet<Factura>();
            ProductosActivo = new HashSet<ProductosActivo>();
        }

        public string DocumentoIdentidad { get; set; }
        public string Nombre { get; set; }
        public decimal LiminteCredito { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Factura> Factura { get; set; }
        public virtual ICollection<ProductosActivo> ProductosActivo { get; set; }
    }
}
