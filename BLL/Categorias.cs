using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Categorias
    {
        public string Descripcion { get; set; }
        public int Tipo { get; set; }

        public Categorias()
        {


        }
        public Categorias(string Descripcion, int Tipo)
        {
            this.Descripcion = Descripcion;
            this.Tipo = Tipo;
        }
        public Conexion ConexiondB = new Conexion();
     

       public bool Insertar()
       {
           return ConexiondB.EjecutarDB("Insert Into Categorias(Descripcion,Tipo)Values('" + Descripcion +"','"+ Tipo+"')");

       }

       public bool Modificar(string Id)
       {
           return ConexiondB.EjecutarDB("Update Categorias set Descripcion='" + Descripcion + "',Tipo ='" + Tipo + "'where IdCategoria='" + Id + "' ");

       }

       public bool Eliminar(string Id)
       {
           string comando;
           comando = "Delete from Categorias where IdCategoria=" + Id;
      
           return ConexiondB.EjecutarDB(comando);
       }

       public bool Buscar(int Id)
       {
           bool mesj = false;
           DataTable dt = new DataTable();
           dt = ConexiondB.BuscarDb("Select *from Categorias where IdCategoria=" + Id);
           if (dt.Rows.Count > 0)
           {

               Tipo = (int)dt.Rows[0]["Tipo"];
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

