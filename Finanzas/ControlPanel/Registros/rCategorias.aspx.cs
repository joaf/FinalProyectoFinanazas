using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Finanzas
{
    public partial class rCategorias : System.Web.UI.Page
    {
        Categorias cat = new Categorias();
        int IdCategoria=0;
        public  string a="";
       

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {


                int.TryParse(Request.QueryString["IdCategoria"], out IdCategoria);

                if (cat.Buscar(IdCategoria))
                {


                    TbIdCategoria.Text = (IdCategoria).ToString();
                    TbDescripcion.Text = cat.Descripcion;
                    TbTipo.Text = cat.Tipo.ToString();
                    BtnGuardar.Text = "Actualizar";
                   
                    

                }
            }
        }


     


        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (TbIdCategoria.Text == string.Empty)
            {



                cat.Descripcion = TbDescripcion.Text;
                cat.Tipo = Convert.ToInt32(TbTipo.Text);

                if (cat.Insertar())
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Categoria Se Guardo Corectamente')", true);

                    Limpiar(); 
                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Categoria No Se Pudo Guardar Corectamente )", true);
                }
            }

            else
            {

                cat.Descripcion = TbDescripcion.Text;
                cat.Tipo = Convert.ToInt32(TbTipo.Text);

                if (cat.Modificar(TbIdCategoria.Text))
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Categoria Se Modificada Corectamente')", true);
                    Limpiar(); 
                }
                else
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert( Categoria No Se  Modificar Corectamente)", true);
                }
            }

        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(); 
        }
        public void Limpiar()
        {
            TbDescripcion.Text = "";
            TbIdCategoria.Text = "";
            TbTipo.Text = "";
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (TbIdCategoria.Text == string.Empty)
            {

                if (!ClientScript.IsClientScriptBlockRegistered("script"))
                    ClientScript.RegisterStartupScript(this.GetType(), "script","alert('El IdCategoria No Puede Estar Vacio Para Eliminar')", true);
                
            }
            else
            {
                try
                {
                    if (cat.Eliminar(TbIdCategoria.Text))
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('Cateroria Se Eliminada Corectamente')", true);

                        Limpiar();
                    }
                    else
                    {
                        if (!ClientScript.IsClientScriptBlockRegistered("script"))
                            ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('No Se  Eliminar Categoria Corectamente')", true);
                    }
                }
                catch (Exception a)
                {
                    if (!ClientScript.IsClientScriptBlockRegistered("script"))
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert(No Se Puede Eliminar Esta IdCategoria Porque Esta Haciendeo Referencia En Otro Tabla)", true);
                  
                }
               
            }
        }

        protected void BtnConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ControlPanel/Consultas/fCategorias.aspx");
        }
    }
}