using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Finanzas
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                btnInicio.Text = "Cerrar Sesion";
                Labelusu.Text = LogOn.Usu;
            }
            else
            {

                Labelusu.Text = "Desconectado";
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogOn.aspx");
          
        }
    }
}