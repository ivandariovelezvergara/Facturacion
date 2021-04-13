using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AdoFacturacion.Facturacion
{
    public class DValorTotal
    {
        private readonly IConfiguration configuration;
        public DValorTotal(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public List<Entities.Facturacion.ValorTotal> RespuestaLista()
        {
            List<Entities.Facturacion.ValorTotal> lista;
            DSQL db = new DSQL(configuration);
            DataTable dt = db.ProcedureTable("DBO.TOTALVALOR", false);
            if (dt.Rows.Count > 0)
            {
                lista = new List<Entities.Facturacion.ValorTotal>();
                foreach (DataRow row in dt.Rows)
                {
                    Entities.Facturacion.ValorTotal respuesta = new Entities.Facturacion.ValorTotal
                    {
                        Productos = Convert.ToInt32(dt.Rows[0][0]),
                        Nombre = row[1].ToString(),
                        Descripcion = row[2].ToString(),
                        Total = Convert.ToInt32(dt.Rows[0][3])
                    };
                    lista.Add(respuesta);
                }
                return lista;
            }
            else
            {
                return null;
            }

        }
    }
}
