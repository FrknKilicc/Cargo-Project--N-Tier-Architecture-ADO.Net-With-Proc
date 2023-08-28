using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace BL
{
    public class Tools
    {
        public static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Cargoo"].ToString());

        public static bool ConnectSet (SqlCommand Command)
        {
            try
            {
                if (Command.Connection.State != System.Data.ConnectionState.Open)
                    Command.Connection.Open();

                return Command.ExecuteNonQuery() > 0;  
            }
            catch
            {
                return false;

            }
            finally 
            {
                if (Command.Connection.State != System.Data.ConnectionState.Closed)
                    Command.Connection.Close ();
                
            }
        }
    }
}
