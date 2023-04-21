﻿using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Xml.Linq;
using JP.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.VisualBasic;
using Radzen.Blazor;
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
        public int employees { get; set; }
        public company() { }
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
        public DateTime joinDate { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string companyID { get; set; }
        public decimal phoneNumber { get; set; }
        public int employeeID { get; set; }
        public string categoryID { get; set; }
        public client() { }
        public client(int _id, string _email, string _firstName, string _lastName, string _companyID, decimal _phoneNumber, int _employeeID, string _categoryID, DateTime _joinDate)
        {
            id = _id;
            email = _email;
            firstName = _firstName;
            lastName = _lastName;
            companyID = _companyID;
            phoneNumber = _phoneNumber;
            employeeID = _employeeID;
            categoryID = _categoryID;
            joinDate = _joinDate;
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
        public DateTime date { get; set; }
        public string companyName { get; set; }
        public string clientfName { get; set; }
        public string clientlName { get; set; }
        public string employeefName { get; set; }
        public string employeelName { get; set; }
        public string productName { get; set; }
        public string categoryName { get; set; }
        public int clientID { get; set; }
        public int fk_dealID { get; set; }
        public sale(DateTime _date, string _companyName, string  _clientfName, string _clientlName, string _employeefName, string _employeelName, string _productName, string _categoryName, int _clientID, int _fk_dealID)
        {
            date = _date;
            companyName = _companyName;
            clientfName = _clientfName;
            clientlName = _clientlName;
            employeefName = _employeefName;
            employeelName = _employeelName;
            productName = _productName;
            categoryName = _categoryName;
            clientID = _clientID;
            fk_dealID = _fk_dealID;
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
        public DateTime date { get; set; }
        public string companyName { get; set; }
        public string clientfName { get; set; }
        public string clientlName { get; set; }
        public string employeefName { get; set; }
        public string employeelName { get; set; }
        public string productName { get; set; }
        public string categoryName { get; set; }
        public int clientID { get; set; }
        public deal() { }
        public deal(DateTime _date, string _companyName, string _clientfName, string _clientlName, string _employeefName, string _employeelName, string _productName, string _categoryName, int _clientID)
        {
            date = _date;
            companyName = _companyName;
            clientfName = _clientfName;
            clientlName = _clientlName;
            employeefName = _employeefName;
            employeelName = _employeelName;
            productName = _productName;
            categoryName = _categoryName;
            clientID = _clientID;
        }
    }

    public class recommended
    {
        public string productname { get; set; }
        public recommended(string _productname)
        {
            productname = _productname;
        }
    }

    public class leaddealsale
    {
        public string leadName { get; set; }
        public string leadCompanyName { get; set; }
        public DateTime leadJoinDate { get; set; }
        public string leadEmployeeName { get; set; }
        public string dealCategoryName { get; set; }
        public string dealProductName { get; set; }
        public DateTime dealDate { get; set; }
        public string saleProductName { get; set; }
        public DateTime saleDate { get; set; }
        public leaddealsale(sale _sale)
        {
            client lead = database.GetClientFromID(_sale.clientID);
            deal deal = database.GetDealFromID(_sale.fk_dealID);
            sale sale = _sale;

            leadName = lead.firstName + " " + lead.lastName;
            leadCompanyName = lead.companyID;
            leadJoinDate = lead.joinDate;
            leadEmployeeName = deal.employeefName + " " + deal.employeelName;
            dealCategoryName = deal.categoryName;
            dealProductName = deal.productName;
            dealDate = deal.date;
            saleProductName = sale.productName;
            saleDate = sale.date;
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

        public static account GetUser(string username, string password)
        {
            List<account> accounts = GetAccounts();
            foreach (account acc in accounts)
            {
                if (acc.username == username && acc.password == password)
                {
                    return acc;
                }
            }
            return null;
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

        public static List<product> GetProducts(int category = 0, string searchTerm = "") // Optional parameter is set to 0 by default
        {
            List<product> products = new List<product>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM product";
                    if (searchTerm != "")
                    {
                        query = "SELECT * FROM product WHERE ProductDescription LIKE \'%" + searchTerm + "%\' OR ProductName LIKE  \'%" + searchTerm + "%\' OR " +
                                                            "ProductID LIKE \'%" + searchTerm + "%' OR ProductPrice LIKE \'%" + searchTerm + "%\' OR " +
                                                            "CreateDate LIKE \'%" + searchTerm + "%\';";
                    }

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

        public static List<client> GetClients(int employeeID = 0, string searchTerm = "") // Default value of 0 to receive all clients (non-leads) in the system
        {
            List<client> clients = new List<client>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "select client.ClientID, client.email, client.fName, client.lName, company.CompanyName, client.PhoneNum, client.EmpID, Catagory.CatagoryName, Client.JoinDate From company inner join client on Company.CompanyID = client.CompanyID inner join catagory on client.CatagoryID = Catagory.CatagoryID;";
                    if (searchTerm != "")
                    {
                        query = "SELECT client.ClientID, client.email, client.fName, client.lName, company.CompanyName, client.PhoneNum, client.EmpID, Catagory.CatagoryName, Client.JoinDate From company inner join client on Company.CompanyID = client.CompanyID inner join catagory on client.CatagoryID = Catagory.CatagoryID WHERE client.ClientID LIKE '%" + searchTerm + "%' OR client.Email LIKE  '%" + searchTerm + "%' OR " +
                                                           "client.fName LIKE '%" + searchTerm + "%' OR client.lName LIKE '%" + searchTerm + "%' OR " +
                                                            "client.PhoneNum LIKE '%" + searchTerm + "%' OR client.EmpID LIKE '%" + searchTerm + "%' OR " +
                                                            "client.CompanyID LIKE '%" + searchTerm + "%' OR client.CatagoryID LIKE '%" + searchTerm + "%';";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Client ID, Email, First Name, Last Name, Company Name, Phone Number, Employee ID, Category Name, Client Join Date
                                clients.Add(new client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDecimal(5), reader.GetInt32(6), reader.GetString(7), reader.GetDateTime(8)));
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

        public static client GetClientFromID(int clientID)
        {
            var client = new client();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "select client.ClientID, client.email, client.fName, client.lName, company.CompanyName, client.PhoneNum, client.EmpID, Catagory.CatagoryName, Client.JoinDate From company inner join client on Company.CompanyID = client.CompanyID inner join catagory on client.CatagoryID = Catagory.CatagoryID " +
                        "WHERE ClientID='"+clientID+"';";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Client ID, Email, First Name, Last Name, Company Name, Phone Number, Employee ID, Category Name, Client Join Date
                                client = new client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDecimal(5), reader.GetInt32(6), reader.GetString(7), reader.GetDateTime(8));
                            }
                        }
                    }
                    connection.Close();
                    return client;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return client;
        }

        public static deal GetDealFromID(int dealID)
        {
            var deal = new deal();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT Deal.DealDate, Company.CompanyName, Client.fName, Client.lName, Employee.fName, Employee.lName, Product.ProductName, Catagory.CatagoryName, Client.ClientID FROM Deal INNER JOIN Client on Deal.ClientID = Client.ClientID INNER JOIN Employee on Deal.EmpID = Employee.EmpID INNER JOIN Product on Product.ProductID = Deal.ProductID INNER JOIN Catagory on Catagory.CatagoryID = Client.CatagoryID INNER JOIN Company on Company.CompanyID = Client.CompanyID " +
                        "WHERE DealID='" + dealID + "';";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Deal Date, Company Name, Client First Name, Client Last Name, Employee First Name, Employee Last Name, Product Name, Category Name, Client ID
                                deal = new deal(reader.GetDateTime(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8));
                            }
                        }
                    }
                    connection.Close();
                    return deal;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return deal;
        }

        // Function to remove client from an employee using the clientID as input
        public static void RemoveClient(int clientID)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "UPDATE Client SET EmpID=6 WHERE ClientID=@clientID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@clientID", clientID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return;
        }

        // Function to delete lead using the clientID as input
        public static void DeleteLead(int clientID)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "DELETE FROM Client WHERE clientID=@clientID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@clientID", clientID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return;
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

        public static List<sale> GetSales(string searchTerm = "")
        {
            List<sale> sales = new List<sale>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT Sale.SaleDate, Company.CompanyName, Client.fName, Client.lName, Employee.fName, Employee.lName, Product.ProductName, Catagory.CatagoryName, Client.ClientID, Sale.fk_DealID FROM Sale INNER JOIN Client on Sale.ClientID = Client.ClientID INNER JOIN Employee on Sale.EmpID = Employee.EmpID INNER JOIN Product on Product.ProductID = Sale.ProductID INNER JOIN Catagory on Catagory.CatagoryID = Client.CatagoryID INNER JOIN Company on Company.CompanyID = Client.CompanyID;";

                    if (searchTerm != "")
                    {
                        query = "SELECT Sale.SaleDate, Company.CompanyName, Client.fName, Client.lName, Employee.fName, Employee.lName, Product.ProductName, Catagory.CatagoryName, Client.ClientID, Sale.fk_DealID FROM Sale INNER JOIN Client on Sale.ClientID = Client.ClientID INNER JOIN Employee on Sale.EmpID = Employee.EmpID INNER JOIN Product on Product.ProductID = Sale.ProductID INNER JOIN Catagory on Catagory.CatagoryID = Client.CatagoryID INNER JOIN Company on Company.CompanyID = Client.CompanyID WHERE " +
                                                         "Sale.SaleDate LIKE '%" + searchTerm + "%' OR Company.CompanyName LIKE '%" + searchTerm + "%' OR Client.fName LIKE '%" + searchTerm + "%' OR Client.lName LIKE '%" + searchTerm + "%' OR " +
                                                         "Employee.fName LIKE '%" + searchTerm + "%' OR Employee.lName LIKE '%" + searchTerm + "%' OR Product.ProductName LIKE '%" + searchTerm + "%' OR Catagory.CatagoryName LIKE '%" + searchTerm + "%';";
                    }
                    

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Sale Date, Company Name, Client First Name, Client Last Name, Employee First Name, Employee Last Name, Product Name, Category Name, Client ID, Associated Deal ID
                                sales.Add(new sale(reader.GetDateTime(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetInt32(9)));
                            }
                        }
                    }
                    connection.Close();
                    sales.Sort((s1, s2) => DateTime.Compare(s2.date, s1.date));
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

        public static List<note> GetNotes(int employeeID = 0, string searchTerm = "") // Specify the employeeID parameter to receive notes from a specific employee
        {
            List<note> notes = new List<note>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM notes;";
                    if (searchTerm != "")
                    {
                        query = "SELECT * FROM notes WHERE NoteName LIKE \'%" + searchTerm + "%\' OR Contents LIKE  \'%" + searchTerm + "%\'" +
                                                           " OR CatagoryID LIKE \'%" + searchTerm + "%\';";
                    }

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

        // Function to create note
        public static void CreateNote(int EmpID, string NoteName, string Contents, int catID)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "INSERT INTO Notes(EmpID, NoteName, Contents, CatagoryID) VALUES (@EmpID, @NoteName, @Contents, @catID);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmpID", EmpID);
                        command.Parameters.AddWithValue("@NoteName", NoteName);
                        command.Parameters.AddWithValue("@Contents", Contents);
                        command.Parameters.AddWithValue("@catID", catID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return;
        }

        // Function to delete note using the noteID as input
        public static void DeleteNote(int noteID)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "DELETE FROM Notes WHERE NoteID=@noteID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@noteID", noteID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return;
        }

        // Function to edit note using the noteID as input
        public static void EditNote(int noteID, string NoteName, string Contents, int CatagoryID)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "UPDATE Notes SET NoteName=@NoteName, Contents=@Contents, CatagoryID=@CatagoryID WHERE NoteID=@noteID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@noteID", noteID);
                        command.Parameters.AddWithValue("@NoteName", NoteName);
                        command.Parameters.AddWithValue("@Contents", Contents);
                        command.Parameters.AddWithValue("@CatagoryID", CatagoryID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return;
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
                    var query = "SELECT Deal.DealDate, Company.CompanyName, Client.fName, Client.lName, Employee.fName, Employee.lName, Product.ProductName, Catagory.CatagoryName, Client.ClientID FROM Deal INNER JOIN Client on Deal.ClientID = Client.ClientID INNER JOIN Employee on Deal.EmpID = Employee.EmpID INNER JOIN Product on Product.ProductID = Deal.ProductID INNER JOIN Catagory on Catagory.CatagoryID = Client.CatagoryID INNER JOIN Company on Company.CompanyID = Client.CompanyID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Deal Date, Company Name, Client First Name, Client Last Name, Employee First Name, Employee Last Name, Product Name, Category Name, Client ID
                                deals.Add(new deal(reader.GetDateTime(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8)));
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

        public static List<recommended> GetRecommendeds(string catname)
        {
            List<recommended> recommendeds = new List<recommended>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT product.ProductName FROM Product INNER JOIN sale ON Product.ProductID = sale.ProductID INNER JOIN client ON client.clientid = sale.clientid INNER JOIN Catagory ON Catagory.CatagoryID = Client.CatagoryID WHERE Catagory.CatagoryName LIKE @Category;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Category", "%" + catname + "%");
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recommendeds.Add(new recommended(reader.GetString(0)));
                            }
                        }
                    }
                    connection.Close();
                    return recommendeds;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return recommendeds;
        }

        public static List<leaddealsale> GetLeadDealSales()
        {
            List<leaddealsale> leaddealsales = new List<leaddealsale>();
            List<sale> sales = GetSales();

            foreach(sale s in sales)
            {
                leaddealsales.Add(new leaddealsale(s));
            }
            leaddealsales.Sort((lds1, lds2) => DateTime.Compare(lds2.saleDate, lds1.saleDate));
            return leaddealsales;
        }

        public static void CreateLead(client lead, int newCompanyID)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "INSERT INTO Client(Email, fName, lName, CompanyID, PhoneNum, EmpID, CatagoryID, JoinDate) VALUES (@Email, @fName, @lName, @CompanyID, @PhoneNum, @EmpID, @CatagoryID, @JoinDate);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fName", lead.firstName);
                        command.Parameters.AddWithValue("@lName", lead.lastName);
                        command.Parameters.AddWithValue("@CompanyID", newCompanyID);
                        command.Parameters.AddWithValue("@PhoneNum", lead.phoneNumber);
                        command.Parameters.AddWithValue("@EmpID", lead.employeeID);
                        command.Parameters.AddWithValue("@CatagoryID", lead.categoryID);
                        command.Parameters.AddWithValue("@JoinDate", lead.joinDate);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return;
        }

        public static int CreateCompany(company company)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "INSERT INTO Company(CompanyName, CompanyRevenue, CatagoryID, employees) VALUES (@CompanyName, @CompanyRevenue, @CatagoryID, @employees);";
                    int newCompanyID;

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CompanyName", company.name);
                        command.Parameters.AddWithValue("@CompanyRevenue", company.revenue);
                        command.Parameters.AddWithValue("@CatagoryID", company.categoryID);
                        command.Parameters.AddWithValue("@employee", company.employees);
                        connection.Open();
                        newCompanyID = (int)command.ExecuteScalar();
                    }
                    connection.Close();
                    return newCompanyID;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return 0;
        }

    }
}