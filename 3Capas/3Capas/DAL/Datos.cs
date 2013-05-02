using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace _3Capas.DAL
{
    public class Datos: Conexion
    {
        public DataTable obtenerDatos()
        {
            try
            {
                string sql = "exec sp_getUsuarios";
                DataTable tabla = select_dt(sql);

                if ((tabla != null) & (tabla.Rows.Count > 0))
                {
                    return tabla;
                }
                else { return null; }
                    
            }
            catch { return null; }
        }
    }
}