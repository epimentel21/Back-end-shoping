using shopping.data.Core;
using shopping.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shopping.data.DataService
{
    public class FacturaDataService:DataServiceBase<int,Factura,ShoppingContext>
    {
        public FacturaDataService(ShoppingContext contex):base(contex)
        {

        }

        public IQueryable<FacturaDetalle>  getDetalleFacturaByIdFactura(int IdFactura)
        {

            var fac = (from a in context.FacturaDetalle
                       where a.IdFactura == IdFactura
                       select a);
            return fac;
        }
   }
}
