using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using static Azure.Core.HttpHeader;

namespace JP.Shared
{
    public class employee
    {
        public int id { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int otherNumber { get; set; }
        public employee(int _id, string _email, string _firstName, string _lastName, int _otherNumber)
        {
            id = _id;
            email = _email;
            firstName = _firstName;
            lastName = _lastName;
            otherNumber = _otherNumber;
        }
    }

    public class product
    {
        public decimal id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int category { get; set; }
        public string categoryName { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public product(int _id, string _name, int _price, int _category, DateTime _date, string _description)
        {
            id = _id;
            name = _name;
            price = _price;
            category = _category;
            categoryName = category == 0 ? "NULL" :
                category == 1 ? "Construction" :
                category == 2 ? "Retail" :
                category == 3 ? "Professional Services" :
                category == 4 ? "Personal Services" :
                category == 5 ? "Business to Business" :
                category == 6 ? "Restaurants & Quick-Serve Restaurants" :
                "Other";
            date = _date;
            description = _description;
        }
    }

    public class category
    {
        public int id { get; set; }
        public string name { get; set; }
        public category(int _id, string _name)
        {
            id = _id;
            name = _name;
        }
    }

    public class company
    {
        public int id { get; set; }
        public string name { get; set; }
        public int revenue { get; set; }
        public int categoryID { get; set; }
        public company(int _id, string _name, int _revenue, int _categoryID)
        {
            id = _id;
            name = _name;
            revenue = _revenue;
            categoryID = _categoryID;
        }
    }

    public class account
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public account(int _id, string _username, string _password)
        {
            id = _id;
            username = _username;
            password = _password;
        }
    }

    public class client
    {
        public int id { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int companyID { get; set; }
        public decimal phoneNumber { get; set; }
        public int employeeID { get; set; }
        public int categoryID { get; set; }

        public client(int _id, string _email, string _firstName, string _lastName, int _companyID, decimal _phoneNumber, int _employeeID, int _categoryID)
        {
            id = _id;
            email = _email;
            firstName = _firstName;
            lastName = _lastName;
            companyID = _companyID;
            phoneNumber = _phoneNumber;
            employeeID = _employeeID;
            categoryID = _categoryID;
        }
    }

    public class meeting
    {
        public int id { get; set; }
        public string time { get; set; }
        public DateTime date { get; set; }
        public decimal clientID { get; set; }
        public decimal employeeID { get; set; }
        public string clientName { get; set; }
        public string company { get; set; }
        public meeting(int _id, string _time, DateTime _date, decimal _clientID, decimal _employeeID, string _clientName, string _company)
        {
            id = _id;
            time = _time;
            date = _date;
            clientID = _clientID;
            employeeID = _employeeID;
            clientName = _clientName;
            company = _company;
        }
    }

    public class sale
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int clientID { get; set; }
        public int employeeID { get; set; }
        public int productID { get; set; }
        public int categoryID { get; set; }
        public sale(int _id, DateTime _date, int _clientID, int _employeeID, int _productID, int _categoryID)
        {
            id = _id;
            date = _date;
            clientID = _clientID;
            employeeID = _employeeID;
            productID = _productID;
            categoryID = _categoryID;
        }
    }

    public class note
    {
        public int id { get; set; }
        public int employeeID { get; set; }
        public string name { get; set; }
        public string contents { get; set; }
        public int categoryID { get; set; }
        public note(int _id, int _employeeID, string _name, string _contents, int _categoryID)
        {
            id = _id;
            employeeID = _employeeID;
            name = _name;
            contents = _contents;
            categoryID = _categoryID;
        }
    }

    public class task
    {
        public int id { get; set; }
        public string name { get; set; }
        public int employeeID { get; set; }
        public task(int _id, string _name, int _employeeID)
        {
            id = _id;
            name = _name;
            employeeID = _employeeID;
        }
    }

    public class deal
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int clientID { get; set; }
        public int employeeID { get; set; }
        public int productID { get; set; }
        public int categoryID { get; set; }
        public deal(int _id, DateTime _date, int _clientID, int _employeeID, int _productID, int _categoryID)
        {
            id = _id;
            date = _date;
            clientID = _clientID;
            employeeID = _employeeID;
            productID = _productID;
            categoryID = _categoryID;
        }
    }

    public class database
    {
        // Input sanitization to prevent SQL injection
        // Example usage:   Tuple<bool, string> data = inputSanitization("Hello World.");
        //                  if (data.Item1) { string myData = data.Item2; } else { /* Ouput error message */ }
        public static Tuple<bool, string> inputSanitization(string input)
        {
            // Only accepting input that is alphanumeric with spaces, underscores, periods, and new lines
            return Tuple.Create(Regex.Match(input, "^[a-zA-Z0-9\\s\\n_.]+$").Success, input);
        }

        public static bool GetUser(string username, string password)
        {
            List<account> accounts = GetAccounts();
            foreach (account account in accounts)
            {
                if (account.username == username && account.password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<employee> GetEmployees()
        {
            List<employee> employees = new List<employee>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM employee;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Employee ID, Email, First Name, Last Name, Account ID
                                employees.Add(new employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
                            }
                        }
                    }
                    connection.Close();
                    return employees;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return employees;
        }

        public static List<product> GetProducts(int category = 0) // Optional parameter is set to 0 by default
        {
            List<product> products = new List<product>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM product";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Product ID, Name, Price, Category ID, Create Date, Description
                                products.Add(new product(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(4), reader.GetString(5)));
                            }
                        }
                    }
                    connection.Close();
                    // Removing products that don't match the category. 
                    // 0 is for all products
                    if (category > 0)
                    {
                        products.RemoveAll(p => p.category != category);
                    }
                    return products;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return products;
        }

        public static List<category> GetCategories()
        {
            List<category> categories = new List<category>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM catagory;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Category ID, Name
                                categories.Add(new category(reader.GetInt32(0), reader.GetString(1)));
                            }
                        }
                    }
                    connection.Close();
                    return categories;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return categories;
        }

        public static List<company> GetCompanies()
        {
            List<company> companies = new List<company>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM company;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Company ID, Name, Revenue, CategoryID
                                companies.Add(new company(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));
                            }
                        }
                    }
                    connection.Close();
                    return companies;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return companies;
        }

        public static List<account> GetAccounts()
        {
            List<account> accounts = new List<account>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM account;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Account ID, Username, Password
                                accounts.Add(new account(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                            }
                        }
                    }
                    connection.Close();
                    return accounts;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return accounts;
        }

        public static List<client> GetLeads()
        {
            return GetClients(6); // 6 is the employee ID foreign key for the leads
        }

        public static List<client> GetClients(int employeeID = 0) // Default value of 0 to receive all clients (non-leads) in the system
        {
            List<client> clients = new List<client>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM client;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Client ID, Email, First Name, Last Name, Company ID, Phone Number, Employee ID, Category ID
                                clients.Add(new client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetDecimal(5), reader.GetInt32(6), reader.GetInt32(7)));
                            }
                        }
                    }
                    connection.Close();
                    if (employeeID > 0) // If employeeID == 6, display all leads. If employeeID > 0, display clients owned by the logged-in salesperson
                    {
                        clients.RemoveAll(p => p.employeeID != employeeID);
                    }
                    else if (employeeID == 0) // Displaying all clients in the system, and not displaying leads
                    {
                        clients.RemoveAll(p => p.employeeID == 6);
                    }
                    return clients;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return clients;
        }

        public static List<meeting> GetMeetings()
        {
            List<meeting> meetings = new List<meeting>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "select meeting.meetingid, meeting.meetingtime, meeting.meetingdate, meeting.clientid, meeting.empid, client.fname, company.companyname from meeting inner join client on meeting.clientid = client.ClientID inner join company on client.companyid = company.companyID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Meeting ID, Time, Date, Client ID, Employee ID
                                meetings.Add(new meeting(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6)));
                            }
                        }
                    }
                    connection.Close();
                    return meetings;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return meetings;
        }

        public static List<sale> GetSales()
        {
            List<sale> sales = new List<sale>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM sale;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Sale ID, Date, Client ID, Employee ID, Product ID, Category ID
                                sales.Add(new sale(reader.GetInt32(0), reader.GetDateTime(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5)));
                            }
                        }
                    }
                    connection.Close();
                    return sales;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return sales;
        }

        public static List<note> GetNotes(int employeeID = 0) // Specify the employeeID parameter to receive notes from a specific employee
        {
            List<note> notes = new List<note>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM notes;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Note ID, Employee ID, Name, Contents, Category ID
                                notes.Add(new note(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
                            }
                        }
                    }
                    connection.Close();
                    if (employeeID > 0) // Displaying only notes owned by the logged-in salesperson
                    {
                        notes.RemoveAll(p => p.employeeID != employeeID);
                    }
                    return notes;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return notes;
        }

        public static List<task> GetTasks()
        {
            List<task> tasks = new List<task>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM task;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Task ID, Name, Employee ID
                                tasks.Add(new task(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                            }
                        }
                    }
                    connection.Close();
                    return tasks;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return tasks;
        }

        public static List<deal> GetDeals()
        {
            List<deal> deals = new List<deal>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM deal;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Deal ID, Date, Client ID, Employee ID, Product ID, Category ID
                                deals.Add(new deal(reader.GetInt32(0), reader.GetDateTime(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5)));
                            }
                        }
                    }
                    connection.Close();
                    return deals;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return deals;
        }
    }
}
