using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarRoles
    {
        public static DataTable traerRoles()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cadena);

            SqlCommand cmd = new SqlCommand("traerRoles", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
           

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            return dt;
        }
    }
}
