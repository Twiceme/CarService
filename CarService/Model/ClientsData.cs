using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    public class ClientsData
    {
        public string LicensePlateNumber { get; set; }
        public string Owner { get; set; }
        public string CarType { get; set; }
        public TirePressures TirePreasures { get; set; }
        public bool IsActive { get; set; }

        public string Status { get; set; }

        public ClientsData()     
        {
            TirePreasures = new TirePressures();
        }

    }
}
