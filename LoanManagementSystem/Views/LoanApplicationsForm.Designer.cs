#nullable disable
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LoanManagementSystem.Views
{
    public partial class LoanApplicationsForm
    {
        private IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblUser;
        private Panel pnlSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private Panel pnlEntry;
        private TableLayoutPanel tlpEntry;
        private Panel pnlActions;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnClear;
        private DataGridView dgvRecords;
        private Label lblMessage;
        private Label lblClientID;
        private ComboBox cboClient;
        private Label lblAmountRequested;
        private TextBox txtAmountRequested;
        private Label lblPurpose;
        private TextBox txtPurpose;
        private Label lblRepaymentPeriod;
        private TextBox txtRepaymentPeriod;

        private void InitializeComponent()
        {
            components = new Container();
            this.SuspendLayout();
            this.pnlHeader = new Panel(); this.lblTitle = new Label(); this.lblUser = new Label();
            this.pnlSearch = new Panel(); this.txtSearch = new TextBox(); this.btnSearch = new Button(); this.btnRefresh = new Button();
            this.pnlEntry = new Panel(); this.tlpEntry = new TableLayoutPanel(); this.pnlActions = new Panel();
            this.btnSave = new Button(); this.btnUpdate = new Button(); this.btnClear = new Button(); this.dgvRecords = new DataGridView(); this.lblMessage = new Label();
            this.lblClientID = new Label(); this.cboClient = new ComboBox();
            this.lblAmountRequested = new Label(); this.txtAmountRequested = new TextBox();
            this.lblPurpose = new Label(); this.txtPurpose = new TextBox();
            this.lblRepaymentPeriod = new Label(); this.txtRepaymentPeriod = new TextBox();
            this.pnlHeader.Dock = DockStyle.Top; this.pnlHeader.Height = 64; this.pnlHeader.BackColor = Color.FromArgb(13,82,49); this.pnlHeader.Padding = new Padding(22,8,18,8);
            this.lblTitle.Text = "Loan Applications"; this.lblTitle.Dock = DockStyle.Left; this.lblTitle.Width = 420; this.lblTitle.TextAlign = ContentAlignment.MiddleLeft; this.lblTitle.Font = new Font("Segoe UI",18,FontStyle.Bold); this.lblTitle.ForeColor = Color.White;
            this.lblUser.Dock = DockStyle.Right; this.lblUser.Width = 310; this.lblUser.TextAlign = ContentAlignment.MiddleRight; this.lblUser.ForeColor = Color.FromArgb(240,220,165);
            this.pnlHeader.Controls.Add(this.lblUser); this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlSearch.Dock = DockStyle.Top; this.pnlSearch.Height = 58; this.pnlSearch.BackColor = Color.White; this.pnlSearch.Padding = new Padding(16,10,16,8);
            this.txtSearch.Location = new Point(16,12); this.txtSearch.Size = new Size(330,30); this.txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left; this.txtSearch.PlaceholderText = "Search records...";
            this.btnSearch.Text = "Search"; this.btnSearch.Location = new Point(360,11); this.btnSearch.Size = new Size(100,32);
            this.btnRefresh.Text = "Refresh"; this.btnRefresh.Location = new Point(470,11); this.btnRefresh.Size = new Size(100,32);
            this.pnlSearch.Controls.AddRange(new Control[] { this.txtSearch,this.btnSearch,this.btnRefresh });
            this.pnlEntry.Dock = DockStyle.Top; this.pnlEntry.Height = 112; this.pnlEntry.BackColor = Color.White; this.pnlEntry.Padding = new Padding(12,8,12,8);
            this.tlpEntry.Dock = DockStyle.Fill; this.tlpEntry.ColumnCount = 4; this.tlpEntry.RowCount = 2; this.tlpEntry.RowStyles.Add(new RowStyle(SizeType.Percent,42F)); this.tlpEntry.RowStyles.Add(new RowStyle(SizeType.Percent,58F));
            this.tlpEntry.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,25.0000F));
            this.tlpEntry.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,25.0000F));
            this.tlpEntry.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,25.0000F));
            this.tlpEntry.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,25.0000F));
            this.lblClientID.Text = "Registered client"; this.lblClientID.Dock = DockStyle.Fill; this.lblClientID.TextAlign = ContentAlignment.BottomLeft; this.lblClientID.Margin = new Padding(6,0,6,2);
            this.cboClient.Dock = DockStyle.Fill; this.cboClient.Margin = new Padding(6,3,6,4); this.cboClient.DropDownStyle = ComboBoxStyle.DropDownList;
            this.tlpEntry.Controls.Add(this.lblClientID,0,0); this.tlpEntry.Controls.Add(this.cboClient,0,1);
            this.lblAmountRequested.Text = "Amount Requested"; this.lblAmountRequested.Dock = DockStyle.Fill; this.lblAmountRequested.TextAlign = ContentAlignment.BottomLeft; this.lblAmountRequested.Margin = new Padding(6,0,6,2);
            this.txtAmountRequested.Dock = DockStyle.Fill; this.txtAmountRequested.Margin = new Padding(6,3,6,4);
            this.tlpEntry.Controls.Add(this.lblAmountRequested,1,0); this.tlpEntry.Controls.Add(this.txtAmountRequested,1,1);
            this.lblPurpose.Text = "Purpose"; this.lblPurpose.Dock = DockStyle.Fill; this.lblPurpose.TextAlign = ContentAlignment.BottomLeft; this.lblPurpose.Margin = new Padding(6,0,6,2);
            this.txtPurpose.Dock = DockStyle.Fill; this.txtPurpose.Margin = new Padding(6,3,6,4);
            this.tlpEntry.Controls.Add(this.lblPurpose,2,0); this.tlpEntry.Controls.Add(this.txtPurpose,2,1);
            this.lblRepaymentPeriod.Text = "Repayment Period (months)"; this.lblRepaymentPeriod.Dock = DockStyle.Fill; this.lblRepaymentPeriod.TextAlign = ContentAlignment.BottomLeft; this.lblRepaymentPeriod.Margin = new Padding(6,0,6,2);
            this.txtRepaymentPeriod.Dock = DockStyle.Fill; this.txtRepaymentPeriod.Margin = new Padding(6,3,6,4);
            this.tlpEntry.Controls.Add(this.lblRepaymentPeriod,3,0); this.tlpEntry.Controls.Add(this.txtRepaymentPeriod,3,1);
            this.pnlEntry.Controls.Add(this.tlpEntry);
            this.pnlActions.Dock = DockStyle.Top; this.pnlActions.Height = 48; this.pnlActions.BackColor = Color.FromArgb(248,249,246); this.pnlActions.Padding = new Padding(16,6,12,6);
            this.btnSave.Text = "Submit Application"; this.btnSave.Size = new Size(165,34); this.btnSave.Location = new Point(16,6); this.btnSave.BackColor = Color.FromArgb(13,82,49); this.btnSave.ForeColor = Color.White; this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnUpdate.Text = "Update"; this.btnUpdate.Size = new Size(110,34); this.btnUpdate.Location = new Point(191,6);
            this.btnClear.Text = "Clear"; this.btnClear.Size = new Size(100,34); this.btnClear.Location = new Point(311,6);
            this.pnlActions.Controls.AddRange(new Control[] { this.btnSave,this.btnUpdate,this.btnClear });
            this.dgvRecords.Dock = DockStyle.Fill; this.dgvRecords.ReadOnly = true; this.dgvRecords.AllowUserToAddRows = false; this.dgvRecords.AllowUserToDeleteRows = false; this.dgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect; this.dgvRecords.MultiSelect = false; this.dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; this.dgvRecords.ScrollBars = ScrollBars.Both; this.dgvRecords.AllowUserToResizeColumns = true; this.dgvRecords.RowHeadersVisible = false; this.dgvRecords.ColumnHeadersHeight = 34; this.dgvRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; this.dgvRecords.DefaultCellStyle.SelectionBackColor = Color.FromArgb(13,82,49); this.dgvRecords.DefaultCellStyle.SelectionForeColor = Color.White; this.dgvRecords.ColumnHeadersHeight = 34; this.dgvRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; this.dgvRecords.BackgroundColor = Color.White; this.dgvRecords.BorderStyle = BorderStyle.FixedSingle; this.dgvRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13,82,49); this.dgvRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; this.dgvRecords.EnableHeadersVisualStyles = false;
            this.lblMessage.Dock = DockStyle.Bottom; this.lblMessage.Height = 26; this.lblMessage.ForeColor = Color.FromArgb(13,82,49); this.lblMessage.Padding = new Padding(12,4,0,0);
            this.Controls.Add(this.dgvRecords);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlEntry);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);
            this.Name = "LoanApplicationsForm";
            this.Text = "Loan Management System - Loan Applications";
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
