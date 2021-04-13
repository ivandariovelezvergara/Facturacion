using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFacturacion.Facturacion
{
    public class BCrearFactura
    {
        private readonly IConfiguration configuration;
        public BCrearFactura(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Entities.Facturacion.Respuesta Respuesta(Entities.Facturacion.CrearFactura facturacion)
        {
            try
            {
                AdoFacturacion.Facturacion.DCrearFactura _db = new AdoFacturacion.Facturacion.DCrearFactura(configuration);
                return _db.Respuesta(facturacion);
            }
            catch (Exception ex)
            {
                return new Entities.Facturacion.Respuesta { Codigo = 0, Mensaje = ex.Message };
            }
        }
    }
}
