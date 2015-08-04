using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Finanzas.ControPanel.Registros
{
    public partial class rTransferencias : System.Web.UI.Page
    {
        public int IdOrigen = 0;
        public int IdDestino = 0;
        public int IdTransferencia = 0;
        public Transferencias tran = new Transferencias();
        protected void Page_Load(object sender, EventArgs e)
        {

            int.TryParse(DdIdCuentaDestion.SelectedValue, out IdDestino);
            int.TryParse(DdIdCuentaOrigen.SelectedValue, out IdOrigen);
            if (!IsPostBack)
            {


                int.TryParse(Request.QueryString["IdTransferencia"], out IdTransferencia);

                if (tran.Buscar(IdTransferencia))
                {
                    TbIdTransferencia.Text = IdTransferencia.ToString();
                    DdIdCuentaOrigen.SelectedIndex = tran.IdCuentaOrigen;
                    DdIdCuentaDestion.SelectedIndex = tran.IdCuentaDestino;
                    TbFecha.Text = tran.Fecha.ToString("yyyy-MM-dd");
                    TbValor.Text = tran.Valor.ToString();
                    TbDescripcion.Text = tran.Descripcion;

                    BtnGuardar.Text = "Actualizar";



                }
            }
            DdIdCuentaDestion.DataSource = Cuentas.Lista("IdCuenta,Descripcion", "Cuentas");
            DdIdCuentaDestion.DataTextField = "Descripcion";
            DdIdCuentaDestion.DataValueField = "IdCuenta";
            DdIdCuentaDestion.DataBind();

            DdIdCuentaOrigen.DataSource = Cuentas.Lista("IdCuenta,Descripcion", "Cuentas");
            DdIdCuentaOrigen.DataTextField = "Descripcion";
            DdIdCuentaOrigen.DataValueField = "IdCuenta";
            DdIdCuentaOrigen.DataBind();


        }
        
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TbIdTransferencia.Text == string.Empty)
            {

                ObtenerDatos();


                if (tran.Insertar())
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Transferencia Se Guardo Corectamente')", true);



                    tran.TransferenciaDestino(IdDestino, Convert.ToInt32(TbValor.Text));

                    tran.TransferenciaOrigen(IdOrigen, Convert.ToInt32(TbValor.Text));
                    Limpiar();
                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Transferencia No Se Pudo Guardar Corectamente )", true);
                }
            }

            else
            {

                ObtenerDatos();

                if (tran.Modificar(TbIdTransferencia.Text))
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Transferencia Se Modificada Corectamente')", true);


                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(Transferencia No Se  Modificar Corectamente)", true);
                }
            }
        }
        public void ObtenerDatos()
        {
            tran.Fecha = Convert.ToDateTime(TbFecha.Text);
            tran.IdCuentaOrigen = IdOrigen;
            tran.IdCuentaDestino = IdDestino;
            tran.Descripcion = TbDescripcion.Text;
            tran.Valor = Convert.ToInt32(TbValor.Text);
        }
        public void Limpiar()
        {
            TbIdTransferencia.Text = "";
            TbValor.Text = "";
            TbDescripcion.Text = "";
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TbIdTransferencia.Text == string.Empty)
                {

                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('El IdTransferencia No Puede Estar Vacio Para Eliminar')", true);

                }
                else
                {
                    if (tran.Eliminar(TbIdTransferencia.Text))
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Transferencia Se Eliminada Corectamente')", true);

                        Limpiar();
                    }
                    else
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Transferencia No Se  Eliminar  Corectamente')", true);
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

        protected void BtnConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ControlPanel/Consultas/fTransferencias.aspx");
        }
    }
}