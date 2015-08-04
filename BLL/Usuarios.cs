using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
   public  class Usuarios
    {
       public int IdUsuario { get; set; }
       public string Usuario { get; set; }
       public string Clave { get; set; }
       public string Email { get; set; }

       public Usuarios(string Usuario,string Clave,string Email)
       {
           this.Usuario = Usuario;
           this.Clave = Clave;
           this.Email = Email;
       }
       public Usuarios()
       {
           Usuario="";
           Clave="";
           Email="";
       }
        public Conexion ConexiondB = new Conexion();
       
       public bool Insertar()
        {
            return ConexiondB.EjecutarDB("Insert Into Usuarios(Usuario,Clave,Email)Values('" + Usuario + "','" + Clave + "','" + Email + "')");

        }

        public bool Modificar(string Id)
        {
            return ConexiondB.EjecutarDB("Update Usuarios set Usuario='" + Usuario + "',Clave ='" + Clave +"',Email='"+ Email + "'where IdUsuario='" + Id + "' ");

        }

        public bool Eliminar(string Id)
        {
            return ConexiondB.EjecutarDB("Delete from Usuarios where IdUsuario=" + Id);
        }

        public bool Buscar(int Id)
        {
            bool mesj = false;
            DataTable dt = new DataTable();
            dt = ConexiondB.BuscarDb("Select *from Usuarios where Usuario=" + Id);
            if (dt.Rows.Count > 0)
            {

                Usuario = dt.Rows[0]["Usuario"].ToString();
                Clave = dt.Rows[0]["Clave"].ToString();
                Email = dt.Rows[0]["Email"].ToString();

                mesj = true;


            }
            return mesj;
        }
        public bool BuscarUsu(string usuario, string contraceña)
        {
            bool mesj = false;
            DataTable dt = new DataTable();
            dt = ConexiondB.BuscarDb("Select  Usuario,Clave from Usuarios where Usuario='" + usuario + "' and Clave='" + contraceña + "'");
            if (dt.Rows.Count > 0)
            {

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
