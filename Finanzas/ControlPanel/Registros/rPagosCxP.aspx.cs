using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Finanzas.ControlPanel.Registros
{
    public partial class rPagosCxP : System.Web.UI.Page
    {

        PagosCxP pag = new PagosCxP();
        PagoDetalle Pd = new PagoDetalle();
        public int IdCuenta = 0; //IdCuenta Pasado de SelecValue De DdICuenta
        public int IdCxP = 0;///IdCxP Pasado del SelecValue De DdIdCxP
        public int IdP = 0; /// IdPago Detalle Sacado del QueryString

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(DdIdCuenta.SelectedValue, out IdCuenta);
            int.TryParse(DdIdCxP.SelectedValue, out IdCxP);
            int.TryParse(Request.QueryString["IdPago"], out IdP);

          
            if (!IsPostBack)
            {

                if (Pd.Buscar(IdP))
                {



                    TbValorDetalle.Text = Pd.Valor.ToString();
                    DdIdCxP.SelectedIndex = Pd.IdCxP;
                    BtnGuardar.Text = "Actulizar";

                }
                else
                {
                    if (pag.Buscar(IdP))
                    {
                        TbIdPago.Text = pag.IdCobro.ToString();
                        DdIdCuenta.SelectedIndex = pag.IdCuenta;
                        TbFecha.Text = pag.Fecha.ToString("yyyy-MM-dd");
                        TbValor.Text = pag.Valor.ToString();



                        Buscar(IdP);

                    }
                }
                DdIdCuenta.DataSource = Cuentas.Lista("IdCuenta,Descripcion ", "Cuentas");
                DdIdCuenta.DataTextField = "Descripcion";
                DdIdCuenta.DataValueField = "IdCuenta";
                DdIdCuenta.DataBind();

                DdIdCxP.DataSource = CxP.Lista("Descripcion,IdCxP ", "CxP");
                DdIdCxP.DataTextField = "Descripcion";
                DdIdCxP.DataValueField = "IdCxP";
                DdIdCxP.DataBind();

            }

        }
        public void Buscar(int ID)
        {


            VistaGridView.DataSource = PagoDetalle.Lista("*", "PagoDetalle where IdPago =" + ID);
            VistaGridView.DataBind();

        }

       
        public void OtenerDatos()
        {

            pag.IdCuenta = IdCuenta;
            pag.Fecha = Convert.ToDateTime(TbFecha.Text);
            pag.Valor = Convert.ToDouble(TbValor.Text);
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {


            if (Session["PagoDetalle"] != null)
            {
                pag = (PagosCxP)Session["PagoDetalle"];
            }

            pag.AgregarDetalle(IdCxP, Convert.ToDouble(TbValorDetalle.Text));

            VistaGridView.DataSource = pag.pagoDetalle;
            VistaGridView.DataBind();

            Session["PagoDetalle"] = pag;
            LimpiarDetelle();
        }
        public void LimpiarDetelle()
        {
            TbIdPagoDetalle.Text = "";
            TbValorDetalle.Text = "";
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TbIdPago.Text == string.Empty)
            {


                if (Session["PagoDetalle"] != null)
                {
                    pag = (PagosCxP)Session["PagoDetalle"];
                }
                OtenerDatos();

                if (pag.Insertar())
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('PagoCxP Se Guardo Corectamente')", true);

                    Limpiar();
                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('PagoCxP No Se Pudo Guardar Corectamente )", true);
                }
            }
            else
            {

                OtenerDatos();
                Limpiar();
                if (pag.Modificar())
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('PagoCxP Se Modificada Corectamente')", true);

                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(PagoCxP No Se  Modificar Corectamente)", true);
                }


            }

        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (TbIdPago.Text == string.Empty)
            {

                if (!ClientScript.IsClientScriptBlockRegistered("script"))
                    ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('El PagoCxP No Puede Estar Vacio Para Eliminar')", true);

            }
            else
            {
                try
                {
                    if (pag.Eliminar(TbIdPago.Text))
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Se Elimino  PagoCxP Corectamente')", true);

                        Limpiar();
                    }
                    else
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('No Se  Elimino PagoCxP Corectamente')", true);
                    }
                }
                catch (Exception a)
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "altert(Este IdPago No Se Puede Eliminar Se Esta Haciendo Referencia En Otra Tabla)", true);

                }
            }

        }
        public void Limpiar()
        {
            TbIdPago.Text = "";
            TbIdPagoDetalle.Text = "";
            TbValorDetalle.Text = "";
            TbValor.Text = "";
            VistaGridView.DataSource = null;
            VistaGridView.DataBind();
        }

        protected void BtnConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ControlPanel/Consultas/fPagosCxP.aspx");
        }

        protected void TbValorDetalle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}