using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;


namespace BL
{
    public class cCrud
    {
        public static DataTable list()
        {
            SqlDataAdapter adp = new SqlDataAdapter("ListCustomer", Tools.con);
            adp.SelectCommand.CommandType = System.Data.CommandType.Text;
            DataTable dataTable = new DataTable();
            adp.Fill(dataTable);
            return dataTable;

        }
        public static bool Add(Customers cust)
        {
            SqlCommand cmd = new SqlCommand("AddCustomer", Tools.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NameSurname", cust.NameSurname);
            cmd.Parameters.AddWithValue("@Adress", cust.Adress);
            cmd.Parameters.AddWithValue("@Phone", cust.Phone);
            cmd.Parameters.AddWithValue("@Mail", cust.Mail);
            cmd.Parameters.AddWithValue("@PaymentStatus", cust.PaymentStatus);
            cmd.Parameters.AddWithValue("@CustomerPW", cust.CustomerPW);
            return Tools.ConnectSet(cmd);

        }
        public static bool Update(Customers cust)
        {
            SqlCommand con = new SqlCommand("UpCustomer", Tools.con);
            con.CommandType = CommandType.StoredProcedure;
            con.Parameters.AddWithValue("@CustomerNo", cust.CustomerNo);
            con.Parameters.AddWithValue("@NameSurname", cust.NameSurname);
            con.Parameters.AddWithValue("@Adress", cust.Adress);
            con.Parameters.AddWithValue("@Phone", cust.Phone);
            con.Parameters.AddWithValue("@Mail", cust.Mail);
            con.Parameters.AddWithValue("@PaymentStatus", cust.PaymentStatus);
            con.Parameters.AddWithValue("@CustomerPW", cust.CustomerPW);
            return Tools.ConnectSet(con);

        }

        public static bool Delete(Customers cust)
        {
            SqlCommand con = new SqlCommand("DelCustomer",Tools.con);
            con.CommandType = CommandType.StoredProcedure;
            con.Parameters.AddWithValue("@CustomerNo", cust.CustomerNo);
            return Tools.ConnectSet(con);




        }
    }
}
