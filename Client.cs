using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBiz_Distribution_Inc.BLL
{
    public class Client
    {
        //For Client.cs Form
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public int FaxNumber { get; set; }
        public int CreditLimit { get; set; }
    }
}
