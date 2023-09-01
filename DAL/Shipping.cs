using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Shipping
    {
        public int ShippingNo { get; set; }
        public string ShippingName { get; set; }
        public string DeliveredLocation { get; set; }
        public string Distance { get; set; }
        public decimal TotalAmount { get; set; }
        public int EmployeeID { get; set; }
    }
}
