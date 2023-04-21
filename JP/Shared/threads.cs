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
            string url = @"https://docs.google.com/spreadsheets/......................./pub?output=csv";
            string saveFileName = "NewLeads.csv";
            new WebClient().DownloadFile(url, saveFileName);

            // Parsing the CSV file
            using (TextFieldParser parser = new TextFieldParser("./" + saveFileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
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
                            case 0:
                                // First item
                                lead.joinDate = Convert.ToDateTime(field);
                                break;
                            case 1:
                                // Second item
                                break;
                            case 2:
                                // Third item
                                break;
                            case 3:
                                // Fourth item
                                break;
                            case 4:
                                // Fifth item
                                break;
                            case 5:
                                // Sixth item

                                // Insert lead and company into database after the last item
                                database.CreateCompany(company);
                                database.CreateLead(lead);
                                break;
                        }
                        counter++;
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
