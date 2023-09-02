using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using DAL;


namespace Cargo_Project_Katmanlı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                Customers cust = new Customers();
                cust.NameSurname = textBox1.Text;
                cust.CustomerPW = textBox2.Text;
                cust.Adress = textBox3.Text;
                cust.Phone = textBox4.Text;
                cust.Mail = textBox5.Text;
                cust.PaymentStatus = textBox6.Text;
                cCrud.Add(cust); // ekleme metodu procdan geliyor

                dataGridView1.DataSource = cCrud.list(); // listeleme metodu procdan geliyor 

                MessageBox.Show("Müşteri  Ekleme Başarılı");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                Shipping shp = new Shipping();
                shp.ShippingName = textBox1.Text;
                shp.DeliveredLocation = textBox2.Text;
                shp.Distance = textBox3.Text;
                shp.TotalAmount = decimal.Parse(textBox4.Text);
                shp.EmployeeID = int.Parse(textBox5.Text);
                cCrud.AddShipment(shp);
                MessageBox.Show("Transfer Ekleme Başarılı");
                dataGridView1.DataSource = cCrud.ListShipment();
;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                Vehicles vehicle = new Vehicles();
                vehicle.VehicleName = textBox1.Text;
                vehicle.VehicleCapacity = textBox2.Text;
                vehicle.VehicleDriver = textBox3.Text;
                vehicle.VehicleExpense = decimal.Parse(textBox4.Text);
                vehicle.EmployeeID = int.Parse(textBox5.Text);
                cCrud.AddVehicles(vehicle);
                MessageBox.Show("Araç Ekleme Başarılı");
                dataGridView1.DataSource = cCrud.ListVehicles();

            }
            else
            {
                MessageBox.Show("Bir İşlem Kategorisi Seçiniz");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {


            dataGridView1.DataSource = cCrud.list();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                Customers cust = new Customers();
                cust.CustomerNo = Convert.ToInt32(textBox1.Tag);
                cust.NameSurname = textBox1.Text;
                cust.CustomerPW = textBox2.Text;
                cust.Adress = textBox3.Text;
                cust.Phone = textBox4.Text;
                cust.Mail = textBox5.Text;
                cust.PaymentStatus = textBox6.Text;
                cCrud.Update(cust);
                MessageBox.Show("Güncelleme Başarılı");
                dataGridView1.DataSource = cCrud.list();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                Shipping ship = new Shipping();
                ship.ShippingNo = Convert.ToInt32(textBox1.Tag);
                ship.ShippingName = textBox1.Text;
                ship.DeliveredLocation = textBox2.Text;
                ship.Distance = textBox3.Text;
                ship.TotalAmount = decimal.Parse(textBox4.Text);
                ship.EmployeeID = Convert.ToInt32(textBox5.Text);
                cCrud.UpShipment(ship);
                MessageBox.Show("Transfer Güncelleme Başarıyla Tamamlandı");
                dataGridView1.DataSource = cCrud.ListShipment();



            }
            else if (comboBox1.SelectedIndex == 3)
            {
                Vehicles vehicle = new Vehicles();

                vehicle.VehicleID = Convert.ToInt32(textBox1.Tag);
                vehicle.VehicleName = textBox1.Text;
                vehicle.VehicleCapacity = textBox2.Text;
                vehicle.VehicleDriver = textBox3.Text;
                vehicle.VehicleExpense = decimal.Parse(textBox4.Text);
                vehicle.EmployeeID = Convert.ToInt32(textBox5.Text);

                cCrud.UpVehicles(vehicle);
                MessageBox.Show("Araçlar Başarıyla Güncellendi");
                dataGridView1.DataSource= cCrud.ListVehicles(); 

                //DataGridViewRow row = dataGridView1.CurrentRow;
                //textBox1.Tag = row.Cells["Araç No"].Value.ToString();
                //textBox1.Text = row.Cells["Araç Adı"].Value.ToString();
                //textBox2.Text = row.Cells["Araç Kapasitesi"].Value.ToString();
                //textBox3.Text = row.Cells["Sürücü Adı"].Value.ToString();
                //textBox4.Text = row.Cells["Araç Harcaması"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Geçerli Bir İşlem Kategorisi Seçiniz");
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                ClearBoxes();
                DataGridViewRow column = dataGridView1.CurrentRow;
                textBox1.Tag = column.Cells["CustomerNo"].Value.ToString();
                textBox1.Text = column.Cells["NameSurname"].Value.ToString();
                textBox2.Text = column.Cells["CustomerPW"].Value.ToString();
                textBox3.Text = column.Cells["Adress"].Value.ToString();
                textBox4.Text = column.Cells["Phone"].Value.ToString();
                textBox5.Text = column.Cells["Mail"].Value.ToString();
                textBox6.Text = column.Cells["PaymentStatus"].Value.ToString();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                ClearBoxes();

                DataGridViewRow row = dataGridView1.CurrentRow;
                textBox1.Tag = row.Cells["Transfer No"].Value.ToString();
                textBox1.Text = row.Cells["Transfer Adı"].Value.ToString();
                textBox2.Text = row.Cells["Varış Yeri"].Value.ToString();
                textBox3.Text = row.Cells["Mesafe"].Value.ToString();
                textBox4.Text = row.Cells["Toplam Tutar"].Value.ToString();
                textBox5.Text = row.Cells["Sorumlu No"].Value.ToString();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                ClearBoxes();
                DataGridViewRow row = dataGridView1.CurrentRow;
                textBox1.Tag = row.Cells["Araç No"].Value.ToString();
                textBox1.Text = row.Cells["Araç Adı"].Value.ToString();
                textBox2.Text = row.Cells["Araç Kapasitesi"].Value.ToString();
                textBox3.Text = row.Cells["Sürücü Adı"].Value.ToString();
                textBox4.Text = row.Cells["Araç Harcaması"].Value.ToString();
                textBox5.Text = row.Cells["Sorumlu No"].Value.ToString();
            }
            else
            {
                MessageBox.Show("işlem tipi seçiniz");

            }



        }
        internal void ClearBoxes()
        {
            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                Customers cust = new Customers();
                cust.CustomerNo = Convert.ToInt32(textBox1.Tag);
                cCrud.Delete(cust);
                MessageBox.Show("Silme İşlemi Başarılı");
                dataGridView1.DataSource = cCrud.list();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                Shipping ship = new Shipping();
                ship.ShippingNo = Convert.ToInt32(textBox1.Tag);
                cCrud.DelShipping(ship);
                MessageBox.Show("Transfer Silme İşlemi Başarılı");
                dataGridView1.DataSource= cCrud.ListShipment();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                Vehicles vehicle = new Vehicles();
                vehicle.VehicleID = Convert.ToInt32(textBox1.Tag);
                cCrud.DelVehicles(vehicle);
                MessageBox.Show("Araç Silme İşlemi Başarılı");
                dataGridView1.DataSource =cCrud.ListVehicles();

            }
            else
            {
                MessageBox.Show("Silme İşlemi Başarısız, Lütfen Geçerli Bir İşlem Kategorisi Seçiniz");
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 2)
            {
                ClearBoxes();
                label4.Hide();
                textBox6.Hide();


                textBox5.Show();
                label5.Show();

                label1.Text = "Transfer Adı";
                label2.Text = "Varış Yeri";
                label3.Text = "Mesafe";
                label6.Text = "Toplam Tutar";
                label5.Text = "Sorumlu NO";


                dataGridView1.DataSource = cCrud.ListShipment();

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                ClearBoxes();

                label4.Show();
                label5.Show();

                textBox5.Show();
                textBox6.Show();

                label1.Text = "Adı Soyadı";
                label2.Text = "Şifre";
                label3.Text = "Adres";
                label6.Text = "Telefon";

                label5.Text = "Mail";

                dataGridView1.DataSource = cCrud.list();
            }
            else if (comboBox1.SelectedIndex == 3)
            {

                ClearBoxes();

                label5.Show();
                label4.Hide();

                textBox5.Show();
                textBox6.Hide();

                label1.Text = "Araç Adı";
                label2.Text = "Araç Kapasitesi";
                label3.Text = "Sürücü Adı";
                label6.Text = "Araç Harcaması";
                label5.Text = "Sorumlu NO";


                dataGridView1.DataSource = cCrud.ListVehicles();

            }
            else
            {
                ClearBoxes();
                MessageBox.Show("Bir İşlem Kategorisi Seçiniz");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            XmlQuerys xmlpage = new XmlQuerys();
            xmlpage.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            XmlQuerys xmlpage = new XmlQuerys();
            xmlpage.Show();
            this.Hide();
        }
    }
}
