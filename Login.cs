using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookBiz_Distribution_Inc.Validation;
using BookBiz_Distribution_Inc.BLL;
using BookBiz_Distribution_Inc.GUI;
using BookBiz_Distribution_Inc.DAL;

namespace BookBiz_Distribution_Inc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if ((textBoxUserName.Text == "PeterWang") && (Validator.IsValidUserName(textBoxUserName)) && (textBoxPassword.Text == "1111") && (Validator.IsValidPassword(textBoxPassword)))
            {
                MessageBox.Show("Welcome to Book Biz ,Manager");

                Books emp = new Books();
                emp.ShowDialog();
            }
            else if ((textBoxUserName.Text == "ThomasMoore") && (Validator.IsValidUserName(textBoxUserName)) && (textBoxPassword.Text == "2222") && (Validator.IsValidPassword(textBoxPassword)))
            {
                MessageBox.Show("Welcome to Book Biz ,Clients");

                Clients cli = new Clients();
                cli.ShowDialog();
            }
            else if ((textBoxUserName.Text == "HenryBrown") && (Validator.IsValidUserName(textBoxUserName)) && (textBoxPassword.Text == "3333") && (Validator.IsValidPassword(textBoxPassword)))
            {
                MessageBox.Show("Welcome to Book Biz , Book Data");

                Employees book = new Employees();
                book.ShowDialog();
            }
            else if ((textBoxUserName.Text == "MaryBrown") && (Validator.IsValidUserName(textBoxUserName)) && (textBoxPassword.Text == "4444") && (Validator.IsValidPassword(textBoxPassword)))
            {
                MessageBox.Show("Welcome to Book Biz , Order Clerks");

                OrderClerks order = new OrderClerks();
                order.ShowDialog();
            }
            else if ((textBoxUserName.Text == "JenniferBouchard") && (Validator.IsValidUserName(textBoxUserName)) && (textBoxPassword.Text == "5555") && (Validator.IsValidPassword(textBoxPassword)))
            {
                MessageBox.Show("Welcome to Book Biz ,Order Clerks");

                OrderClerks order = new OrderClerks();
                order.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!!", "Warning");

            }
        }
    }
}
