using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Finanzas
{
    public partial class rCuentas : System.Web.UI.Page
    {
        public int IdCuenta=0;
        Cuentas c = new Cuentas();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                int.TryParse(Request.QueryString["IdCuenta"], out IdCuenta);

                if (c.Buscar(IdCuenta))
                {

                    TbIdCuenta.Text= c.IdCuenta.ToString();
                    TbDescripcion.Text = c.Descripcion;
                    TbBalence.Text= c.Balance.ToString();
                    BtnGuardar.Text = "Actualizar";
                   
                    

                }
            }
        
        }
       
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TbIdCuenta.Text == string.Empty)
            {

                OtenerDatos();


                if (c.Insertar())
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Cuenta Se Guardo Corectamente')", true);

                    Limpiar(); 
                 
                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Cuenta No Se Pudo Guardar Corectamente )", true);
                }
            }

            else
            {

                OtenerDatos();

                if (c.Modificar(TbIdCuenta.Text))
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Cuenta Se Modificada Corectamente')", true);


                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(Cuenta No Se  Modificar Corectamente)", true);
                }
            }
        }
       

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TbIdCuenta.Text == string.Empty)
                {

                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('El IdCuenta No Puede Estar Vacio Para Eliminar')", true);

                }
                else
                {
                    if (c.Eliminar(TbIdCuenta.Text))
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('No  Se Eliminada Cuenta Corectamente')", true);

                        Limpiar();
                    }
                    else
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(' No Se  Eliminar  Cuenta Corectamente')", true);
                    }
                }
            }
            catch (Exception)
            {
                if (!ClientScript.IsClientScriptBlockRegistered("script"))
                    ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(No Se Puede Eliminar Esta IdCuenta Porque Esta Haciendeo Referencia En Otro Tabla)", true);
               
            }
           
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        public void OtenerDatos()
        {
            c.Descripcion = TbDescripcion.Text;
            c.Balance = Convert.ToDouble(TbBalence.Text);
        }
        public void Limpiar()
        {
            TbIdCuenta.Text = "";
            TbDescripcion.Text = "";
            TbBalence.Text = "";
        }

        protected void BtnConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ControlPanel/Consultas/fCuentas.aspx");
        }
    }
}