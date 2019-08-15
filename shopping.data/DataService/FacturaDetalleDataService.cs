using shopping.data.Core;
using shopping.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopping.data.DataService
{
    public class FacturaDetalleDataService:DataServiceBase<int,FacturaDetalle,ShoppingContext>
    {
        public FacturaDetalleDataService(ShoppingContext context) : base(context)
        {

        }

    }
}
