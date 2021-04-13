using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Controllers
{
    public class FacturacionesController : Controller
    {
        private readonly IConfiguration configuration;
        public FacturacionesController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }


        [Route("Facturacion/Consulta")]
        [HttpPost]
        public ActionResult<Entities.Facturacion.FacturacionRespuesta> resp(Entities.Facturacion.Facturacion facturacion)
        {
            BFacturacion.Facturacion.BConsultaFactura factura = new BFacturacion.Facturacion.BConsultaFactura(configuration);
            return factura.Respuesta(facturacion);
        }

        [HttpPost]
        [Route("Facturacion/CrearFactura")]
        public ActionResult<Entities.Facturacion.Respuesta> respu(Entities.Facturacion.CrearFactura facturacion)
        {
            BFacturacion.Facturacion.BCrearFactura factura = new BFacturacion.Facturacion.BCrearFactura(configuration);
            return factura.Respuesta(facturacion);
        }

        [HttpPost]
        [Route("Facturacion/CrearProducto")]
        public ActionResult<Entities.Facturacion.Respuesta> respu(Entities.Facturacion.CrearProducto facturacion)
        {
            BFacturacion.Facturacion.BCrearProducto factura = new BFacturacion.Facturacion.BCrearProducto(configuration);
            return factura.Respuesta(facturacion);
        }

        [HttpPost]
        [Route("Facturacion/EditarProducto")]
        public ActionResult<Entities.Facturacion.Respuesta> respue(Entities.Facturacion.EditarProducto facturacion)
        {
            BFacturacion.Facturacion.BEditarProducto factura = new BFacturacion.Facturacion.BEditarProducto(configuration);
            return factura.Respuesta(facturacion);
        }

        [HttpPost]
        [Route("Facturacion/ELiminarFactura")]
        public ActionResult<Entities.Facturacion.Respuesta> respues(Entities.Facturacion.ELiminarFactura facturacion)
        {
            BFacturacion.Facturacion.BEliminarFactura factura = new BFacturacion.Facturacion.BEliminarFactura(configuration);
            return factura.Respuesta(facturacion);
        }

        [HttpPost]
        [Route("Facturacion/EliminarProducto")]
        public ActionResult<Entities.Facturacion.Respuesta> respues(Entities.Facturacion.ELiminarProducto facturacion)
        {
            BFacturacion.Facturacion.BEliminrProducto factura = new BFacturacion.Facturacion.BEliminrProducto(configuration);
            return factura.Respuesta(facturacion);
        }


        [HttpGet]
        [Route("Administracion/ListaCompra")]
        public ActionResult<dynamic> GetList()
        {
            BFacturacion.Facturacion.BlistaCompra list = new BFacturacion.Facturacion.BlistaCompra(configuration);
            return list.Respuesta();
        }

        [HttpGet]
        [Route("Administracion/ListaPrecios")]
        public ActionResult<dynamic> GetLista()
        {
            BFacturacion.Facturacion.BListaPrecios list = new BFacturacion.Facturacion.BListaPrecios(configuration);
            return list.Respuesta();
        }

        [HttpGet]
        [Route("Administracion/ListaPrecios")]
        public ActionResult<dynamic> GetListas()
        {
            BFacturacion.Facturacion.BlistaProductos list = new BFacturacion.Facturacion.BlistaProductos(configuration);
            return list.Respuesta();
        }

        [HttpGet]
        [Route("Administracion/ListaPrecios")]
        public ActionResult<dynamic> GetListasvalor()
        {
            BFacturacion.Facturacion.BTotalValor list = new BFacturacion.Facturacion.BTotalValor(configuration);
            return list.Respuesta();
        }

        [HttpPost]
        [Route("Facturacion/FechaCompra")]
        public ActionResult<Entities.Facturacion.FechaCompraRespuesta> respuesta(Entities.Facturacion.FechaCompra facturacion)
        {
            BFacturacion.Facturacion.BFechaCompra factura = new BFacturacion.Facturacion.BFechaCompra(configuration);
            return factura.Respuesta(facturacion);
        }
    }
}
