using System;
using System.Globalization;
using System.Data;
using System.Windows.Forms;
using LoanManagementSystem.Controllers;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Views
{
    public partial class LoanApplicationsForm : Form
    {
        private readonly LoanController _controller = new LoanController();
        private int _selectedApplicationID;

        public LoanApplicationsForm() : this(new StaffUser
        {
            UserID = 1,
            FullName = "Preview User",
            Role = "Administrator"
        })
        {
        }

        public LoanApplicationsForm(StaffUser user)
        {
            InitializeComponent();

            lblUser.Text = user.FullName + " | " + user.Role;

            btnSearch.Click += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnClear.Click += btnClear_Click;
            dgvRecords.CellClick += dgvRecords_CellClick;

            Load += LoanApplicationsForm_Load;
        }

        private void LoanApplicationsForm_Load(object? sender, EventArgs e)
        {
            LoadClientChoices();
            LoadApplications();
        }

        private void LoadClientChoices()
        {
            try
            {
                DataTable clients = _controller.GetClientChoices();
                cboClient.DataSource = clients;
                cboClient.DisplayMember = "FullName";
                cboClient.ValueMember = "ClientID";
                cboClient.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ShowError("Load registered clients", ex);
            }
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadApplications(txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadApplications();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                LoanApplication application = ReadApplicationFromForm();
                application.ApplicationDate = DateTime.Today;

                _controller.AddApplication(application);

                MessageBox.Show("Loan application submitted for review.",
                    "Loan Applications", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadApplications();
                ClearForm();
            }
            catch (Exception ex)
            {
                ShowError("Submit application", ex);
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (_selectedApplicationID == 0)
            {
                MessageBox.Show("Select an application from the table first.",
                    "Loan Applications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                LoanApplication application = ReadApplicationFromForm();
                application.ApplicationID = _selectedApplicationID;

                _controller.UpdateApplication(application);

                MessageBox.Show("Pending application updated successfully.",
                    "Loan Applications", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadApplications(txtSearch.Text.Trim());
                ClearForm();
            }
            catch (Exception ex)
            {
                ShowError("Update application", ex);
            }
        }

        private LoanApplication ReadApplicationFromForm()
        {
            if (cboClient.SelectedValue == null)
            {
                throw new ArgumentException("Select a registered client.");
            }

            int clientID = Convert.ToInt32(cboClient.SelectedValue);

            if (!decimal.TryParse(txtAmountRequested.Text.Trim(),
                    NumberStyles.Number, CultureInfo.CurrentCulture, out decimal amount))
            {
                throw new ArgumentException("Enter a valid loan amount.");
            }

            if (!int.TryParse(txtRepaymentPeriod.Text.Trim(), out int period))
            {
                throw new ArgumentException("Enter the repayment period in months.");
            }

            return new LoanApplication
            {
                ClientID = clientID,
                AmountRequested = amount,
                Purpose = txtPurpose.Text.Trim(),
                RepaymentPeriod = period
            };
        }

        private void dgvRecords_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvRecords.Rows[e.RowIndex];

            if (Convert.ToString(row.Cells["Status"].Value) != "Pending Review")
            {
                ClearForm();
                MessageBox.Show("Only applications awaiting review can be edited.",
                    "Loan Applications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _selectedApplicationID = Convert.ToInt32(row.Cells["ApplicationID"].Value);
            cboClient.SelectedValue = Convert.ToInt32(row.Cells["ClientID"].Value);
            txtAmountRequested.Text = Convert.ToString(row.Cells["AmountRequested"].Value) ?? "";
            txtPurpose.Text = Convert.ToString(row.Cells["Purpose"].Value) ?? "";
            txtRepaymentPeriod.Text = Convert.ToString(row.Cells["RepaymentPeriod"].Value) ?? "";
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void LoadApplications(string search = "")
        {
            try
            {
                dgvRecords.DataSource = _controller.GetApplications(search);
                lblMessage.Text = "Application records loaded.";
            }
            catch (Exception ex)
            {
                ShowError("Load applications", ex);
            }
        }

        private void ClearForm()
        {
            _selectedApplicationID = 0;

            cboClient.SelectedIndex = -1;
            txtAmountRequested.Clear();
            txtPurpose.Clear();
            txtRepaymentPeriod.Clear();

            dgvRecords.ClearSelection();
            cboClient.Focus();
        }

        private static void ShowError(string action, Exception ex)
        {
            MessageBox.Show(ex.Message, action,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
