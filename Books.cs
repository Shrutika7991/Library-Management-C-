using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookBiz_Distribution_Inc.DAL;
using BookBiz_Distribution_Inc.BLL;
using BookBiz_Distribution_Inc.Validation;
using System.IO;

namespace BookBiz_Distribution_Inc.GUI
{
    public partial class Books : Form
    {
        List<Book> listBooks = new List<Book>();
        public Books()
        {
            InitializeComponent();
            buttonListBooks.Enabled = true;
        }
        private void ClearAll()
        {
            foreach (var stud in this.Controls)
            {
                if (stud is TextBox)
                {
                    ((TextBox)stud).Text = String.Empty;
                }
            }

        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            if ((Validator.IsValidISBN(textBoxISBN)) && (Validator.IsValidName(textBoxTitle)) && (Validator.IsValidPrice(textBoxUnitPrice)) && (Validator.IsValidOption(comboBoxCategory)) && (Validator.IsValidOption(comboBoxPublishers)) && (Validator.IsValidYear(textBoxYearPublished)) && (Validator.IsValidQuantity(textBoxQuantityonHand)) && (Validator.IsValidID(textBoxAuthorID)) && (Validator.IsValidName(textBoxFirstName)) && (Validator.IsValidName(textBoxLastName)) && (Validator.IsValidEmail(textBoxEmail)) && Validator.IsUniqueBookID(listBooks, Convert.ToInt32(textBoxISBN.Text)))
            {

                Book book = new Book();

                //Add to the list
                book.ISBN = Convert.ToInt32(textBoxISBN.Text);
                book.Title = textBoxTitle.Text;
                book.UnitPrice = Convert.ToInt32(textBoxUnitPrice.Text);
                book.Category = comboBoxCategory.Text;
                book.Publisher = comboBoxPublishers.Text;
                book.YearPublished = Convert.ToInt32(textBoxYearPublished.Text);
                book.QuantityonHand = Convert.ToInt32(textBoxQuantityonHand.Text);
                book.AuthorID = Convert.ToInt32(textBoxAuthorID.Text);
                book.FirstName = textBoxFirstName.Text;
                book.LastName = textBoxLastName.Text;
                book.Email = textBoxEmail.Text;
                BookDAL.Save(book);
                listBooks.Add(book);
                buttonListBooks.Enabled = true;
                ClearAll();

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if ((Validator.IsValidISBN(textBoxISBN)) && (Validator.IsValidName(textBoxTitle)) && (Validator.IsValidPrice(textBoxUnitPrice)) && (Validator.IsValidOption(comboBoxCategory)) && (Validator.IsValidOption(comboBoxPublishers)) && (Validator.IsValidYear(textBoxYearPublished)) && (Validator.IsValidQuantity(textBoxQuantityonHand)) && (Validator.IsValidID(textBoxAuthorID)) && (Validator.IsValidName(textBoxFirstName)) && (Validator.IsValidName(textBoxLastName)) && (Validator.IsValidEmail(textBoxEmail)) && Validator.IsUniqueBookID(listBooks, Convert.ToInt32(textBoxISBN.Text)))
            {
                Book book = new Book();
                //string FilePath = Application.StartupPath + @"\Books.dat";
                //StreamWriter sWriter = new StreamWriter(FilePath,true);

                book.ISBN = Convert.ToInt32(textBoxISBN.Text);
                book.Title = textBoxTitle.Text;
                book.UnitPrice = Convert.ToInt32(textBoxUnitPrice.Text);
                book.Category = comboBoxCategory.Text;
                book.Publisher = comboBoxPublishers.Text;
                book.YearPublished = Convert.ToInt32(textBoxYearPublished.Text);
                book.QuantityonHand = Convert.ToInt32(textBoxQuantityonHand.Text);
                book.AuthorID = Convert.ToInt32(textBoxAuthorID.Text);
                book.FirstName = textBoxFirstName.Text;
                book.LastName = textBoxLastName.Text;
                book.Email = textBoxEmail.Text;
                BookDAL.Save(book);
                ClearAll();


            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonListBooks_Click(object sender, EventArgs e)
        {
            listViewBooks.Items.Clear();
            BookDAL.ListBooks(listViewBooks);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int search = comboBoxSearch.SelectedIndex;
            switch (search)
            {
                case -1: // The user didn't select any search option
                    MessageBox.Show("Please select the search option");
                    break;
                case 0: //The user selected the search by ISBN

                    Book book = BookDAL.Search(Convert.ToInt32(textBoxInput.Text));
                    if (book != null)
                    {
                        textBoxISBN.Text = (book.ISBN).ToString();
                        textBoxTitle.Text = book.Title;
                        textBoxUnitPrice.Text = (book.UnitPrice).ToString();
                        comboBoxCategory.Text = book.Category;
                        comboBoxPublishers.Text = book.Publisher;
                        textBoxYearPublished.Text = (book.YearPublished).ToString();
                        textBoxQuantityonHand.Text = (book.QuantityonHand).ToString();
                        textBoxAuthorID.Text = (book.AuthorID).ToString();
                        textBoxFirstName.Text = book.FirstName;
                        textBoxLastName.Text = book.LastName;
                        textBoxEmail.Text = book.Email;
                    }

                    else
                    {
                        MessageBox.Show("Book not Found!");
                        textBoxInput.Clear();
                        textBoxInput.Focus();
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
