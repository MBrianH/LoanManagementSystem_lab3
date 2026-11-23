using System;
using System.Globalization;
using System.Windows.Forms;
using LoanManagementSystem.Controllers;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Views
{
    public partial class LoanPayoutsForm : Form
    {
        private readonly LoanController _controller = new LoanController();

        public LoanPayoutsForm() : this(new StaffUser
        {
            UserID = 1,
            FullName = "Preview User",
            Role = "Administrator"
        })
        {
        }

        public LoanPayoutsForm(StaffUser user)
        {
            InitializeComponent();

            lblUser.Text = user.FullName + " | " + user.Role;

            btnSearch.Click += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnSave.Click += btnSave_Click;
            btnClear.Click += btnClear_Click;
            dgvRecords.CellClick += dgvRecords_CellClick;

            Load += LoanPayoutsForm_Load;
        }

        private void LoanPayoutsForm_Load(object? sender, EventArgs e)
        {
            LoadApprovedApplications();
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadApprovedApplications(txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadApprovedApplications();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtApplicationID.Text.Trim(), out int applicationID))
                {
                    throw new ArgumentException("Select an approved application from the table.");
                }

                if (!decimal.TryParse(txtPayoutAmount.Text.Trim(),
                        NumberStyles.Number, CultureInfo.CurrentCulture, out decimal amount))
                {
                    throw new ArgumentException("Enter a valid payout amount.");
                }

                if (!int.TryParse(txtRepaymentPeriod.Text.Trim(), out int period))
                {
                    throw new ArgumentException("Enter the repayment period in months.");
                }

                _controller.AddPayout(
                    applicationID,
                    amount,
                    DateTime.Today,
                    txtPaymentMethod.Text.Trim(),
                    txtReference.Text.Trim(),
                    period);

                MessageBox.Show("Loan payout recorded successfully.",
                    "Loan Payouts", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadApprovedApplications();
                ClearForm();
            }
            catch (Exception ex)
            {
                ShowError("Record payout", ex);
            }
        }

        private void dgvRecords_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvRecords.Rows[e.RowIndex];
            txtApplicationID.Text = Convert.ToString(row.Cells["ApplicationID"].Value) ?? "";
            txtPayoutAmount.Text = Convert.ToString(row.Cells["AmountRequested"].Value) ?? "";
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void LoadApprovedApplications(string search = "")
        {
            try
            {
                dgvRecords.DataSource = _controller.GetApprovedApplications(search);
                lblMessage.Text = "Only approved applications without a payout are listed.";
            }
            catch (Exception ex)
            {
                ShowError("Load approved applications", ex);
            }
        }

        private void ClearForm()
        {
            txtApplicationID.Clear();
            txtPayoutAmount.Clear();
            txtPaymentMethod.Clear();
            txtReference.Clear();
            txtRepaymentPeriod.Clear();
            dgvRecords.ClearSelection();
        }

        private static void ShowError(string action, Exception ex)
        {
            MessageBox.Show(ex.Message, action,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
