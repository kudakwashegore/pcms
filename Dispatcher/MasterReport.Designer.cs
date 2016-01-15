namespace UIView
{
    partial class MasterReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.MasterReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.filterPanel = new System.Windows.Forms.Panel();
            this.viewButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.vehicleComboBox = new System.Windows.Forms.ComboBox();
            this.masterReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MasterReportBindingSource)).BeginInit();
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MasterReportBindingSource
            // 
            this.MasterReportBindingSource.DataSource = typeof(UIView.Reporting.MasterReport);
            // 
            // filterPanel
            // 
            this.filterPanel.BackColor = System.Drawing.SystemColors.Info;
            this.filterPanel.Controls.Add(this.viewButton);
            this.filterPanel.Controls.Add(this.label1);
            this.filterPanel.Controls.Add(this.vehicleComboBox);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 0);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(901, 37);
            this.filterPanel.TabIndex = 0;
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(347, 8);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(75, 23);
            this.viewButton.TabIndex = 2;
            this.viewButton.Text = "View Report";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vehicle Name:";
            // 
            // vehicleComboBox
            // 
            this.vehicleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vehicleComboBox.FormattingEnabled = true;
            this.vehicleComboBox.Location = new System.Drawing.Point(90, 8);
            this.vehicleComboBox.Name = "vehicleComboBox";
            this.vehicleComboBox.Size = new System.Drawing.Size(251, 21);
            this.vehicleComboBox.TabIndex = 0;
            // 
            // masterReportViewer
            // 
            this.masterReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "MasterReportDataset";
            reportDataSource2.Value = this.MasterReportBindingSource;
            this.masterReportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.masterReportViewer.LocalReport.ReportEmbeddedResource = "UIView.MasterReport.rdlc";
            this.masterReportViewer.Location = new System.Drawing.Point(0, 37);
            this.masterReportViewer.Name = "masterReportViewer";
            this.masterReportViewer.Size = new System.Drawing.Size(901, 375);
            this.masterReportViewer.TabIndex = 1;
            // 
            // MasterReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 412);
            this.Controls.Add(this.masterReportViewer);
            this.Controls.Add(this.filterPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MasterReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Master Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MasterReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MasterReportBindingSource)).EndInit();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox vehicleComboBox;
        private System.Windows.Forms.Button viewButton;
        private Microsoft.Reporting.WinForms.ReportViewer masterReportViewer;
        private System.Windows.Forms.BindingSource MasterReportBindingSource;
    }
}