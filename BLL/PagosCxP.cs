using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
   public  class PagosCxP
    {
        public int IdPago { get; set; }
        public int IdCobro { get; set; }
        public int IdCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public double Valor { get; set; }
        public List<PagoDetalle> pagoDetalle { get; set; }

        public PagosCxP(int IdCuenta,DateTime Fecha,double Valor)
        {
            this.IdCobro=IdCobro;
            this.Fecha = Fecha;
            this.Valor = Valor;
            pagoDetalle = new List<PagoDetalle>();
        }
        public PagosCxP()
        {
            IdCobro = 0;
            Fecha = DateTime.Now;
            Valor = Valor;
            pagoDetalle = new List<PagoDetalle>();
        }
         public Conexion ConexiondB = new Conexion();

         public bool Insertar()
         {
             String Comando;

             Comando = "Insert Into PagoCxP(IdCuenta,Fecha,Valor)Values('" + this.IdCuenta + "','" + this.Fecha.ToString("MM/dd/yyyy") + "','" + this.Valor + "')";

             foreach (PagoDetalle pag in pagoDetalle)
             {
                 Comando += "Insert Into PagoDetalle(IdPago,IdCxP,Valor)Values(@@IDENTITY,'" + pag.IdCxP + "','" + pag.Valor + "')";
             }


             return ConexiondB.EjecutarDB(Comando);
         }
         public void AgregarDetalle( int IdCxP, double Valor)
         {

             this.pagoDetalle.Add(new PagoDetalle( IdCxP, Valor));
         }
         public bool Modificar()
         {
             String Comando;

             Comando = "Update PagoCxP set IdCuenta='" + this.IdCuenta + "',Fecha ='" + this.Fecha.ToString("MM/dd/yyyy") + "',Valor='" + this.Valor + "'where IdCobro='" + this.IdCobro + "' ";

             ConexiondB.EjecutarDB("Delete PagoCxP where IdPago=" + this.IdPago);

             foreach (PagoDetalle pag in pagoDetalle)
             {
                 Comando += "Insert Into PagoDetalle(IdPago,IdCxP,Valor)Values('" + this.IdPago + "','" + pag.IdCxP + "','" + pag.Valor + "')";
             }

             return ConexiondB.EjecutarDB(Comando);
         }
       public bool Eliminar(string Id)
       {
           return ConexiondB.EjecutarDB("Delete from PagoCxP where IdPago=" + Id);
       }
       public bool Buscar(int Id)
       {
           bool mesj = false;
           DataTable dt = new DataTable();
           dt = ConexiondB.BuscarDb("Select *from PagoCxP where IdPago=" + Id);
           if (dt.Rows.Count > 0)
           {
               IdCobro = (int)dt.Rows[0]["IdPago"];
               IdCuenta = (int)dt.Rows[0]["IdCuenta"];
               Fecha = (DateTime)dt.Rows[0]["Fecha"];
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
