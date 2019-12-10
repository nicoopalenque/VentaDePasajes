using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;


namespace ClasesBase
{
    public class TrabajarViajes
    {
        public static ObservableCollection<Pasaje> traerViajesCollection()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerPasaje", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            ObservableCollection<Pasaje> lista = new ObservableCollection<Pasaje>();

            cnn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {

                Pasaje oPasaje = new Pasaje();
                oPasaje.Pas_Codigo = (int)reader["Pas_Codigo"];
                oPasaje.Emp_Codigo = (int)reader["Emp_Codigo"];
                oPasaje.Cli_DNI = (int)reader["Cli_DNI"];
                oPasaje.Pas_Asiento = (int)reader["Pas_Asiento"];
                oPasaje.Pas_FechaHora = (DateTime)reader["Pas_FechaHora"];
                oPasaje.Pas_Precio = (decimal)reader["Pas_Precio"];
                oPasaje.Cli_Nombre = (string)reader["Cli_Nombre"];
                oPasaje.Cli_Apellido = (string)reader["Cli_Apellido"];
                oPasaje.Ser_FechaHora = (DateTime)reader["Ser_FechaHora"];
                oPasaje.Ciu_Origen = (string)reader["Ciu_Origen"];
                oPasaje.Ciu_Destino = (string)reader["Ciu_Destino"];
                oPasaje.Aut_Codigo = (int)reader["Aut_Codigo"];
                oPasaje.Aut_Matricula = (string)reader["Aut_Matricula"];
                oPasaje.Aut_Servicio = (string)reader["Aut_TipoServicio"];
                oPasaje.Emp_Nombre = (string)reader["Emp_Nombre"];
                oPasaje.Ser_Codigo = (int)reader["Ser_Codigo"];

                lista.Add(oPasaje);
            }
            return lista;
        }

        public static DataTable traerViajes()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerPasaje", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
