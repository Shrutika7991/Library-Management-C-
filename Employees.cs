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
    public partial class Employees : Form
    {
        List<Employee> listEmployees = new List<Employee>();
        public Employees()
        {
            InitializeComponent();
            buttonListUsers.Enabled = true;
        }

        private void ClearAll()
        {
            foreach (var stud in this.Controls)
            {
                if (stud is TextBox)
                {
                    ((TextBox)stud).Text = String.Empty;
                } else if (stud is MaskedTextBox)
                {
                    ((MaskedTextBox)stud).Text = String.Empty;
                }
            }

        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            if ((Validator.IsValidUserID(textBoxUserID)) && (Validator.IsValidName(textBoxFirstName)) && (Validator.IsValidName(textBoxLastName)) && (Validator.IsValidID(textBoxPassword)) && Validator.IsUniqueID(listEmployees, Convert.ToInt32(textBoxUserID.Text)))
            {
                emp.UserID = Convert.ToInt32(textBoxUserID.Text);
                emp.FirstName = textBoxFirstName.Text;
                emp.LastName = textBoxLastName.Text;
                emp.Position = comboBoxPosition.Text;
                emp.PhoneNumber = maskedTextBoxPhoneNumber.Text;
                emp.Password = Convert.ToInt32(textBoxPassword.Text);
                //Add to the list
                BookDAL.Save(emp);
                listEmployees.Add(emp);
                buttonListUsers.Enabled = true;
                ClearAll();

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if ((Validator.IsValidID(textBoxUserID)) && (Validator.IsValidName(textBoxFirstName)) && (Validator.IsValidName(textBoxLastName)) && (Validator.IsValidID(textBoxPassword)) && Validator.IsUniqueID(listEmployees, Convert.ToInt32(textBoxUserID.Text)))
            {
                Employee emp = new Employee();
                //string FilePath = Application.StartupPath + @"\Books.dat";
                //StreamWriter sWriter = new StreamWriter(FilePath,true);

                emp.UserID = Convert.ToInt32(textBoxUserID.Text);
                emp.FirstName = textBoxFirstName.Text;
                emp.LastName = textBoxLastName.Text;
                emp.Position = comboBoxPosition.Text;
                emp.PhoneNumber = maskedTextBoxPhoneNumber.Text;
                emp.Password = Convert.ToInt32(textBoxPassword.Text);
                BookDAL.Save(emp);
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

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int search = comboBoxSearch.SelectedIndex;
            switch (search)
            {
                case -1: // The user didn't select any search option
                    MessageBox.Show("Please select the search option");
                    break;
                case 0: //The user selected the search by Customer ID
                    Employee emp = BookDAL.SearchEmployee(Convert.ToInt32(textBoxInput.Text));
                    if (emp != null)
                    {
                        textBoxUserID.Text = (emp.UserID).ToString();
                        textBoxFirstName.Text = emp.FirstName;
                        textBoxLastName.Text = emp.LastName;
                        comboBoxPosition.Text = emp.Position;
                        maskedTextBoxPhoneNumber.Text = emp.PhoneNumber;
                        textBoxPassword.Text = (emp.Password).ToString();
                    }

                    else
                    {
                        MessageBox.Show("User not Found!");
                        textBoxInput.Clear();
                        textBoxInput.Focus();
                    }
                    break;
                default:
                    break;

            }
        }

        private void buttonListUsers_Click(object sender, EventArgs e)
        {
            listViewUsers.Items.Clear();
            BookDAL.ListEmployees(listViewUsers);
        }

    }
}
