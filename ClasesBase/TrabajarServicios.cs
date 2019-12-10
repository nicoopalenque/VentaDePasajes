using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ClasesBase;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarServicios
    {
        public static Servicio traerServicio(string cod)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerServicio", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", cod);

            SqlDataReader reader;
            Servicio oServicio = null;
            cnn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                oServicio = new Servicio();
                oServicio.Ter_Codigo_Origen = (int)reader["Ter_Codigo_Origen"];
                oServicio.Ter_Codigo_Destino = (int)reader["Ter_Codigo_Destino"];
                //oServicio.Ser_FechaHora = (DateTime)reader["Ser_FechaHora"];
                oServicio.Ser_Estado = (String)reader["Ser_Estado"];
                oServicio.Aut_Codigo = (int)reader["Aut_Codigo"];

                return oServicio;
            }
            return null;
        }

        public static DataTable traerServicios()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerServicios", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        public static ObservableCollection<Servicio> traerServiciosCollection()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerServicios", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            ObservableCollection<Servicio> lista = new ObservableCollection<Servicio>();

            cnn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                Servicio oServicio = new Servicio();
                
                oServicio.Ser_Codigo = (int)reader["Ser_Codigo"];
                oServicio.Aut_Codigo = (int)reader["Aut_Codigo"];
                oServicio.Ser_FechaHora = (DateTime)reader["Ser_FechaHora"];
                oServicio.Ter_Codigo_Origen = (int)reader["Ter_Codigo_Origen"];
                oServicio.Ter_Codigo_Destino = (int)reader["Ter_Codigo_Destino"];
                oServicio.Ser_Estado = (string)reader["Ser_Estado"];

                oServicio.Ter_Origen = (string)reader["Terminal_Origen"];
                oServicio.Ter_Destino = (string)reader["Terminal_Destino"];
                oServicio.Emp_Nombre = (string)reader["Emp_Nombre"];
                oServicio.Emp_Telefono = (string)reader["Emp_Telefono"];
                oServicio.Emp_Direccion = (string)reader["Emp_Direccion"];
                oServicio.Emp_Email = (string)reader["Emp_Email"];
                oServicio.Aut_Capacidad = (int)reader["Aut_Capacidad"];
                oServicio.Aut_Matricula = (string)reader["Aut_Matricula"];
                oServicio.Aut_Pisos = (int)reader["Aut_CantidadPisos"];
                oServicio.Aut_TipoServicio = (string)reader["Aut_TipoServicio"];
                
                lista.Add(oServicio);
            }
            return lista;
        }

        public static ObservableCollection<Servicio> filtrarServiciosOrigen(int cod)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerServicioOrigen", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", cod);

            ObservableCollection<Servicio> lista = new ObservableCollection<Servicio>();

            cnn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                Servicio oServicio = new Servicio();

                oServicio.Ser_Codigo = (int)reader["Ser_Codigo"];
                oServicio.Aut_Codigo = (int)reader["Aut_Codigo"];
                oServicio.Ser_FechaHora = (DateTime)reader["Ser_FechaHora"];
                oServicio.Ter_Codigo_Origen = (int)reader["Ter_Codigo_Origen"];
                oServicio.Ter_Codigo_Destino = (int)reader["Ter_Codigo_Destino"];
                oServicio.Ser_Estado = (string)reader["Ser_Estado"];
                
                lista.Add(oServicio);
            }
            return lista;
        }

        public static Servicio traerPasajesServicio(int id) 
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerPasajesServicio", cnn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader;

            Servicio oServicio = null;

            cnn.Open();

            reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                oServicio = new Servicio();

                oServicio.Ser_Codigo = (int)reader["Ser_Codigo"];
                oServicio.Ser_FechaHora = (DateTime)reader["Ser_FechaHora"];
                oServicio.Ser_Estado = (string)reader["Ser_Estado"];
                oServicio.Ter_Origen = (string)reader["Terminal_Origen"];
                oServicio.Ter_Destino = (string)reader["Terminal_Destino"];

                return oServicio;   
            }
            return null;
        }

    }
}
