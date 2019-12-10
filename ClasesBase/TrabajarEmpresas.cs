using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarEmpresas
    {

        public static DataTable traerEmpresas()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerEmpresas", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        public static void agregarEmpresa(Empresa c)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("agregarEmpresa", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", c.Emp_Nombre);
            cmd.Parameters.AddWithValue("@direccion", c.Emp_Direccion);
            cmd.Parameters.AddWithValue("@telefono", c.Emp_Telefono);
            cmd.Parameters.AddWithValue("@email", c.Emp_Email);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void actualizarEmpresa(Empresa c)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("actualizarEmpresa", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", c.Emp_Codigo);
            cmd.Parameters.AddWithValue("@nombre", c.Emp_Nombre);
            cmd.Parameters.AddWithValue("@direccion", c.Emp_Direccion);
            cmd.Parameters.AddWithValue("@telefono", c.Emp_Telefono);
            cmd.Parameters.AddWithValue("@email", c.Emp_Email);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void eliminarEmpresa(int cod)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("eliminarEmpresa", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", cod);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
