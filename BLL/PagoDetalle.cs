using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class PagoDetalle
    {
       
        public int IdCxP { get; set; }
        public Double Valor { get; set; }
        public Conexion ConexiondB =new Conexion();

        public PagoDetalle(int IdCxP, double Valor)
        {
            this.IdCxP = IdCxP;
            this.Valor = Valor;
        }
        public PagoDetalle()
        {
            IdCxP = 0;
            Valor = 0;
        }
        public bool Buscar(int Id)
        {
            bool mesj = false;
            DataTable dt = new DataTable();
            dt = ConexiondB.BuscarDb("Select *from PagoDetalle where IdPago=" + Id);
            if (dt.Rows.Count > 0)
            {

                IdCxP = (int)dt.Rows[0]["IdCxP"];
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
