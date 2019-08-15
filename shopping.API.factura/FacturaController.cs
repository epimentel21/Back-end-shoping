using Microsoft.AspNetCore.Mvc;
using shopping.data.DataService;
using shopping.data.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace shopping.API.factura
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private FacturaDataService facturaDataService;
        private FacturaDetalleDataService facturaDetalleDataService;


        public FacturaController(FacturaDataService facturaDataService, FacturaDetalleDataService facturaDetalleDataService)
        {
            this.facturaDataService = facturaDataService;
            this.facturaDetalleDataService = facturaDetalleDataService;
        }

        [HttpGet]
        public IEnumerable<Factura> getAll()
        {
            var resultado = facturaDataService.GetAll(); ;
            return resultado;
        }


        [HttpGet]
        public Factura getItemByID(int Id)
        {   

            var producto = facturaDataService.GetItemById(Id);
            return producto;
        }


        [HttpPost]
        public  IActionResult AddOrUpdate([FromBody] Factura factura)
        {

            var resultado = new { estatus = true, mensaje = "", resultado = facturaDataService.AddOrUpdate(factura) };
            return Ok(resultado);
        }

        [HttpPost]
        public IActionResult AddOrUpdateFacturaDetalle([FromBody] FacturaDetalle factura)
        {

            var resultado = new { estatus = true, mensaje = "", id = facturaDetalleDataService.AddOrUpdate(factura) };
            return Ok(resultado);
        }

        [HttpGet]
        public IEnumerable<FacturaDetalle> getDetalleByID(int Id)
        {

            var detalle = facturaDataService.getDetalleFacturaByIdFactura(Id);
            return detalle;
        }

        [HttpPost]
        public IActionResult deleteDetalleByID([FromBody] FacturaDetalle detalle)
        {
            facturaDetalleDataService.DeleteItemById(detalle.Id);
            return Ok();
        }

        [HttpGet]
        public FacturaDetalle detalleFacturaById(int Id)
        {
            var resultado = facturaDetalleDataService.GetItemById(Id);
            return resultado;
        }

    }
}