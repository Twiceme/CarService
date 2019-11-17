using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    public class CentralDataCsvReader
    {
        public string CSVPath { get; set; }

        public List<CentralData> CentralDataList { get; set; }

        public CentralDataCsvReader(string Path)
        {
            CSVPath = Path;
            CentralDataList = new List<CentralData>();
        }
        public CentralDataCsvReader()
        {
            CentralDataList = new List<CentralData>();
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
                    CentralData Data = new CentralData
                    {
                        LicensePlateNumber = csv.GetField<string>("Rendszám"),
                        Owner = csv.GetField<string>("Tulaj"),
                        CarType = csv.GetField<string>("Típus"),
                        IsStolen = csv.GetField<string>("Lopottnak jelentve") == "Lopott" ? true : false,                     
                    };
                    CentralDataList.Add(Data);
                }
            }
        }
    }
}
