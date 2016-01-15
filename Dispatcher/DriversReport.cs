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
    public partial class DriversReport: Form
    {
        public DriversReport()
        {
            InitializeComponent();
        }

        private void DriversReport_Load(object sender, EventArgs e)
        {
            try
            {
                NewVehicleCompobox();
                vehicleComboBox.SelectedIndex = 0;

                NewDriverCompobox();
                driverNameComboBox.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("No data to show yet.");
                this.Close();
            }


            MasterReportBindingSource.DataSource = UIView.Reporting.MasterReport.GetList(int.Parse(vehicleComboBox.SelectedValue.ToString()), int.Parse(driverNameComboBox.SelectedValue.ToString()));
            this.masterReportViewer.RefreshReport();
        }

        private void NewVehicleCompobox()
        {
            vehicleComboBox.ValueMember = "Id";
            vehicleComboBox.DisplayMember = "FullName";
            vehicleComboBox.DataSource = VehicleData.GetList();
        }
        private void NewDriverCompobox()
        {
            driverNameComboBox.ValueMember = "Id";
            driverNameComboBox.DisplayMember = "FullName";
            driverNameComboBox.DataSource = DriverBl.GetList();
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            MasterReportBindingSource.DataSource = UIView.Reporting.MasterReport.GetList(int.Parse(vehicleComboBox.SelectedValue.ToString()), int.Parse(driverNameComboBox.SelectedValue.ToString()));
            masterReportViewer.RefreshReport();
        }
    }
}
