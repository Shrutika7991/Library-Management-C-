using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookBiz_Distribution_Inc.BLL;
using BookBiz_Distribution_Inc.DAL;
using BookBiz_Distribution_Inc.Validation;

namespace BookBiz_Distribution_Inc.GUI
{
    public partial class OrderClerks : Form
    {
        public OrderClerks()
        {
            InitializeComponent();
            BookDAL.GetClientID(comboBoxClientID);
            BookDAL.GetISBN(comboBoxISBN);
            BookDAL.GetPhoneNumber(comboBoxPhoneNumber);
            BookDAL.GetPublisherID(comboBoxPublisherName);
            BookDAL.GetAuthorID(comboBoxAuthorID);

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            OrderClerk order = new OrderClerk();
            if ((Validator.IsValidID(Convert.ToString(textBoxOrderID.Text))) && (Validator.IsValidEmail(textBoxEmail)) && Validator.IsValidQuantity(textBoxQuantity))
            {

                order.OrderId = Convert.ToInt32(textBoxOrderID.Text);
                order.ClientId = Convert.ToInt32(comboBoxClientID.SelectedItem);
                order.ISBN = Convert.ToString(comboBoxISBN.SelectedItem);
                order.AuthorId = Convert.ToInt32(comboBoxAuthorID.SelectedItem);
                order.Quantity = Convert.ToInt32(textBoxQuantity.Text);
                order.PhoneNumber = Convert.ToString(comboBoxPhoneNumber.SelectedItem);
                order.PublisherName = comboBoxPublisherName.Text;
                order.Email = textBoxEmail.Text;
                BookDAL.AddOrder(order);
                textBoxOrderID.Clear();
                textBoxQuantity.Clear();


            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxOrderID.Clear();
            textBoxQuantity.Clear();

        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            BookDAL.DeleteOrder(Convert.ToInt32(textBoxOrderID.Text));
            MessageBox.Show("order cancelled");
        }

        private void buttonSearch_Click_1(object sender, EventArgs e)
        {

            OrderClerk order = BookDAL.SearchOrder(Convert.ToInt32(textBoxInput.Text));
            if (order != null)
            {
                MessageBox.Show("Order Found");
                textBoxOrderID.BackColor = Color.White;
                textBoxOrderID.Text = Convert.ToString(order.OrderId);
                comboBoxClientID.SelectedItem = order.ClientId;
                comboBoxISBN.SelectedItem = order.ISBN;
                comboBoxAuthorID.SelectedItem = order.AuthorId;
                textBoxQuantity.Text = Convert.ToString(order.Quantity);
                comboBoxPhoneNumber.SelectedItem = order.PhoneNumber;
                comboBoxPublisherName.SelectedItem = order.PublisherName;
                textBoxEmail.Text = order.Email;
            }
            else
            {
                MessageBox.Show("Order not Found!!");
                textBoxOrderID.Clear();
                textBoxOrderID.Focus();
            }
        }

        private void buttonListOrders_Click(object sender, EventArgs e)
        {
            listViewOrders.Items.Clear();
            BookDAL.ListOrders(listViewOrders);
            MessageBox.Show("Orders Listed");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            OrderClerk order = new OrderClerk();
            if ((Validator.IsValidID(Convert.ToString(textBoxOrderID.Text))) && (Validator.IsValidEmail(textBoxEmail)) && Validator.IsValidQuantity(textBoxQuantity))
            {

                order.OrderId = Convert.ToInt32(textBoxOrderID.Text);
                order.ClientId = Convert.ToInt32(comboBoxClientID.SelectedItem);
                order.ISBN = Convert.ToString(comboBoxISBN.SelectedItem);
                order.AuthorId = Convert.ToInt32(comboBoxAuthorID.SelectedItem);
                order.Quantity = Convert.ToInt32(textBoxQuantity.Text);
                order.PhoneNumber = Convert.ToString(comboBoxPhoneNumber.SelectedItem);
                order.PublisherName = comboBoxPublisherName.Text;
                order.Email = textBoxEmail.Text;
                BookDAL.AddOrder(order);
                textBoxOrderID.Clear();
                textBoxQuantity.Clear();


            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            BookDAL.DeleteOrder(Convert.ToInt32(textBoxInput.Text));
            MessageBox.Show("order cancelled");
        }
    }
}
