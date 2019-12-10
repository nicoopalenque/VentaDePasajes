using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarPasajes
    {
        public static DataTable traerServicio()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);
            SqlCommand cmd = new SqlCommand("traerOrigen",cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static int agregarPasaje(Pasaje p)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("agregarPasaje", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dni", p.Cli_DNI);
            cmd.Parameters.AddWithValue("@cod", p.Ser_Codigo);
            cmd.Parameters.AddWithValue("@asiento", p.Pas_Asiento);
            cmd.Parameters.AddWithValue("@precio", p.Pas_Precio);
            cmd.Parameters.AddWithValue("@fechaHora", p.Pas_FechaHora);

            cnn.Open();
            int id = (int)cmd.ExecuteScalar();
            cnn.Close();
            return id;
        }

        public static ObservableCollection<Pasaje> traerPasajes(int cod)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerPasajesServicio", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", cod);

            ObservableCollection<Pasaje> lista = new ObservableCollection<Pasaje>();

            cnn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                Pasaje oPasaje = new Pasaje();

                oPasaje.Pas_Codigo = (int)reader["Pas_Codigo"];
                oPasaje.Cli_DNI = (int)reader["Cli_DNI"];
                oPasaje.Ser_Codigo = (int)reader["Ser_Codigo"];
                oPasaje.Pas_Asiento = (int)reader["Pas_Asiento"];
                oPasaje.Pas_Precio = (decimal)reader["Pas_Precio"];
                oPasaje.Pas_FechaHora = (DateTime)reader["Pas_FechaHora"];

                lista.Add(oPasaje);
            }

            return lista;
        }
        public static void eliminarPasaje(int cod) 
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("eliminarPasaje",cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", cod);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
