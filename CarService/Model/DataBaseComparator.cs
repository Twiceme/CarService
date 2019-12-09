using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    public class DataBaseComparator
    {
        public List<ClientsData> ClientsDatas { get; set; }
        public List<CentralData> centralDatas { get; set; }
        public List<CarChecker> CarCheckers { get; set; }

        public DataBaseComparator(List<ClientsData> ClientsDatas, List<CentralData> centralDatas)
        {
            this.ClientsDatas = ClientsDatas;
            this.centralDatas = centralDatas;
            CarCheckers = new List<CarChecker>();
        }
        public DataBaseComparator()
        {
            this.ClientsDatas = new List<ClientsData>();
            this.centralDatas = new List<CentralData>();
            CarCheckers = new List<CarChecker>();
        }
        public void CheckCars()
        {
            foreach(ClientsData client in ClientsDatas)
            {
                string status = String.Empty;
                bool Exists = false;
                for(int i = 0; i< centralDatas.Count; i++)
                {
                    if(centralDatas[i].LicensePlateNumber == client.LicensePlateNumber)
                    {
                        Exists = true;
                        if (centralDatas[i].IsStolen)
                        {
                            status = "Riasztás";
                        }
                        else if (centralDatas[i].CarType != client.CarType || centralDatas[i].Owner != client.Owner)
                        {
                            if(centralDatas[i].CarType != client.CarType && centralDatas[i].Owner != client.Owner) 
                                status = "Gyanús (Típus és tulajdonos)";
                            else if(centralDatas[i].CarType != client.CarType)
                                status = "Gyanús (Típus)";
                            else
                                status = "Gyanús (Tulajdonos)";
                        }
                        else
                        {
                            status = "Tiszta";
                        }
                    }
                }
                if (!Exists)
                    status = "No Data was found";
                client.Status = status;
            }
        }
        public void UploadDataToSQL()
        {
            CarCheckers.Clear();
            CheckCars();
            foreach (ClientsData client in ClientsDatas)
            {
                SingleCarcheckerUpload(client);
            }
        }

        public void SingleCarcheckerUpload(ClientsData clientsData)
        {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateClientsDataStatus", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@LicensePlateNumber", SqlDbType.VarChar).Value = clientsData.LicensePlateNumber;
                        cmd.Parameters.Add("@ComparisonResult", SqlDbType.VarChar).Value = clientsData.Status;
                        cmd.ExecuteNonQuery();
                    }
                }
        }
    }
}
