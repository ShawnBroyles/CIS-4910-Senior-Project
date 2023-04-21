using Microsoft.VisualBasic.FileIO;
using System;
using System.Net;
using System.Threading;

namespace JP.Shared
{
    public class threads
    {
        public static void ImportNewLeads()
        {
            // Download CSV file from Google Forms
            string url = @"https://docs.google.com/spreadsheets/d/e/2PACX-1vSsR7-FkWD-Im63Yrm7wRp7u_OGmsU6p4aVJnvM6CzZrP0Hgp7oSVtc5FPj1KEf752jyaSxRrBFU140/pub?output=csv";
            string saveFileName = "NewLeads.csv";
            new WebClient().DownloadFile(url, saveFileName);

            // Determining the line to start reading from so we can avoid duplicate data
            string fileLineNumber = "LineNumber.txt";
            int lineContinue = 0;

            // Creating file if it does not exist
            if (!File.Exists(fileLineNumber)) 
            {
                using (StreamWriter sw = File.AppendText(fileLineNumber))
                {
                    sw.WriteLine('0');
                    sw.Close();
                }
            }

            // Reading from the file
            StreamReader sr = new StreamReader(fileLineNumber);
            string line = sr.ReadLine();
            lineContinue = Convert.ToInt32(line);
            sr.Close();


            // Parsing the CSV file
            using (TextFieldParser parser = new TextFieldParser("./" + saveFileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                // Read a line each time we iterate through this loop
                while (!parser.EndOfData)
                {
                    if ((int)parser.LineNumber > lineContinue)
                    {
                        // Reading fields sequentially
                        string[] fields = parser.ReadFields();
                        int counter = 0;
                        client lead = new client();
                        company company = new company();
                        foreach (string field in fields)
                        {
                            switch (counter)
                            {
                                // Determining which field we're reading from the row
                                case 0:
                                    lead.joinDate = Convert.ToDateTime(field);
                                    break;
                                case 1:
                                    lead.firstName = Convert.ToString(field);
                                    break;
                                case 2:
                                    lead.lastName = Convert.ToString(field);
                                    break;
                                case 3:
                                    lead.email = Convert.ToString(field);
                                    break;
                                case 4:
                                    lead.phoneNumber = Convert.ToInt32(field);
                                    break;
                                case 5:
                                    company.name = Convert.ToString(field);
                                    break;
                                case 6:
                                    company.categoryID = Convert.ToInt32(field);
                                    break;
                                case 7:
                                    company.revenue = Convert.ToInt32(field);
                                    break;
                                case 8:
                                    company.employees = Convert.ToInt32(field);
                                    // Insert lead and company into database after the last item
                                    lead.employeeID = 6; // New Lead
                                    int newCompanyID = database.CreateCompany(company);
                                    database.CreateLead(lead, newCompanyID);
                                    break;
                                default:
                                    break;
                            }
                            counter++;
                        }
                        lineContinue = (int)parser.LineNumber;
                        System.IO.File.WriteAllText(fileLineNumber, Convert.ToString(lineContinue));
                    }
                    
                }
            }

            // Sleep for 1 hour
            Thread.Sleep(3600000);

            // Recursion
            ImportNewLeads();
        }
    }
}
