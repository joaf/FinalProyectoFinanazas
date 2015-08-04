using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Finanzas.ControPanel.Registros
{
    public partial class rIngresos : System.Web.UI.Page
    {
        public int IdCategoria = 0;
        public int IdCuenta = 0;
        public int IdIngreso = 0;
        public Ingresos ing = new Ingresos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                int.TryParse(Request.QueryString["IdIngreso"], out IdIngreso);

                if (ing.Buscar(IdIngreso))
                {
                    TbIdIngreso.Text = Convert.ToString(IdIngreso);
                    DdIdCuenta.SelectedIndex = ing.IdCuenta;
                    DdIdCategoria.SelectedIndex = ing.IdCategoria;
                    TbFecha.Text = ing.Fecha.ToString("yyyy-MM-dd");
                    TbValor.Text = ing.Valor.ToString();
                    TbDescripcion.Text = ing.Descripcion;

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
            if (TbIdIngreso.Text == string.Empty)
            {

                ObtenerDatos();


                if (ing.Insertar())
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Ingreso Se Guardo Corectamente')", true);



                    ing.CuentaSuma(IdCuenta, Convert.ToInt32(TbValor.Text));
                    Limpiar();
                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Ingreso No Se Pudo Guardar Corectamente )", true);
                }
            }

            else
            {

                ObtenerDatos();

                if (ing.Modificar(TbIdIngreso.Text))
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Ingreso Se Modificada Corectamente')", true);


                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(Ingreso No Se  Modificar Corectamente)", true);
                }
            }
        }
        public void ObtenerDatos()
        {
            ing.IdCuenta = IdCuenta;
            ing.IdCategoria = IdCategoria;
            ing.Fecha = Convert.ToDateTime(TbFecha.Text);
            ing.Valor = Convert.ToDouble(TbValor.Text);
            ing.Descripcion = TbDescripcion.Text;

        }
        public void Limpiar()
        {
            TbIdIngreso.Text = "";
            TbValor.Text = "";
            TbDescripcion.Text = "";
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TbIdIngreso.Text == string.Empty)
                {

                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('El IdIngreso No Puede Estar Vacio Para Eliminar')", true);

                }
                else
                {
                    if (ing.Eliminar(TbIdIngreso.Text))
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Ingreso Se Eliminada Corectamente')", true);

                        Limpiar();
                    }
                    else
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Ingreso No Se  Eliminar  Corectamente')", true);
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
            Response.Redirect("/ControlPanel/Consultas/fIngresos.aspx");
        }

    }
}
