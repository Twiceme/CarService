using System;
using System.Collections.Generic;
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
                for(int i = 0; i< centralDatas.Count; i++)
                {
                    if(centralDatas[i].LicensePlateNumber == client.LicensePlateNumber)
                    {
                        if (centralDatas[i].IsStolen)
                        {
                            status = "Riasztás";
                        }
                        else if (centralDatas[i].CarType != client.CarType || centralDatas[i].Owner != client.Owner)
                        {
                            status = "Gyanús";
                        }
                        else
                        {
                            status = "Tiszta";
                        }
                    }                   
                }
                CarChecker car = new CarChecker();
                car.LicensePLateNumber = client.LicensePlateNumber;
                car.Owner = client.Owner;
                car.CarType = client.CarType;
                car.Status = status;
                CarCheckers.Add(car);
            }
        }
    }
}
