using System;
using System.Windows.Forms;
using LoanManagementSystem.Controllers;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Views
{
    public partial class LoanDecisionsForm : Form
    {
        private readonly LoanController _controller = new LoanController();
        private readonly StaffUser _currentUser;

        public LoanDecisionsForm() : this(new StaffUser
        {
            UserID = 1,
            FullName = "Preview User",
            Role = "Administrator"
        })
        {
        }

        public LoanDecisionsForm(StaffUser user)
        {
            InitializeComponent();
            _currentUser = user;

            lblUser.Text = user.FullName + " | " + user.Role;
            cboDecision.Items.AddRange(new object[] { "Approved", "Rejected" });

            btnSearch.Click += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnSave.Click += btnSave_Click;
            btnClear.Click += btnClear_Click;
            dgvRecords.CellClick += dgvRecords_CellClick;

            Load += LoanDecisionsForm_Load;
        }

        private void LoanDecisionsForm_Load(object? sender, EventArgs e)
        {
            LoadPendingApplications();
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadPendingApplications(txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadPendingApplications();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtApplicationID.Text.Trim(), out int applicationID))
                {
                    throw new ArgumentException("Select a pending application first.");
                }

                string decision = Convert.ToString(cboDecision.SelectedItem) ?? "";
                _controller.Decide(applicationID, decision, txtDecisionNote.Text.Trim(), _currentUser.UserID);

                MessageBox.Show("The application decision has been recorded.",
                    "Loan Decisions", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadPendingApplications(txtSearch.Text.Trim());
                ClearForm();
            }
            catch (Exception ex)
            {
                ShowError("Record decision", ex);
            }
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
                return;
            }

            txtApplicationID.Text = Convert.ToString(row.Cells["ApplicationID"].Value) ?? "";
            txtDecisionNote.Clear();
            cboDecision.SelectedIndex = -1;
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void LoadPendingApplications(string search = "")
        {
            try
            {
                dgvRecords.DataSource = _controller.GetApplications(search, "Pending Review");
                lblMessage.Text = "Select an application with Pending Review status.";
            }
            catch (Exception ex)
            {
                ShowError("Load applications", ex);
            }
        }

        private void ClearForm()
        {
            txtApplicationID.Clear();
            txtDecisionNote.Clear();
            cboDecision.SelectedIndex = -1;
            dgvRecords.ClearSelection();
        }

        private static void ShowError(string action, Exception ex)
        {
            MessageBox.Show(ex.Message, action,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
