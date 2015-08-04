using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Finanzas.ControPanel.Registros
{
    public partial class rCxC : System.Web.UI.Page
    {
        public int IdCuenta = 0;
        public int IdCxC = 0;
        public CxC cc = new CxC();
        public Cuentas c = new Cuentas();
        public string result = "";
        public int id=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                int.TryParse(Request.QueryString["IdCxC"], out IdCxC);

                if (cc.Buscar(IdCxC))
                {
                    TbIdCxC.Text = cc.IdCxC.ToString();
                    DdIdCuenta.SelectedIndex = cc.IdCuenta;
                    TbFecha.Text = cc.Fecha.ToString("yyyy-MM-dd");
                    TbValor.Text = cc.Valor.ToString();
                    TbBalance.Text = cc.Balance.ToString();
                    TbDescripcion.Text = cc.Descripcion;
                  
                    BtnGuardar.Text = "Actualizar";



                }
            }
            if (c.Buscar(1))
            {
                TbBalance.Text = c.Balance.ToString();

            }
           
 
            DdIdCuenta.DataSource = Cuentas.Lista("IdCuenta,Descripcion", "Cuentas");
            DdIdCuenta.DataTextField = "Descripcion";
            DdIdCuenta.DataValueField = "IdCuenta";
        //    DdIdCuenta.Items.FindByValue(result).Selected = true;
            DdIdCuenta.DataBind();
        }
      
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TbIdCxC.Text == string.Empty)
            {

                ObtenerDatos();


                if (cc.Insertar())
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Cuenta Por Cobrar Se Guardo Corectamente')", true);

                    Limpiar(); 


                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('No Cuenta Por Cobrar Se Pudo Guardar Corectamente )", true);
                }
            }

            else
            {

                ObtenerDatos();

                if (cc.Modificar(TbIdCxC.Text))
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Cuenta Por Cobrar Se Modificada Corectamente')", true);


                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(Cuenta Por Cobar No Se  Modificar Corectamente)", true);
                }
            }
        }
        public void ObtenerDatos()
        {
            cc.IdCuenta = IdCuenta;
            cc.Fecha = Convert.ToDateTime(TbFecha.Text);
            cc.Valor = Convert.ToDouble(TbValor.Text);
            cc.Balance = Convert.ToDouble(TbBalance.Text);
            cc.Descripcion = TbDescripcion.Text;
        }
        public void Limpiar(){

            TbIdCxC.Text="";
            TbValor.Text = "";
            TbDescripcion.Text = "";
            TbBalance.Text = "";
            
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TbIdCxC.Text == string.Empty)
                {

                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('El IdCxC No Puede Estar Vacio Para Eliminar')", true);

                }
                else
                {
                    if (cc.Eliminar(TbIdCxC.Text))
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Cuenta Por Cobrar Se Eliminada Corectamente')", true);

                        Limpiar();
                    }
                    else
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Cuenta Por Cobar No Se  Eliminar Cuenta Corectamente')", true);
                    }
                }
            }
            catch (Exception)
            {
                
              if (!ClientScript.IsClientScriptBlockRegistered("script"))
                    ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(No Se Puede Eliminar Esta Cuenta Porque Esta Haciendeo Referencia En Otro Tabla)", true);
            }
           
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BtnConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ControlPanel/Consultas/fCxC.aspx");
        }

        protected void DdIdCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
           result = DdIdCuenta.SelectedValue.ToString();
           int.TryParse(result, out IdCuenta);
            
        }

        
    }
}