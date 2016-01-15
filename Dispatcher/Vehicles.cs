using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RueEngine.Entities;
using RueEngine.Bl;
using RueEngine.Utilities;

namespace UIView
{
    public partial class Vehicles : Form
    {
        private int Id = 0;
        private DataTable _dataTable = null;

        public Vehicles()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(Valid())
            {
                VehicleBl vehicleBl = new VehicleBl();

                vehicleBl.Save(Id, nameTextBox.Text, registrationNumberTextBox.Text);

                nameTextBox.Text = registrationNumberTextBox.Text  = "";
                Id = 0;

                RefreshGrid();
            }            
        }

        private void RefreshGrid()
        {
            _dataTable = Utility.ToDataTable(VehicleBl.GetList());
            bindingSource.DataSource = _dataTable;
            dataGridView.DataSource = bindingSource;
            dataGridView.Update();
            dataGridView.Refresh();

            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "Vehicle name";
            dataGridView.Columns[2].HeaderText = "Registration Number";

            dataGridViewSearch.SetColumns(dataGridView.Columns);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];

                Id = int.Parse(Convert.ToString(selectedRow.Cells["Id"].Value));
                nameTextBox.Text = Convert.ToString(selectedRow.Cells["Name"].Value);
                registrationNumberTextBox.Text = Convert.ToString(selectedRow.Cells["RegistrationNumber"].Value);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];

                Id = int.Parse(Convert.ToString(selectedRow.Cells["Id"].Value));

                if (MessageBox.Show(String.Format("Are you sure to delete {0}({1})?", Convert.ToString(selectedRow.Cells["Name"].Value), Convert.ToString(selectedRow.Cells["RegistrationNumber"].Value)), "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (TripBl.VehicleInUse(Id) || RefillBl.VehicleInUse(Id))
                    {
                        MessageBox.Show("Vehicle is in use, can't be deleted.");
                        return;
                    }

                    VehicleBl vehicleBl = new VehicleBl();
                    vehicleBl.Delete(Id);
                    Id = 0;

                    RefreshGrid();
                }
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = registrationNumberTextBox.Text = "";
            Id = 0;
        }

        private void Vehicles_Load(object sender, EventArgs e)
        {
            RefreshGrid();
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
            if (String.IsNullOrEmpty(nameTextBox.Text) || String.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Invalid value for vehicle name");
                nameTextBox.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(registrationNumberTextBox.Text) || String.IsNullOrWhiteSpace(registrationNumberTextBox.Text))
            {
                MessageBox.Show("Invalid value for registration number");
                registrationNumberTextBox.Focus();
                return false;
            }

            return true;
        }
    }
}
