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
    public partial class Clients : Form
    {
        List<Client> listClients = new List<Client>();
        public Clients()
        {
            InitializeComponent();
            buttonListCLients.Enabled = true;
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

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            Client cli = new Client();
            if ((Validator.IsValidID(textBoxClientID)) && (Validator.IsValidName(textBoxClientName)) && (Validator.IsValidName(textBoxStreet)) && (Validator.IsValidName(textBoxCity)) && (Validator.IsValidName(textBoxPostalCode)) && (Validator.IsValidNum(textBoxFaxNumber)) && (Validator.IsValidNum(textBoxCreditLimit)) && Validator.IsUniqueID(listClients, Convert.ToInt32(textBoxClientID.Text)))
            {
                cli.ClientID = Convert.ToInt32(textBoxClientID.Text);
                cli.ClientName = textBoxClientName.Text;
                cli.Street = textBoxStreet.Text;
                cli.City = textBoxCity.Text;
                cli.PostalCode = textBoxPostalCode.Text;
                cli.PhoneNumber = maskedTextBoxPhoneNumber.Text;
                cli.FaxNumber = Convert.ToInt32(textBoxFaxNumber.Text);
                cli.CreditLimit = Convert.ToInt32(textBoxCreditLimit.Text);
                //Add to the list
                BookDAL.Save(cli);
                listClients.Add(cli);
                buttonListCLients.Enabled = true;
                ClearAll();

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if ((Validator.IsValidID(textBoxClientID)) && (Validator.IsValidName(textBoxClientName)) && (Validator.IsValidName(textBoxStreet)) && (Validator.IsValidName(textBoxCity)) && (Validator.IsValidName(textBoxPostalCode)) && (Validator.IsValidNum(textBoxFaxNumber)) && (Validator.IsValidNum(textBoxCreditLimit)) && Validator.IsUniqueID(listClients, Convert.ToInt32(textBoxClientID.Text)))
            {
                Client cli = new Client();
                //string FilePath = Application.StartupPath + @"\Books.dat";
                //StreamWriter sWriter = new StreamWriter(FilePath,true);

                cli.ClientID = Convert.ToInt32(textBoxClientID.Text);
                cli.ClientName = textBoxClientName.Text;
                cli.Street = textBoxStreet.Text;
                cli.City = textBoxCity.Text;
                cli.PostalCode = textBoxPostalCode.Text;
                cli.PhoneNumber = maskedTextBoxPhoneNumber.Text;
                cli.FaxNumber = Convert.ToInt32(textBoxFaxNumber.Text);
                cli.CreditLimit = Convert.ToInt32(textBoxCreditLimit.Text);
                BookDAL.Save(cli);
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
                    Client cli = BookDAL.SearchCLient(Convert.ToInt32(textBoxInput.Text));
                    if (cli != null)
                    {
                        textBoxClientID.Text = (cli.ClientID).ToString();
                        textBoxClientName.Text = cli.ClientName;
                        textBoxStreet.Text = cli.Street;
                        textBoxCity.Text = cli.City;
                        textBoxPostalCode.Text = cli.PostalCode;
                        maskedTextBoxPhoneNumber.Text = cli.PhoneNumber;
                        textBoxFaxNumber.Text = (cli.FaxNumber).ToString();
                        textBoxCreditLimit.Text = (cli.CreditLimit).ToString();
                    }

                    else
                    {
                        MessageBox.Show("Client not Found!");
                        textBoxInput.Clear();
                        textBoxInput.Focus();
                    }
                    break;
                default:
                    break;

            }
        }

        private void buttonListCLients_Click(object sender, EventArgs e)
        {
            listViewClients.Items.Clear();
            BookDAL.ListClients(listViewClients);
        }
    }
}
