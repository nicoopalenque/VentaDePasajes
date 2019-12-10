using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarUsuarios
    {

        public static Usuario validarUsuario(string username, string pass)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("validarUsuario", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@pass", pass);

            SqlDataReader reader;

            Usuario oUsuario;

            cnn.Open();

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                oUsuario = new Usuario();
                oUsuario.Rol_Codigo = (String)reader["Rol_Codigo"];
                oUsuario.Usu_ApellidoNombre = (String)reader["Usu_ApellidoNombre"];
                oUsuario.Usu_NombreUsuario = (String)reader["Usu_NombreUsuario"];
                oUsuario.Usu_Contraseña = (String)reader["Usu_Contraseña"];
                return oUsuario;
            }
            return null;
        }

        public static ObservableCollection<Usuario> traerUsuariosCollection()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerUsuarios", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            ObservableCollection<Usuario> lista = new ObservableCollection<Usuario>();

            cnn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read()==true)
            {
                Usuario oUsuario = new Usuario();

                oUsuario.Usu_ID = (Int32)reader["Usu_ID"];
                oUsuario.Usu_NombreUsuario = (string)reader["Usu_NombreUsuario"];
                oUsuario.Usu_Contraseña = (string)reader["Usu_Contraseña"];
                oUsuario.Usu_ApellidoNombre = (string)reader["Usu_ApellidoNombre"];
                oUsuario.Rol_Codigo = (string)reader["Rol_Codigo"];


                lista.Add(oUsuario);
            }
            
            return lista;
        }

        public static int agregarUsuario(Usuario u)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("agregarUsuario", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", u.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@password", u.Usu_Contraseña);
            cmd.Parameters.AddWithValue("@lastname", u.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@rol", u.Rol_Codigo);

            cnn.Open();
            int id = (int)cmd.ExecuteScalar();
            cnn.Close();

            return id;
        }

        public static void actualizarUsuario(Usuario u)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("actualizarUsuario", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", u.Usu_ID);
            cmd.Parameters.AddWithValue("@username", u.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@pass", u.Usu_Contraseña);
            cmd.Parameters.AddWithValue("@ayn", u.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@rol", u.Rol_Codigo);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void eliminarUsuario(Usuario u)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("eliminarUsuario", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", u.Usu_ID);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

    }
}
