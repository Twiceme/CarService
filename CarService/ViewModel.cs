using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    public class ViewModel : INotifyPropertyChanged
    {
        private DataBaseComparator dataBaseComparator;
        private DataRetriever sqlClientsRetriever;
        private DataRetriever sqlCentralRetriever;
        private ClientsDataTransporter clientsDataTransporter;
        private CentralDataTransporter centralDataTransporter;
        private ClientDataCsvReader clientDataCsvReader;
        private CentralDataCsvReader centralDataCsvReader;
        private TireEqualizer tireEqualizer;
        private List<CentralData> centralDatas;
        private List<ClientsData> clientsDatas;
        private List<ClientsData> sqlClientList;
        private List<CentralData> sqlCentralDataList;
        public  ClientsData client;

        public ViewModel()
        {
            dataBaseComparator = new DataBaseComparator();
            sqlClientsRetriever = new DataRetriever();
            sqlCentralRetriever = new DataRetriever();
            clientsDataTransporter = new ClientsDataTransporter();
            centralDataTransporter = new CentralDataTransporter();
            clientDataCsvReader = new ClientDataCsvReader();
            centralDataCsvReader = new CentralDataCsvReader();
            tireEqualizer = new TireEqualizer();
            centralDatas = new List<CentralData>();
            clientsDatas = new List<ClientsData>();
            sqlClientList = new List<ClientsData>();
            sqlCentralDataList = new List<CentralData>();
            client = new ClientsData();
        }

        public DataBaseComparator DataBaseComparator
        {
            get
            {
                return this.dataBaseComparator;
            }
            set
            {
                if (value != this.dataBaseComparator)
                {
                    this.dataBaseComparator = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DataRetriever SqlClientsRetriever
        {
            get
            {
                return this.sqlClientsRetriever;
            }
            set
            {
                if (value != this.sqlClientsRetriever)
                {
                    this.sqlClientsRetriever = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DataRetriever SqlCentralRetriever
        {
            get
            {
                return this.sqlCentralRetriever;
            }
            set
            {
                if (value != this.sqlCentralRetriever)
                {
                    this.sqlCentralRetriever = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ClientsDataTransporter ClientsDataTransporter
        {
            get
            {
                return this.clientsDataTransporter;
            }
            set
            {
                if (value != this.clientsDataTransporter)
                {
                    this.clientsDataTransporter = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public CentralDataTransporter CentralDataTransporter
        {
            get
            {
                return this.centralDataTransporter;
            }
            set
            {
                if (value != this.centralDataTransporter)
                {
                    this.centralDataTransporter = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ClientDataCsvReader ClientDataCsvReader
        {
            get
            {
                return this.clientDataCsvReader;
            }
            set
            {
                if (value != this.clientDataCsvReader)
                {
                    this.clientDataCsvReader = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public CentralDataCsvReader CentralDataCsvReader
        {
            get
            {
                return this.centralDataCsvReader;
            }
            set
            {
                if (value != this.centralDataCsvReader)
                {
                    this.centralDataCsvReader = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public TireEqualizer TireEqualizer
        {
            get
            {
                return this.tireEqualizer;
            }
            set
            {
                if (value != this.tireEqualizer)
                {
                    this.tireEqualizer = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<CentralData> CentralDatas
        {
            get
            {
                return this.centralDatas;
            }
            set
            {
                if (value != this.centralDatas)
                {
                    this.centralDatas = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<ClientsData> ClientsDatas
        {
            get
            {
                return this.clientsDatas;
            }
            set
            {
                if (value != this.clientsDatas)
                {
                    this.clientsDatas = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<ClientsData> SqlClientList
        {
            get
            {
                return this.sqlClientList;
            }
            set
            {
                if (value != this.sqlClientList)
                {
                    this.sqlClientList = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<CentralData> SqlCentralDataList
        {
            get
            {
                return this.sqlCentralDataList;
            }
            set
            {
                if (value != this.sqlCentralDataList)
                {
                    this.sqlCentralDataList = value;
                    NotifyPropertyChanged();
                }
            }

        }

        public ClientsData Client
        {
            get
            {
                return this.client;
            }
            set
            {
                if (value != this.client)
                {
                    this.client = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string ClientLicensePLate
        {
            get
            {
                return this.client.LicensePlateNumber;
            }
            set
            {
                if (value != this.client.LicensePlateNumber)
                {
                    this.client.LicensePlateNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void LoadClientDataFromCsv(string Path)
        {
            ClientsDataTransporter.Path = Path;
            ClientsDataTransporter.UploadCsvToSql();

        }
        public void LoadClientsDataFromSql()
        {
            SqlClientsRetriever.SetSQLClientList();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
