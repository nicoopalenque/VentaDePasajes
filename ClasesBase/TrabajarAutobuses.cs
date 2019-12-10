using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace ClasesBase
{
    public class TrabajarAutobuses
    {
       
        public static DataTable traerAutobus()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerAutobuses", cnn);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            
            return dt;
        }

        public static void agregarAutobus(Autobus a)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("agregarAutobus", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cap", a.Aut_Capacidad);
            cmd.Parameters.AddWithValue("@serv", a.Aut_TipoServicio);
            cmd.Parameters.AddWithValue("@mat", a.Aut_Matricula);
            cmd.Parameters.AddWithValue("@emp", a.Emp_Codigo);
            cmd.Parameters.AddWithValue("@pisos", a.Aut_CantidadPisos);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void actualizarAutobus(Autobus a)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("actualizarAutobus", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("id", a.Aut_Codigo);
            cmd.Parameters.AddWithValue("@cap", a.Aut_Capacidad);
            cmd.Parameters.AddWithValue("@serv", a.Aut_TipoServicio);
            cmd.Parameters.AddWithValue("@mat", a.Aut_Matricula);
            cmd.Parameters.AddWithValue("@emp", a.Emp_Codigo);
            cmd.Parameters.AddWithValue("@pisos", a.Aut_CantidadPisos);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void eliminarAutobus(int cod)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("eliminarAutobus", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", cod);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
