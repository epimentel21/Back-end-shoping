using shopping.data.Core;
using System;
using System.Collections.Generic;

namespace shopping.data.Models
{
    public partial class ProductosActivo: ModelBase<int>
    {
        public int IdCliente { get; set; }
        public string TipoTransacion { get; set; }
        public string NumeroActivo { get; set; }
        public DateTime FechaActivo { get; set; }
        public decimal CantidaActivo { get; set; }
        public int ProductoQty { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Productos IdProductoNavigation { get; set; }
    }
}
