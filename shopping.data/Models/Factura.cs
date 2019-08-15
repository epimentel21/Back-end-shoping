using shopping.data.Core;
using System;
using System.Collections.Generic;

namespace shopping.data.Models
{
    public partial class Factura: ModelBase<int>
    {
        public Factura()
        {
            FacturaDetalle = new HashSet<FacturaDetalle>();
        }

        public string NumberFactura { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public bool Active { get; set; }
        public byte[] RowVersion { get; set; }

        public  Cliente IdClienteNavigation { get; set; }
        public  ICollection<FacturaDetalle> FacturaDetalle { get; set; }
    }
}
