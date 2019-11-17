using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    public class ClientDataCsvReader
    {
        public string CSVPath { get; set; }
        
        public List<ClientsData> ClientsDataList { get; set; }

        public ClientDataCsvReader(string CSVPath)
        {
            ClientsDataList = new List<ClientsData>();
            this.CSVPath = CSVPath;
        }
        public ClientDataCsvReader()
        {
            ClientsDataList = new List<ClientsData>();
        }
        public void ReadDataFromCSV()
        {
            using (StreamReader reader = new StreamReader(CSVPath))
            using (CsvReader csv = new CsvReader(reader))
            {
                csv.Configuration.CultureInfo = CultureInfo.InvariantCulture;
                csv.Read();
                csv.ReadHeader();
                    while (csv.Read())
                    {
                        ClientsData Client = new ClientsData();

                        Client.LicensePlateNumber = csv.GetField<string>("Rendszám");
                        Client.Owner = csv.GetField<string>("Tulaj");
                        Client.CarType = csv.GetField<string>("Típus");
                        Client.tirePressures.LeftFrontPressure = csv.GetField<double>("Bal első kerék nyomása");
                        Client.tirePressures.RightFrontPressure = csv.GetField<double>("Jobb első kerék nyomása");
                        Client.tirePressures.LeftRearPressure = csv.GetField<double>("Bal hátsó kerék nyomása");
                        Client.tirePressures.RightRearPressure = csv.GetField<double>("Jobb hátsó kerék nyomása");
                        
                        ClientsDataList.Add(Client);
                    }
            }
        }
    }
}
