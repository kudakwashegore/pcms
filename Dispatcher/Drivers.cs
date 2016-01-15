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
    public partial class Drivers : Form
    {
        private int Id = 0;
        private DataTable _dataTable = null;
       
        public Drivers()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {           
            if(Valid())
            {
                DriverBl driverBl = new DriverBl();

                driverBl.Save(Id, fullNameTextBox.Text);

                fullNameTextBox.Text = "";
                Id = 0;

                RefreshGrid();
            }
            
        }

        private void Drivers_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];

                Id = int.Parse(Convert.ToString(selectedRow.Cells["Id"].Value));                
                fullNameTextBox.Text = Convert.ToString(selectedRow.Cells["FullName"].Value);
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            fullNameTextBox.Text = "";
            Id = 0;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];

                Id = int.Parse(Convert.ToString(selectedRow.Cells["Id"].Value));

                if (MessageBox.Show(String.Format("Are you sure to delete {0}?", Convert.ToString(selectedRow.Cells["FullName"].Value)), "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(TripBl.DriverInUse(Id))
                    {
                        MessageBox.Show("Driver is in use, can't be deleted.");
                        return;
                    }

                    DriverBl driverBl = new DriverBl();
                    driverBl.Delete(Id);
                    Id = 0;

                    RefreshGrid();
                }
            }
        }

        private void RefreshGrid()
        {
            _dataTable = Utility.ToDataTable(DriverBl.GetList());
            bindingSource.DataSource = _dataTable;
            dataGridView.DataSource = bindingSource;
            dataGridView.Update();
            dataGridView.Refresh();

            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "Full Name";

            dataGridViewSearch.SetColumns(dataGridView.Columns);
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

        public bool Valid()
        {
            if (String.IsNullOrEmpty(fullNameTextBox.Text) || String.IsNullOrWhiteSpace(fullNameTextBox.Text))
            {
                MessageBox.Show("Invalid value for driver name");
                fullNameTextBox.Focus();
                return false;
            }

            return true;
        }

    }
}
