namespace UIView
{
    partial class Trips
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
            this.startDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.driverComboBox = new System.Windows.Forms.ComboBox();
            this.mileageStartTextBox = new System.Windows.Forms.TextBox();
            this.mileageEndTextBox = new System.Windows.Forms.TextBox();
            this.expenseAccountTextBox = new System.Windows.Forms.TextBox();
            this.tripDetailsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.startTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
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
            this.saveButton.Location = new System.Drawing.Point(729, 530);
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
            this.cancelButton.Location = new System.Drawing.Point(648, 530);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // startDateDateTimePicker
            // 
            this.startDateDateTimePicker.CustomFormat = "ddd dd MMM yyy";
            this.startDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDateDateTimePicker.Location = new System.Drawing.Point(177, 278);
            this.startDateDateTimePicker.Name = "startDateDateTimePicker";
            this.startDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.startDateDateTimePicker.TabIndex = 2;
            // 
            // endDateDateTimePicker
            // 
            this.endDateDateTimePicker.CustomFormat = "ddd dd MMM yyy";
            this.endDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDateDateTimePicker.Location = new System.Drawing.Point(598, 278);
            this.endDateDateTimePicker.Name = "endDateDateTimePicker";
            this.endDateDateTimePicker.Size = new System.Drawing.Size(206, 20);
            this.endDateDateTimePicker.TabIndex = 3;
            // 
            // driverComboBox
            // 
            this.driverComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driverComboBox.FormattingEnabled = true;
            this.driverComboBox.Location = new System.Drawing.Point(177, 381);
            this.driverComboBox.Name = "driverComboBox";
            this.driverComboBox.Size = new System.Drawing.Size(200, 21);
            this.driverComboBox.TabIndex = 4;
            // 
            // mileageStartTextBox
            // 
            this.mileageStartTextBox.Location = new System.Drawing.Point(177, 345);
            this.mileageStartTextBox.Name = "mileageStartTextBox";
            this.mileageStartTextBox.Size = new System.Drawing.Size(200, 20);
            this.mileageStartTextBox.TabIndex = 5;
            // 
            // mileageEndTextBox
            // 
            this.mileageEndTextBox.Location = new System.Drawing.Point(600, 345);
            this.mileageEndTextBox.Name = "mileageEndTextBox";
            this.mileageEndTextBox.Size = new System.Drawing.Size(204, 20);
            this.mileageEndTextBox.TabIndex = 6;
            // 
            // expenseAccountTextBox
            // 
            this.expenseAccountTextBox.Location = new System.Drawing.Point(600, 381);
            this.expenseAccountTextBox.Name = "expenseAccountTextBox";
            this.expenseAccountTextBox.Size = new System.Drawing.Size(204, 20);
            this.expenseAccountTextBox.TabIndex = 7;
            // 
            // tripDetailsRichTextBox
            // 
            this.tripDetailsRichTextBox.Location = new System.Drawing.Point(179, 424);
            this.tripDetailsRichTextBox.Name = "tripDetailsRichTextBox";
            this.tripDetailsRichTextBox.Size = new System.Drawing.Size(625, 84);
            this.tripDetailsRichTextBox.TabIndex = 8;
            this.tripDetailsRichTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "End Date and Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Start Date and Time :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Driver:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Mileage Start:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(516, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Mileage End:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(493, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Expense Account:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(99, 424);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Trip Details:";
            // 
            // startTimeDateTimePicker
            // 
            this.startTimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimeDateTimePicker.Location = new System.Drawing.Point(177, 305);
            this.startTimeDateTimePicker.Name = "startTimeDateTimePicker";
            this.startTimeDateTimePicker.ShowUpDown = true;
            this.startTimeDateTimePicker.Size = new System.Drawing.Size(91, 20);
            this.startTimeDateTimePicker.TabIndex = 16;
            // 
            // endTimeDateTimePicker
            // 
            this.endTimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endTimeDateTimePicker.Location = new System.Drawing.Point(598, 305);
            this.endTimeDateTimePicker.Name = "endTimeDateTimePicker";
            this.endTimeDateTimePicker.ShowUpDown = true;
            this.endTimeDateTimePicker.Size = new System.Drawing.Size(84, 20);
            this.endTimeDateTimePicker.TabIndex = 17;
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(729, 209);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 19;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(648, 208);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 20;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(567, 208);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 21;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(124, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Vehicle:";
            // 
            // vehicleComboBox
            // 
            this.vehicleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vehicleComboBox.FormattingEnabled = true;
            this.vehicleComboBox.Location = new System.Drawing.Point(177, 241);
            this.vehicleComboBox.Name = "vehicleComboBox";
            this.vehicleComboBox.Size = new System.Drawing.Size(627, 21);
            this.vehicleComboBox.TabIndex = 22;
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
            this.dataGridViewSearch.Size = new System.Drawing.Size(816, 27);
            this.dataGridViewSearch.TabIndex = 24;
            this.dataGridViewSearch.Text = "advancedDataGridViewSearchToolBar1";
            this.dataGridViewSearch.Search += new Zuby.ADGV.AdvancedDataGridViewSearchToolBarSearchEventHandler(this.dataGridViewSearch_Search);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.FilterAndSortEnabled = true;
            this.dataGridView.Location = new System.Drawing.Point(3, 31);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(813, 158);
            this.dataGridView.TabIndex = 25;
            this.dataGridView.FilterStringChanged += new System.EventHandler(this.dataGridView_FilterStringChanged);
            // 
            // Trips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(816, 565);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.dataGridViewSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.vehicleComboBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.endTimeDateTimePicker);
            this.Controls.Add(this.startTimeDateTimePicker);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tripDetailsRichTextBox);
            this.Controls.Add(this.expenseAccountTextBox);
            this.Controls.Add(this.mileageEndTextBox);
            this.Controls.Add(this.mileageStartTextBox);
            this.Controls.Add(this.driverComboBox);
            this.Controls.Add(this.endDateDateTimePicker);
            this.Controls.Add(this.startDateDateTimePicker);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Trips";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Trip";
            this.Load += new System.EventHandler(this.Trips_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DateTimePicker startDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateDateTimePicker;
        private System.Windows.Forms.TextBox mileageStartTextBox;
        private System.Windows.Forms.TextBox mileageEndTextBox;
        private System.Windows.Forms.TextBox expenseAccountTextBox;
        private System.Windows.Forms.RichTextBox tripDetailsRichTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker startTimeDateTimePicker;
        private System.Windows.Forms.DateTimePicker endTimeDateTimePicker;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ComboBox driverComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox vehicleComboBox;
        private Zuby.ADGV.AdvancedDataGridViewSearchToolBar dataGridViewSearch;
        private Zuby.ADGV.AdvancedDataGridView dataGridView;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}