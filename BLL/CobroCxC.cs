using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class CobroCxC
    {
        public int IdCobro { get; set; }
        public int IdCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public double Valor { get; set; }
        public List<CobroDetalle> cobroDetalle { get; set; }


        public CobroCxC(int IdCuenta,DateTime Fecha,double Valor)
        {
           
            this.IdCuenta=IdCuenta;
            this.Fecha = Fecha;
            this.Valor = Valor;
            cobroDetalle = new List<CobroDetalle>();

        }
        public CobroCxC()
        {
            IdCobro = 0;
            IdCuenta = 0;
            Fecha = DateTime.Now;
            Valor = Valor;
            cobroDetalle = new List<CobroDetalle>();

        }
         public Conexion ConexiondB = new Conexion();

         public bool Insertar()
         {
             String Comando;

             Comando = "Insert Into CobroCxC(IdCuenta,Fecha,Valor)Values('" + this.IdCuenta + "','" + this.Fecha.ToString("MM/dd/yyyy") + "','" + this.Valor + "')";
          
             foreach (CobroDetalle cob in cobroDetalle)
             {
                 Comando += "Insert Into CobroDetalle(IdCobro,IdCxC,Valor)Values(Values(@@IDENTITY,'" + cob.IdCxC + "','" + cob.Valor + "')";
             }


             return ConexiondB.EjecutarDB(Comando);
         }
         public void AgregarDetalle(int IdCxC, double Valor)
         {

             this.cobroDetalle.Add(new CobroDetalle(IdCxC,Valor));
         }
        
       public bool Modificar()
       {
           String Comando;

           Comando = "Update CobroCxC set IdCuenta='" + this.IdCuenta + "',Fecha ='" + this.Fecha.ToString("MM/dd/yyyy") + "',Valor='" + this.Valor + "'where IdCobro='" + this.IdCobro + "' ";

           ConexiondB.EjecutarDB("Delete CobroCxC where IdCobro=" + this.IdCobro);

           foreach (CobroDetalle cob in cobroDetalle)
           {
               Comando += "Insert Into CobroDetalle(IdCobro,IdCxC,Valor)Values('" +this.IdCobro +"','" + cob.IdCxC + "','" + cob.Valor + "')";
           }

           return ConexiondB.EjecutarDB(Comando);
       }

       public bool Eliminar(string Id)
       {
           return ConexiondB.EjecutarDB("Delete from CobroCxC where IdCobro=" + Id);
       }

       public bool Buscar(int Id)
       {
           bool mesj = false;
           DataTable dt = new DataTable();
           dt = ConexiondB.BuscarDb("Select *from CobroCxC where IdCobro=" + Id);
           if (dt.Rows.Count > 0)
           {
               IdCobro = (int)dt.Rows[0]["IdCobro"];
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
