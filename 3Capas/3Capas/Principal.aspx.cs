using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _3Capas.BLL;

namespace _3Capas
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {      
            
        }

        protected void boton_buscar_Click(object sender, EventArgs e)
        {
            Negocio bll = new Negocio();
            gv_principal.DataSource = bll.obtenerDatos();
            gv_principal.DataBind();
        }
    }
}