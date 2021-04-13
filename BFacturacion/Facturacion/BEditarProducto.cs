using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFacturacion.Facturacion
{
    public class BEditarProducto
    {
        private readonly IConfiguration configuration;
        public BEditarProducto(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Entities.Facturacion.Respuesta Respuesta(Entities.Facturacion.EditarProducto facturacion)
        {
            try
            {
                AdoFacturacion.Facturacion.DEditarProducto _db = new AdoFacturacion.Facturacion.DEditarProducto(configuration);
                return _db.respuesta(facturacion);
            }
            catch (Exception ex)
            {
                return new Entities.Facturacion.Respuesta { Codigo = 0, Mensaje = ex.Message };
            }
        }
    }
}
