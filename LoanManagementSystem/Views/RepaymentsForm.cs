using System;
using System.Globalization;
using System.Data;
using System.Windows.Forms;
using LoanManagementSystem.Controllers;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Views
{
    public partial class RepaymentsForm : Form
    {
        private readonly LoanController _controller = new LoanController();

        public RepaymentsForm() : this(new StaffUser
        {
            UserID = 1,
            FullName = "Preview User",
            Role = "Administrator"
        })
        {
        }

        public RepaymentsForm(StaffUser user)
        {
            InitializeComponent();

            lblUser.Text = user.FullName + " | " + user.Role;

            btnSearch.Click += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnSave.Click += btnSave_Click;
            btnClear.Click += btnClear_Click;
            dgvRecords.CellClick += dgvRecords_CellClick;

            Load += RepaymentsForm_Load;
        }

        private void RepaymentsForm_Load(object? sender, EventArgs e)
        {
            LoadActiveLoans();
            LoadRepayments();
        }

        private void LoadActiveLoans()
        {
            try
            {
                DataTable loans = _controller.GetLoanChoices();
                cboLoan.DataSource = loans;
                cboLoan.DisplayMember = "LoanName";
                cboLoan.ValueMember = "LoanID";
                cboLoan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ShowError("Load active loans", ex);
            }
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadRepayments(txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadRepayments();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (cboLoan.SelectedValue == null)
                {
                    throw new ArgumentException("Select an active loan.");
                }

                int loanID = Convert.ToInt32(cboLoan.SelectedValue);

                if (!decimal.TryParse(txtAmountPaid.Text.Trim(),
                        NumberStyles.Number, CultureInfo.CurrentCulture, out decimal amount))
                {
                    throw new ArgumentException("Enter a valid repayment amount.");
                }

                _controller.AddRepayment(
                    loanID,
                    amount,
                    DateTime.Today,
                    txtPaymentMethod.Text.Trim(),
                    txtReceiptReference.Text.Trim());

                MessageBox.Show("Repayment recorded successfully.",
                    "Repayments", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadActiveLoans();
                LoadRepayments();
                ClearForm();
            }
            catch (Exception ex)
            {
                ShowError("Record repayment", ex);
            }
        }

        private void dgvRecords_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvRecords.Rows[e.RowIndex];
            cboLoan.SelectedValue = Convert.ToInt32(row.Cells["LoanID"].Value);
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void LoadRepayments(string search = "")
        {
            try
            {
                dgvRecords.DataSource = _controller.GetRepayments(search);
                lblMessage.Text = "Repayment history loaded.";
            }
            catch (Exception ex)
            {
                ShowError("Load repayments", ex);
            }
        }

        private void ClearForm()
        {
            cboLoan.SelectedIndex = -1;
            txtAmountPaid.Clear();
            txtPaymentMethod.Clear();
            txtReceiptReference.Clear();
            dgvRecords.ClearSelection();
        }

        private static void ShowError(string action, Exception ex)
        {
            MessageBox.Show(ex.Message, action,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
