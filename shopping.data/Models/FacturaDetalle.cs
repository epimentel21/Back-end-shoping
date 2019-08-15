using shopping.data.Core;
using System;
using System.Collections.Generic;

namespace shopping.data.Models
{
    public partial class FacturaDetalle: ModelBase<int>
    {
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int Qty { get; set; }
        public decimal Precio { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
        public virtual Productos IdProductoNavigation { get; set; }
    }
}
