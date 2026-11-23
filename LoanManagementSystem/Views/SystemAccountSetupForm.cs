using System;
using System.Windows.Forms;
using LoanManagementSystem.Controllers;

namespace LoanManagementSystem.Views
{
    public partial class SystemAccountSetupForm : Form
    {
        public SystemAccountSetupForm()
        {
            InitializeComponent();

            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            btnCreateAccount.Click += btnCreateAccount_Click;
            btnBack.Click += (sender, e) => Close();
        }

        private void btnCreateAccount_Click(object? sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(
                    "Complete all fields before creating the account.",
                    "System Account Setup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "The passwords do not match.",
                    "System Account Setup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            try
            {
                AccountController controller = new AccountController();

                if (controller.AdministratorExists())
                {
                    MessageBox.Show(
                        "The first Administrator account has already been created. Sign in and use Staff Management to manage staff accounts.",
                        "Setup already completed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Close();
                    return;
                }

                controller.CreateAccount(fullName, username, password, "Administrator");

                MessageBox.Show(
                    "The Administrator account has been created. You can now sign in.",
                    "Setup complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "System Account Setup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
