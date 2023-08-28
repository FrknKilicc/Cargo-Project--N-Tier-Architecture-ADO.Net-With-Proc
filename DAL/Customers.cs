using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Customers
    {
        public int CustomerNo { get; set; }
        public string NameSurname { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string PaymentStatus { get; set; }
        public string CustomerPW { get; set; }
    }
}
