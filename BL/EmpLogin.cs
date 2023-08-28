using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using DAL;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Net;
using Microsoft.Win32.SafeHandles;
//using System.Data.SqlClient;

namespace BL
{
    public class EmpLogin
    {
       
        public static bool EmployeesLogin(Employees emp)
        {
            SqlConnection coon = new SqlConnection("Server=DESKTOP-38T2N6J;Database=Cargo;Integrated Security=true");
            SqlCommand con = new SqlCommand("LoginEmployee",coon);
            //SqlCommand con = new SqlCommand();
            //con.Connection = coon
        
            con.CommandType = CommandType.StoredProcedure;    
            coon.Open();
            con.Parameters.AddWithValue("@Mail", emp.Mail);
            con.Parameters.AddWithValue("@EmployeePW", emp.EmployeePW);
            
            con.ExecuteNonQuery();
       
            SqlDataReader reader = con.ExecuteReader();
       
            if (reader.Read())
            { 
                
               
                return true;

            }
            else
            {
                return false;
            }
            coon.Close();

           
        }
        public static bool employeesLogin2(SqlDataReader sqlDataReader)
        {
            if (sqlDataReader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
