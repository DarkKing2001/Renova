using Datoss;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Negocio
{
    public class Mantenedor
    {
        //Funcion Rechazado o Aprobado de Solicitud

        public static string RechazoString(bool aprobado)
        {
            string a = "Rechazado";

            if (aprobado != false)
            {
                a = "Aprobado";

                return a;
            }
            else
            {
                return a;
            }
        }

        public static bool RechazoBool(string aprobado)
        {
            bool a = false;

            if (aprobado == "Aprobado")
            {
                a = true;

                return a;
            }
            else
            {
                return a;
            }
        }


        //Funcion Cambiar bool a Aprobado o Reprobado

        public static string AprobadoString(bool aprobado)
        {
            string a = "Reprobado";

            if (aprobado != false)
            {
                a = "Aprobado";

                return a;
            }
            else
            {
                return a;
            }
        }

        public static bool AprobadoBool(string aprobado)
        {
            bool a = false;

            if (aprobado == "Aprobado")
            {
                a = true;

                return a;
            }
            else
            {
                return a;
            }
        }

        //Mantenedor Persona

        public static bool ValidarRut(string rut, char dv)
        {

            int r = Convert.ToInt32(rut);
            int m = 0;
            int s = 1;            

            for (; r != 0; r /=10)
            {
                s = (s + r % 10 * (9 - m++ % 6)) % 11;
            }

            if (dv == (char) (s != 0 ? s + 47 : 75))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool BuscarRut(string rut)
        {
            string sql = "select rut from persona " +
                        "Where rut = '" + rut + "';";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {
                        Persona p = new Persona();
                        p.Rut = leer["rut"].ToString();

                        if (rut == p.Rut)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return false;
                }
                else
                {
                    MessageBox.Show("No se ha encontrado el rut");
                    return false;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar rut: " + e.ToString());
                return false;
            }

        }

        public static int IdPersona()
        {
            string sql = "select MAX(id) as id from persona;";
            int id = 0;

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {
                    while (leer.Read())
                    {
                        id = leer.GetInt32("id");
                    }

                    return id +1;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return id;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar datos: " + e.ToString());
                return id;
            }

        }

        public static int BuscarIdPersona(string rut)
        {
            string sql = "select id from persona " +
                          "Where rut = '" + rut + "';";
            int id = 0;

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {
                    while (leer.Read())
                    {
                        id = leer.GetInt32("id");
                    }

                    return id;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return id;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar datos: " + e.ToString());
                return id;
            }

        }

        public static string BuscarRutPersona(int id)
        {
            string sql = "select rut from persona " +
                          "Where id = " + id + ";";

            string rut = "";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {
                    while (leer.Read())
                    {
                        rut = leer.GetString("rut");
                    }

                    return rut;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return rut;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar datos: " + e.ToString());
                return rut;
            }

        }

        public static bool Agregar(Persona persona)
        {
            int id = IdPersona();

            string sql = "INSERT INTO persona " +
                    "(id, rut, p_nombre, s_nombre, apellido_p, " +
                    "apellido_m, correo, comuna_id) values " +
                    "(" + id + ", '" + persona.Rut + "', '" + persona.Nombre +
                    "', '" + persona.Snombre + "', '" + persona.Apellido_p +
                    "', '" + persona.Apellido_m + "', '" + persona.Correo +
                    "', " + persona.Comuna + ");";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Agregado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al agregar: " + e.ToString());
                return false;
            }

        }

        public static bool Modificar(Persona persona)
        {
            string sql = "UPDATE persona SET" +
                    " p_nombre = '" + persona.Nombre +
                    "', s_nombre = '" + persona.Snombre +
                    "', apellido_p = '" + persona.Apellido_p +
                    "', apellido_m = '" + persona.Apellido_m +
                    "', correo = '" + persona.Correo +
                    "', comuna_id = " + persona.Comuna +
                    " Where rut = '" + persona.Rut + "';";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Modificado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al modificada: " + e.ToString());
                return false;
            }

        }

        public static bool Eliminar(string rut)
        {
            string sql = "Delete from persona " +
                        "Where rut = '" + rut + "';";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Eliminado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Eliminar: " + e.ToString());
                return false;
            }

        }

        public static List<Persona> Buscar(string rut)
        {
            List<Persona> personas = new List<Persona>();
            MySqlDataReader leer = null;

            string sql = "Select * from persona " +
                        "Where rut = '" + rut + "';";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                leer = comando.ExecuteReader();

                if (leer.HasRows)
                {
                    
                    while (leer.Read())
                    {

                        Persona p = new Persona();

                        p.Rut = leer.GetString("rut");
                        p.Nombre = leer.GetString("p_nombre");
                        p.Snombre = leer.GetString("s_nombre");
                        p.Apellido_p = leer.GetString("apellido_p");
                        p.Apellido_m = leer.GetString("apellido_m");
                        p.Correo = leer.GetString("correo");
                        p.Comuna = leer.GetInt32("comuna_id");

                        personas.Add(p);
                    }
                                         
                    return personas;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        public static List<Persona> MostrarPersonas()
        {
            List<Persona> personas = new List<Persona>();

            string sql = "Select * from persona " +
                         "Where id >4;";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {

                        Persona p = new Persona();

                        /*p.Rut = leer.GetInt32("rut");
                        p.Nombre = leer.GetString("p_nombre");
                        p.Snombre = leer.GetString("s_nombre");
                        p.Apellido_p = leer.GetString("apellido_p");
                        p.Apellido_m = leer.GetString("apellido_m");
                        p.Correo = leer.GetString("correo");
                        p.Comuna = leer.GetInt32("comuna_id");*/

                        p.Rut = leer["rut"].ToString();
                        p.Nombre = leer["p_nombre"].ToString();
                        p.Snombre = leer["s_nombre"].ToString();
                        p.Apellido_p = leer["apellido_p"].ToString();
                        p.Apellido_m = leer["apellido_m"].ToString();
                        p.Correo = leer["correo"].ToString();
                        p.Comuna = int.Parse(leer["comuna_id"].ToString());

                        personas.Add(p);
                    }

                    return personas;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        //Mantenedor Usuarios

        public static bool BuscarNombreUsuario(string usuario)
        {

            string sql = "Select * from usuario " +
                        "Where nombre = '" + usuario + "';";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {
                    return true;                    
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return false;
            }

        }

        public static bool BuscarRutUsuario(string rut)
        {

            string sql = "Select * from usuario " +
                        "Where persona_id = " + BuscarIdPersona(rut) + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return false;
            }

        }

        public static bool BuscarUsuario(string usuario, string contra)
        {

            string sql = "Select contrasenia from usuario " +
                        "Where nombre = '" + usuario + "';";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {
                        Usuario u = new Usuario();
                        u.Contra = leer["contrasenia"].ToString();

                        if (contra == u.Contra)
                        {
                            MessageBox.Show("Usuario Encontrado");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Contraseña incorrecta");
                            return false;
                        }
                    }
                    return false;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return false;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return false;
            }

        }

        public static bool AgregarUsuario(Usuario usuario)
        {
            int id = BuscarIdPersona(usuario.Rut); 

            string sql = "INSERT INTO usuario " +
                    "(persona_id, nombre, contrasenia) values " +
                    "(" + id + ", '" + usuario.Nombre +
                    "', '" + usuario.Contra + "');";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Agregado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al agregar: " + e.ToString());
                return false;
            }

        }

        public static bool ModificarUsuario(Usuario usuario)
        {
            int id = BuscarIdPersona(usuario.Rut);

            string sql = "UPDATE usuario SET" +
                    " nombre = '" + usuario.Nombre +
                    "', contrasenia = '" + usuario.Contra +
                    "' Where persona_id = " + id + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Modificado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al modificada: " + e.ToString());
                return false;
            }

        }

        public static bool EliminarUsuario(string rut)
        {
            int id = BuscarIdPersona(rut);

            string sql = "Delete from usuario " +
                        "Where persona_id = " + id + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Eliminado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Eliminar: " + e.ToString());
                return false;
            }

        }

        public static List<Usuario> BuscarUsuarios(string rut)
        {
            List<Usuario> usuarios = new List<Usuario>();
            int id = BuscarIdPersona(rut);

            string sql = "Select * from usuario " +
                        "Where persona_id = " + id + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {

                        Usuario u = new Usuario();

                        u.Rut = BuscarRutPersona(leer.GetInt32("persona_id"));
                        u.Nombre = leer.GetString("nombre");
                        u.Contra = leer.GetString("contrasenia");

                        //return u;
                        usuarios.Add(u);
                    }

                    return usuarios;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        public static List<Usuario> MostrarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            string sql = "Select * from usuario " +
                         "Where id >4;";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {

                        Usuario u = new Usuario();

                        u.Rut = BuscarRutPersona(leer.GetInt32("persona_id"));
                        u.Nombre = leer.GetString("nombre");
                        u.Contra = leer.GetString("contrasenia");

                        usuarios.Add(u);
                    }

                    return usuarios;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        //Mantenedor Medico

        public static bool BuscarRutEM(string rut)
        {

            string sql = "Select * from medico " +
                        "Where persona_id = " + BuscarIdPersona(rut) + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return false;
            }

        }

        public static bool AgregarMedico(Medico medico)
        {
            string sql = "INSERT INTO medico " +
                    "(persona_id, examen_visual, examen_auditivo, examen_psicologico, " +
                    "coordinacion_motriz, examen_general, aprobado) values " +
                    "(" + BuscarIdPersona(medico.Rut) + ", " + AprobadoBool(medico.ExamenV) +
                    ", " + AprobadoBool(medico.ExamenA) + ", " + AprobadoBool(medico.ExamenP) +
                    ", " + AprobadoBool(medico.CoordinacionM) + ", " + AprobadoBool(medico.ExamenG) +
                    ", " + AprobadoBool(medico.Aprobado) + ");";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Agregado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al agregar: " + e.ToString());
                return false;
            }

        }

        public static bool ModificarMedico(Medico medico)
        {
            string sql = "UPDATE medico SET" +
                    " examen_visual = " + AprobadoBool(medico.ExamenV) +
                    ", examen_auditivo = " + AprobadoBool(medico.ExamenA) +
                    ", examen_psicologico = " + AprobadoBool(medico.ExamenP) +
                    ", coordinacion_motriz = " + AprobadoBool(medico.CoordinacionM) +
                    ", examen_general = " + AprobadoBool(medico.ExamenG) +
                    ", aprobado = " + AprobadoBool(medico.Aprobado) +
                    " Where persona_id = " + BuscarIdPersona(medico.Rut) + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Modificado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al modificar: " + e.ToString());
                return false;
            }

        }

        public static bool EliminarMedico(string rut)
        {
            string sql = "Delete from medico " +
                        "Where persona_id = " + BuscarIdPersona(rut) + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Eliminado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Eliminar: " + e.ToString());
                return false;
            }

        }

        public static List<Medico> BuscarMedico(string rut)
        {
            List<Medico> medicos = new List<Medico>();

            string sql = "Select * from medico " +
                        "Where persona_id = " + BuscarIdPersona(rut) + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {

                        Medico m = new Medico();

                        m.Rut = BuscarRutPersona(int.Parse(leer["persona_id"].ToString()));
                        m.ExamenV = AprobadoString(bool.Parse(leer["examen_visual"].ToString()));
                        m.ExamenA = AprobadoString(bool.Parse(leer["examen_auditivo"].ToString()));
                        m.ExamenP = AprobadoString(bool.Parse(leer["examen_psicologico"].ToString()));
                        m.CoordinacionM = AprobadoString(bool.Parse(leer["coordinacion_motriz"].ToString()));
                        m.ExamenG = AprobadoString(bool.Parse(leer["examen_general"].ToString()));
                        m.Aprobado = AprobadoString(bool.Parse(leer["aprobado"].ToString()));

                        //string ev = AprobadoString(bool.Parse((leer["examen_visual"].ToString())));

                        medicos.Add(m);
                    }

                    return medicos;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        public static List<Medico> MostrarMedicos()
        {
            List<Medico> medicos = new List<Medico>();

            string sql = "Select * from medico;";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {

                        Medico m = new Medico();

                        m.Rut = BuscarRutPersona(int.Parse(leer["persona_id"].ToString()));
                        m.ExamenV = AprobadoString(bool.Parse(leer["examen_visual"].ToString()));
                        m.ExamenA = AprobadoString(bool.Parse(leer["examen_auditivo"].ToString()));
                        m.ExamenP = AprobadoString(bool.Parse(leer["examen_psicologico"].ToString()));
                        m.CoordinacionM = AprobadoString(bool.Parse(leer["coordinacion_motriz"].ToString()));
                        m.ExamenG = AprobadoString(bool.Parse(leer["examen_general"].ToString()));
                        m.Aprobado = AprobadoString(bool.Parse(leer["aprobado"].ToString()));

                        medicos.Add(m);
                    }

                    return medicos;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        //Mantenedor Instructor

        public static bool BuscarRutEP(string rut)
        {

            string sql = "Select * from instructor " +
                        "Where persona_id = " + BuscarIdPersona(rut) + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return false;
            }

        }

        public static bool AgregarEP(Instructor instructor)
        {
            string sql = "INSERT INTO instructor " +
                    "(rut, f_graves, f_leves, aprobado) values " +
                    "(" + instructor.Rut + ", " + instructor.FaltasG +
                    ", " + instructor.FaltasL + ", " + AprobadoBool(instructor.Aprobado) + ");";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Agregado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al agregar: " + e.ToString());
                return false;
            }

        }

        public static bool ModificarEP(Instructor instructor)
        {
            string sql = "UPDATE instructor SET" +
                    " f_graves = " + instructor.FaltasG +
                    ", f_leves = " + instructor.FaltasL +
                    ", aprobado = " + AprobadoBool(instructor.Aprobado) +
                    " Where rut = " + instructor.Rut + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Modificado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al modificada: " + e.ToString());
                return false;
            }

        }

        public static bool EliminarEP(string rut)
        {
            string sql = "Delete from instructor " +
                        "Where rut = " + rut + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Eliminado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Eliminar: " + e.ToString());
                return false;
            }

        }

        public static List<Instructor> BuscarEP(string rut)
        {
            List<Instructor> instructores = new List<Instructor>();

            string sql = "Select * from instructor " +
                        "Where rut = " + rut + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {

                        Instructor i = new Instructor();

                        i.Rut = leer.GetString("rut");
                        i.FaltasG = leer.GetInt32("f_graves");
                        i.FaltasL = leer.GetInt32("f_leves");
                        i.Aprobado = AprobadoString(bool.Parse(leer["aprobado"].ToString()));

                        instructores.Add(i);
                    }

                    return instructores;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        public static List<Instructor> MostrarEEPP()
        {
            List<Instructor> instructores = new List<Instructor>();

            string sql = "Select * from instructor;";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {

                        Instructor i = new Instructor();

                        i.Rut = leer.GetString("rut");
                        i.FaltasG = leer.GetInt32("f_graves");
                        i.FaltasL = leer.GetInt32("f_leves");
                        i.Aprobado = AprobadoString(bool.Parse(leer["aprobado"].ToString()));

                        instructores.Add(i);
                    }

                    return instructores;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        //Funcionario

        public static bool BuscarRutET(string rut)
        {

            string sql = "Select * from funcionario " +
                        "Where persona_id = " + BuscarIdPersona(rut) + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return false;
            }

        }

        public static bool AgregarET(Funcionario funcionario)
        {
            string sql = "INSERT INTO funcionario " +
                    "(persona_id, p_correctas, p_incorrectas, aprobado) values " +
                    "(" + BuscarIdPersona(funcionario.Rut) + ", " + funcionario.PreguntasC +
                    ", " + funcionario.PreguntasI + ", " + AprobadoBool(funcionario.Aprobado) + ");";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Agregado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al agregar: " + e.ToString());
                return false;
            }

        }

        public static bool ModificarET(Funcionario funcionario)
        {
            string sql = "UPDATE funcionario SET" +
                    " p_correctas = " + funcionario.PreguntasC +
                    ", p_incorrectas = " + funcionario.PreguntasI +
                    ", aprobado = " + AprobadoBool(funcionario.Aprobado) +
                    " Where persona_id = " + BuscarIdPersona(funcionario.Rut) + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Modificado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al modificada: " + e.ToString());
                return false;
            }

        }

        public static bool EliminarET(string rut)
        {
            string sql = "Delete from funcionario " +
                        "Where persona_id = " + BuscarIdPersona(rut) + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Eliminado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Eliminar: " + e.ToString());
                return false;
            }

        }

        public static List<Funcionario> BuscarET(string rut)
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            string sql = "Select * from funcionario " +
                        "Where persona_id = " + BuscarIdPersona(rut) + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {

                        Funcionario f = new Funcionario();

                        f.Rut = BuscarRutPersona(leer.GetInt32("persona_id"));
                        f.PreguntasC = leer.GetInt32("p_correctas");
                        f.PreguntasI = leer.GetInt32("p_incorrectas");
                        f.Aprobado = AprobadoString(bool.Parse(leer["aprobado"].ToString()));

                        funcionarios.Add(f);
                    }

                    return funcionarios;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        public static List<Funcionario> MostrarEETT()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            string sql = "Select * from funcionario;";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {

                        Funcionario f = new Funcionario();

                        f.Rut = BuscarRutPersona(leer.GetInt32("persona_id"));
                        f.PreguntasC = leer.GetInt32("p_correctas");
                        f.PreguntasI = leer.GetInt32("p_incorrectas");
                        f.Aprobado = AprobadoString(bool.Parse(leer["aprobado"].ToString()));

                        funcionarios.Add(f);
                    }

                    return funcionarios;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        //Solicitud

        public static string RenovacionString(bool renovacion)
        {
            string a = "Primera Licencia";

            if (renovacion != false)
            {
                a = "Renovacion";

                return a;
            }
            else
            {
                return a;
            }
        }

        public static bool RenovacionBool(string renovacion)
        {
            bool a = false;

            if (renovacion == "Renovacion")
            {
                a = true;

                return a;
            }
            else
            {
                return a;
            }
        }

        public static bool BuscarSoliRut(string rut)
        {
            string sql = "select * from solicitud " +
                          "Where persona_id = " + BuscarIdPersona(rut) + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return false;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar datos: " + e.ToString());
                return false;
            }

        }

        public static bool AgregarSolicitud(Solicitud solicitud)
        {
            /*string sql = "INSERT INTO solicitud " +
                    "(persona_id, fecha, dni, licencia, recidencia, certificadoE, aprobada) values " +
                    "(" + BuscarIdPersona(solicitud.Rut) + ", '" + solicitud.Fecha.ToString("yyyy/MM/dd HH:mm") +
                    "', @dni, '" + solicitud.Licencia + "', '" + solicitud.Certificado + "', '" + solicitud.Recidencia + 
                    "', " + AprobadoBool(solicitud.Aprobado) + ");";*/

            string sql = "INSERT INTO solicitud " +
                    "(persona_id, fecha, renovacion, clase, dni, licencia, recidencia, certificadoE, aprobada) values " +
                    "(" + BuscarIdPersona(solicitud.Rut) + ", '" + solicitud.Fecha.ToString("yyyy/MM/dd HH:mm") +
                    "', " + RenovacionBool(solicitud.Renovacion) + ", '" + solicitud.Clase + "', @dni, @licencia, @recidencia, @CertificadoE" +
                    ", " + RechazoBool(solicitud.Aprobado) + ");";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.Parameters.AddWithValue("dni", solicitud.Carnet);
                comando.Parameters.AddWithValue("licencia", solicitud.Licencia);
                comando.Parameters.AddWithValue("recidencia", solicitud.Recidencia);
                comando.Parameters.AddWithValue("certificadoE", solicitud.Certificado);
                comando.ExecuteNonQuery();
                MessageBox.Show("Agregado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al agregar: " + e.ToString());
                return false;
            }

        }

        public static bool ModificarSolicitud(Solicitud solicitud)
        {
            string sql = "UPDATE solicitud SET" +
                    " fecha = '" + solicitud.Fecha.ToString("yyyy-MM-dd HH:mm:ss") +
                    "', renovacion = " + RenovacionBool(solicitud.Renovacion) +
                    ", clase = '" + solicitud.Clase +
                    "', dni = @dni"  +
                    ", licencia = @licencia" +
                    ", recidencia = @recidencia" +
                    ", certificadoE = @certificadoE" + 
                    ", aprobado = " + RechazoBool(solicitud.Aprobado) +
                    " Where persona_id = " + BuscarIdPersona(solicitud.Rut) + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.Parameters.AddWithValue("dni", solicitud.Carnet);
                comando.Parameters.AddWithValue("licencia", solicitud.Licencia);
                comando.Parameters.AddWithValue("recidencia", solicitud.Recidencia);
                comando.Parameters.AddWithValue("certificadoE", solicitud.Certificado);
                comando.ExecuteNonQuery();
                MessageBox.Show("Modificado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al modificada: " + e.ToString());
                return false;
            }

        }

        public static bool EliminarSolicitud(int soli)
        {
            string sql = "Delete from solicitud " +
                        "Where numSoli = " + soli + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Eliminado correctamente");

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Eliminar: " + e.ToString());
                return false;
            }

        }

        public static List<Solicitud> BuscarSolicitud(string rut)
        {
            List<Solicitud> solicitudes = new List<Solicitud>();

            string sql = "Select * from solicitud " +
                        "Where persona_id = " + BuscarIdPersona(rut) + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {
                        Solicitud s = new Solicitud();

                        //DateTime f = DateTime.Parse(leer["fecha"].ToString());

                        //MemoryStream ms = new MemoryStream((byte[])leer["dni"]);

                        s.NumSoli = int.Parse(leer.GetString("numSoli"));
                        s.Rut = BuscarRutPersona(leer.GetInt32("persona_id"));
                        s.Fecha = DateTime.Parse(leer["fecha"].ToString());
                        s.Renovacion = RenovacionString(bool.Parse(leer["renovacion"].ToString()));
                        s.Clase = leer.GetString("clase");
                        s.Carnet = (byte[])leer["dni"];
                        s.Recidencia = (byte[])leer["recidencia"];
                        s.Licencia = (byte[])leer["licencia"];
                        s.Certificado = (byte[])leer["certificadoE"];
                        //s.Carnet = null;
                        //s.Recidencia = null;
                        //s.Licencia = null;
                        //s.Certificado = null;
                        s.Aprobado = RechazoString(bool.Parse(leer["aprobada"].ToString()));

                        solicitudes.Add(s);
                    }

                    return solicitudes;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        public static List<Solicitud> MostrarSolicitudes()
        {
            List<Solicitud> solicitudes = new List<Solicitud>();

            string sql = "Select * from solicitud;";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {

                        Solicitud s = new Solicitud();

                        s.NumSoli = int.Parse(leer.GetString("numSoli"));
                        s.Rut = BuscarRutPersona(leer.GetInt32("persona_id"));
                        s.Fecha = DateTime.Parse(leer["fecha"].ToString());
                        s.Renovacion = RenovacionString(bool.Parse(leer["renovacion"].ToString()));
                        s.Clase = leer.GetString("clase");
                        s.Carnet = (byte[])leer["dni"];
                        s.Recidencia = (byte[])leer["recidencia"];
                        s.Licencia = (byte[])leer["licencia"];
                        s.Certificado = (byte[])leer["certificadoE"];
                        //s.Carnet = null;
                        //s.Recidencia = null;
                        //s.Licencia = null;
                        //s.Certificado = null;
                        s.Aprobado = RechazoString(bool.Parse(leer["aprobada"].ToString()));

                        solicitudes.Add(s);
                    }

                    return solicitudes;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        public static MemoryStream BuscarCarnet(int soli)
        {

            string sql = "Select dni from solicitud " +
                        "Where numSoli = " + soli + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {

                        MemoryStream ms = new MemoryStream((byte[])leer["dni"]);

                        return ms;
                    }

                    return null;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        public static MemoryStream BuscarLicencia(int soli)
        {

            string sql = "Select licencia from solicitud " +
                        "Where numSoli = " + soli + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {

                        MemoryStream ms = new MemoryStream((byte[])leer["licencia"]);

                        return ms;
                    }

                    return null;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        public static MemoryStream BuscarRecidencia(int soli)
        {

            string sql = "Select recidencia from solicitud " +
                        "Where numSoli = " + soli + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {

                        MemoryStream ms = new MemoryStream((byte[])leer["recidencia"]);

                        return ms;
                    }

                    return null;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        public static MemoryStream BuscarCertificado(int soli)
        {

            string sql = "Select certificadoE from solicitud " +
                        "Where numSoli = " + soli + ";";

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {

                        MemoryStream ms = new MemoryStream((byte[])leer["certificadoE"]);

                        return ms;
                    }

                    return null;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return null;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return null;
            }

        }

        public static byte[] ImageByte(Image image)
        {
            BitmapSource bitmapSource = (BitmapSource)image.Source;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            MemoryStream memoryStream = new MemoryStream();
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            encoder.Save(memoryStream);

            return memoryStream.ToArray();
        }

        public static Image ByteImage(byte[] byteArray)
        {
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                BitmapImage imageSource = new BitmapImage();
                imageSource.BeginInit();
                imageSource.StreamSource = stream;
                imageSource.CacheOption = BitmapCacheOption.OnLoad;
                imageSource.EndInit();

                Image imageControl = new Image();
                imageControl.Source = imageSource;
                return imageControl;
            }
        }

        public static int BuscarHoras(DateTime fecha)
        {
            int cantidad = 0;

            string sql = "Select count(fecha) as fecha from solicitud " +
                         "Where fecha = '" + fecha.ToString("yyyy-MM-dd HH:mm:ss") + "';"; 

            MySqlConnection ConnexionBD = ConexionBD.conexion();
            ConnexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, ConnexionBD);
                MySqlDataReader leer = comando.ExecuteReader();

                if (leer.HasRows)
                {

                    while (leer.Read())
                    {
                        cantidad = leer.GetInt32("fecha");

                        return cantidad;
                    }

                    return cantidad;
                }
                else
                {
                    MessageBox.Show("No se han encontrado datos");
                    return cantidad;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al Buscar: " + e.ToString());
                return cantidad;
            }

        }

    }
}
