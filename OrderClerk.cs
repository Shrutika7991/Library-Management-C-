using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBiz_Distribution_Inc.BLL
{
    public class OrderClerk
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public string PhoneNumber { get; set; }
        public string PublisherName { get; set; }
        public int Quantity { get; set; }
        public string Email { get; set; }

    }
}
