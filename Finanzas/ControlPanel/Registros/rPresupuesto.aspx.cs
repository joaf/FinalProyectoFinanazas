using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Finanzas.ControlPanel.Registros
{
    public partial class rPresupuesto : System.Web.UI.Page
    {
        Presupuesto pre = new Presupuesto();
        PresupuestoDetalles Pd=new PresupuestoDetalles();
        public int IdCategoria = 0;
        public int IdPresu = 0;
        public int IdP = 0;
        public int IdDd = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(DdIdCategoria.SelectedValue, out IdCategoria);
            int.TryParse(Request.QueryString["IdPresupuesto"], out IdP);
            int.TryParse(Request.QueryString["IdPresupuestoDetalle"], out IdDd);

            if (!IsPostBack)
            {
                if (Pd.Buscar(IdDd))
                {



                    TbValor.Text = Pd.Valor.ToString();
                    DdIdCategoria.SelectedIndex = Pd.IdCategoria;
                    BtnGuardar.Text = "Actulizar";

                }
                else
                {
                    if (pre.Buscar(IdP))
                    {

                        TbFecha.Text = pre.Fecha.ToString("yyyy-MM-dd");
                        TbDescripcion.Text = pre.Descripcion;



                        Buscar(IdP);

                    }

                }

                DdIdCategoria.DataSource = Categorias.Lista("Descripcion,IdCategoria ", "Categorias");
                DdIdCategoria.DataTextField = "Descripcion";
                DdIdCategoria.DataValueField = "IdCategoria";
                DdIdCategoria.DataBind();

            }
        }
        
        public void Buscar(int ID)
        {


            VistaGridView.DataSource = PresupuestoDetalles.Lista("*", "PresupuestoDetalles where IdPresupuesto =" + ID);
            VistaGridView.DataBind();

        }
        protected void BtnSiguiente_Click(object sender, EventArgs e)
        {
             if (TbIdPresupuesto.Text == string.Empty)
            {


                if (Session["CobroDetalle"] != null)
                {
                    pre = (Presupuesto)Session["PresupuestoDetalle"];
                }
                OtenerDatos();

                if (pre.Insertar())
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Presupuesto Se Guardo Corectamente')", true);
                     VistaGridView.DataSource = null;
                     VistaGridView.DataBind();
                   Limpiar();
                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Presupuesto No Se Pudo Guardar Corectamente )", true);
                }
            }
            else
            {

                OtenerDatos();
                Limpiar();
                if (pre.Modificar())
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Presupuesto Se Modificada Corectamente')", true);

                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(Presupuesto No Se  Modificar Corectamente)", true);
                }


            
            }
        }
        public void OtenerDatos()
        {
            pre.Fecha= Convert.ToDateTime(TbFecha.Text);
            pre.Descripcion=TbDescripcion.Text;
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (TbIdPresupuesto.Text == string.Empty)
            {

                if (!ClientScript.IsClientScriptBlockRegistered("script"))
                    ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('El IdPresupuesto No Puede Estar Vacio Para Eliminar')", true);

            }
            else
            {
                try
                {
                    if (pre.Eliminar(TbIdPresupuesto.Text))
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(' Se Elimino  Presupuesto Corectamente')", true);

                        Limpiar();
                    }
                    else
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('No Se  Elimino Presupuesto Corectamente')", true);
                    }
                }
                catch (Exception a)
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "altert(Este IdPresupuesto No Se Puede Eliminar Se Esta Haciendo Referencia En Otra Tabla)", true);

                }

            }
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        public void LimpiarDetalle()
        {
            TbIdPresupuestoDetalle.Text = "";
            TbValor.Text = "";

        }
        public void Limpiar()
        {
            TbIdPresupuesto.Text = "";
            TbIdPresupuestoDetalle.Text = "";
            TbValor.Text = "";
            TbDescripcion.Text = "";
            VistaGridView.DataSource = null;
            VistaGridView.DataBind();
            
        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (Session["PresupuestoDetalle"] != null)
            {
                pre = (Presupuesto)Session["PresupuestoDetalle"];
            }

            pre.AgregarDetalle(IdCategoria, Convert.ToDouble(TbValor.Text));

            VistaGridView.DataSource = pre.presupuestoDetalle;
            VistaGridView.DataBind();

            Session["PresupuestoDetalle"] = pre;
            LimpiarDetalle();
        }
    }
}