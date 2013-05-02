using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/*
 * Web:          AndresVergara's Blog.
 * Autor:        G. Andres Vergara Rojas.
 * Contacto:     andresvergara.cl@gmail.com
 * Fecha:        Mayo 2012
 */

namespace _3Capas.DAL
{
    public class ConexionSqlServer: Conexion
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataAdapter adaptador;

        // metodo que instancia los objetos de conexion
        protected void conectar()
        {
            try
            {
                conexion = new SqlConnection(cadena_conexion);
                comando = new SqlCommand();
                comando.Connection = conexion;
                adaptador = new SqlDataAdapter();
            }
            catch { }
        }

        // consulta basica select, update o delete
        public string select(string consulta)
        {
            try
            {
                conectar();
                comando.CommandText = consulta;
                comando.CommandTimeout = timeout;
                conexion.Open();
                Object reader = comando.ExecuteScalar();

                if (reader != null)
                {
                    conexion.Close();
                    conexion.Dispose();
                    if (reader.ToString() == "1") return "OK";
                    else return "ERROR";
                }
                else
                {
                    conexion.Close();
                    conexion.Dispose();
                    return "ERROR CONEXION";
                }
            }
            catch { return null; }
        }

        // retorna un select en forma de datatable
        public DataTable select_dt(string sql)
        {
            try
            {
                conectar();          
                DataTable dt = new DataTable();
                comando.CommandText = sql;
                comando.CommandTimeout = timeout;
                conexion.Open();

                adaptador.SelectCommand = comando;
                adaptador.Fill(dt);
                conexion.Close();
                comando.Dispose();

                return dt;
            }
            catch { return null; }
        } 
    }
}