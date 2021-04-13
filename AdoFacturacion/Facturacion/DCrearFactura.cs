using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoFacturacion.Facturacion
{
    public class DCrearFactura
    {
        private readonly IConfiguration configuration;
        public DCrearFactura(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Entities.Facturacion.Respuesta Respuesta(Entities.Facturacion.CrearFactura crear)
        {
            SqlParameter[] param = new SqlParameter[]

            {
               new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@CLIENTE",
                    Value = crear.Cliente
                },
                new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@PRODUCTOS",
                    Value = crear.IdProductos
                }
           };
            DSQL db = new DSQL(configuration);
            DataTable dt = db.ProcedureTable("DBO.CREARFACTURA", true, param);
            if (dt.Rows.Count > 0)
            {
                Entities.Facturacion.Respuesta resultado = new Entities.Facturacion.Respuesta
                {
                    Codigo = Convert.ToInt32(dt.Rows[0][0]),
                    Mensaje = dt.Rows[0][1].ToString()
                };
                return resultado;
            }
            else
            {
                return null;
            }

        }
    }
}
