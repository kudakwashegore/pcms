using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

using RueEngine.Bl;
using RueEngine.Entities;
using RueEngine.Utilities;

namespace UIView
{
    public partial class Trips : Form
    {
        private int Id = 0;
        private DataTable _dataTable = null;

        public Trips()
        {
            InitializeComponent();
        } 

        private void Trips_Load(object sender, EventArgs e)
        {
            RefreshGrid();            

            NewDriverCompobox();
            NewVehicleCompobox();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {            
            if(Valid())
            { 
                TripBl tripBl = new TripBl();

                try
                {
                    tripBl.Save(Id, DateTime.Parse(startDateDateTimePicker.Text + " " + startTimeDateTimePicker.Text), DateTime.Parse(endDateDateTimePicker.Text + " " + endTimeDateTimePicker.Text), int.Parse(vehicleComboBox.SelectedValue.ToString()), int.Parse(driverComboBox.SelectedValue.ToString()), RefillBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())).Id, decimal.Parse(mileageStartTextBox.Text), decimal.Parse(mileageEndTextBox.Text), tripDetailsRichTextBox.Text, expenseAccountTextBox.Text);

                    startDateDateTimePicker.Text = startTimeDateTimePicker.Text = endDateDateTimePicker.Text = endTimeDateTimePicker.Text = DateTime.Now.ToString();
                    mileageStartTextBox.Text = mileageEndTextBox.Text = tripDetailsRichTextBox.Text = expenseAccountTextBox.Text = "";
                    Id = 0;
                }
                catch 
                {
                    MessageBox.Show("Trip not saved, make sure you add a fuel refill for this vehicle. ");
                }
                RefreshGrid();
                NewDriverCompobox();
                NewVehicleCompobox();
            }
        }

        private void RefreshGrid()
        {           

            _dataTable = Utility.ToDataTable(TripData.GetList());
            bindingSource.DataSource = _dataTable;
            dataGridView.DataSource = bindingSource;
            dataGridView.Update();
            dataGridView.Refresh();

            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "Start Date";
            dataGridView.Columns[2].HeaderText = "Start Time";
            dataGridView.Columns[3].HeaderText = "End Date";
            dataGridView.Columns[4].HeaderText = "End Time";
            dataGridView.Columns[5].Visible = false;
            dataGridView.Columns[6].HeaderText = "Driver";
            dataGridView.Columns[7].Visible = false;
            dataGridView.Columns[8].HeaderText = "Vehicle";
            dataGridView.Columns[9].HeaderText = "Refill Date";
            dataGridView.Columns[10].HeaderText = "Start Mileage";
            dataGridView.Columns[11].HeaderText = "End Mileage";
            dataGridView.Columns[12].Visible = false;
            dataGridView.Columns[13].Visible = false;

            dataGridViewSearch.SetColumns(dataGridView.Columns);
        }

        private void NewDriverCompobox()
        {
            driverComboBox.ValueMember = "Id";
            driverComboBox.DisplayMember = "FullName";
            driverComboBox.DataSource = DriverBl.GetList();
        }
        private void SelectedDriverCompobox(int Id)
        {
            driverComboBox.ValueMember = "Id";
            driverComboBox.DisplayMember = "FullName";
            driverComboBox.DataSource = DriverBl.GetList();
            driverComboBox.SelectedValue = Id;
        }
        private void vehicleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mileageStartTextBox.Text = TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())) != null ? TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())).MileageEnd.ToString() : "";
        }

        private void NewVehicleCompobox()
        {
            vehicleComboBox.ValueMember = "Id";
            vehicleComboBox.DisplayMember = "FullName";
            vehicleComboBox.DataSource = VehicleData.GetList();

            if (vehicleComboBox.Items.Count > 0) vehicleComboBox.SelectedIndex = 0;

            mileageStartTextBox.Text =  TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())) != null ? TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())).MileageEnd.ToString() : "";
        }
        private void SelectedVehicleCompobox(int Id)
        {
            vehicleComboBox.ValueMember = "Id";
            vehicleComboBox.DisplayMember = "FullName";
            vehicleComboBox.DataSource = VehicleData.GetList();
            vehicleComboBox.SelectedValue = Id;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];

                Id = int.Parse(Convert.ToString(selectedRow.Cells["Id"].Value));
                startDateDateTimePicker.Text = Convert.ToString(selectedRow.Cells["DateStart"].Value);
                startTimeDateTimePicker.Text = Convert.ToString(selectedRow.Cells["TimeStart"].Value);
                endDateDateTimePicker.Text = Convert.ToString(selectedRow.Cells["DateEnd"].Value);
                endTimeDateTimePicker.Text = Convert.ToString(selectedRow.Cells["TimeEnd"].Value);
                SelectedDriverCompobox(int.Parse(selectedRow.Cells["DriverId"].Value.ToString()));
                SelectedVehicleCompobox(int.Parse(selectedRow.Cells["VehicleId"].Value.ToString()));
                mileageStartTextBox.Text = Convert.ToString(selectedRow.Cells["MileageStart"].Value);
                mileageEndTextBox.Text = Convert.ToString(selectedRow.Cells["MileageEnd"].Value);
                tripDetailsRichTextBox.Text = Convert.ToString(selectedRow.Cells["TripDetails"].Value);
                expenseAccountTextBox.Text = Convert.ToString(selectedRow.Cells["ExpenseAccount"].Value);                
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];

                Id = int.Parse(Convert.ToString(selectedRow.Cells["Id"].Value));

                if (MessageBox.Show(String.Format("Are you sure to delete a trip on {0}?", Convert.ToString(selectedRow.Cells["DateStart"].Value)), "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TripBl tripBl = new TripBl();
                    tripBl.Delete(Id);
                    Id = 0;

                    RefreshGrid();
                    NewDriverCompobox();
                }
            }
        }

        private void dataGridView_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSource.Filter = dataGridView.FilterString;
        }

        private void dataGridViewSearch_Search(object sender, Zuby.ADGV.AdvancedDataGridViewSearchToolBarSearchEventArgs e)
        {
            int startColumn = 0;
            int startRow = 0;
            if (!e.FromBegin)
            {
                bool endcol = dataGridView.CurrentCell.ColumnIndex + 1 >= dataGridView.ColumnCount;
                bool endrow = dataGridView.CurrentCell.RowIndex + 1 >= dataGridView.RowCount;

                if (endcol && endrow)
                {
                    startColumn = dataGridView.CurrentCell.ColumnIndex;
                    startRow = dataGridView.CurrentCell.RowIndex;
                }
                else
                {
                    startColumn = endcol ? 0 : dataGridView.CurrentCell.ColumnIndex + 1;
                    startRow = dataGridView.CurrentCell.RowIndex + (endcol ? 1 : 0);
                }
            }

            DataGridViewCell c = dataGridView.FindCell(
                e.ValueToSearch,
                e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                startRow,
                startColumn,
                e.WholeWord,
                e.CaseSensitive);

            if (c != null)
                dataGridView.CurrentCell = c;
        }

        public bool Valid()
        {
            if (String.IsNullOrEmpty(mileageStartTextBox.Text) ||
                String.IsNullOrWhiteSpace(mileageStartTextBox.Text) ||
                !Utility.IsNumber(mileageStartTextBox.Text)
                )
            {
                MessageBox.Show("Invalid value for mileage start");
                mileageStartTextBox.Focus();
                return false;
            }

            if (TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())) != null && TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString()), Id).MileageEnd > decimal.Parse(mileageStartTextBox.Text))
            {
                MessageBox.Show("This vehicle is already above the mileage start given.");
                mileageStartTextBox.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(mileageEndTextBox.Text) ||
                String.IsNullOrWhiteSpace(mileageEndTextBox.Text) ||
                !Utility.IsNumber(mileageEndTextBox.Text)
                )
            {
                MessageBox.Show("Invalid value for mileage end");
                mileageEndTextBox.Focus();
                return false;
            }

            if (Decimal.Parse(mileageEndTextBox.Text) < Decimal.Parse(mileageStartTextBox.Text))
            {
                MessageBox.Show("Mileage end can not be less than mileage start");
                mileageEndTextBox.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(tripDetailsRichTextBox.Text) ||
                String.IsNullOrWhiteSpace(tripDetailsRichTextBox.Text) 
                )
            {
                MessageBox.Show("Invalid value for trip details");
                tripDetailsRichTextBox.Focus();
                return false;
            }
           
            if (TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString()), Id) != null && DateTime.Parse(startDateDateTimePicker.Text + " " + startTimeDateTimePicker.Text) <= TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString()), Id).DateTimeEnd)
            {
                MessageBox.Show("Start date and time can not be before end of the previous trip for this vehicle");
                startDateDateTimePicker.Focus();
                return false;
            }

            if (DateTime.Parse(startDateDateTimePicker.Text + " " + startTimeDateTimePicker.Text) >= DateTime.Parse(endDateDateTimePicker.Text + " " + endTimeDateTimePicker.Text))
            {
                MessageBox.Show("End date and time can not be before start date and time");
                endDateDateTimePicker.Focus();
                return false;
            }

            return true;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            startDateDateTimePicker.Text = startTimeDateTimePicker.Text = endDateDateTimePicker.Text = endTimeDateTimePicker.Text = DateTime.Now.ToString();
            mileageStartTextBox.Text = mileageEndTextBox.Text = tripDetailsRichTextBox.Text = expenseAccountTextBox.Text = "";

            NewVehicleCompobox();
            Id = 0;
        }
        
    }

    public class TripData
    {
        public virtual int Id { get; set; }
        public virtual string DateStart { get; set; }
        public virtual string TimeStart { get; set; }
        public virtual string DateEnd { get; set; }
        public virtual string TimeEnd { get; set; }
        public virtual int DriverId { get; set; }
        public virtual string DriverName { get; set; }
        public virtual int VehicleId { get; set; }
        public virtual string VehicleName { get; set; }
        public virtual string RefillDate { get; set; }
        public virtual decimal MileageStart { get; set; }
        public virtual decimal MileageEnd { get; set; }
        public virtual string TripDetails { get; set; }
        public virtual string ExpenseAccount { get; set; }

        public static List<TripData> GetList()
        {
            List<TripData> items = new List<TripData>();

            foreach(var item in TripBl.GetList())
            {
                TripData tripData = new TripData();

                tripData.Id = item.Id;
                tripData.DateStart = item.DateTimeStart.ToString("dddd dd MMM yyyy");
                tripData.TimeStart = item.DateTimeStart.ToString("hh:mm tt");
                tripData.DateEnd = item.DateTimeEnd.ToString("dddd dd MMM yyyy");
                tripData.TimeEnd = item.DateTimeEnd.ToString("hh:mm tt");
                tripData.DriverId = item.DriverId;
                tripData.DriverName = new DriverBl().GetById(item.DriverId).FullName;
                tripData.VehicleId = item.VehicleId;
                tripData.VehicleName = string.Format("{0}({1})", new VehicleBl().GetById(item.VehicleId).Name, new VehicleBl().GetById(item.VehicleId).RegistrationNumber);
                tripData.RefillDate = new RefillBl().GetById(item.RefillId).DateAndTime.ToString("dddd dd MMM yyyy");
                tripData.MileageStart = item.MileageStart;
                tripData.MileageEnd = item.MileageEnd;
                tripData.TripDetails = item.TripDetails;
                tripData.ExpenseAccount = item.ExpenseAccount;

                items.Add(tripData);

            }

            return items;
        }
    }

}
