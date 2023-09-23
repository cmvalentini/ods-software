using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seguridad
{
   public  class DigitosDAL
    {
        Conexion con = new Conexion();

        

        public void ActualizarDVH(string tabla, int id, string hash)
        {
            try
            {
                var listaParams = new List<SqlParameter>();
                SqlParameter para1 = new SqlParameter("@tabla", tabla);
                para1.SqlDbType = SqlDbType.VarChar;
                SqlParameter para2 = new SqlParameter("@id", id);
                para2.SqlDbType = SqlDbType.Int;
                SqlParameter para3 = new SqlParameter("@dvh", hash);
                para3.SqlDbType = SqlDbType.VarChar;

                listaParams.Add(para1);
                listaParams.Add(para2);
                listaParams.Add(para3);
                con.Conectar();
                bool ok = con.EjecutarProcedureconListaParametros("ActualizarDVH", listaParams);
                con.Desconectar();
               
            }
            catch (Exception)
            {
               
            }

        }

        public void ActualizarDVV(string tabla, string dvv)
        {
            try
            {
                var listaParams = new List<SqlParameter>();
                SqlParameter para1 = new SqlParameter("@tabla", tabla);
                para1.SqlDbType = SqlDbType.VarChar;
                SqlParameter para2 = new SqlParameter("@dvv", dvv);
                para2.SqlDbType = SqlDbType.VarChar;

                listaParams.Add(para1);
                listaParams.Add(para2);

                bool ok = con.EjecutarProcedureconListaParametros("ActualizarDVV", listaParams);
            }
            catch (Exception)
            {
                 
            }

        }

        public DataRow BuscarRegistro(string tabla, int id)
        {
            try
            {
                var listaParams = new List<SqlParameter>();
                SqlParameter para1 = new SqlParameter("@tabla", tabla);
                para1.SqlDbType = SqlDbType.NVarChar;
                SqlParameter para2 = new SqlParameter("@id", id);
                para2.SqlDbType = SqlDbType.Int;

                listaParams.Add(para1);
                listaParams.Add(para2);

                DataTable datos = con.Selectsp("BuscarRegistro", listaParams);

                if (datos.Rows.Count == 1)
                {
                    return datos.Rows[0];
                }
                else
                {
                    //error
                    return null;
                }
            }
            catch (Exception )
            {
                throw;
            }

        }

        public string ObtenerDVV(string tabla)
        {
            try
            {
                var listaParams = new List<SqlParameter>();
                SqlParameter para1 = new SqlParameter("@tabla", tabla);
                para1.SqlDbType = SqlDbType.VarChar;
                listaParams.Add(para1);

                DataTable datos = con.Selectsp("ObtenerDVV", listaParams);
                if (datos.Rows.Count > 0)
                {
                    DataRow fila = datos.Rows[0];
                    string dvv = fila.Field<string>("DVV");
                    return dvv;
                }
                else
                {
                    //error
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }

        public DataTable ObtenerTabla(string tabla)
        {
            try
            {
                var listaParams = new List<SqlParameter>();
                SqlParameter para1 = new SqlParameter("@tabla", tabla);
                para1.SqlDbType = SqlDbType.NVarChar;
                listaParams.Add(para1);

                DataTable datos = con.Selectsp("ObtenerTabla", listaParams);
                if (datos.Rows.Count > 0)
                {
                    return datos;
                }
                else
                {
                    //error
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}

