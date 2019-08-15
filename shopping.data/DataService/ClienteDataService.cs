using shopping.data.Core;
using shopping.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopping.data.DataService
{
    public class ClienteDataService:DataServiceBase<int,Cliente,ShoppingContext>
    {
        public ClienteDataService(ShoppingContext context):base(context)
        {

        }
    }
}
