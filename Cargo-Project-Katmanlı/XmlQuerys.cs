using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BL;
using System.Data.SqlClient;
using System.Xml;

namespace Cargo_Project_Katmanlı
{
    public partial class XmlQuerys : Form
    {
        public XmlQuerys()
        {
            InitializeComponent();
        }

        private void XmlQuerys_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement root = xmlDocument.CreateElement("Shipping");

            SqlConnection con = new SqlConnection("Server=FURKAN\\FURKANKILIC;Database=Cargo;Integrated Security = true ;");
            SqlCommand sqlCommand = new SqlCommand("select*from Shipping", con);
            con.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                XmlElement shipping = xmlDocument.CreateElement("Shipment");
                XmlAttribute Shipping_Name = xmlDocument.CreateAttribute("Shipping_Name");
                Shipping_Name.Value = reader["ShippingName"].ToString();

                XmlAttribute Delivered_Location = xmlDocument.CreateAttribute("Delivered_Location");
                Delivered_Location.Value = reader["DeliveredLocation"].ToString();
                XmlAttribute Delivered_Location1 = xmlDocument.CreateAttribute("Delivered_Location");
                Delivered_Location.Value = reader["DeliveredLocation"].ToString();


                XmlAttribute ShippingNumber = xmlDocument.CreateAttribute("ShippingNumber");
                ShippingNumber.Value = reader["ShippingNo"].ToString();

                shipping.Attributes.Append(Shipping_Name);
                shipping.Attributes.Append(Delivered_Location);
                shipping.Attributes.Append(ShippingNumber);
                root.AppendChild(shipping);
            }
            con.Close();
            xmlDocument.AppendChild(root);

            xmlDocument.Save("Shipping.XML");
            MessageBox.Show("Kayıt Başarılı");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement root = xmlDocument.CreateElement("Customers");

            SqlConnection con = new SqlConnection("Server=FURKAN\\FURKANKILIC;Database=Cargo;Integrated Security = true ;");
            SqlCommand command = new SqlCommand("select* from Customers",con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                XmlElement Customer = xmlDocument.CreateElement("Customers");

                XmlAttribute Customer_NO = xmlDocument.CreateAttribute("Customer_No");
                Customer_NO.Value = reader["CustomerNo"].ToString();

                XmlAttribute Customer_Name = xmlDocument.CreateAttribute("Customer_Name");
                Customer_Name.Value = reader["NameSurname"].ToString();

                XmlAttribute Customer_Adress = xmlDocument.CreateAttribute("Customer_Adress");
                Customer_Adress.Value = reader["Adress"].ToString();

                XmlAttribute Customer_Phone = xmlDocument.CreateAttribute("Customer_Phone");
                Customer_Phone.Value = reader["Phone"].ToString();

                XmlAttribute Customer_Mail = xmlDocument.CreateAttribute("Customer_Mail");
                Customer_Mail.Value = reader["Mail"].ToString();

                XmlAttribute Customer_Payment_Status = xmlDocument.CreateAttribute("Customer_Payment_Status");
                Customer_Payment_Status.Value = reader["PaymentStatus"].ToString();

                Customer.Attributes.Append(Customer_NO);
                Customer.Attributes.Append(Customer_Name);
                Customer.Attributes.Append(Customer_Adress);
                Customer.Attributes.Append(Customer_Phone);
                Customer.Attributes.Append(Customer_Mail);
                Customer.Attributes.Append(Customer_Payment_Status);
                root.AppendChild(Customer);


            }
            con.Close();
            xmlDocument.AppendChild(root);
            xmlDocument.Save("Customer.XML");
            MessageBox.Show("Kayıt Başarıyla Oluşturuldu.");


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement root = xmlDocument.CreateElement("Vehicles");

            SqlConnection sqlConnection = new SqlConnection("Server=FURKAN\\FURKANKILIC;Database=Cargo;Integrated Security = true ;");
            SqlCommand sqlCommand = new SqlCommand("Select*from vehicles",sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                XmlElement Vehicles = xmlDocument.CreateElement("Vehicless");

                XmlAttribute VehicleIdenty = xmlDocument.CreateAttribute("VehicleIdenty");
                VehicleIdenty.Value = reader["VehicleID"].ToString();

                XmlAttribute VehicleName = xmlDocument.CreateAttribute("VehicleName");
                VehicleName.Value = reader["VehicleName"].ToString();

                XmlAttribute VehicleDriver = xmlDocument.CreateAttribute("VehicleDriver");
                VehicleDriver.Value = reader["VehicleDriver"].ToString();

                XmlAttribute VehicleCapacity_KG = xmlDocument.CreateAttribute("VehicleCapacity_KG");
                VehicleCapacity_KG.Value = reader["VehicleDriver"].ToString();

                XmlAttribute VehicleExpense_Dolar = xmlDocument.CreateAttribute("VehicleExpense_Dolar");
                VehicleExpense_Dolar.Value = reader["VehicleExpense"].ToString();

                XmlAttribute EmployeIdenty = xmlDocument.CreateAttribute("EmployeIdenty");
                EmployeIdenty.Value = reader["EmployeeID"].ToString();

                Vehicles.Attributes.Append(VehicleIdenty);
                Vehicles.Attributes.Append(VehicleName);
                Vehicles.Attributes.Append(VehicleDriver);
                Vehicles.Attributes.Append(VehicleCapacity_KG);
                Vehicles.Attributes.Append(VehicleExpense_Dolar);
                Vehicles.Attributes.Append(EmployeIdenty);
                root.AppendChild(Vehicles);



            }
            xmlDocument.AppendChild(root);
            xmlDocument.Save("Vehicles.XML");
            MessageBox.Show("Kayıt Başarıyla Oluşturuldu");

        }
    }
}
