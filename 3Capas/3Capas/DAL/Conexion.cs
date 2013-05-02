/*
 * Web:          AndresVergara's Blog.
 * Autor:        G. Andres Vergara Rojas.
 * Contacto:     andresvergara.cl@gmail.com
 * Fecha:        Mayo 2012
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace _3Capas.DAL
{
    public class Conexion
    {
        
        protected string tipo_conexion;
        protected string cadena_conexion;
        protected int timeout;

        public Conexion()
        {
            tipo_conexion = System.Configuration.ConfigurationManager.ConnectionStrings["TIPO_CONEXION"].ToString();
            timeout = 500;
            cadena_conexion = conector(tipo_conexion);
        }

        protected  string conector(string tipo)
        {
            if (tipo == "oracle")
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["ConOracle"].ToString();
            }
            if (tipo == "sqlserver")
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["ConSqlServer"].ToString();
            }
            else
            {
                return "";
            }
        }

        protected string select(string consulta)
        {
            if (tipo_conexion == "oracle")
            {
                ConexionOracle oracle = new ConexionOracle();
                return oracle.select(consulta);
            }
            else if (tipo_conexion == "sqlserver")
            {
                ConexionSqlServer sqlserver = new ConexionSqlServer();
                return sqlserver.select(consulta);
            }
            else {
                return null;            
            }
        }

        protected DataTable select_dt(string consulta)
        {
            if (tipo_conexion == "oracle")
            {
                ConexionOracle oracle = new ConexionOracle();
                return oracle.select_dt(consulta);
            }
            else if (tipo_conexion == "sqlserver")
            {
                ConexionSqlServer sqlserver = new ConexionSqlServer();
                return sqlserver.select_dt(consulta);
            }
            else
            {
                return null;
            }
        }
    }
}