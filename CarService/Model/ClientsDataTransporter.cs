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
    public class ClientsDataTransporter
    {
        public string Path  { get; set; }
 
        public void UploadCsvToSql()
        {
            ClientDataCsvReader csvreader = new ClientDataCsvReader(Path);
            csvreader.ReadDataFromCSV();
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                sqlCon.Open();
                using (SqlCommand command = new SqlCommand("sp_Init_ClientsData", sqlCon))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
            foreach (ClientsData client in csvreader.ClientsDataList)
            {
                SingleCliendToSql(client);
            }
        }

        public void SingleCliendToSql(ClientsData client)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                sqlCon.Open();
                using (SqlCommand cmd = new SqlCommand("UpdateClientsData", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LicensePlateNumber", client.LicensePlateNumber);
                    cmd.Parameters.AddWithValue("@CarOwner", client.Owner);
                    cmd.Parameters.AddWithValue("@CarType", client.CarType);
                    cmd.Parameters.AddWithValue("@LeftFrontPressure", client.TirePreasures.LeftFrontPressure);
                    cmd.Parameters.AddWithValue("@RightFrontPressure", client.TirePreasures.RightFrontPressure);
                    cmd.Parameters.AddWithValue("@LeftRearPressure", client.TirePreasures.LeftRearPressure);
                    cmd.Parameters.AddWithValue("@RightRearPressure", client.TirePreasures.RightRearPressure);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteDataFromSQL(string LicensePlateNumber)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                sqlCon.Open();
                using (SqlCommand command = new SqlCommand("DeleteClientsData", sqlCon))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LicensePlateNumber", LicensePlateNumber);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
