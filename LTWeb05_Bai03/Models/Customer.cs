using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb05_Bai03.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Tel { get; set; }
        public string Gender { get; set; }
        public string Hobby { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}