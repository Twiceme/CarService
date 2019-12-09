using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CarService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            CultureInfo culture = CultureInfo.CreateSpecificCulture("hu-HU");
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";      
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            DataRetriever s = new DataRetriever();
            s.SetSQLClientList();
            List<ClientsData> clientsDatas = s.SQLClientList;
            DataRetriever e = new DataRetriever();
            e.SetSQLCentralData();
            List<CentralData> centralDatas = e.SQLCentralDataList;
            DataBaseComparator x = new DataBaseComparator(clientsDatas, centralDatas);
            x.CheckCars();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            ClientsData c = new ClientsData();

        }
    }
}
