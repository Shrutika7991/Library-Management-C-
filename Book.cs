using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBiz_Distribution_Inc.BLL
{
    public class Book
    {
        //For Login 
        public string UserName { get; set; }
        public string Password { get; set; }

        //For Books.cs Form
        public int ISBN { get; set; }
        public string Title { get; set; }
        public int UnitPrice { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
        public int YearPublished { get; set; }
        public int QuantityonHand { get; set; }
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
