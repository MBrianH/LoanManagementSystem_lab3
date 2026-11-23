#nullable disable
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LoanManagementSystem.Views
{
    public partial class ReportsForm
    {
        private IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlFilters;
        private Label lblFromDate;
        private DateTimePicker dtpFromDate;
        private Label lblToDate;
        private DateTimePicker dtpToDate;
        private Button btnRunReport;
        private Label lblClientStatement;
        private ComboBox cboClients;
        private Button btnViewStatement;
        private Button btnPrintStatement;
        private DataGridView dgvRecords;

        private void InitializeComponent()
        {
            components = new Container();
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlFilters = new Panel();
            lblFromDate = new Label();
            dtpFromDate = new DateTimePicker();
            lblToDate = new Label();
            dtpToDate = new DateTimePicker();
            btnRunReport = new Button();
            lblClientStatement = new Label();
            cboClients = new ComboBox();
            btnViewStatement = new Button();
            btnPrintStatement = new Button();
            dgvRecords = new DataGridView();

            SuspendLayout();

            pnlHeader.BackColor = Color.FromArgb(13, 82, 49);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 64;
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(22, 8, 18, 8);

            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Reports";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            pnlHeader.Controls.Add(lblTitle);

            pnlFilters.BackColor = Color.White;
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Height = 148;
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(18, 10, 18, 10);

            lblFromDate.Font = new Font("Segoe UI", 9.5F);
            lblFromDate.Location = new Point(18, 8);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(210, 22);
            lblFromDate.Text = "From date";

            dtpFromDate.Font = new Font("Segoe UI", 9.5F);
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(18, 32);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(210, 25);

            lblToDate.Font = new Font("Segoe UI", 9.5F);
            lblToDate.Location = new Point(248, 8);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(210, 22);
            lblToDate.Text = "To date";

            dtpToDate.Font = new Font("Segoe UI", 9.5F);
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(248, 32);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(210, 25);

            btnRunReport.BackColor = Color.FromArgb(13, 82, 49);
            btnRunReport.FlatStyle = FlatStyle.Flat;
            btnRunReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRunReport.ForeColor = Color.White;
            btnRunReport.Location = new Point(478, 27);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new Size(150, 36);
            btnRunReport.Text = "Run Report";
            btnRunReport.UseVisualStyleBackColor = false;

            lblClientStatement.Font = new Font("Segoe UI", 9.5F);
            lblClientStatement.Location = new Point(18, 91);
            lblClientStatement.Name = "lblClientStatement";
            lblClientStatement.Size = new Size(150, 28);
            lblClientStatement.Text = "Client loan statement";
            lblClientStatement.TextAlign = ContentAlignment.MiddleLeft;

            cboClients.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClients.Font = new Font("Segoe UI", 9.5F);
            cboClients.Location = new Point(175, 91);
            cboClients.Name = "cboClients";
            cboClients.Size = new Size(300, 28);

            btnViewStatement.Font = new Font("Segoe UI", 9.5F);
            btnViewStatement.Location = new Point(495, 87);
            btnViewStatement.Name = "btnViewStatement";
            btnViewStatement.Size = new Size(190, 36);
            btnViewStatement.Text = "View Statement";
            btnViewStatement.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnPrintStatement.Font = new Font("Segoe UI", 9.5F);
            btnPrintStatement.Location = new Point(700, 87);
            btnPrintStatement.Name = "btnPrintStatement";
            btnPrintStatement.Size = new Size(190, 36);
            btnPrintStatement.Text = "Print Statement";
            btnPrintStatement.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            pnlFilters.Controls.Add(lblFromDate);
            pnlFilters.Controls.Add(dtpFromDate);
            pnlFilters.Controls.Add(lblToDate);
            pnlFilters.Controls.Add(dtpToDate);
            pnlFilters.Controls.Add(btnRunReport);
            pnlFilters.Controls.Add(lblClientStatement);
            pnlFilters.Controls.Add(cboClients);
            pnlFilters.Controls.Add(btnViewStatement);
            pnlFilters.Controls.Add(btnPrintStatement);

            dgvRecords.AllowUserToAddRows = false;
            dgvRecords.AllowUserToDeleteRows = false;
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecords.BackgroundColor = Color.White;
            dgvRecords.BorderStyle = BorderStyle.FixedSingle;
            dgvRecords.ColumnHeadersHeight = 36;
            dgvRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13, 82, 49);
            dgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRecords.DefaultCellStyle.SelectionBackColor = Color.FromArgb(13, 82, 49);
            dgvRecords.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvRecords.Dock = DockStyle.Fill;
            dgvRecords.EnableHeadersVisualStyles = false;
            dgvRecords.MultiSelect = false;
            dgvRecords.Name = "dgvRecords";
            dgvRecords.ReadOnly = true;
            dgvRecords.RowHeadersVisible = false;
            dgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Controls.Add(dgvRecords);
            Controls.Add(pnlFilters);
            Controls.Add(pnlHeader);

            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(248, 249, 246);
            ClientSize = new Size(1050, 700);
            MinimumSize = new Size(1000, 620);
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.Sizable;
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Loan Management System - Reports";
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
    }
}
