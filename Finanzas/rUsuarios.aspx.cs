using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;


namespace Finanzas.ControPanel.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        Usuarios usus = new Usuarios();
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TbIdUsuario.Text == string.Empty)
            {

                OtenerDatos();


                if (usus.Insertar())
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Usuario Se Guardo Corectamente')", true);

                    Limpiar();

                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Usuario No Se Pudo Guardar Corectamente )", true);
                }
            }

            else
            {

                OtenerDatos();

                if (usus.Modificar(TbIdUsuario.Text))
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Usuario Se Modificada Corectamente')", true);


                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(Usuario No Se  Modificar Corectamente)", true);
                }
            }
        }
        public void OtenerDatos()
        {
            usus.Usuario = TbUsuario.Text;
            usus.Clave = TbContraceña.Text;
            usus.Email = TbEmail.Text;
        }
        public void Limpiar()
        {
            TbIdUsuario.Text = "";
            TbUsuario.Text = "";
            TbContraceña.Text = "";
            TbEmail.Text = "";

        }
        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TbIdUsuario.Text == string.Empty)
                {

                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('El IdUsuario No Puede Estar Vacio Para Eliminar')", true);

                }
                else
                {
                    if (usus.Eliminar(TbIdUsuario.Text))
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Usuario Se Eliminada Corectamente')", true);

                        Limpiar();
                    }
                    else
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Usuario No Se  Eliminar  Corectamente')", true);
                    }
                }
            }
            catch (Exception)
            {
                if (!ClientScript.IsClientScriptBlockRegistered("script"))
                    ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(No Se Puede Eliminar Esta IdIngreso Porque Esta Haciendeo Referencia En Otro Tabla)", true);
                
            }
           
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BtnLimpiar_Click1(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
