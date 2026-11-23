using System;
using System.Windows.Forms;
using LoanManagementSystem.Views;

namespace LoanManagementSystem
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The application could not start. Make sure MariaDB is running and the database has been created." +
                    Environment.NewLine + Environment.NewLine + ex.Message,
                    "Loan Management System",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
