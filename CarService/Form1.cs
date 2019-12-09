using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService
{
    public partial class Form1 : Form
    {
        ViewModel vm = new ViewModel();
        bool isLoaded = true;
        bool isCompared = false;
        bool isAdding = false;
        public Form1()
        {
            InitializeComponent();       
            bindingSource1 = new BindingSource();
            bindingSource1.DataSource = vm;
            txtLicensePLate.DataBindings.Add(nameof(txtLicensePLate.Text), vm, "Client.LicensePlateNumber", false, DataSourceUpdateMode.OnPropertyChanged);
            txtOwner.DataBindings.Add(nameof(txtOwner.Text), vm, "Client.Owner", false, DataSourceUpdateMode.OnPropertyChanged);
            txtCarType.DataBindings.Add(nameof(txtCarType.Text), vm, "Client.CarType", false, DataSourceUpdateMode.OnPropertyChanged);
            txtLeftFrontPreasure.DataBindings.Add(nameof(txtLeftFrontPreasure.Text), vm, "Client.TirePreasures.LeftFrontPressure", false, DataSourceUpdateMode.OnValidation);
            txtRightFrontPreasure.DataBindings.Add(nameof(txtRightFrontPreasure.Text), vm, "Client.TirePreasures.RightFrontPressure", false, DataSourceUpdateMode.OnValidation);
            txtLeftRearPreasure.DataBindings.Add(nameof(txtLeftRearPreasure.Text), vm, "Client.TirePreasures.LeftRearPressure", false, DataSourceUpdateMode.OnValidation);
            txtRightRearPreasure.DataBindings.Add(nameof(txtRightRearPreasure.Text), vm, "Client.TirePreasures.RightRearPressure", false, DataSourceUpdateMode.OnValidation);
            txtDelete.DataBindings.Add(nameof(txtDelete.Text),vm, "Client.LicensePlateNumber", false, DataSourceUpdateMode.OnPropertyChanged);
            txtnewlfp.DataBindings.Add(nameof(txtnewlfp.Text), vm, "TireEqualizer.NewTirePressures.LeftFrontPressure", false, DataSourceUpdateMode.OnValidation);
            txtnewrfp.DataBindings.Add(nameof(txtnewrfp.Text), vm, "TireEqualizer.NewTirePressures.RightFrontPressure", false, DataSourceUpdateMode.OnValidation);
            txtnewlfrp.DataBindings.Add(nameof(txtnewlfrp.Text), vm, "TireEqualizer.NewTirePressures.LeftRearPressure", false, DataSourceUpdateMode.OnValidation);
            txtnewrrp.DataBindings.Add(nameof(txtnewrrp.Text), vm, "TireEqualizer.NewTirePressures.RightRearPressure", false, DataSourceUpdateMode.OnValidation);
            txtoriginalleftfrontpressure.DataBindings.Add(nameof(txtoriginalleftfrontpressure.Text), vm, "Client.TirePreasures.LeftFrontPressure", false, DataSourceUpdateMode.OnPropertyChanged);
            txtoriginalrightfrontpresure.DataBindings.Add(nameof(txtoriginalrightfrontpresure.Text), vm, "Client.TirePreasures.RightFrontPressure", false, DataSourceUpdateMode.OnPropertyChanged);
            txtoriginalleftrearpressure.DataBindings.Add(nameof(txtoriginalleftrearpressure.Text), vm, "Client.TirePreasures.LeftRearPressure", false, DataSourceUpdateMode.OnPropertyChanged);
            txtoriginalrightrearpressure.DataBindings.Add(nameof(txtoriginalrightrearpressure.Text), vm, "Client.TirePreasures.RightRearPressure", false, DataSourceUpdateMode.OnPropertyChanged);
            txtLicencePLate.DataBindings.Add(nameof(txtLicencePLate.Text), vm, "Client.LicensePlateNumber", false, DataSourceUpdateMode.OnPropertyChanged);
            txtCarOwner.DataBindings.Add(nameof(txtCarOwner.Text), vm, "Client.Owner", false, DataSourceUpdateMode.OnPropertyChanged);
            txtType.DataBindings.Add(nameof(txtType.Text), vm, "Client.CarType", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSearch.DataBindings.Add(nameof(txtSearch.Text), vm, "Client.LicensePlateNumber", false, DataSourceUpdateMode.OnPropertyChanged);
            pictureBox3.DataBindings.Add(nameof(pictureBox3.Image), vm, "TireEqualizer.NewTirePressures.LeftFrontPicture", false, DataSourceUpdateMode.OnPropertyChanged);
            pictureBox4.DataBindings.Add(nameof(pictureBox4.Image), vm, "TireEqualizer.NewTirePressures.RightFrontPicture", false, DataSourceUpdateMode.OnPropertyChanged);
            pictureBox5.DataBindings.Add(nameof(pictureBox5.Image), vm, "TireEqualizer.NewTirePressures.LeftRearPicture", false, DataSourceUpdateMode.OnPropertyChanged);
            pictureBox6.DataBindings.Add(nameof(pictureBox6.Image), vm, "TireEqualizer.NewTirePressures.RightRearPicture", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                vm.ClientsDataTransporter.Path = openFileDialog.FileName;
                vm.ClientsDataTransporter.UploadCsvToSql();
                vm.SqlClientsRetriever.SetSQLClientList();
                DisplayClients();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayClients();
            DisplayCentralData();
            DisplayOriginalClients();
            vm.Client.TirePreasures.LeftFrontPicture = Properties.Resources.cartire; 
            vm.Client.TirePreasures.RightFrontPicture = Properties.Resources.cartire;
            vm.Client.TirePreasures.LeftRearPicture = Properties.Resources.cartire; 
            vm.Client.TirePreasures.RightRearPicture = Properties.Resources.cartire; 
        }
        private void DisplayCentralData()
        {          
            vm.SqlCentralRetriever.SetSQLCentralData();
            vm.SqlCentralDataList = vm.SqlCentralRetriever.SQLCentralDataList;
            grdClients.AutoGenerateColumns = false;
            grdCentralData.DataSource = null;
            grdCentralData.DataSource = vm.SqlCentralDataList;
            grdCentralData.Columns["CentralLicensePlateNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            grdCentralData.Columns["CentralOwner"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            grdCentralData.Columns["CentralCarType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            grdCentralData.Columns["Stolen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;

        }

        private void DisplayOriginalClients()
        {
            grdOriginalClients.AutoGenerateColumns = false;
            grdOriginalClients.DataSource = null;
            grdOriginalClients.DataSource = vm.SqlClientList;
            grdOriginalClients.Columns["clmLicense"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            grdOriginalClients.Columns["clmOwner"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            grdOriginalClients.Columns["clmCarType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdOriginalClients.Size = new System.Drawing.Size(600, 490);
        }
        private void DisplayClients()
        {
            vm.SqlClientsRetriever.SetSQLClientList();
            vm.SqlClientList = vm.SqlClientsRetriever.SQLClientList;
            grdClients.AutoGenerateColumns = false;
            grdClients.DataSource = null;
            grdClients.DataSource = vm.SqlClientList;
            grdClients.Columns["LicensePlateNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            grdClients.Columns["Owner"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            if (isCompared)
            {
                grdClients.Columns["Status"].Visible = true;
                grdClients.Size = new System.Drawing.Size(650, 490);
                grdClients.Columns["CarType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                grdClients.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                foreach (DataGridViewRow row in grdClients.Rows)
                {
                    if (row.Cells["Status"].Value.ToString() == "Tiszta")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (row.Cells["Status"].Value.ToString() == "Riasztás")
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
            else
            {
                grdClients.Columns["Status"].Visible = false;
                grdClients.Columns["CarType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grdClients.Size = new System.Drawing.Size(600, 490);
            }

            lblClientNumber.Text = "The Total number of clients: " + grdClients.RowCount.ToString();
        }

        private void grdClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isLoaded)
                return;
            if(isAdding)
            {
                vm.Client = new ClientsData();
                return;
            }
            int rowindex = grdClients.CurrentCell.RowIndex;
            int columnindex = grdClients.CurrentCell.ColumnIndex;
            string g = grdClients.CurrentCell.ValueType.ToString();
            vm.Client = grdClients.Rows[rowindex].DataBoundItem as ClientsData;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            vm.Client = new ClientsData();
            isAdding = true;
            btnSave.Visible = true;
            btnAdd.Visible = false;
            btnCancel.Visible = true;
            EnableTextBoxes();
            txtLicensePLate.Text = String.Empty;
            txtOwner.Text = String.Empty;
            txtCarType.Text = String.Empty;
            txtLeftFrontPreasure.Text = String.Empty;
            txtRightFrontPreasure.Text = String.Empty;
            txtLeftRearPreasure.Text = String.Empty;
            txtRightRearPreasure.Text = String.Empty;
            isLoaded = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            isAdding = false;
            vm.ClientsDataTransporter.SingleCliendToSql(vm.Client);
            DisplayClients();
            btnSave.Visible = false;
            btnAdd.Visible = true;
            btnCancel.Visible = false;
            DisableTextBoxes();
            isLoaded = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayClients();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            vm.ClientsDataTransporter.DeleteDataFromSQL(txtDelete.Text);
            DisplayClients();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isAdding = false;
            btnSave.Visible = false;
            btnAdd.Visible = true;
            btnCancel.Visible = false;
            txtCarType.Enabled = false;
            txtLicensePLate.Enabled = false;
            txtOwner.Enabled = false;
            txtLeftFrontPreasure.Enabled = false;
            txtRightFrontPreasure.Enabled = false;
            txtLeftRearPreasure.Enabled = false;
            txtRightRearPreasure.Enabled = false;
            isLoaded = true;
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedIndex != tabControl1.TabPages.IndexOf(tabCentralData))
                return;

        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            isCompared = true;
            vm.DataBaseComparator.ClientsDatas = vm.SqlClientList;
            vm.DataBaseComparator.centralDatas = vm.SqlCentralDataList;
            vm.DataBaseComparator.UploadDataToSQL();
            DisplayClients();
            btnDisableCompare.Visible = true;
            btnCompare.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            btnAdd.Visible = false;
            btnCancel.Visible = true;
            EnableTextBoxes();
            txtLicensePLate.Enabled = false;
        }

        public void EnableTextBoxes()
        {
            txtLicensePLate.Enabled = true;
            txtCarType.Enabled = true;
            txtOwner.Enabled = true;
            txtLeftFrontPreasure.Enabled = true;
            txtRightFrontPreasure.Enabled = true;
            txtLeftRearPreasure.Enabled = true;
            txtRightRearPreasure.Enabled = true;
        }

        public void DisableTextBoxes()
        {
            txtLicensePLate.Enabled = false;
            txtCarType.Enabled = false;
            txtOwner.Enabled = false;
            txtLeftFrontPreasure.Enabled = false;
            txtRightFrontPreasure.Enabled = false;
            txtLeftRearPreasure.Enabled = false;
            txtRightRearPreasure.Enabled = false;
        }

        public void EnableOriginalTextBoxes()
        {           
            txtnewlfp.Enabled = true;
            txtnewlfrp.Enabled = true;
            txtnewrfp.Enabled = true;
            txtnewrrp.Enabled = true;
        }

        private void btnDisableCompare_Click(object sender, EventArgs e)
        {
            isCompared = false;
            vm.DataBaseComparator.ClientsDatas = vm.SqlClientList;
            vm.DataBaseComparator.centralDatas = vm.SqlCentralDataList;
            vm.DataBaseComparator.UploadDataToSQL();
            DisplayClients();
            btnDisableCompare.Visible = false;
            btnCompare.Visible = true;
        }

        private void grdOriginalClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isLoaded)
                return;
            int rowindex = grdOriginalClients.CurrentCell.RowIndex;
            int columnindex = grdOriginalClients.CurrentCell.ColumnIndex;
            string g = grdOriginalClients.CurrentCell.ValueType.ToString();
            vm.Client = grdOriginalClients.Rows[rowindex].DataBoundItem as ClientsData;
        }

        private void btnPressureEdit_Click(object sender, EventArgs e)
        {
            vm.TireEqualizer.AutomaticEqualizer();
            vm.TireEqualizer.NewTirePressures.LeftFrontPressure = 3;
        }

        private void btnOriginalAdd_Click(object sender, EventArgs e)
        {
            vm.TireEqualizer.TirePressures = vm.Client.TirePreasures;
            EnableOriginalTextBoxes();
        }
    }
}
