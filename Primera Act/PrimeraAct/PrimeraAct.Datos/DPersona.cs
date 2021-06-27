using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PrimeraAct.Entidades;
using System.Data.SqlClient;

namespace PrimeraAct.Datos
{
    public class DPersona
    {
        //Se ocupa la función listar para mostrar los datos en el GridView
        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //El procedimiento almacenado se llama "Listar_Persona"
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("Listar_Persona", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();

            }
        }

        //Se crea una función pública para insertar los datos dentro de la BD
        public string Insertar(Persona obj)
        {

            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {

                //El procedimiento se llama "Insertar_Persona" y se le mandan todos los parámetros
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("Insertar_Persona",SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = obj.Nombre;
                Comando.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = obj.Apellido;
                Comando.Parameters.Add("@Edad", SqlDbType.Int).Value = obj.Edad;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = obj.Telefono;
                Comando.Parameters.Add("@Idrol", SqlDbType.Int).Value = obj.IdRol;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "Ok" : "No se pudo insertar el registro";
            }
            catch(Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;

        }
    }
}
