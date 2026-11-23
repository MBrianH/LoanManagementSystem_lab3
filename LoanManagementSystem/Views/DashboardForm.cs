using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using LoanManagementSystem.Controllers;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Views
{
    public partial class DashboardForm : Form
    {
        private readonly StaffUser _currentStaff;
        private readonly LoanController _controller = new LoanController();

        public DashboardForm() : this(new StaffUser
        {
            UserID = 1,
            FullName = "Preview User",
            Username = "preview",
            Role = "Administrator",
            AccountStatus = "Active"
        })
        {
        }

        public DashboardForm(StaffUser staff)
        {
            InitializeComponent();
            _currentStaff = staff;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                WindowState = FormWindowState.Maximized;
            }

            lblCurrentUser.Text = staff.FullName + Environment.NewLine + staff.Role;
            lblWelcome.Text = "Welcome, " + staff.FullName;

            ConfigureMenu();

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                LoadDashboardCounts();
            }
        }

        private void ConfigureMenu()
        {
            btnClients.Visible = HasRole("Administrator", "Loan Officer");
            btnApplications.Visible = HasRole("Administrator", "Loan Officer");
            btnDecisions.Visible = HasRole("Administrator", "Loan Manager");
            btnPayouts.Visible = HasRole("Administrator", "Cashier");
            btnActiveLoans.Visible = HasRole("Administrator", "Loan Officer", "Loan Manager", "Cashier");
            btnRepayments.Visible = HasRole("Administrator", "Cashier");
            btnSchedule.Visible = HasRole("Administrator", "Cashier", "Loan Manager");
            btnReports.Visible = HasRole("Administrator", "Loan Manager");
            btnStaff.Visible = _currentStaff.Role == "Administrator";

            btnClients.Click += (sender, e) => OpenForm(new ClientManagementForm(_currentStaff));
            btnApplications.Click += (sender, e) => OpenForm(new LoanApplicationsForm(_currentStaff));
            btnDecisions.Click += (sender, e) => OpenForm(new LoanDecisionsForm(_currentStaff));
            btnPayouts.Click += (sender, e) => OpenForm(new LoanPayoutsForm(_currentStaff));
            btnActiveLoans.Click += (sender, e) => OpenForm(new ActiveLoansForm(_currentStaff));
            btnRepayments.Click += (sender, e) => OpenForm(new RepaymentsForm(_currentStaff));
            btnSchedule.Click += (sender, e) => OpenForm(new RepaymentScheduleForm(_currentStaff));
            btnReports.Click += (sender, e) => OpenForm(new ReportsForm(_currentStaff));
            btnStaff.Click += (sender, e) => OpenForm(new StaffManagementForm(_currentStaff));
            btnLogout.Click += (sender, e) => Close();
        }

        private bool HasRole(params string[] roles)
        {
            foreach (string role in roles)
            {
                if (_currentStaff.Role == role)
                {
                    return true;
                }
            }

            return false;
        }

        private void OpenForm(Form form)
        {
            using (form)
            {
                form.ShowDialog(this);
            }

            LoadDashboardCounts();
        }

        private void LoadDashboardCounts()
        {
            try
            {
                DataTable counts = _controller.GetDashboardCounts();

                if (counts.Rows.Count == 0)
                {
                    return;
                }

                DataRow row = counts.Rows[0];

                lblClientsValue.Text = Convert.ToString(row["Clients"]) ?? "0";
                lblApplicationsValue.Text = Convert.ToString(row["Applications"]) ?? "0";
                lblLoansValue.Text = Convert.ToString(row["ActiveLoans"]) ?? "0";
                lblOverdueValue.Text = Convert.ToString(row["Overdue"]) ?? "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The dashboard totals could not be loaded. Check the database connection." +
                    Environment.NewLine + Environment.NewLine + ex.Message,
                    "Dashboard",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
