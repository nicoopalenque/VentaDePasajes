using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarCiudades
    {
        
        public static DataTable traerCiudades()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerCiudades", cnn);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            return dt;
        }

        public static void agregarCiudad(Ciudad c)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("agregarCiudad", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", c.Ciu_Nombre);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void actualizarCiudad(Ciudad c)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("actualizarCiudad", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("cod", c.Ciu_Codigo);
            cmd.Parameters.AddWithValue("@nombre", c.Ciu_Nombre);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void eliminarCiudad(int cod)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("eliminarCiudad", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", cod);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
