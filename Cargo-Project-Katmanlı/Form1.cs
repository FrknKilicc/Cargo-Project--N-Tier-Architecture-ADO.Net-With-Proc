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
            Customers cust = new Customers();
            cust.NameSurname = textBox1.Text;
            cust.CustomerPW = textBox2.Text;
            cust.Adress = textBox3.Text;
            cust.Phone = textBox4.Text;
            cust.Mail = textBox5.Text;
            cust.PaymentStatus = textBox6.Text;
            cCrud.Add(cust); // ekleme metodu procdan geliyor
            MessageBox.Show("Ekleme İşlemi Başarılı");
            dataGridView1.DataSource = cCrud.list(); // listeleme metodu procdan geliyor 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customers cust = new Customers();

           dataGridView1.DataSource = cCrud.list();

        }

        private void button3_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow column = this.dataGridView1.CurrentRow;
            textBox1.Tag = column.Cells["CustomerNo"].Value.ToString();
            textBox1.Text = column.Cells["NameSurname"].Value.ToString();
            textBox2.Text = column.Cells["CustomerPW"].Value.ToString();
            textBox3.Text = column.Cells["Adress"].Value.ToString();
            textBox4.Text = column.Cells["Phone"].Value.ToString();
            textBox5.Text = column.Cells["Mail"].Value.ToString();
            textBox6.Text = column.Cells["PaymentStatus"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Customers cust = new Customers();
            cust.CustomerNo = Convert.ToInt32(textBox1.Tag);
            cCrud.Delete(cust);
            MessageBox.Show("Silme İşlemi Başarılı");
            dataGridView1.DataSource = cCrud.list();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
