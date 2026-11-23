using System;
using System.Windows.Forms;
using LoanManagementSystem.Controllers;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Views
{
    public partial class RepaymentScheduleForm : Form
    {
        private readonly LoanController _controller = new LoanController();

        public RepaymentScheduleForm()
        {
            InitializeComponent();
            this.btnSearch.Click += btnSearch_Click;
            this.btnRefresh.Click += btnRefresh_Click;
            this.Load += RepaymentScheduleForm_Load;
        }

        public RepaymentScheduleForm(StaffUser user) : this()
        {
            this.lblUser.Text = user.FullName + " | " + user.Role;
        }

        private void RepaymentScheduleForm_Load(object? sender, EventArgs e)
        {
            LoadRecords();
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadRecords(this.txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            this.txtSearch.Clear();
            LoadRecords();
        }

        private void LoadRecords(string search = "")
        {
            try
            {
                this.dgvRecords.DataSource = _controller.GetSchedule(search);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Repayment Schedule", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
