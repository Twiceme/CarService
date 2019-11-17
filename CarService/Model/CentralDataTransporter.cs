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
    public class CentralDataTransporter
    {
        public string Path { get; set; }

        public void UploadCsvToSql()
        {
            CentralDataCsvReader csvReader = new CentralDataCsvReader(Path);
            csvReader.ReadDataFromCSV();
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                sqlCon.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM CentralData", sqlCon))
                {
                    command.ExecuteNonQuery();
                }

                foreach (CentralData data in csvReader.CentralDataList)
                {
                    using (SqlCommand cmd = new SqlCommand("sp_update_CentralData", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LicensePlateNumber", data.LicensePlateNumber);
                        cmd.Parameters.AddWithValue("@CarOwner", data.Owner);
                        cmd.Parameters.AddWithValue("@CarType", data.CarType);
                        cmd.Parameters.AddWithValue("@isStolen", data.IsStolen);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
