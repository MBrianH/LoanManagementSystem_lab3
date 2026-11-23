using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using LoanManagementSystem.Controllers;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Views
{
    public partial class ReportsForm : Form
    {
        private readonly LoanController _controller = new LoanController();
        private readonly PrintDocument _printDocument = new PrintDocument();
        private string _statementText = "";

        public ReportsForm() : this(new StaffUser
        {
            UserID = 1,
            FullName = "Preview User",
            Role = "Administrator"
        })
        {
        }

        public ReportsForm(StaffUser user)
        {
            InitializeComponent();

            dtpFromDate.Value = DateTime.Today.AddMonths(-1);
            dtpToDate.Value = DateTime.Today;

            btnRunReport.Click += btnRunReport_Click;
            btnViewStatement.Click += btnViewStatement_Click;
            btnPrintStatement.Click += btnPrintStatement_Click;
            _printDocument.PrintPage += PrintDocument_PrintPage;
            FormClosed += (sender, e) => _printDocument.Dispose();

            Load += ReportsForm_Load;
        }

        private void ReportsForm_Load(object? sender, EventArgs e)
        {
            LoadClients();
        }

        private void LoadClients()
        {
            try
            {
                DataTable clients = _controller.GetClientChoicesForReports();

                cboClients.DataSource = clients;
                cboClients.DisplayMember = "FullName";
                cboClients.ValueMember = "ClientID";

                LoadReport();
            }
            catch (Exception ex)
            {
                ShowError("Load report data", ex);
            }
        }

        private void btnRunReport_Click(object? sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            if (dtpToDate.Value.Date < dtpFromDate.Value.Date)
            {
                MessageBox.Show(
                    "The end date must be on or after the start date.",
                    "Reports",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dgvRecords.DataSource = _controller.GetReports(
                    dtpFromDate.Value.Date,
                    dtpToDate.Value.Date);
            }
            catch (Exception ex)
            {
                ShowError("Run report", ex);
            }
        }

        private void btnViewStatement_Click(object? sender, EventArgs e)
        {
            if (cboClients.SelectedValue == null)
            {
                MessageBox.Show(
                    "Select a client first.",
                    "Loan Statement",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int clientID = Convert.ToInt32(cboClients.SelectedValue);
                DataTable statement = _controller.GetLoanStatement(clientID);

                dgvRecords.DataSource = statement;
                _statementText = BuildStatementText(statement);

                if (statement.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "There are no loan transactions for this client.",
                        "Loan Statement",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ShowError("View loan statement", ex);
            }
        }

        private string BuildStatementText(DataTable statement)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            builder.AppendLine("LOAN MANAGEMENT SYSTEM");
            builder.AppendLine("Client Loan Statement");
            builder.AppendLine("Client: " + cboClients.Text);
            builder.AppendLine("Generated: " + DateTime.Now.ToString("g"));
            builder.AppendLine(new string('-', 80));

            foreach (DataRow row in statement.Rows)
            {
                builder.AppendLine(
                    Convert.ToString(row["EntryDate"]) + " | " +
                    Convert.ToString(row["EntryType"]) + " | " +
                    Convert.ToString(row["Amount"]) + " | Balance: " +
                    Convert.ToString(row["Balance"]));
            }

            return builder.ToString();
        }

        private void btnPrintStatement_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_statementText))
            {
                MessageBox.Show(
                    "View a client's loan statement before printing.",
                    "Loan Statement",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = _printDocument;
            preview.Width = 900;
            preview.Height = 700;
            preview.ShowDialog(this);
        }

        private void PrintDocument_PrintPage(object? sender, PrintPageEventArgs e)
        {
            using Font font = new Font("Segoe UI", 10F);
            e.Graphics.DrawString(
                _statementText,
                font,
                Brushes.Black,
                e.MarginBounds);
        }

        private void ShowError(string action, Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                action,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
