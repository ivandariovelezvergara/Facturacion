using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFacturacion.Facturacion
{
   public  class BConsultaFactura
    {
        private readonly IConfiguration configuration;
        public BConsultaFactura(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Entities.Facturacion.FacturacionRespuesta Respuesta(Entities.Facturacion.Facturacion facturacion)
        {
            try
            {
                AdoFacturacion.Facturacion.DConsultaFactura _db = new AdoFacturacion.Facturacion.DConsultaFactura(configuration);
                return _db.Respuesta(facturacion);
            }
            catch (Exception ex)
            {
                return new Entities.Facturacion.FacturacionRespuesta { Codigo = 0, Mensaje = ex.Message };
            }
        }
    }
}
