using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBiz_Distribution_Inc.BLL
{
    public class Employee
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string PhoneNumber {get; set;}
        public int Password { get; set; }
        public string Email { get; set; }
    }
}
