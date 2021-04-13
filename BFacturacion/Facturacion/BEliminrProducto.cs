using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFacturacion.Facturacion
{
    public class BEliminrProducto
    {
        private readonly IConfiguration configuration;
        public BEliminrProducto(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Entities.Facturacion.Respuesta Respuesta(Entities.Facturacion.ELiminarProducto facturacion)
        {
            try
            {
                AdoFacturacion.Facturacion.DEliminarProducto _db = new AdoFacturacion.Facturacion.DEliminarProducto(configuration);
                return _db.respuesta(facturacion);
            }
            catch (Exception ex)
            {
                return new Entities.Facturacion.Respuesta { Codigo = 0, Mensaje = ex.Message };
            }
        }
    }
}
