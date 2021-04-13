using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoFacturacion.Facturacion
{
    public class DEditarProducto
    {
        private readonly IConfiguration configuration;
        public DEditarProducto(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public Entities.Facturacion.Respuesta respuesta(Entities.Facturacion.EditarProducto crear)
        {
            SqlParameter[] param = new SqlParameter[]

            {

               new SqlParameter
                {
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@ID",
                    Value = crear.IdProducto
                },
               new SqlParameter
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@NOMBRE",
                    Value = crear.Nombre
                },
               new SqlParameter
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@DESCRIPCION",
                    Value = crear.Descripcion
                },
                 new SqlParameter
                {
                    DbType = DbType.Boolean,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@DISPONIBLE",
                    Value = crear.Disponible
                },
                  new SqlParameter
                {
                    DbType = DbType.Decimal,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@PRECIOCOMPRA",
                    Value = crear.PrecioCompra
                },
                   new SqlParameter
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@PRECIOVENTA",
                    Value = crear.PrecioVenta
                },
           };
            DSQL db = new DSQL(configuration);
            DataTable dt = db.ProcedureTable("DBO.EDITARPRODUCTO", true, param);
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
