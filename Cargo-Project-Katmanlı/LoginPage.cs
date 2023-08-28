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

        }

        private void button1_Click(object sender, EventArgs e)
        {    
            Form1 pages = new Form1();
            Employees emp = new Employees();
            emp.Mail = textBox1.Text;
            emp.EmployeePW = textBox2.Text;
       
            //MessageBox.Show(EmpLogin.EmployeesLogin(emp).ToString());
 

            //MessageBox.Show("Giriş Başarılı");
            //pages.Show();
            //this.Hide();



            if (EmpLogin.EmployeesLogin(emp))
            {
                MessageBox.Show("Giriş Başarılı");
                pages.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Başarısız");
            }




        }
    }
}
