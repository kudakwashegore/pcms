namespace UIView
{
    partial class Refills
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.litreageTextBox = new System.Windows.Forms.TextBox();
            this.mileageTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.newButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.vehicleComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridViewSearch = new Zuby.ADGV.AdvancedDataGridViewSearchToolBar();
            this.dataGridView = new Zuby.ADGV.AdvancedDataGridView();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(656, 470);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(575, 470);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "ddd dd MMM yyy";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(81, 388);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(261, 20);
            this.dateTimePicker.TabIndex = 2;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(473, 431);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(260, 20);
            this.amountTextBox.TabIndex = 3;
            // 
            // litreageTextBox
            // 
            this.litreageTextBox.Location = new System.Drawing.Point(83, 434);
            this.litreageTextBox.Name = "litreageTextBox";
            this.litreageTextBox.Size = new System.Drawing.Size(259, 20);
            this.litreageTextBox.TabIndex = 4;
            // 
            // mileageTextBox
            // 
            this.mileageTextBox.Location = new System.Drawing.Point(473, 388);
            this.mileageTextBox.Name = "mileageTextBox";
            this.mileageTextBox.Size = new System.Drawing.Size(258, 20);
            this.mileageTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Amount: $";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Litreage: Ltrs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mileage: Km";
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(656, 287);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 11;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(575, 287);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 12;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(494, 287);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 13;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 347);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Vehicle:";
            // 
            // vehicleComboBox
            // 
            this.vehicleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vehicleComboBox.FormattingEnabled = true;
            this.vehicleComboBox.Location = new System.Drawing.Point(81, 347);
            this.vehicleComboBox.Name = "vehicleComboBox";
            this.vehicleComboBox.Size = new System.Drawing.Size(650, 21);
            this.vehicleComboBox.TabIndex = 24;
            this.vehicleComboBox.SelectedIndexChanged += new System.EventHandler(this.vehicleComboBox_SelectedIndexChanged);
            // 
            // dataGridViewSearch
            // 
            this.dataGridViewSearch.AllowMerge = false;
            this.dataGridViewSearch.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.dataGridViewSearch.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSearch.MaximumSize = new System.Drawing.Size(0, 27);
            this.dataGridViewSearch.MinimumSize = new System.Drawing.Size(0, 27);
            this.dataGridViewSearch.Name = "dataGridViewSearch";
            this.dataGridViewSearch.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.dataGridViewSearch.Size = new System.Drawing.Size(744, 27);
            this.dataGridViewSearch.TabIndex = 26;
            this.dataGridViewSearch.Text = "advancedDataGridViewSearchToolBar1";
            this.dataGridViewSearch.Search += new Zuby.ADGV.AdvancedDataGridViewSearchToolBarSearchEventHandler(this.dataGridViewSearch_Search);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.FilterAndSortEnabled = true;
            this.dataGridView.Location = new System.Drawing.Point(0, 30);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(744, 233);
            this.dataGridView.TabIndex = 27;
            this.dataGridView.FilterStringChanged += new System.EventHandler(this.dataGridView_FilterStringChanged);
            // 
            // Refills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(744, 505);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.dataGridViewSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.vehicleComboBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mileageTextBox);
            this.Controls.Add(this.litreageTextBox);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Refills";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Fuel Refill";
            this.Load += new System.EventHandler(this.Refills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.TextBox litreageTextBox;
        private System.Windows.Forms.TextBox mileageTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox vehicleComboBox;
        private Zuby.ADGV.AdvancedDataGridViewSearchToolBar dataGridViewSearch;
        private Zuby.ADGV.AdvancedDataGridView dataGridView;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}