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
    public class DataRetriever
    {
        public List<ClientsData> SQLClientList { get; private set; }
        public List<CentralData> SQLCentralDataList { get; private set; }

        public DataRetriever()
        {
            SQLClientList = new List<ClientsData>();
            SQLCentralDataList = new List<CentralData>();
        }

        public void SetSQLClientList()
        {
            SQLClientList.Clear();
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_RetrieveClients", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ClientsData Client = new ClientsData();
                    Client.LicensePlateNumber = reader["LicensePlateNumber"].ToString();
                    Client.Owner = reader["Owner"].ToString();
                    Client.CarType = reader["CarType"].ToString();
                    Client.IsActive  = Boolean.Parse(reader["isActive"].ToString());
                    Client.tirePressures.LeftFrontPressure = Double.Parse(reader["LeftFrontPressure"].ToString());
                    Client.tirePressures.RightFrontPressure = Double.Parse(reader["RightFrontPressure"].ToString());
                    Client.tirePressures.LeftRearPressure = Double.Parse(reader["LeftRearPressure"].ToString());
                    Client.tirePressures.RightRearPressure = Double.Parse(reader["RightRearPressure"].ToString());
                    SQLClientList.Add(Client);
                }
            }
        }

        public void SetSQLCentralData()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_RetrieveCentralData", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CentralData centralData = new CentralData();
                    centralData.LicensePlateNumber = reader["LicensePlateNumber"].ToString();
                    centralData.Owner = reader["Owner"].ToString();
                    centralData.CarType = reader["CarType"].ToString();
                    centralData.IsStolen = Boolean.Parse(reader["isStolen"].ToString());
                    SQLCentralDataList.Add(centralData);
                }
            }
        }


    }
}
