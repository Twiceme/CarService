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
        public Form1()
        {
            InitializeComponent();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
  //          vm.SqlClinetsRetriever.SetSQLClientList();
   //         vm.SqlClientList = vm.SqlClinetsRetriever.SQLClientList;
            dataGridView1.RowCount = vm.SqlClientList.Count;
            int i = 0;
            foreach (ClientsData client in vm.SqlClientList)
            {
                dataGridView1.Rows[i].Cells["LicensePlateNumber"].Value = client.LicensePlateNumber;
                dataGridView1.Rows[i].Cells["Owner"].Value = client.Owner;
                dataGridView1.Rows[i].Cells["CarType"].Value = client.CarType;
                i++;
            }
            label1.Text = dataGridView1.RowCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vm.SqlClinetsRetriever.SetSQLClientList();
            vm.SqlClientList = vm.SqlClinetsRetriever.SQLClientList;
        }
    }
}
