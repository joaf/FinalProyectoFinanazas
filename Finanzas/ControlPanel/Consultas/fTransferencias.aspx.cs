using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Finanzas.ControlPanel.Consultas
{
    public partial class fTransferencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void BtnConsulta_Click(object sender, EventArgs e)
        {
            GridViewVista.DataSource = Transferencias.Lista("*", "Transferencias Where " + Tipo() + " like'" + TbBuscar.Text + "%'");
            GridViewVista.DataBind();
        }
        public string Tipo()
        {
            string tipo = "";
            if (TipoDropDownList.SelectedIndex == 0)
            {

                tipo = "IdTransferencia";

            }
            else
                if (TipoDropDownList.SelectedIndex == 1)
                {
                    tipo = "Fecha";

                }
                else
                    if (TipoDropDownList.SelectedIndex == 2)
                    {
                        tipo = "IdCuentaOrigen";
                    }
                    else
                        if (TipoDropDownList.SelectedIndex == 0)
                        {

                            tipo = "IdCuentaDestino";

                        }
                        else
                            if (TipoDropDownList.SelectedIndex == 1)
                            {
                                tipo = "Descripcion";

                            }
                            else
                                if (TipoDropDownList.SelectedIndex == 2)
                                {
                                    tipo = "Valor";
                                }
            return tipo;
        }
    }
}