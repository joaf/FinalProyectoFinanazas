using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;


namespace BLL
{
    public class Cuentas
    {
        public int IdCuenta { get; set; }
        public string Descripcion { get; set; }
        public double Balance { get; set; }

        public Cuentas(string Descripcion, Double Balance)
        {
            this.Descripcion = Descripcion;
            this.Balance = Balance;
        }
        public Cuentas()
        {
            IdCuenta = 0;
            Descripcion = "";
            Balance = 0;
        }
        public Conexion ConexiondB = new Conexion();
        public bool Insertar()
        {
            return ConexiondB.EjecutarDB("Insert Into Cuentas(Descripcion,Balance)Values('" + Descripcion + "','" + Balance + "')");

        }

        public bool Modificar(string Id)
        {
            return ConexiondB.EjecutarDB("Update Cuentas set Descripcion='" + Descripcion + "',Balance ='" + Balance + "'where IdCuenta='" + Id + "' ");

        }

        public bool Eliminar(string Id)
        {
            return ConexiondB.EjecutarDB("Delete from Cuentas where IdCuenta=" + Id);
        }

        public bool Buscar(int Id)
        {
            bool mesj = false;
            DataTable dt = new DataTable();
            dt = ConexiondB.BuscarDb("Select *from Cuentas where IdCuenta=" + Id);
            if (dt.Rows.Count > 0)
            {
                IdCuenta = (int)dt.Rows[0]["IdCuenta"];
                Balance = (Double)dt.Rows[0]["Balance"];
                Descripcion = dt.Rows[0]["Descripcion"].ToString();

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
