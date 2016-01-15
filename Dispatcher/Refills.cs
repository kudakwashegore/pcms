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
    public partial class Refills : Form
    {
        private int Id = 0;
        private DataTable _dataTable = null;

        public Refills()
        {
            InitializeComponent();
        }

        private void Refills_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            NewVehicleCompobox();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {            
            if(Valid())
            {
                RefillBl refillBl = new RefillBl();           
            
                //Close  previous refill
                if (Id == 0 && RefillBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())) != null) refillBl.SetClosed(RefillBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())));
                try
                {


                    refillBl.Save(Id, DateTime.Parse(dateTimePicker.Text), int.Parse(vehicleComboBox.SelectedValue.ToString()), decimal.Parse(amountTextBox.Text), double.Parse(litreageTextBox.Text), decimal.Parse(mileageTextBox.Text));                

                    dateTimePicker.Text = DateTime.Today.ToString();
                    amountTextBox.Text = mileageTextBox.Text = litreageTextBox.Text = "";
                    Id = 0;
                }
                catch (Exception ex) { MessageBox.Show("Error occured: " + ex.Message); }           

                RefreshGrid();
                NewVehicleCompobox();
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            dateTimePicker.Text = DateTime.Today.ToString();
            amountTextBox.Text = mileageTextBox.Text = litreageTextBox.Text = "";
            Id = 0;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];

                Id = int.Parse(Convert.ToString(selectedRow.Cells["Id"].Value));
                dateTimePicker.Text = Convert.ToString(selectedRow.Cells["Date"].Value);
                SelectedVehicleCompobox(int.Parse(selectedRow.Cells["VehicleId"].Value.ToString()));
                amountTextBox.Text = Convert.ToString(selectedRow.Cells["Amount"].Value);
                mileageTextBox.Text = Convert.ToString(selectedRow.Cells["Mileage"].Value);
                litreageTextBox.Text = Convert.ToString(selectedRow.Cells["Litreage"].Value);                
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];

                Id = int.Parse(Convert.ToString(selectedRow.Cells["Id"].Value));

                if (MessageBox.Show(String.Format("Are you sure to delete refill on {0}?", Convert.ToString(selectedRow.Cells["Date"].Value)), "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (TripBl.RefillInUse(Id))
                    {
                        MessageBox.Show("Refill is in use, can't be deleted.");
                        return;
                    }

                    RefillBl refillBl = new RefillBl();
                    refillBl.Delete(Id);
                    Id = 0;

                    RefreshGrid();
                }
            }
        }
        private void vehicleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mileageTextBox.Text = TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())) != null ? TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())).MileageEnd.ToString() : "";
        }

        private void RefreshGrid()
        {
            _dataTable = Utility.ToDataTable(RefillData.GetList());

            bindingSource.DataSource = _dataTable;
            dataGridView.DataSource = bindingSource;
            dataGridView.Update();
            dataGridView.Refresh();

            dataGridView.Columns[0].Visible = dataGridView.Columns[2].Visible = false;
            dataGridView.Columns[3].HeaderText = "Vehicle Name";

            dataGridViewSearch.SetColumns(dataGridView.Columns);
        }

        private void NewVehicleCompobox()
        {
            vehicleComboBox.ValueMember = "Id";
            vehicleComboBox.DisplayMember = "FullName";
            vehicleComboBox.DataSource = VehicleData.GetList();
            
            if(vehicleComboBox.Items.Count > 0) vehicleComboBox.SelectedIndex =  0;

            mileageTextBox.Text = TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())) != null ? TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())).MileageEnd.ToString() : "";
        }
        private void SelectedVehicleCompobox(int Id)
        {
            vehicleComboBox.ValueMember = "Id";
            vehicleComboBox.DisplayMember = "FullName";
            vehicleComboBox.DataSource = VehicleData.GetList();
            vehicleComboBox.SelectedValue = Id;
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

        private void dataGridView_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSource.Filter = dataGridView.FilterString;
        }

        public bool  Valid()
        {
            if (String.IsNullOrEmpty(mileageTextBox.Text) ||
                String.IsNullOrWhiteSpace(mileageTextBox.Text) ||
                !Utility.IsNumber(mileageTextBox.Text) 
                )
            {
                MessageBox.Show("Invalid value for mileage");
                mileageTextBox.Focus();
                return false;
            }

            if(Id == 0 && TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())) != null && TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())).MileageEnd > decimal.Parse(mileageTextBox.Text))
            {
                MessageBox.Show("This vehicle is already above the mileage given.");
                mileageTextBox.Focus();
                return false;
            }

            if (Id > 0 && RefillBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString()), Id) != null && RefillBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString()), Id).Mileage > decimal.Parse(mileageTextBox.Text))
            {
                MessageBox.Show("This vehicle was already above the mileage given.");
                mileageTextBox.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(litreageTextBox.Text) ||
                String.IsNullOrWhiteSpace(litreageTextBox.Text) ||
                !Utility.IsNumber(litreageTextBox.Text)
                )
            {
                MessageBox.Show("Invalid value for litreage");
                litreageTextBox.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(amountTextBox.Text) ||
                String.IsNullOrWhiteSpace(amountTextBox.Text) ||
                !Utility.IsNumber(amountTextBox.Text)
                )
            {
                MessageBox.Show("Invalid value for amount");
                amountTextBox.Focus();
                return false;
            }

            if (RefillBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString()), Id) != null && DateTime.Parse(dateTimePicker.Text) < RefillBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString()), Id).DateAndTime)
            { 
                MessageBox.Show("Date can not be before the previous refill for this vehicle");
                dateTimePicker.Focus();
                return false;
            }

            if (TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())) != null && DateTime.Parse(dateTimePicker.Text).Date < TripBl.GetPrevious(int.Parse(vehicleComboBox.SelectedValue.ToString())).DateTimeEnd.Date)
            {
                MessageBox.Show("Date can not be before the previous last trip for this vehicle");
                dateTimePicker.Focus();
                return false;
            }

            

            return true;
        }

        
    }

    public class RefillData
    {
        public virtual int Id { get; set; }
        public virtual string Date { get; set; }

        public virtual int VehicleId { get; set; }
        public virtual string VehicleName { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual double Litreage { get; set; }
        public virtual decimal Mileage { get; set; }

        public static List<RefillData> GetList()
        {            
            List<RefillData> items = new List<RefillData>();

            foreach(var item in RefillBl.GetList())
            {
                RefillData refillData = new RefillData();
                refillData.Id = item.Id;
                refillData.Date = item.DateAndTime.ToString("dddd dd MMM yyyy");
                refillData.VehicleId = item.VehicleId;
                refillData.VehicleName = string.Format("{0}({1})", new VehicleBl().GetById(item.VehicleId).Name, new VehicleBl().GetById(item.VehicleId).RegistrationNumber);
                refillData.Amount = item.Amount;
                refillData.Litreage = item.Litreage;
                refillData.Mileage = item.Mileage;

                items.Add(refillData);
            }

            return items;
        }
       
    }
}
