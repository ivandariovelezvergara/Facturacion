using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFacturacion.Facturacion
{

        public class BListaPrecios
        {
            private readonly IConfiguration configuration;
            public BListaPrecios(IConfiguration _configuration)
            {
                configuration = _configuration;
            }
            public List<Entities.Facturacion.ListaPrecios> Respuesta()
            {
                try
                {
                    AdoFacturacion.Facturacion.DListaPrecios _db = new AdoFacturacion.Facturacion.DListaPrecios(configuration);
                    return _db.RespuestaLista();
                }
                catch (Exception )
                {
                    return null;
                }
            }
        }
}

