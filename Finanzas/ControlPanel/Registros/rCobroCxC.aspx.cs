using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Finanzas
{
    public partial class rCobroCxC : System.Web.UI.Page
    {
        CobroCxC Cob = new CobroCxC();
        CobroDetalle Cd = new CobroDetalle();
        public int IdCuenta = 0;
        public int IdCobro = 0;
        public int IdCxC = 0;
        public int IdC = 0;
        public int IdD = 0;
        public int IdDC = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(DdIdCuenta.SelectedValue, out IdCuenta);
            int.TryParse(DdIdCxC.SelectedValue, out IdCxC);
            if (!IsPostBack)
            {
                int.TryParse(Request.QueryString["IdCobro"], out IdC);
                int.TryParse(Request.QueryString["IdCobroDetalle"], out IdD);

                if (Cd.Buscar(IdD))
                {



                    TbValorDetalle.Text = Cd.Valor.ToString();
                    DdIdCxC.SelectedIndex = Cd.IdCxC;
                    BtnGuardar.Text = "Actulizar";

                }
                else
                {
                    if (Cob.Buscar(IdC))
                    {
                        TbIdCobro.Text = Cob.IdCobro.ToString();
                        DdIdCuenta.SelectedIndex = Cob.IdCuenta;
                        TbFecha.Text = Cob.Fecha.ToString("yyyy-MM-dd");
                        TbValor.Text = Cob.Valor.ToString();



                        Buscar(IdC);

                    }
                }
               
            }
                DdIdCuenta.DataSource = Cuentas.Lista("IdCuenta,Descripcion ", "Cuentas");
                DdIdCuenta.DataTextField = "Descripcion";
                DdIdCuenta.DataValueField = "IdCuenta";
                DdIdCuenta.DataBind();

                DdIdCxC.DataSource = CxC.Lista("Descripcion,IdCxC ", "CxC");
                DdIdCxC.DataTextField = "Descripcion";
                DdIdCxC.DataValueField = "IdCxC";
                DdIdCxC.DataBind();


            
        }
        public void Buscar(int ID)
        {
            

            VistaGridView.DataSource = CobroDetalle.Lista("*", "CobroDetalle where IdCobro =" + ID);
            VistaGridView.DataBind();
            
        }

        protected void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (TbIdCobro.Text == string.Empty)
            {


                if (Session["CobroDetalle"] != null)
                {
                    Cob = (CobroCxC)Session["CobroDetalle"];
                }
                OtenerDatos();

                if (Cob.Insertar())
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('CobroCxC Se Guardo Corectamente')", true);

                    Limpiar();
                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('CobroCxC No Se Pudo Guardar Corectamente )", true);
                }
            }
            else
            {

                OtenerDatos();
                Limpiar();
                if (Cob.Modificar())
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('CobroCxC Se Modificada Corectamente')", true);

                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(CobroCxC No Se  Modificar Corectamente)", true);
                }


            }

        }
        public void OtenerDatos()
        {

            Cob.IdCuenta = IdCuenta;
            Cob.Fecha = Convert.ToDateTime(TbFecha.Text);
            Cob.Valor = Convert.ToDouble(TbValor.Text);
            
        }
        public void Limpiar()
        {
            TbIdCobro.Text = "";
            TbIdCobroDetalle.Text = "";
            TbValorDetalle.Text = "";
            TbValor.Text = "";
            VistaGridView.DataSource = null;
            VistaGridView.DataBind();
        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {


            if (Session["CobroDetalle"] != null)
            {
                Cob = (CobroCxC)Session["CobroDetalle"];
            }

            Cob.AgregarDetalle(IdCxC, Convert.ToDouble(TbValorDetalle.Text));

            VistaGridView.DataSource = Cob.cobroDetalle;
            VistaGridView.DataBind();

            Session["CobroDetalle"] = Cob;

            LimpiarDetalle();
        }
        public void LimpiarDetalle()
        {
            TbIdCobroDetalle.Text = "";
            TbValorDetalle.Text = "";
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (TbIdCobro.Text == string.Empty)
            {

                if (!ClientScript.IsClientScriptBlockRegistered("script"))
                    ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('El IdCobro No Puede Estar Vacio Para Eliminar')", true);

            }
            else
            {
                try
                {
                    if (Cob.Eliminar(TbIdCobro.Text))
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(' Se Elimino  CobroCxC Corectamente')", true);

                        Limpiar();
                    }
                    else
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('No Se  Elimino CobroCxC Corectamente')", true);
                    }
                }
                catch (Exception a)
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "altert(Este IdCobroDetalle No Se Puede Eliminar Se Esta Haciendo Referencia En Otra Tabla)", true);

                }

            }
        }

        protected void BtnConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ControlPanel/Consultas/fCobrosCxC.aspx");
        }
    }
}