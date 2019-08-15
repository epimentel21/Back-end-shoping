using Microsoft.AspNetCore.Mvc;
using shopping.data.DataService;
using shopping.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.API.Producto
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductoController:ControllerBase
    {
        ProductoDataService productoDataService;
        public ProductoController(ProductoDataService productoDataService)
        {
            this.productoDataService = productoDataService;
        }


        [HttpGet]
        public IEnumerable<Productos> getAll()
        {
            var resultado = productoDataService.GetAll();
            return resultado;
        }


        [HttpGet]
        public Productos getItemByID(int Id)
        {
            var producto = productoDataService.GetItemById(Id);
            return producto;
        }

       

    }
}
