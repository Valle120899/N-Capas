using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PrimeraAct.Datos;
using PrimeraAct.Entidades;

namespace PrimeraAct.Negocio
{
    public class NPersona
    {

        //Se hace un llamado a los métodos que se ocuparán en la presentación

        //El método listar sólo retorna Listar, debido que no solicita algún valor.
        public static DataTable Listar()
        {
            DPersona Datos = new DPersona();
            return Datos.Listar();
        }

        //El método de insertar solicita todos los atributos que fueron especificados en el procedimiento almacenado en la BD
        public static string Insertar(String Nombre, string Apellido, int Edad, String Telefono, int Idrol)
        {
            DPersona Datos = new DPersona();
            Persona Obj = new Persona();
            Obj.Nombre = Nombre;
            Obj.Apellido = Apellido;
            Obj.Edad = Edad;
            Obj.Telefono = Telefono;
            Obj.IdRol = Idrol;

            return Datos.Insertar(Obj);

        }


    }
}
