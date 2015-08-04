using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BLL;
using System.Security;


namespace Finanzas
{
    public partial class LogOn : System.Web.UI.Page
    {
       Usuarios us = new Usuarios();
        public static string  Usu;
        public static string Cont;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logon_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/rUsuarios.aspx");
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            if (us.BuscarUsu(TbUsuario.Text, TbContra.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(TbUsuario.Text, recordarme.Checked);
                Session["Usuario"] = TbUsuario.Text;
                Usu = TbUsuario.Text;
                Cont = TbContra.Text;
            }
            else
            {
                Msg.Text = " Usuario O Contraceña INVALIDA. Intentelo de Nuevo.";
            }
        }
    
    }
}