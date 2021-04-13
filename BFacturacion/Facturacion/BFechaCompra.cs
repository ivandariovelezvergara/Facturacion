using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFacturacion.Facturacion
{
   public  class BFechaCompra
    {
        private readonly IConfiguration configuration;
        public BFechaCompra(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Entities.Facturacion.FechaCompraRespuesta Respuesta(Entities.Facturacion.FechaCompra facturacion)
        {
            try
            {
                AdoFacturacion.Facturacion.DFechaCompra _db = new AdoFacturacion.Facturacion.DFechaCompra(configuration);
                return _db.Respuesta(facturacion);
            }
            catch (Exception )
            {
                return null;
            }
        }
    }
}
