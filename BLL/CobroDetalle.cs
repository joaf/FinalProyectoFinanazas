using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
  public  class CobroDetalle
    {
        public int IdCxC { get; set; }
        public double Valor { get; set; }
        Conexion ConexiondB = new Conexion();
        public CobroDetalle( int IdCxC, double Valor)
        {
           
            this.IdCxC = IdCxC;
            this.Valor = Valor;
        }
        public CobroDetalle()
        {
            IdCxC = 0;
            Valor = 0;
        }
        public bool Buscar(int Id)
        {
            bool mesj = false;
            DataTable dt = new DataTable();
            dt = ConexiondB.BuscarDb("Select *from CobroDetalle where IdCobro=" + Id);
            if (dt.Rows.Count > 0)
            {
              
                IdCxC = (int)dt.Rows[0]["IdCxC"];
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
