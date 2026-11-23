using System;
using System.Windows.Forms;
using LoanManagementSystem.Controllers;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Views
{
    public partial class ClientManagementForm : Form
    {
        private readonly LoanController _controller = new LoanController();
        private int _selectedClientID;

        public ClientManagementForm() : this(new StaffUser
        {
            UserID = 1,
            FullName = "Preview User",
            Role = "Administrator"
        })
        {
        }

        public ClientManagementForm(StaffUser user)
        {
            InitializeComponent();

            lblUser.Text = user.FullName + " | " + user.Role;

            btnSearch.Click += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnClear.Click += btnClear_Click;
            dgvRecords.CellClick += dgvRecords_CellClick;

            Load += ClientManagementForm_Load;
        }

        private void ClientManagementForm_Load(object? sender, EventArgs e)
        {
            LoadClients();
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadClients(txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadClients();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                Client client = ReadClientFromForm();
                client.RegistrationDate = DateTime.Today;

                _controller.SaveClient(client);

                MessageBox.Show("Client details saved successfully.",
                    "Client Management", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadClients();
                ClearForm();
            }
            catch (Exception ex)
            {
                ShowError("Save client", ex);
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (_selectedClientID == 0)
            {
                MessageBox.Show("Select a client from the table before updating.",
                    "Client Management", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Client client = ReadClientFromForm();
                client.ClientID = _selectedClientID;

                _controller.SaveClient(client);

                MessageBox.Show("Client details updated successfully.",
                    "Client Management", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadClients(txtSearch.Text.Trim());
                ClearForm();
            }
            catch (Exception ex)
            {
                ShowError("Update client", ex);
            }
        }

        private Client ReadClientFromForm()
        {
            return new Client
            {
                FullName = txtFullName.Text.Trim(),
                IdentificationNumber = txtIdentificationNumber.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                RegistrationDate = DateTime.Today
            };
        }

        private void dgvRecords_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvRecords.Rows[e.RowIndex];

            _selectedClientID = Convert.ToInt32(row.Cells["ClientID"].Value);
            txtFullName.Text = Convert.ToString(row.Cells["FullName"].Value) ?? "";
            txtIdentificationNumber.Text = Convert.ToString(row.Cells["IdentificationNumber"].Value) ?? "";
            txtPhoneNumber.Text = Convert.ToString(row.Cells["PhoneNumber"].Value) ?? "";
            txtAddress.Text = Convert.ToString(row.Cells["Address"].Value) ?? "";
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void LoadClients(string search = "")
        {
            try
            {
                dgvRecords.DataSource = _controller.GetClients(search);
                lblMessage.Text = "Client records loaded.";
            }
            catch (Exception ex)
            {
                ShowError("Load clients", ex);
            }
        }

        private void ClearForm()
        {
            _selectedClientID = 0;

            txtFullName.Clear();
            txtIdentificationNumber.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();

            dgvRecords.ClearSelection();
            txtFullName.Focus();
        }

        private static void ShowError(string action, Exception ex)
        {
            MessageBox.Show(ex.Message, action,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
