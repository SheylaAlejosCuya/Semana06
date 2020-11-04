using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DProducto
    {
        public List<Producto> Listar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            List<Producto> productos = null;

            try
            {
                commandText = "USP_GetProducto";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto", System.Data.SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                productos = new List<Producto>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, commandText,
                    System.Data.CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            IdProducto = reader["idproducto"] != null ? Convert.ToInt32(reader["idproducto"]) : 0,
                            NombreProducto = reader["nombreProducto"] != null ? Convert.ToString(reader["nombreProducto"]) : string.Empty,
                            CantidadPorUnidad = reader["cantidadPorUnidad"] != null ? Convert.ToString(reader["cantidadPorUnidad"]) : string.Empty,
                            PrecioUnidad = reader["precioUnidad"] != null ? Convert.ToInt32(reader["precioUnidad"]) : 0
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productos;
        }

        public void Insertar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;

            try
            {
                commandText = "USP_InsProducto";
                parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@nombre", System.Data.SqlDbType.VarChar);
                parameters[0].Value = producto.NombreProducto;
                parameters[1] = new SqlParameter("@cantidad", System.Data.SqlDbType.VarChar);
                parameters[1].Value = producto.CantidadPorUnidad;
                parameters[2] = new SqlParameter("@precio", System.Data.SqlDbType.Int);
                parameters[2].Value = producto.PrecioUnidad;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, commandText, System.Data.CommandType.StoredProcedure, parameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;

            try
            {
                commandText = "USP_UdpProducto";
                parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@idproducto", System.Data.SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                parameters[1] = new SqlParameter("@nombre", System.Data.SqlDbType.VarChar);
                parameters[1].Value = producto.NombreProducto;
                parameters[2] = new SqlParameter("@cantidad", System.Data.SqlDbType.VarChar);
                parameters[2].Value = producto.CantidadPorUnidad;
                parameters[3] = new SqlParameter("@precio", System.Data.SqlDbType.Int);
                parameters[3].Value = producto.PrecioUnidad;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, commandText, System.Data.CommandType.StoredProcedure, parameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(int IdProducto)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;

            try
            {
                commandText = "USP_DelProducto";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto", System.Data.SqlDbType.Int);
                parameters[0].Value = IdProducto;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, commandText, System.Data.CommandType.StoredProcedure, parameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
