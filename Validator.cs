using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookBiz_Distribution_Inc.BLL;
using BookBiz_Distribution_Inc.DAL;
using System.IO;

namespace BookBiz_Distribution_Inc.Validation
{
    public static class Validator
    {
        private static string filePath = Application.StartupPath + @"\Books.dat";
        public static bool IsValidID(TextBox text)
        {
            int ID;
            if ((text.TextLength != 4) || !((Int32.TryParse(text.Text, out ID))))
            {
                MessageBox.Show("Invalid ID");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;

        }

        public static bool IsValidISBN(TextBox ISBN)
        {
            int ID;
            if ((ISBN.TextLength != 4) || !((Int32.TryParse(ISBN.Text, out ID))))
            {
                MessageBox.Show("Invalid ISBN");
                ISBN.Clear();
                ISBN.Focus();
                return false;
            }
            return true;

        }

        public static bool IsValidUserID(TextBox text)
        {
            int ID;
            if ((text.TextLength != 4) || !((Int32.TryParse(text.Text, out ID))))
            {
                MessageBox.Show("Invalid ID, Enter a 4 digit value");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;

        }

        public static bool IsValidID(string ID)
        {
            int TempID;
            if ((ID.Length != 5) || (!Int32.TryParse(ID, out TempID)))
            {
                MessageBox.Show("Invalid Id Enter a 5 digit value!! Enter Again");
                return false;
            }
            return true;
        }

        public static bool IsValidUserName(TextBox username)
        {
            for (int i = 0; i < username.TextLength; i++)
            {
                if ((char.IsDigit(username.Text, i)) || (char.IsWhiteSpace(username.Text, i)))
                {
                    MessageBox.Show("Invalid Username,Check Again!!");
                    username.Clear();
                    username.Focus();
                    return false;
                }
            }
            return true;

        }

        public static bool IsValidPassword(TextBox password)
        {


            if (password.TextLength != 4)
            {
                MessageBox.Show("Password Length Insufficient!!");
                password.Clear();
                password.Focus();
                return false;

            }
            return true;
        }

        public static bool IsValidEmail(TextBox text)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(text.Text))
                return (true);
            else
                MessageBox.Show("Invalid Email");
                return (false);
        }

        public static bool IsValidName(TextBox text)
        {
            for (int i = 0; i < text.TextLength; i++)
            {
                if (char.IsDigit(text.Text, i))
                {
                    MessageBox.Show("Invalid Title, Please enter book name.", "INVALID BOOK NAME");
                    text.Clear();
                    text.Focus();
                    return false;
                }

            }
            return true;
        }

        public static bool IsValidOption(ComboBox text)
        {
            if (text.SelectedItem == null)
            {
                MessageBox.Show("Invalid Item");
                text.Focus();
                return false;
            }
            return true;
        }

        public static bool CheckQuantity(TextBox ISBN, TextBox Quantity)
        {
            int QOH = BookDAL.getQOH(ISBN.Text);
            if ((Convert.ToInt32(Quantity.Text)) > QOH)
            {
                MessageBox.Show("Quantity exceeds.Not enough Stock!");
                Quantity.Clear();

                return false;

            }
            return true;

        }

        public static bool IsValidPrice(TextBox text)
        {
                int price;
                if (!((Int32.TryParse(text.Text, out price))))
                {
                    MessageBox.Show("Invalid Price, Please enter price.", "INVALID PRICE");
                    text.Clear();
                    text.Focus();
                    return false;
                }

            return true;

        }

        public static bool IsValidNum(TextBox text)
        {
            int num;
            if ((text.TextLength != 7) || !((Int32.TryParse(text.Text, out num))))
            {
                MessageBox.Show("Invalid value. Enter 7 digits", "Warning");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;

        }

        public static bool IsValidQuantity(TextBox text)
        {
            int num;
            if ((text.TextLength < 4) || !((Int32.TryParse(text.Text, out num))))
            {
                MessageBox.Show("Invalid value. Maximum 3 digits.", "Warning");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;

        }

        public static bool IsValidYear(TextBox text)
        {
            int num;
            int Year1 = int.Parse(text.Text);
            DateTime currentDate = DateTime.Today;
            int Year2 = int.Parse(currentDate.Year.ToString());
            if ((text.TextLength != 4 ) || !((Int32.TryParse(text.Text, out num))) || (Year1 >= Year2))
            {
                MessageBox.Show("Invalid year.", "INVALID YEAR");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;

        }

        public static bool IsUniqueBookID(List<Book> listBooks, int isbn)
        {
            foreach (Book b in listBooks)
            {
                if (b.ISBN == isbn)
                {
                    MessageBox.Show("Duplicate ISBN, please enter a unique one.");
                    return false;
                }
            }
            
            return true;
        }

        public static bool IsUniqueID(List<Client> listClients, int id)
        {
            foreach (Client c in listClients)
            {
                if (c.ClientID == id)
                {
                    MessageBox.Show("Duplicate ClientID, please enter a unique one.");
                    return false;
                }
            }
            return true;
        }

        public static bool IsUniqueID(List<Employee> listEmployees, int id)
        {
            foreach (Employee e in listEmployees)
            {
                if (e.UserID == id)
                {
                    MessageBox.Show("Duplicate EmployeeID, please enter a unique one.");
                    return false;
                }
            }
            return true;
        }
    }
}
