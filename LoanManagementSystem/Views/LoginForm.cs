using System;
using System.ComponentModel;
using System.Windows.Forms;
using LoanManagementSystem.Controllers;

namespace LoanManagementSystem.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            btnLogin.Click += btnLogin_Click;
            btnSystemSetup.Click += btnSystemSetup_Click;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                CheckFirstAdministrator();
            }
        }

        private void CheckFirstAdministrator()
        {
            // Keep the setup link visible. SystemAccountSetupForm checks whether
            // an Administrator already exists before allowing account creation.
            btnSystemSetup.Visible = true;
        }

        private void chkShowPassword_CheckedChanged(object? sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnSystemSetup_Click(object? sender, EventArgs e)
        {
            using SystemAccountSetupForm setupForm = new SystemAccountSetupForm();
            setupForm.ShowDialog(this);

            CheckFirstAdministrator();
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Enter your username and password.",
                    "Missing information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                LoginController controller = new LoginController();
                var staff = controller.Login(username, password);

                if (staff == null)
                {
                    MessageBox.Show(
                        "The username or password is incorrect, or the account is inactive.",
                        "Sign-in failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                Hide();

                using (DashboardForm dashboard = new DashboardForm(staff))
                {
                    dashboard.ShowDialog();
                }

                txtPassword.Clear();
                Show();
                CheckFirstAdministrator();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to sign in. Check that MariaDB is running and the database is ready." +
                    Environment.NewLine + Environment.NewLine + ex.Message,
                    "Sign-in error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void lblBrandName_Click(object sender, EventArgs e)
        {

        }
    }
}
