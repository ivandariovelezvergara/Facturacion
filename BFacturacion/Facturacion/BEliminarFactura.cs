using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFacturacion.Facturacion
{
    public class BEliminarFactura
    {
        private readonly IConfiguration configuration;
        public BEliminarFactura(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Entities.Facturacion.Respuesta Respuesta(Entities.Facturacion.ELiminarFactura facturacion)
        {
            try
            {
                AdoFacturacion.Facturacion.DEliminarFactura _db = new AdoFacturacion.Facturacion.DEliminarFactura(configuration);
                return _db.respuesta(facturacion);
            }
            catch (Exception ex)
            {
                return new Entities.Facturacion.Respuesta { Codigo = 0, Mensaje = ex.Message };
            }
        }
    }
}
