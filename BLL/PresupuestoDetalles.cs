using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;


namespace BLL
{
    public class PresupuestoDetalles
    {
       
        public int IdCategoria { get; set; }
        public double Valor { get; set; }
        public Conexion ConexiondB = new Conexion();

        public PresupuestoDetalles(int IdCategoria ,double Valor)
        {
            this.IdCategoria = IdCategoria;
            this.Valor = Valor;
        }
        public PresupuestoDetalles()
        {
            IdCategoria = 0;
            Valor = 0;
        }
        public bool Buscar(int Id)
        {
            bool mesj = false;
            DataTable dt = new DataTable();
            dt = ConexiondB.BuscarDb("Select *from PresupuestoDetalles where IdPresupuestoDetalle=" + Id);
            if (dt.Rows.Count > 0)
            {

                IdCategoria = (int)dt.Rows[0]["IdCategoria"];
                Valor = (double)dt.Rows[0]["Valor"];

                mesj = true;


            }
            return mesj;
        }
    

        public static DataTable Lista(String Campos, String FiltroWhere)
        {
            Conexion c = new Conexion();
            return c.BuscarDb("Select " + Campos + " from " + FiltroWhere);
        }
    }
}
