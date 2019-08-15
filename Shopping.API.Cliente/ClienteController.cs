using Microsoft.AspNetCore.Mvc;
using shopping.data.DataService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.API.Cliente
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteDataService clienteDataService;

        public ClienteController(ClienteDataService clienteDataService)
        {
            this.clienteDataService = clienteDataService;
        }

        [HttpGet]
        public IEnumerable<shopping.data.Models.Cliente> getAllClientes()
        {
            var resultado = clienteDataService.GetAll();
            return resultado;
        }

        [HttpGet]
        public shopping.data.Models.Cliente getClienteByID(int Id)
        {
            var producto = clienteDataService.GetItemById(Id);
            return producto;
        }

   

    }
}
