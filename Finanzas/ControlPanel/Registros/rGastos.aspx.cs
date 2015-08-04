using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Finanzas.ControPanel.Registros
{
    public partial class rGastos : System.Web.UI.Page
    {
        public int IdCategoria = 0;
        public int IdCuenta = 0;
        public int IdGasto=0;
        public Gastos gas = new Gastos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                int.TryParse(Request.QueryString["IdGasto"], out IdGasto);

                if (gas.Buscar(IdGasto))
                {
                    TbIdGasto.Text = Convert.ToString(IdGasto);
                    DdIdCuenta.SelectedIndex = gas.IdCuenta;
                    DdIdCategoria.SelectedIndex = gas.IdCategoria;
                    TbFecha.Text = gas.Fecha.ToString("yyyy-MM-dd");
                    TbValor.Text = gas.Valor.ToString();
                    TbDescripcion.Text = gas.Descripcion;

                    BtnGuardar.Text = "Actualizar";



                }
            }
            int.TryParse(DdIdCategoria.SelectedValue, out IdCategoria);
            int.TryParse(DdIdCuenta.SelectedValue, out IdCuenta);
            DdIdCategoria.DataSource = Categorias.Lista("IdCategoria,Descripcion", "Categorias");
            DdIdCategoria.DataTextField = "Descripcion";
            DdIdCategoria.DataValueField = "IdCategoria";
            DdIdCategoria.DataBind();

            DdIdCuenta.DataSource = Cuentas.Lista("IdCuenta,Descripcion", "Cuentas");
            DdIdCuenta.DataTextField = "Descripcion";
            DdIdCuenta.DataValueField = "IdCuenta";
            DdIdCuenta.DataBind();


        }
       
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TbIdGasto.Text == string.Empty)
            {

                ObtenerDatos();


                if (gas.Insertar())
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Gasto Se Guardo Corectamente')", true);

                  
                    gas.CuentaResta(IdCuenta, Convert.ToInt32(TbValor.Text));
                    Limpiar(); 
                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Gasto No Se Pudo Guardar Corectamente )", true);
                }
            }

            else
            {

                ObtenerDatos();

                if (gas.Modificar(TbIdGasto.Text))
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Gasto Se Modificada Corectamente')", true);


                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(Cuenta No Se  Modificar Corectamente)", true);
                }
            }
        }
        public void ObtenerDatos()
        {
            gas.IdCuenta = IdCuenta;
            gas.IdCategoria = IdCategoria;
            gas.Fecha = Convert.ToDateTime(TbFecha.Text);
            gas.Valor = Convert.ToDouble(TbValor.Text);
            gas.Descripcion = TbDescripcion.Text;

        }
        public void Limpiar()
        {
            TbIdGasto.Text = "";
            TbDescripcion.Text = "";
            TbValor.Text = "";
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TbIdGasto.Text == string.Empty)
                {

                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('El IdGasto No Puede Estar Vacio Para Eliminar')", true);

                }
                else
                {
                    if (gas.Eliminar(TbIdGasto.Text))
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Gasto Se Eliminada Corectamente')", true);

                        Limpiar();
                    }
                    else
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Gasto No Se  Eliminar  Corectamente')", true);
                    }
                }
            }
            catch (Exception)
            {

                if (!ClientScript.IsClientScriptBlockRegistered("script"))
                    ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(No Se Puede Eliminar Esta IdGasto Porque Esta Haciendeo Referencia En Otro Tabla)", true);
            }
           
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BtnConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ControlPanel/Consultas/fGastos.aspx");
        }

        

    }
}