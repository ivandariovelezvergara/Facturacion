using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFacturacion.Facturacion
{
   public  class BlistaCompra
    {
        private readonly IConfiguration configuration;
        public BlistaCompra(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public List<Entities.Facturacion.ListaCompras> Respuesta()
        {
            try
            {
                AdoFacturacion.Facturacion.DListaCompras _db = new AdoFacturacion.Facturacion.DListaCompras(configuration);
                return _db.RespuestaLista();
            }
            catch (Exception )
            {
                return null;
            }
        }
    }
}
