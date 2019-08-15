using shopping.data.Core;
using shopping.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopping.data.DataService
{
    public class ProductoDataService:DataServiceBase<int,Productos,ShoppingContext>
    {
        public ProductoDataService(ShoppingContext context):base(context)
        {

        }
    }
}
