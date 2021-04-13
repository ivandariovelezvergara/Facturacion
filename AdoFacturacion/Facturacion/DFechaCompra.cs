using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoFacturacion.Facturacion
{
    public class DFechaCompra
    {
            private readonly IConfiguration configuration;
            public DFechaCompra(IConfiguration _configuration)
            {
                configuration = _configuration;
            }
            public Entities.Facturacion.FechaCompraRespuesta Respuesta(Entities.Facturacion.FechaCompra fecha)
            {
                SqlParameter[] param = new SqlParameter[]

              {
               new SqlParameter
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@NUMERODOCUMENTO",
                    Value = fecha.NumeroDocumento
                }
               };
                DSQL db = new DSQL(configuration);
                DataTable dt = db.ProcedureTable("DBO.FECHACOMPRA", true, param);
                if (dt.Rows.Count > 0)
                {

                    Entities.Facturacion.FechaCompraRespuesta resultado = new Entities.Facturacion.FechaCompraRespuesta
                    {
                        Nombres = dt.Rows[0][0].ToString(),
                        UltimaCompra = dt.Rows[0][1].ToString(),
                        Frecuencia = dt.Rows[0][2].ToString()
                    };
                    resultado.Codigo = 1;
                    resultado.Mensaje = "OK";
                    return resultado;
                }
                else
                {
                    return new Entities.Facturacion.FechaCompraRespuesta
                    {
                        Codigo = Convert.ToInt32(dt.Rows[0][0]),
                        Mensaje = dt.Rows[0][1].ToString()
                    };
                }
            }
        
    }
}
