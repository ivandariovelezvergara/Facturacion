using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFacturacion.Facturacion
{
    public class BTotalValor
    {
        private readonly IConfiguration configuration;
        public BTotalValor(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public List<Entities.Facturacion.ValorTotal> Respuesta()
        {
            try
            {
                AdoFacturacion.Facturacion.DValorTotal _db = new AdoFacturacion.Facturacion.DValorTotal(configuration);
                return _db.RespuestaLista();
            }
            catch (Exception )
            {
                return null;
            }
        }
    }
}
