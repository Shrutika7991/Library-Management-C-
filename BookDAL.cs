using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBiz_Distribution_Inc.BLL;
using System.Windows.Forms;
using System.IO;

namespace BookBiz_Distribution_Inc.DAL
{
    public static class BookDAL
    {
        private static string filePath1 = Application.StartupPath + @"\Employees.dat";
        private static string filePath2 = Application.StartupPath + @"\Client.dat";
        private static string filePath3 = Application.StartupPath + @"\Books.dat";
        private static string filePath4 = Application.StartupPath + @"\Orders.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Save(Book book)
        {
                StreamWriter sWriter = new StreamWriter(filePath3, true);
                sWriter.WriteLine(book.ISBN + "," + book.Title + "," + book.UnitPrice + "," + book.Category + "," + book.Publisher + "," + book.YearPublished + "," + book.QuantityonHand + "," + book.AuthorID + "," + book.FirstName + "," + book.LastName + "," + book.Email);
                sWriter.Close();
                MessageBox.Show("Book Data has been saved.");
        }

        public static void ListBooks(ListView listViewBooks)
        {
            //step 1: Create an object of type StreamReader
            StreamReader sReader = new StreamReader(filePath3);
            listViewBooks.Items.Clear();

            // Step 2: Read the file until teh end of the file
                     
            string line = sReader.ReadLine();                           //- Read line by line
            while (line != null)
            {
                string[] fields = line.Split(',');                      //- Split the line into an array of string based on seperator
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);                           // - Add data to the listView control
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                item.SubItems.Add(fields[5]);
                item.SubItems.Add(fields[6]);
                item.SubItems.Add(fields[7]);
                item.SubItems.Add(fields[8]);
                item.SubItems.Add(fields[9]);
                item.SubItems.Add(fields[10]);
                listViewBooks.Items.Add(item);
                line = sReader.ReadLine();                              // Attention : read the next line
            }
            sReader.Close();
        }

        public static List<Book> ListBooks()
        {
            List<Book> listBooks = new List<Book>();
            //step 1: Create an object of type StreamReader
            StreamReader sReader = new StreamReader(filePath3);
            // Step 2: Read the file until teh end of the file
            
            string line = sReader.ReadLine();                           //- Read line by line
            while (line != null)
            {
                string[] fields = line.Split(',');                      //- Split the line into an array of string based on seperator
                Book book = new Book();
                book.ISBN = Convert.ToInt32(fields[0]);                 // - Add data to the listView control
                book.Title = fields[1];
                book.UnitPrice = Convert.ToInt32(fields[2]);
                book.Category = fields[3];
                book.Publisher = fields[4];
                book.YearPublished = Convert.ToInt32(fields[5]);
                book.QuantityonHand = Convert.ToInt32(fields[6]);
                book.AuthorID = Convert.ToInt32(fields[7]);
                book.FirstName = fields[8]; 
                book.LastName = fields[9];
                book.Email = fields[10];
                listBooks.Add(book);
                line = sReader.ReadLine();                              // Attention : read the next line
            }
            return listBooks;
        }

        public static Book Search(int ISBN)
        {
            Book book = new Book();

            StreamReader sReader = new StreamReader(filePath3);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (ISBN == Convert.ToInt32(fields[0]))
                {
                    book.ISBN = Convert.ToInt32(fields[0]);                 // - Add data to the listView control
                    book.Title = fields[1];
                    book.UnitPrice = Convert.ToInt32(fields[2]);
                    book.Category = fields[3];
                    book.Publisher = fields[4];
                    book.YearPublished = Convert.ToInt32(fields[5]);
                    book.QuantityonHand = Convert.ToInt32(fields[6]);
                    book.AuthorID = Convert.ToInt32(fields[7]);
                    book.FirstName = fields[8];
                    book.LastName = fields[9];
                    book.Email = fields[10];
                    return book;
                }
                line = sReader.ReadLine();                               // Attention : read the next line
            }
            sReader.Close();                                                //Fixing the Problem by closing the file
            return null;
        }
        public static void GetClientID(ComboBox combo)
        {

            StreamReader Reader = new StreamReader(filePath2, true);
            string sReader = Reader.ReadLine();
            while (sReader != null)
            {
                string[] field = sReader.Split(',');
                combo.Items.Add(field[0]);
                sReader = Reader.ReadLine();
            }

        }
        public static void GetPhoneNumber(ComboBox combo)
        {

            StreamReader Reader = new StreamReader(filePath2, true);
            string sReader = Reader.ReadLine();
            while (sReader != null)
            {
                string[] field = sReader.Split(',');
                combo.Items.Add(field[5]);
                sReader = Reader.ReadLine();
            }

        }

        public static void GetISBN(ComboBox combo)
        {

            StreamReader Reader = new StreamReader(filePath1, true);
            string sReader = Reader.ReadLine();
            while (sReader != null)
            {
                string[] field = sReader.Split(',');
                combo.Items.Add(field[0]);
                sReader = Reader.ReadLine();
            }

        }

        public static void GetPublisherID(ComboBox combo)
        {

            StreamReader Reader = new StreamReader(filePath3, true);
            string sReader = Reader.ReadLine();
            while (sReader != null)
            {
                string[] field = sReader.Split(',');
                combo.Items.Add(field[4]);
                sReader = Reader.ReadLine();
            }

        }

        public static void GetAuthorID(ComboBox combo)
        {

            StreamReader Reader = new StreamReader(filePath3, true);
            string sReader = Reader.ReadLine();
            while (sReader != null)
            {
                string[] field = sReader.Split(',');
                combo.Items.Add(field[7]);
                sReader = Reader.ReadLine();
            }

        }

        public static int getQOH(string ISBN)
        {
            int QOH = 0;
            StreamReader sReader = new StreamReader(filePath3, true);
            string reader = sReader.ReadLine();
            while (reader != null)
            {
                string[] field = reader.Split(',');
                if (ISBN == field[0])
                {
                    QOH = Convert.ToInt32(field[4]);

                }
                reader = sReader.ReadLine();
            }
            return QOH;
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        //private static string filePath = Application.StartupPath + @"\Employee.dat";
       // private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Save(Employee emp)
        {
            StreamWriter sWriter = new StreamWriter(filePath1, true);
            sWriter.WriteLine(emp.UserID + "," + emp.FirstName + "," + emp.LastName + "," + emp.Position + "," + emp.PhoneNumber + "," + emp.Password);
            sWriter.Close();
            MessageBox.Show("Employee Data has been saved.");

        }

        public static void ListEmployees(ListView listViewEmployees)
        {
            //step 1: Create an object of type StreamReader
            StreamReader sReader = new StreamReader(filePath1);
            listViewEmployees.Items.Clear();

            // Step 2: Read the file until teh end of the file

            string line = sReader.ReadLine();                           //- Read line by line
            while (line != null)
            {
                string[] fields = line.Split(',');                      //- Split the line into an array of string based on seperator
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);                           // - Add data to the listView control
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                item.SubItems.Add(fields[4]);
                listViewEmployees.Items.Add(item);
                line = sReader.ReadLine();                              // Attention : read the next line
            }
            sReader.Close();
        }

        public static List<Employee> ListEmployees()
        {
            List<Employee> listEmployees = new List<Employee>();
            //step 1: Create an object of type StreamReader
            StreamReader sReader = new StreamReader(filePath1);
            // Step 2: Read the file until teh end of the file

            string line = sReader.ReadLine();                           //- Read line by line
            while (line != null)
            {
                string[] fields = line.Split(',');                      //- Split the line into an array of string based on seperator
                Employee emp = new Employee();
                emp.UserID = Convert.ToInt32(fields[0]);                 // - Add data to the listView control
                emp.FirstName = fields[1];
                emp.LastName = fields[2];
                emp.Position = fields[3];
                emp.PhoneNumber = fields[4];
                emp.Password = Convert.ToInt32(fields[5]);
                listEmployees.Add(emp);
                line = sReader.ReadLine();                              // Attention : read the next line
            }
            return listEmployees;
        }

        public static Employee SearchEmployee(int UserID)
        {
            Employee emp = new Employee();

            StreamReader sReader = new StreamReader(filePath1);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (UserID == Convert.ToInt32(fields[0]))
                {
                    emp.UserID = Convert.ToInt32(fields[0]);                 // - Add data to the listView control
                    emp.FirstName = fields[1];
                    emp.LastName = fields[2];
                    emp.Position = fields[3];
                    emp.PhoneNumber = fields[4];
                    emp.Password = Convert.ToInt32(fields[5]);
                    return emp;
                }
                line = sReader.ReadLine();                               // Attention : read the next line
            }
            sReader.Close();                                                //Fixing the Problem by closing the file
            return null;
        }

        ///////////////////////////////////////////////////////////////////////////////////////
        // Client DAL

        public static void Save(Client cli)
        {
            StreamWriter sWriter = new StreamWriter(filePath2, true);
            sWriter.WriteLine(cli.ClientID + "," + cli.ClientName + "," + cli.Street + "," + cli.City + "," + cli.PostalCode + "," + cli.PhoneNumber + "," + cli.FaxNumber + "," + cli.CreditLimit);
            sWriter.Close();
            MessageBox.Show("Client Data has been saved.");

        }

        public static void ListClients(ListView listViewClients)
        {
            //step 1: Create an object of type StreamReader
            StreamReader sReader = new StreamReader(filePath2);
            listViewClients.Items.Clear();

            // Step 2: Read the file until teh end of the file

            string line = sReader.ReadLine();                           //- Read line by line
            while (line != null)
            {
                string[] fields = line.Split(',');                      //- Split the line into an array of string based on seperator
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);                           // - Add data to the listView control
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                item.SubItems.Add(fields[5]);
                item.SubItems.Add(fields[6]);
                item.SubItems.Add(fields[7]);
                listViewClients.Items.Add(item);
                line = sReader.ReadLine();                              // Attention : read the next line
            }
            sReader.Close();
        }

        public static List<Client> ListClients()
        {
            List<Client> listClients = new List<Client>();
            //step 1: Create an object of type StreamReader
            StreamReader sReader = new StreamReader(filePath2);
            // Step 2: Read the file until teh end of the file

            string line = sReader.ReadLine();                           //- Read line by line
            while (line != null)
            {
                string[] fields = line.Split(',');                      //- Split the line into an array of string based on seperator
                Client cli = new Client();
                cli.ClientID = Convert.ToInt32(fields[0]);                 // - Add data to the listView control
                cli.ClientName = fields[1];
                cli.Street = fields[2];
                cli.City = fields[3];
                cli.PostalCode = fields[4];
                cli.PhoneNumber = fields[5];
                cli.FaxNumber = Convert.ToInt32(fields[6]);
                cli.CreditLimit = Convert.ToInt32(fields[7]);
                listClients.Add(cli);
                line = sReader.ReadLine();                              // Attention : read the next line
            }
            return listClients;
        }

        public static Client SearchCLient(int ClientID)
        {
            Client cli = new Client();

            StreamReader sReader = new StreamReader(filePath2);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (ClientID == Convert.ToInt32(fields[0]))
                {
                    cli.ClientID = Convert.ToInt32(fields[0]);                 // - Add data to the listView control
                    cli.ClientName = fields[1];
                    cli.Street = fields[2];
                    cli.City = fields[3];
                    cli.PostalCode = fields[4];
                    cli.PhoneNumber = fields[5];
                    cli.FaxNumber = Convert.ToInt32(fields[6]);
                    cli.CreditLimit = Convert.ToInt32(fields[7]);
                    return cli;
                }
                line = sReader.ReadLine();                               // Attention : read the next line
            }
            sReader.Close();                                                //Fixing the Problem by closing the file
            return null;
        }


        /////////////////////////////////////////////////////////////////////////////////
        ///Orders DAL

        public static void AddOrder(OrderClerk order)
        {
            StreamWriter sWriter = new StreamWriter(filePath4, true);
            sWriter.WriteLine(order.OrderId + "," + order.ClientId + "," + order.ISBN + "," + order.AuthorId + "," + order.Quantity + "," + order.PhoneNumber + "," + order.PublisherName + "," + order.Email);
            sWriter.Close();
            MessageBox.Show("Order Added!");

        }

        public static OrderClerk SearchOrder(int OrderId)
        {
            OrderClerk order = new OrderClerk();
            StreamReader sReader = new StreamReader(filePath4, true);
            string Reader = sReader.ReadLine();
            while (Reader != null)
            {
                string[] fields = Reader.Split(',');
                if (OrderId == Convert.ToInt32(fields[0]))
                {
                    order.OrderId = Convert.ToInt32(fields[0]);
                    order.ClientId = Convert.ToInt32(fields[1]);
                    order.ISBN = fields[2];
                    order.AuthorId = Convert.ToInt32(fields[3]);
                    order.Quantity = Convert.ToInt32(fields[4]);
                    order.PhoneNumber = fields[5];
                    order.PublisherName = fields[6];
                    order.Email = fields[7]; ;


                    return order;
                }
                Reader = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }

        public static void ListOrders(ListView listViewOrders)
        {
            OrderClerk order = new OrderClerk();
            listViewOrders.Items.Clear();
            StreamReader sReader = new StreamReader(filePath4, true);
            string Reader = sReader.ReadLine();
            while (Reader != null)
            {
                string[] fields = Reader.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                item.SubItems.Add(fields[5]);
                item.SubItems.Add(fields[6]);
                item.SubItems.Add(fields[7]);
                listViewOrders.Items.Add(item);
                Reader = sReader.ReadLine();
            }
            sReader.Close();
        }

        public static void DeleteOrder(int OrderId)
        {
            StreamReader sReader = new StreamReader(filePath4, true);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((OrderId) != (Convert.ToInt32(fields[0])))
                {

                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6] + "," + fields[7]);


                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            sWriter.Close();

            File.Delete(filePath4);
            File.Move(fileTemp, filePath4);
        }
    }
}
