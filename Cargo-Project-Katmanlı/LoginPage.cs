using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using DAL;

namespace Cargo_Project_Katmanlı
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            Employees personel = new Employees();
            personel.Mail = textBox1.Text;
            personel.EmployeePW = textBox2.Text;

            if (cCrud.uLogin(personel) == 1)
            {
                MessageBox.Show("giriş başarılı");
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("giriş başarısız");
                textBox1.Clear();
                textBox2.Clear();

            }




        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                panel1.Visible = false;


            }
            else if (radioButton2.Checked == true)
            {
                panel1.Visible = true;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                panel1.Visible = false;


            }
            else if (radioButton2.Checked == true)
            {
                panel1.Visible = true;
            }

        }
    }
}
