using System;
using System.Windows.Forms;
using LoanManagementSystem.Controllers;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repositories;

namespace LoanManagementSystem.Views
{
    public partial class StaffManagementForm : Form
    {
        private readonly StaffUser _currentUser;
        private readonly AccountController _accountController = new AccountController();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        private int _selectedUserID;

        public StaffManagementForm() : this(new StaffUser
        {
            UserID = 1,
            FullName = "Preview User",
            Role = "Administrator"
        })
        {
        }

        public StaffManagementForm(StaffUser user)
        {
            InitializeComponent();
            _currentUser = user;

            cboRole.SelectedIndex = 0;

            btnCreate.Click += btnCreate_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnClear.Click += btnClear_Click;
            btnChangeStatus.Click += btnChangeStatus_Click;
            dgvStaff.CellClick += dgvStaff_CellClick;

            Load += StaffManagementForm_Load;
        }

        private void StaffManagementForm_Load(object? sender, EventArgs e)
        {
            LoadStaff();
        }

        private void btnCreate_Click(object? sender, EventArgs e)
        {
            try
            {
                _accountController.CreateAccount(
                    txtFullName.Text,
                    txtUsername.Text,
                    txtPassword.Text,
                    Convert.ToString(cboRole.SelectedItem) ?? "");

                MessageBox.Show(
                    "Staff account created successfully.",
                    "Staff Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearForm();
                LoadStaff();
            }
            catch (Exception ex)
            {
                ShowError("Create staff account", ex);
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (_selectedUserID == 0)
            {
                MessageBox.Show(
                    "Select a staff member from the table before updating.",
                    "Staff Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _staffRepository.UpdateStaff(
                    _selectedUserID,
                    txtFullName.Text.Trim(),
                    txtUsername.Text.Trim(),
                    Convert.ToString(cboRole.SelectedItem) ?? "");

                MessageBox.Show(
                    "Staff account updated successfully.",
                    "Staff Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearForm();
                LoadStaff();
            }
            catch (Exception ex)
            {
                ShowError("Update staff account", ex);
            }
        }

        private void btnChangeStatus_Click(object? sender, EventArgs e)
        {
            if (_selectedUserID == 0)
            {
                MessageBox.Show("Select a staff member first.");
                return;
            }

            if (_selectedUserID == _currentUser.UserID)
            {
                MessageBox.Show("You cannot deactivate the account you are currently using.");
                return;
            }

            try
            {
                string currentStatus = Convert.ToString(
                    dgvStaff.CurrentRow?.Cells["AccountStatus"].Value) ?? "Active";

                string newStatus = currentStatus == "Active" ? "Inactive" : "Active";
                _staffRepository.UpdateStatus(_selectedUserID, newStatus);

                ClearForm();
                LoadStaff();
            }
            catch (Exception ex)
            {
                ShowError("Change account status", ex);
            }
        }

        private void dgvStaff_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvStaff.Rows[e.RowIndex];

            _selectedUserID = Convert.ToInt32(row.Cells["UserID"].Value);
            txtFullName.Text = Convert.ToString(row.Cells["FullName"].Value) ?? "";
            txtUsername.Text = Convert.ToString(row.Cells["Username"].Value) ?? "";
            cboRole.SelectedItem = Convert.ToString(row.Cells["Role"].Value);
            txtPassword.Clear();
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void LoadStaff()
        {
            try
            {
                dgvStaff.DataSource = _staffRepository.GetAll();
            }
            catch (Exception ex)
            {
                ShowError("Load staff accounts", ex);
            }
        }

        private void ClearForm()
        {
            _selectedUserID = 0;

            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cboRole.SelectedIndex = 0;

            dgvStaff.ClearSelection();
            txtFullName.Focus();
        }

        private static void ShowError(string action, Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                action,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
