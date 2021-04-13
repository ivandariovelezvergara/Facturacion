using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFacturacion.Facturacion
{
    public class BCrearProducto
    {
        private readonly IConfiguration configuration;
        public BCrearProducto(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Entities.Facturacion.Respuesta Respuesta(Entities.Facturacion.CrearProducto facturacion)
        {
            try
            {
                AdoFacturacion.Facturacion.DCrearProducto _db = new AdoFacturacion.Facturacion.DCrearProducto(configuration);
                return _db.respuesta(facturacion);
            }
            catch (Exception ex)
            {
                return new Entities.Facturacion.Respuesta { Codigo = 0, Mensaje = ex.Message };
            }
        }
    }
}
