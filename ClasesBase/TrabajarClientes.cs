using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarClientes
    {
        public static void agregarCliente(Cliente c)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);
            SqlCommand cmd = new SqlCommand("agregarCliente", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@dni", c.Cli_DNI);
            cmd.Parameters.AddWithValue("@nom", c.Cli_Nombre);
            cmd.Parameters.AddWithValue("@ape", c.Cli_Apellido);
            cmd.Parameters.AddWithValue("@tel", c.Cli_Telefono);
            cmd.Parameters.AddWithValue("@email", c.Cli_Email);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        
        public static void actualizarCliente(Cliente c){
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);
            SqlCommand cmd = new SqlCommand("actualizarCliente", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@dni", c.Cli_DNI);
            cmd.Parameters.AddWithValue("@nom", c.Cli_Nombre);
            cmd.Parameters.AddWithValue("@ape", c.Cli_Apellido);
            cmd.Parameters.AddWithValue("@tel", c.Cli_Telefono);
            cmd.Parameters.AddWithValue("@email", c.Cli_Email);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable traerClientes()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerClientes", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            return dt;
        }

        public static Cliente traerCliente(string dni)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerClienteDNI", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dni", dni);

            SqlDataReader reader;

            Cliente oCliente = null;

            cnn.Open();

            reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                oCliente = new Cliente();
                oCliente.Cli_DNI = (int)reader["Cli_DNI"];
                oCliente.Cli_Apellido = (String)reader["Cli_Apellido"];
                oCliente.Cli_Nombre = (String)reader["Cli_Nombre"];
                oCliente.Cli_Telefono = (String)reader["Cli_Telefono"];
                oCliente.Cli_Email = (String)reader["Cli_Email"];

                return oCliente;
            }
            return null;
        }

        public static void eliminarCliente(int dni)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("eliminarCliente", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dni", dni);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable buscarPorDNI(string dni)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerClienteDNI", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dni", dni);

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        public static Cliente traerPasajeCliente(int num)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerClientePasaje", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@num", num);

            SqlDataReader reader;

            Cliente oCliente;

            cnn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                oCliente = new Cliente();
                oCliente.Cli_DNI = (int)reader["Cli_DNI"];
                oCliente.Cli_Apellido = (string)reader["Cli_Apellido"];
                oCliente.Cli_Nombre = (string)reader["Cli_Nombre"];
                return oCliente;
            }
            return null;
        }
    }
}
