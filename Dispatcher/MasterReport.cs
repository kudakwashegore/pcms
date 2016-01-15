using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using RueEngine.Bl;
using RueEngine.Entities;
using RueEngine.Utilities;

namespace UIView
{
    public partial class MasterReport : Form
    {
        public MasterReport()
        {
            InitializeComponent();
        }

        private void MasterReport_Load(object sender, EventArgs e)
        {
            try
            {
                NewVehicleCompobox();
                vehicleComboBox.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("No data to show yet.");
                this.Close();
            }
            

            MasterReportBindingSource.DataSource = UIView.Reporting.MasterReport.GetList(int.Parse(vehicleComboBox.SelectedValue.ToString()));
            this.masterReportViewer.RefreshReport();
        }

        private void NewVehicleCompobox()
        {
            vehicleComboBox.ValueMember = "Id";
            vehicleComboBox.DisplayMember = "FullName";
            vehicleComboBox.DataSource = VehicleData.GetList();
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            MasterReportBindingSource.DataSource = UIView.Reporting.MasterReport.GetList(int.Parse(vehicleComboBox.SelectedValue.ToString()));
            masterReportViewer.RefreshReport();
        }
    }
}
