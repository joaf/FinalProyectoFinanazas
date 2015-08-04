using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Finanzas.ControPanel.Registros
{
    public partial class rCxP : System.Web.UI.Page
    {
        public int IdCuenta = 0;
        public int IdCxP = 0;
        public CxP cp = new CxP();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                int.TryParse(Request.QueryString["IdCxP"], out IdCxP);

                if (cp.Buscar(IdCxP))
                {
                    TbIdCxP.Text = cp.IdCxP.ToString();
                    DdIdCuenta.SelectedIndex = cp.IdCuenta;
                    TbFecha.Text = cp.Fecha.ToString("yyyy-MM-dd");
                    TbValor.Text = cp.Valor.ToString();
                    TbBalance.Text = cp.Balance.ToString();
                    TbDescripcion.Text = cp.Descripcion;

                    BtnGuardar.Text = "Actualizar";



                }
            }
            int.TryParse(DdIdCuenta.SelectedValue, out IdCuenta);
            DdIdCuenta.DataSource = Cuentas.Lista("IdCuenta,Descripcion", "Cuentas");
            DdIdCuenta.DataTextField = "Descripcion";
            DdIdCuenta.DataValueField = "IdCuenta";
            DdIdCuenta.DataBind();
        }
        
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TbIdCxP.Text == string.Empty)
            {

                ObtenerDatos();

                if (cp.Insertar())
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Cuenta Por Pagar Se Guardo Corectamente')", true);

                    Limpiar();


                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('No Cuenta Por Pagar Se Pudo Guardar Corectamente )", true);
                }
            }

            else
            {

                ObtenerDatos();
                if (cp.Modificar(TbIdCxP.Text))
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Cuenta Por Pagar Se Modificada Corectamente')", true);


                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(Cuenta Por Pagar No Se  Modificar Corectamente)", true);
                }
            }
        }
        public void ObtenerDatos()
        {
            cp.IdCuenta = IdCuenta;
            cp.Fecha = Convert.ToDateTime(TbFecha.Text);
            cp.Valor = Convert.ToDouble(TbValor.Text);
            cp.Balance = Convert.ToDouble(TbBalance.Text);
            cp.Descripcion = TbDescripcion.Text;
        }
        public void Limpiar()
        {

            TbIdCxP.Text = "";
            TbValor.Text = "";
            TbDescripcion.Text = "";
            TbBalance.Text = "";

        }
        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TbIdCxP.Text == string.Empty)
                {

                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('El IdCxP No Puede Estar Vacio Para Eliminar')", true);

                }
                else
                {
                    if (cp.Eliminar(TbIdCxP.Text))
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Cuenta Por Pagar NO Se Eliminada Corectamente')", true);

                        Limpiar();
                    }
                    else
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Cuenta Por Pagar No Se  Eliminar Cuenta Corectamente')", true);
                    }
                }
            }
            catch (Exception)
            {
                if (!ClientScript.IsClientScriptBlockRegistered("script"))
                    ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(No Se Puede Eliminar Esta CxP Porque Esta Haciendeo Referencia En Otro Tabla)", true);
            }
           
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BtnConsultas_Click(object sender, EventArgs e)
        {
           /// Response.Redirect("/ControlPanel/Consultas/fCxP.aspx");
            Response.Redirect("/ControlPanel/Consultas/fCxP.aspx");
        }

       

        
    }
}