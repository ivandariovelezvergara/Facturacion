using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFacturacion.Facturacion
{
   public class BlistaProductos
    {
        private readonly IConfiguration configuration;
        public BlistaProductos(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public List<Entities.Facturacion.ListaProducto> Respuesta()
        {
            try
            {
                AdoFacturacion.Facturacion.DListaProducto _db = new AdoFacturacion.Facturacion.DListaProducto(configuration);
                return _db.RespuestaLista();
            }
            catch (Exception )
            {
                return null;
            }
        }
    }
}
