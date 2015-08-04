using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Transferencias
    {
        public int IdTranferencia { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCuentaOrigen { get; set; }
        public int IdCuentaDestino { get; set; }
        public string Descripcion { get; set; }
        public double Valor { get; set; }

        public Transferencias( DateTime Fecha, int IdCuenatOrigen, int IdCuentaDestino,string Descripcion,int Valor)
        {
            this.Fecha = Fecha;
            this.IdCuentaOrigen = IdCuentaOrigen;
            this.IdCuentaDestino = IdCuentaDestino;
            this.Descripcion = Descripcion;
            this.Valor = Valor;
        }
        public Transferencias()
        {
            Fecha = DateTime.Now;
            IdCuentaDestino = 0;
            IdCuentaOrigen = 0;
            Descripcion = "";
            Valor = 0;
        }
        public Conexion ConexiondB = new Conexion();
        public bool Insertar()
        {
            return ConexiondB.EjecutarDB("Insert Into Transferencias(Fecha,IdCuentaOrigen,IdCuentaDestino,Descripcion,Valor)Values('" + Fecha.ToString("MM/dd/yyyy") + "','" + IdCuentaOrigen + "','" + IdCuentaDestino + "','" + Descripcion + "','" + Valor + "')");

        }
        public bool TransferenciaOrigen(int Id ,int Valor)
        {
            return ConexiondB.EjecutarDB("Update Cuentas set Balance = Balance -'" + Valor + "'where IdCuenta='" + Id + "' ");

        }
        public bool TransferenciaDestino(int Id, int Valor)
        {
            return ConexiondB.EjecutarDB("Update Cuentas set Balance = Balance +'" + Valor + "'where IdCuenta='" + Id + "' ");

        }

        public bool Modificar(string Id)
        {
            return ConexiondB.EjecutarDB("Update Transferencias set Fecha='" + Fecha.ToString("MM/dd/yyyy") + "',IdCuentaOrigen ='" + IdCuentaOrigen + "',IdCuentaDetino='" + IdCuentaDestino + "',Descripcion='" + Descripcion + "',Valor='" + Valor + "'where IdCobroDetalle='" + Id + "' ");

        }

        public bool Eliminar(string Id)
        {
            return ConexiondB.EjecutarDB("Delete from Transferencias where IdTrasnferencia=" + Id);
        }

        public bool Buscar(int Id)
        {
            bool mesj = false;
            DataTable dt = new DataTable();
            dt = ConexiondB.BuscarDb("Select *from Transferencias where IdTransferencia=" + Id);
            if (dt.Rows.Count > 0)
            {
                IdTranferencia = (int)dt.Rows[0]["IdTransferencia"];
                Fecha = (DateTime)dt.Rows[0]["Fecha"];
                IdCuentaDestino = (int)dt.Rows[0]["IdCuentaDestino"];
                IdCuentaOrigen= (int)dt.Rows[0]["IdCuentaOrigen"];
                Descripcion = dt.Rows[0]["Descripcion"].ToString();
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
