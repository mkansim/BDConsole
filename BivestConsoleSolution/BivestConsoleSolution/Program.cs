using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BivestConsoleSolution
{
    class Profile
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string ip_address { get; set; }
    }
    class Program
    {
        private static readonly string path = @"C:\Users\Public\Bidvest\";
        static void Main(string[] args)
        {
            string inputFile = path + "BDG_Input.txt";
            string outputFile = path + "BDG_Output.json";
            if (File.Exists(inputFile))
            {
                string line;
                List<Profile> BidvestDataList = new List<Profile>();

                StreamReader file = new StreamReader(inputFile);

                while ((line = file.ReadLine()) != null)
                {
                    try
                    {
                        string[] rowData = line.Split('|');
                        BidvestDataList.Add(new Profile
                        {
                            id = rowData[0],
                            first_name = rowData[1],
                            last_name = rowData[2],
                            email = rowData[3],
                            gender = rowData[4],
                            ip_address = rowData[5]
                        });

                    }
                    catch (Exception ex)
                    {
                        new Exception("Error found : " + ex.Message);
                    }
                    
                }

                file.Close();

                if (BidvestDataList.Count > 0)
                {
                    using (StreamWriter outputfile = File.CreateText(outputFile))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(outputfile, BidvestDataList);
                    }
                }
                
            }
            else
            {
                throw new Exception("File does not exist");
            }

        }
    }
}
