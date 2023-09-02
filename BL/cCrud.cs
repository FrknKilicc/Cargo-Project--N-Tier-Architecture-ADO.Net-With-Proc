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
        public static bool AddShipment(Shipping Ship)
        {
            SqlCommand cmd = new SqlCommand("AddShipment", Tools.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ShippingName", Ship.ShippingName);
            cmd.Parameters.AddWithValue("@DeliveredLocation", Ship.DeliveredLocation);
            cmd.Parameters.AddWithValue("@Distance", Ship.Distance);
            cmd.Parameters.AddWithValue("@TotalAmount", Ship.TotalAmount);
            cmd.Parameters.AddWithValue("@EmployeeID", Ship.EmployeeID);
            return Tools.ConnectSet(cmd);
        }
        public static bool AddVehicles(Vehicles vch)
        {
            SqlCommand cmd = new SqlCommand("AddVehicles", Tools.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VehicleName", vch.VehicleName);
            cmd.Parameters.AddWithValue("@VehicleCapacity", vch.VehicleCapacity);
            cmd.Parameters.AddWithValue("@VehicleDriver", vch.VehicleDriver);
            cmd.Parameters.AddWithValue("@VehicleExpense", vch.VehicleExpense);
            cmd.Parameters.AddWithValue("@EmployeeID", vch.EmployeeID);
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
        public static bool UpVehicles(Vehicles vhc)
        {
            SqlCommand command = new SqlCommand("UpVehicles", Tools.con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@VehicleID", vhc.VehicleID);
            command.Parameters.AddWithValue("@VehicleName", vhc.VehicleName);
            command.Parameters.AddWithValue("@VehicleCapacity", vhc.VehicleCapacity);
            command.Parameters.AddWithValue("@VehicleDriver", vhc.VehicleDriver);
            command.Parameters.AddWithValue("@VehicleExpense", vhc.VehicleExpense);
            command.Parameters.AddWithValue("@EmployeeID", vhc.EmployeeID);
            return Tools.ConnectSet(command);
        }

        public static bool UpShipment(Shipping Shipment)
        {
            SqlCommand command = new SqlCommand("UpShipment", Tools.con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ShippingNo", Shipment.ShippingNo);
            command.Parameters.AddWithValue("@ShippingName",Shipment.ShippingName);
            command.Parameters.AddWithValue("@DeliveredLocation",Shipment.DeliveredLocation);
            command.Parameters.AddWithValue("@Distance",Shipment.Distance);
            command.Parameters.AddWithValue("@TotalAmount",Shipment.TotalAmount);
            command.Parameters.AddWithValue("@EmployeeID", Shipment.EmployeeID);
            return Tools.ConnectSet(command);

        }

        public static bool Delete(Customers cust)
        {
            SqlCommand con = new SqlCommand("DelCustomer", Tools.con);
            con.CommandType = CommandType.StoredProcedure;
            con.Parameters.AddWithValue("@CustomerNo", cust.CustomerNo);
            return Tools.ConnectSet(con);




        }
        public static bool DelVehicles(Vehicles Vhc)
        {
            SqlCommand command = new SqlCommand("DelVehicles", Tools.con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@VehicleID", Vhc.VehicleID);
            return Tools.ConnectSet(command);
        }
        public static bool DelShipping(Shipping shipment)
        {
            SqlCommand sqlCommand = new SqlCommand("DelShipping", Tools.con);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ShippingNo", shipment.ShippingNo);
            return Tools.ConnectSet(sqlCommand);

        }
        public static DataTable ListShipment()
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ListShipment", Tools.con);
            sqlDataAdapter.SelectCommand.CommandType = System.Data.CommandType.Text;
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt;

        }
        public static DataTable ListVehicles()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("ListVehicles", Tools.con);
            adapter.SelectCommand.CommandType = System.Data.CommandType.Text;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public static int uLogin(Employees personel)
        {
            SqlDataAdapter adp = new SqlDataAdapter("Emplogin", Tools.con);
            adp.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

            adp.SelectCommand.Parameters.AddWithValue("@username", personel.Mail);
            adp.SelectCommand.Parameters.AddWithValue("@Password", personel.EmployeePW);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }


        }

    }
}
