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
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement root = xmlDocument.CreateElement("Shipping");

            SqlConnection con = new SqlConnection("Server=DESKTOP-38T2N6J;Database=Cargo;Integrated Security = true ;");
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
    }
}
