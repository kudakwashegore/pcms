using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RueEngine.Bl;
using RueEngine.Utilities;

namespace UIView
{
    public partial class Main : Form
    {
        private DataTable _dataTable = null;

        public Main()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trips form = new Trips();
            form.ShowDialog();
        }

        private void refillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refills form = new Refills();
            form.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Drivers form = new Drivers();
            form.ShowDialog();
        } 
        private void vehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vehicles form = new Vehicles();
            form.ShowDialog();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            RefreshGrid();
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
            dataGridView.Columns[12].HeaderText = "Trip Details";
            dataGridView.Columns[13].HeaderText = "Expense Account";        

            dataGridViewSearch.SetColumns(dataGridView.Columns);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void dataGridView_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSource.Filter = dataGridView.FilterString;
        }

        private void dataGridView_SortStringChanged(object sender, EventArgs e)
        {
            bindingSource.Sort = dataGridView.SortString;
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

        private void masterSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterReport form = new MasterReport();
            form.ShowDialog();
        }

        private void driversToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DriversReport form = new DriversReport();
            form.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About form = new About();
            form.ShowDialog();
        }

    }
}
