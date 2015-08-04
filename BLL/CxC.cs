using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
   public  class CxC
    {
       public int IdCxC { get; set; }
       public int IdCuenta { set; get; }
       public DateTime Fecha { set; get; }
       public double Valor { set; get; }
       public double Balance { set; get; }
       public string Descripcion { set; get; }

       public CxC(int IdCuenta, DateTime Fecha, double Valor, double Balance, string Descripcion)
       {
           this.IdCuenta = IdCuenta;
           this.Fecha = Fecha;
           this.Valor = Valor;
           this.Balance = Balance;
           this.Descripcion = Descripcion;
       }
       public CxC()
       {
           IdCxC = 0;
           IdCuenta = 0;
           Fecha = DateTime.Now;
           Valor = 0;
           Balance = 0;
           Descripcion = "";
       }
       public Conexion ConexiondB = new Conexion();
       public bool Insertar()
       {
           return ConexiondB.EjecutarDB("Insert Into CxC(IdCuenta,Fecha,Valor,Balance,Descripcion)Values('" + IdCuenta + "','" + Fecha.ToString("MM/dd/yyyy") + "','" + Valor + "','" + Balance + "','" + Descripcion + "')");

       }

       public bool Modificar(string Id)
       {
           return ConexiondB.EjecutarDB("Update CxC set IdCuenta='" + IdCuenta + "',Fecha ='" + Fecha.ToString("MM/dd/yyyy") + "',Valor='" + Valor + "',Balance='" + Balance + "',Descripcion='" + Descripcion + "'where IdCxC='" + Id + "' ");

       }

       public bool Eliminar(string Id)
       {
           return ConexiondB.EjecutarDB("Delete from CxC where IdCxC=" + Id);
       }

       public bool Buscar(int Id)
       {
           bool mesj = false;
           DataTable dt = new DataTable();
           dt = ConexiondB.BuscarDb("Select *from CxC where IdCxC=" + Id);
           if (dt.Rows.Count > 0)
           {
               IdCxC=(int)dt.Rows[0]["IdCxC"];
               IdCuenta = (int)dt.Rows[0]["IdCuenta"];
               Fecha = (DateTime)dt.Rows[0]["Fecha"];
               Valor = (double)dt.Rows[0]["Valor"];
               Balance =(double) dt.Rows[0]["Balance"];
               Descripcion=dt.Rows[0]["Descripcion"].ToString();
               
               
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
