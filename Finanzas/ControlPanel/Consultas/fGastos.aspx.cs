using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Finanzas.ControlPanel.Consultas
{
    public partial class fGastos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnConsulta_Click(object sender, EventArgs e)
        {
            GridViewVista.DataSource = Gastos.Lista("*", "Gastos Where " + Tipo() + " like'" + TbBuscar.Text + "%'");
            GridViewVista.DataBind();
        }
        public string Tipo()
        {
            string tipo = "";
            if (TipoDropDownList.SelectedIndex == 0)
            {

                tipo = "IdGasto";

            }
            else
                if (TipoDropDownList.SelectedIndex == 1)
                {
                    tipo = "IdCuenta";

                }
                else
                    if (TipoDropDownList.SelectedIndex == 2)
                    {
                        tipo = "IdCategoria";
                    }
                    else
                        if (TipoDropDownList.SelectedIndex == 0)
                        {

                            tipo = "Fecha";

                        }
                        else
                            if (TipoDropDownList.SelectedIndex == 1)
                            {
                                tipo = "Valor";

                            }
                            else
                                if (TipoDropDownList.SelectedIndex == 2)
                                {
                                    tipo = "Descripcion";
                                }
            return tipo;
        }
    }
}