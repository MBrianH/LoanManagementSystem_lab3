#nullable disable
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LoanManagementSystem.Views
{
    public partial class RepaymentScheduleForm
    {
        private IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblUser;
        private Panel pnlSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private DataGridView dgvRecords;

        private void InitializeComponent()
        {
            components = new Container();
            this.SuspendLayout();
            this.pnlHeader = new Panel(); this.lblTitle = new Label(); this.lblUser = new Label();
            this.pnlSearch = new Panel(); this.txtSearch = new TextBox(); this.btnSearch = new Button(); this.btnRefresh = new Button(); this.dgvRecords = new DataGridView();
            this.pnlHeader.Dock = DockStyle.Top; this.pnlHeader.Height = 64; this.pnlHeader.BackColor = Color.FromArgb(13,82,49); this.pnlHeader.Padding = new Padding(22,8,18,8);
            this.lblTitle.Text = "Repayment Schedule"; this.lblTitle.Dock = DockStyle.Left; this.lblTitle.Width = 420; this.lblTitle.TextAlign = ContentAlignment.MiddleLeft; this.lblTitle.Font = new Font("Segoe UI",18,FontStyle.Bold); this.lblTitle.ForeColor = Color.White;
            this.lblUser.Dock = DockStyle.Right; this.lblUser.Width = 310; this.lblUser.TextAlign = ContentAlignment.MiddleRight; this.lblUser.ForeColor = Color.FromArgb(240,220,165);
            this.pnlHeader.Controls.Add(this.lblUser); this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlSearch.Dock = DockStyle.Top; this.pnlSearch.Height = 58; this.pnlSearch.BackColor = Color.White; this.pnlSearch.Padding = new Padding(16,10,16,8);
            this.txtSearch.Location = new Point(16,12); this.txtSearch.Size = new Size(330,28); this.txtSearch.PlaceholderText = "Search records...";
            this.btnSearch.Text = "Search"; this.btnSearch.Location = new Point(360,11); this.btnSearch.Size = new Size(95,30);
            this.btnRefresh.Text = "Refresh"; this.btnRefresh.Location = new Point(465,11); this.btnRefresh.Size = new Size(95,30);
            this.pnlSearch.Controls.AddRange(new Control[] { this.txtSearch,this.btnSearch,this.btnRefresh });
            this.dgvRecords.Dock = DockStyle.Fill; this.dgvRecords.ReadOnly = true; this.dgvRecords.AllowUserToAddRows = false; this.dgvRecords.AllowUserToDeleteRows = false; this.dgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect; this.dgvRecords.MultiSelect = false; this.dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; this.dgvRecords.RowHeadersVisible = false; this.dgvRecords.ColumnHeadersHeight = 34; this.dgvRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; this.dgvRecords.DefaultCellStyle.SelectionBackColor = Color.FromArgb(13,82,49); this.dgvRecords.DefaultCellStyle.SelectionForeColor = Color.White; this.dgvRecords.BackgroundColor = Color.White; this.dgvRecords.BorderStyle = BorderStyle.FixedSingle; this.dgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13,82,49); this.dgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; this.dgvRecords.EnableHeadersVisualStyles = false;
            this.Controls.Add(this.dgvRecords);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);
            this.Name = "RepaymentScheduleForm";
            this.Text = "Loan Management System - Repayment Schedule";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.ClientSize = new Size(1100, 700);
            this.MinimumSize = new Size(980, 620);
            this.BackColor = Color.FromArgb(248, 249, 246);
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            this.ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
    }
}
