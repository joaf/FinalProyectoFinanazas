﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Gastos
    {
        public int IdGasto { get; set; }
        public int IdCuenta { get; set; }
        public int IdCategoria { get; set; }
        public DateTime Fecha { get; set; }
        public double Valor { get; set; }
        public string Descripcion { get; set; }

        public Gastos(int IdCuena, int IdCategoria, DateTime Fecha, int Valor, string Descripcion)
        {
            this.IdCuenta = IdCuenta;
            this.IdCategoria = IdCategoria;
            this.Fecha = Fecha;
            this.Valor = Valor;
            this.Descripcion = Descripcion;

        }
        public Gastos()
        {
            IdGasto = 0;
            IdCuenta = 0;
            IdCategoria = 0;
            Fecha = DateTime.Now;
            Valor = 0;
            Descripcion = "";
        }
         public Conexion ConexiondB = new Conexion();
     

       public bool Insertar()
       {
           return ConexiondB.EjecutarDB("Insert Into Gastos(IdCuenta,IdCategoria,Fecha,Valor,Descripcion)Values('" + IdCuenta + "','" + IdCategoria + "','" + Fecha.ToString("MM/dd/yyyy") + "','" + Valor + "','" + Descripcion + "')");

       }
       public bool CuentaResta(int Id ,int Valor){
        
           return ConexiondB.EjecutarDB("Update Cuentas set Balance = Balance -'" + Valor + "'where IdCuenta='" + Id + "' ");

       }

       public bool Modificar(string Id)
       {
           return ConexiondB.EjecutarDB("Update Gastos set IdCuenta='" + IdCuenta + "',IdCategoria='" + IdCategoria + "',Fecha ='" + Fecha.ToString("MM/dd/yyyy") + "',Valor='" + Valor + "',Descripcion='" + Descripcion + "'where IdGasto='" + Id + "' ");

       }

       public bool Eliminar(string Id)
       {
           return ConexiondB.EjecutarDB("Delete from Gasto where IdGasto=" + Id);
       }

       public bool Buscar(int Id)
       {
           bool mesj = false;
           DataTable dt = new DataTable();
           dt = ConexiondB.BuscarDb("Select *from Gastos where IdGasto=" + Id);
           if (dt.Rows.Count > 0)
           {

               IdGasto = (int)dt.Rows[0]["IdGasto"];
               IdCuenta = (int)dt.Rows[0]["IdCuenta"];
               IdCategoria = (int)dt.Rows[0]["IdCategoria"];
               Fecha = (DateTime)dt.Rows[0]["Fecha"];
               Valor = (double)dt.Rows[0]["Valor"];
               Descripcion = dt.Rows[0]["Valor"].ToString();



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

