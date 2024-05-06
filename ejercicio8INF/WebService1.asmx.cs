using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ejercicio8INF
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public int ModificarPersona(int persona_id,
                                    string nombre,
                                    string ap_paterno,
                                    string ap_materno,
                                    string tipo,
                                    string correo,
                                    string departamento)
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                string servidor = "localhost";
                string bd = "bdleonel";
                string usuario = "root";
                string password = "";
                string CadenaConexion = "server=" + servidor + ";" + "user=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
                string query = "UPDATE persona SET nombre ='" + nombre + "', ap_paterno='" + ap_paterno + "', ap_materno='" + ap_materno + "', tipo='" + tipo + "', correo='" + correo + "', departamento='" + departamento + "' WHERE persona_id = " + persona_id;
                con.ConnectionString = CadenaConexion;
                con.Open();
                MySqlCommand comando = new MySqlCommand(query, con);
                comando.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Se ha modificado la persona con id: " + persona_id);
                return 2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        //agregar persona
        [WebMethod]
        public int AgregarPersona(string nombre, string ap_paterno, string ap_materno, string tipo, string correo, string departamento)
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                string servidor = "localhost";
                string bd = "bdleonel";
                string usuario = "root";
                string password = "";
                string CadenaConexion = "server=" + servidor + ";" + "user=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
                con.ConnectionString = CadenaConexion;
                con.Open();
                string query = "INSERT INTO persona (nombre, ap_paterno,ap_materno,correo, tipo,departamento) VALUES ('" + nombre + "', '" + ap_paterno + "', '" + ap_materno + "', '" + correo + "', '" + tipo + "', '" + departamento + "')";
                MySqlCommand comando = new MySqlCommand(query, con);
                comando.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Se ha agregado una nueva persona.");
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        //eliminar persona
        [WebMethod]
        public int EliminarPersona(int persona_id)
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                string servidor = "localhost";
                string bd = "bdleonel";
                string usuario = "root";
                string password = "";
                string CadenaConexion = "server=" + servidor + ";" + "user=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
                con.ConnectionString = CadenaConexion;
                con.Open();
                string query = "DELETE FROM persona WHERE persona_id = " + persona_id;
                MySqlCommand comando = new MySqlCommand(query, con);
                comando.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Se ha eliminado la persona con id: " + persona_id);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }


    }
}
