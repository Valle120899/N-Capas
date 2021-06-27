using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PrimeraAct.Datos
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;
        private static Conexion Con = null;

        private Conexion()
        {
            //La BD se nombró PrimeraAct
            this.Base = "PrimeraAct";

            //Al trabajarse de manera local, se puede hacer poniendo la IP de la máquina o localhost.
            this.Servidor = "localhost";

            //Se trabajó sin autentificación de Windows, por eso los campos usuario y clave son nulos
            this.Usuario = "";
            this.Clave = "";
            this.Seguridad = true;

        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server="+this.Servidor + "; Database="+this.Base+"; ";
                if (this.Seguridad)
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "Integrated Security = SSPI";
                }
                else
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "User Id="+this.Usuario+"; Password="+this.Clave;
                }
            }
            catch(Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion getInstancia()
        {
            if(Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }

    }
}
