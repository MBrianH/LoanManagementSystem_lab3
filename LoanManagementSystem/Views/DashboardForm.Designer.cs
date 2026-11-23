#nullable disable
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LoanManagementSystem.Views
{
    public partial class DashboardForm
    {
        private IContainer components = null;
        private Panel pnlSidebar;
        private Label lblBrand;
        private Label lblCurrentUser;
        private FlowLayoutPanel flpMenu;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblWelcome;
        private Panel pnlContent;
        private TableLayoutPanel tlpCards;
        private Panel pnlClients;
        private Panel pnlApplications;
        private Panel pnlActiveLoans;
        private Panel pnlOverdue;
        private Label lblClientsCaption;
        private Label lblApplicationsCaption;
        private Label lblLoansCaption;
        private Label lblOverdueCaption;
        private Label lblClientsValue;
        private Label lblApplicationsValue;
        private Label lblLoansValue;
        private Label lblOverdueValue;
        private Button btnClients;
        private Button btnApplications;
        private Button btnDecisions;
        private Button btnPayouts;
        private Button btnActiveLoans;
        private Button btnRepayments;
        private Button btnSchedule;
        private Button btnReports;
        private Button btnStaff;
        private Button btnLogout;

        private void InitializeComponent()
        {
            components = new Container();
            this.SuspendLayout();
            this.pnlSidebar = new Panel(); this.lblBrand = new Label(); this.lblCurrentUser = new Label(); this.flpMenu = new FlowLayoutPanel();
            this.pnlHeader = new Panel(); this.lblTitle = new Label(); this.lblWelcome = new Label(); this.pnlContent = new Panel(); this.tlpCards = new TableLayoutPanel();
            this.pnlClients = new Panel(); this.pnlApplications = new Panel(); this.pnlActiveLoans = new Panel(); this.pnlOverdue = new Panel();
            this.lblClientsCaption = new Label(); this.lblApplicationsCaption = new Label(); this.lblLoansCaption = new Label(); this.lblOverdueCaption = new Label();
            this.lblClientsValue = new Label(); this.lblApplicationsValue = new Label(); this.lblLoansValue = new Label(); this.lblOverdueValue = new Label();
            this.btnClients = new Button(); this.btnApplications = new Button(); this.btnDecisions = new Button(); this.btnPayouts = new Button(); this.btnActiveLoans = new Button(); this.btnRepayments = new Button(); this.btnSchedule = new Button(); this.btnReports = new Button(); this.btnStaff = new Button(); this.btnLogout = new Button();
            this.pnlSidebar.Dock = DockStyle.Left; this.pnlSidebar.Width = 235; this.pnlSidebar.BackColor = Color.FromArgb(13,82,49); this.pnlSidebar.Padding = new Padding(10,12,10,12);
            this.lblBrand.Text = "LOAN\nMANAGEMENT\nSYSTEM"; this.lblBrand.Dock = DockStyle.Top; this.lblBrand.Height = 92; this.lblBrand.TextAlign = ContentAlignment.MiddleCenter; this.lblBrand.ForeColor = Color.White; this.lblBrand.Font = new Font("Segoe UI",15,FontStyle.Bold);
            this.lblCurrentUser.Dock = DockStyle.Top; this.lblCurrentUser.Height = 70; this.lblCurrentUser.TextAlign = ContentAlignment.MiddleCenter; this.lblCurrentUser.ForeColor = Color.FromArgb(240,220,165); this.lblCurrentUser.Font = new Font("Segoe UI",9.5F);
            this.flpMenu.Dock = DockStyle.Fill; this.flpMenu.FlowDirection = FlowDirection.TopDown; this.flpMenu.WrapContents = false; this.flpMenu.AutoScroll = true; this.flpMenu.Padding = new Padding(0,8,0,8);
            this.pnlSidebar.Controls.Add(this.flpMenu); this.pnlSidebar.Controls.Add(this.lblCurrentUser); this.pnlSidebar.Controls.Add(this.lblBrand);
            this.pnlHeader.Dock = DockStyle.Top; this.pnlHeader.Height = 108; this.pnlHeader.BackColor = Color.White; this.pnlHeader.Padding = new Padding(28,8,20,8);
            this.lblTitle.Text = "Dashboard"; this.lblTitle.Dock = DockStyle.Top; this.lblTitle.Height = 58; this.lblTitle.TextAlign = ContentAlignment.MiddleLeft; this.lblTitle.Font = new Font("Segoe UI",22,FontStyle.Bold); this.lblTitle.ForeColor = Color.FromArgb(13,82,49);
            this.lblWelcome.Dock = DockStyle.Top; this.lblWelcome.Height = 28; this.lblWelcome.TextAlign = ContentAlignment.MiddleLeft; this.lblWelcome.ForeColor = Color.DimGray; this.lblWelcome.Font = new Font("Segoe UI",10F);
            this.pnlHeader.Controls.Add(this.lblWelcome); this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlContent.Dock = DockStyle.Fill; this.pnlContent.BackColor = Color.FromArgb(248,249,246); this.pnlContent.Padding = new Padding(14,16,14,14);
            this.tlpCards.Dock = DockStyle.Top; this.tlpCards.Height = 138; this.tlpCards.ColumnCount = 4; this.tlpCards.RowCount = 1; this.tlpCards.RowStyles.Add(new RowStyle(SizeType.Percent,100F));
            this.tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,25F)); this.tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,25F)); this.tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,25F)); this.tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,25F));
            this.pnlClients.Dock = DockStyle.Fill; this.pnlClients.BackColor = Color.White; this.pnlClients.BorderStyle = BorderStyle.FixedSingle; this.pnlClients.Margin = new Padding(8); this.pnlClients.Padding = new Padding(14,10,14,8);
            this.lblClientsCaption.Text = "Clients"; this.lblClientsCaption.Dock = DockStyle.Top; this.lblClientsCaption.Height = 34; this.lblClientsCaption.TextAlign = ContentAlignment.MiddleLeft; this.lblClientsCaption.Font = new Font("Segoe UI",9.5F,FontStyle.Bold); this.lblClientsCaption.ForeColor = Color.FromArgb(90,90,90);
            this.lblClientsValue.Text = "0"; this.lblClientsValue.Dock = DockStyle.Fill; this.lblClientsValue.TextAlign = ContentAlignment.MiddleLeft; this.lblClientsValue.Font = new Font("Segoe UI",24,FontStyle.Bold); this.lblClientsValue.ForeColor = Color.FromArgb(13,82,49);
            this.pnlClients.Controls.Add(this.lblClientsValue); this.pnlClients.Controls.Add(this.lblClientsCaption);
            this.pnlApplications.Dock = DockStyle.Fill; this.pnlApplications.BackColor = Color.White; this.pnlApplications.BorderStyle = BorderStyle.FixedSingle; this.pnlApplications.Margin = new Padding(8); this.pnlApplications.Padding = new Padding(14,10,14,8);
            this.lblApplicationsCaption.Text = "Applications"; this.lblApplicationsCaption.Dock = DockStyle.Top; this.lblApplicationsCaption.Height = 34; this.lblApplicationsCaption.TextAlign = ContentAlignment.MiddleLeft; this.lblApplicationsCaption.Font = new Font("Segoe UI",9.5F,FontStyle.Bold); this.lblApplicationsCaption.ForeColor = Color.FromArgb(90,90,90);
            this.lblApplicationsValue.Text = "0"; this.lblApplicationsValue.Dock = DockStyle.Fill; this.lblApplicationsValue.TextAlign = ContentAlignment.MiddleLeft; this.lblApplicationsValue.Font = new Font("Segoe UI",24,FontStyle.Bold); this.lblApplicationsValue.ForeColor = Color.FromArgb(13,82,49);
            this.pnlApplications.Controls.Add(this.lblApplicationsValue); this.pnlApplications.Controls.Add(this.lblApplicationsCaption);
            this.pnlActiveLoans.Dock = DockStyle.Fill; this.pnlActiveLoans.BackColor = Color.White; this.pnlActiveLoans.BorderStyle = BorderStyle.FixedSingle; this.pnlActiveLoans.Margin = new Padding(8); this.pnlActiveLoans.Padding = new Padding(14,10,14,8);
            this.lblLoansCaption.Text = "Active Loans"; this.lblLoansCaption.Dock = DockStyle.Top; this.lblLoansCaption.Height = 34; this.lblLoansCaption.TextAlign = ContentAlignment.MiddleLeft; this.lblLoansCaption.Font = new Font("Segoe UI",9.5F,FontStyle.Bold); this.lblLoansCaption.ForeColor = Color.FromArgb(90,90,90);
            this.lblLoansValue.Text = "0"; this.lblLoansValue.Dock = DockStyle.Fill; this.lblLoansValue.TextAlign = ContentAlignment.MiddleLeft; this.lblLoansValue.Font = new Font("Segoe UI",24,FontStyle.Bold); this.lblLoansValue.ForeColor = Color.FromArgb(13,82,49);
            this.pnlActiveLoans.Controls.Add(this.lblLoansValue); this.pnlActiveLoans.Controls.Add(this.lblLoansCaption);
            this.pnlOverdue.Dock = DockStyle.Fill; this.pnlOverdue.BackColor = Color.White; this.pnlOverdue.BorderStyle = BorderStyle.FixedSingle; this.pnlOverdue.Margin = new Padding(8); this.pnlOverdue.Padding = new Padding(14,10,14,8);
            this.lblOverdueCaption.Text = "Overdue"; this.lblOverdueCaption.Dock = DockStyle.Top; this.lblOverdueCaption.Height = 34; this.lblOverdueCaption.TextAlign = ContentAlignment.MiddleLeft; this.lblOverdueCaption.Font = new Font("Segoe UI",9.5F,FontStyle.Bold); this.lblOverdueCaption.ForeColor = Color.FromArgb(90,90,90);
            this.lblOverdueValue.Text = "0"; this.lblOverdueValue.Dock = DockStyle.Fill; this.lblOverdueValue.TextAlign = ContentAlignment.MiddleLeft; this.lblOverdueValue.Font = new Font("Segoe UI",24,FontStyle.Bold); this.lblOverdueValue.ForeColor = Color.FromArgb(13,82,49);
            this.pnlOverdue.Controls.Add(this.lblOverdueValue); this.pnlOverdue.Controls.Add(this.lblOverdueCaption);
            this.tlpCards.Controls.Add(this.pnlClients,0,0);
            this.tlpCards.Controls.Add(this.pnlApplications,1,0);
            this.tlpCards.Controls.Add(this.pnlActiveLoans,2,0);
            this.tlpCards.Controls.Add(this.pnlOverdue,3,0);
            this.btnClients.Text = "Clients"; this.btnClients.Width = 205; this.btnClients.Height = 39; this.btnClients.TextAlign = ContentAlignment.MiddleLeft; this.btnClients.Padding = new Padding(12,0,4,0); this.btnClients.BackColor = Color.FromArgb(13,82,49); this.btnClients.ForeColor = Color.White; this.btnClients.FlatStyle = FlatStyle.Flat; this.btnClients.FlatAppearance.BorderColor = Color.FromArgb(225,238,230); this.btnClients.Font = new Font("Segoe UI",9.5F,FontStyle.Bold); this.btnClients.Margin = new Padding(0,3,0,3);
            this.flpMenu.Controls.Add(this.btnClients);
            this.btnApplications.Text = "Loan Applications"; this.btnApplications.Width = 205; this.btnApplications.Height = 39; this.btnApplications.TextAlign = ContentAlignment.MiddleLeft; this.btnApplications.Padding = new Padding(12,0,4,0); this.btnApplications.BackColor = Color.FromArgb(13,82,49); this.btnApplications.ForeColor = Color.White; this.btnApplications.FlatStyle = FlatStyle.Flat; this.btnApplications.FlatAppearance.BorderColor = Color.FromArgb(225,238,230); this.btnApplications.Font = new Font("Segoe UI",9.5F,FontStyle.Bold); this.btnApplications.Margin = new Padding(0,3,0,3);
            this.flpMenu.Controls.Add(this.btnApplications);
            this.btnDecisions.Text = "Loan Decisions"; this.btnDecisions.Width = 205; this.btnDecisions.Height = 39; this.btnDecisions.TextAlign = ContentAlignment.MiddleLeft; this.btnDecisions.Padding = new Padding(12,0,4,0); this.btnDecisions.BackColor = Color.FromArgb(13,82,49); this.btnDecisions.ForeColor = Color.White; this.btnDecisions.FlatStyle = FlatStyle.Flat; this.btnDecisions.FlatAppearance.BorderColor = Color.FromArgb(225,238,230); this.btnDecisions.Font = new Font("Segoe UI",9.5F,FontStyle.Bold); this.btnDecisions.Margin = new Padding(0,3,0,3);
            this.flpMenu.Controls.Add(this.btnDecisions);
            this.btnPayouts.Text = "Loan Payouts"; this.btnPayouts.Width = 205; this.btnPayouts.Height = 39; this.btnPayouts.TextAlign = ContentAlignment.MiddleLeft; this.btnPayouts.Padding = new Padding(12,0,4,0); this.btnPayouts.BackColor = Color.FromArgb(13,82,49); this.btnPayouts.ForeColor = Color.White; this.btnPayouts.FlatStyle = FlatStyle.Flat; this.btnPayouts.FlatAppearance.BorderColor = Color.FromArgb(225,238,230); this.btnPayouts.Font = new Font("Segoe UI",9.5F,FontStyle.Bold); this.btnPayouts.Margin = new Padding(0,3,0,3);
            this.flpMenu.Controls.Add(this.btnPayouts);
            this.btnActiveLoans.Text = "Active Loans"; this.btnActiveLoans.Width = 205; this.btnActiveLoans.Height = 39; this.btnActiveLoans.TextAlign = ContentAlignment.MiddleLeft; this.btnActiveLoans.Padding = new Padding(12,0,4,0); this.btnActiveLoans.BackColor = Color.FromArgb(13,82,49); this.btnActiveLoans.ForeColor = Color.White; this.btnActiveLoans.FlatStyle = FlatStyle.Flat; this.btnActiveLoans.FlatAppearance.BorderColor = Color.FromArgb(225,238,230); this.btnActiveLoans.Font = new Font("Segoe UI",9.5F,FontStyle.Bold); this.btnActiveLoans.Margin = new Padding(0,3,0,3);
            this.flpMenu.Controls.Add(this.btnActiveLoans);
            this.btnRepayments.Text = "Repayments"; this.btnRepayments.Width = 205; this.btnRepayments.Height = 39; this.btnRepayments.TextAlign = ContentAlignment.MiddleLeft; this.btnRepayments.Padding = new Padding(12,0,4,0); this.btnRepayments.BackColor = Color.FromArgb(13,82,49); this.btnRepayments.ForeColor = Color.White; this.btnRepayments.FlatStyle = FlatStyle.Flat; this.btnRepayments.FlatAppearance.BorderColor = Color.FromArgb(225,238,230); this.btnRepayments.Font = new Font("Segoe UI",9.5F,FontStyle.Bold); this.btnRepayments.Margin = new Padding(0,3,0,3);
            this.flpMenu.Controls.Add(this.btnRepayments);
            this.btnSchedule.Text = "Repayment Schedule"; this.btnSchedule.Width = 205; this.btnSchedule.Height = 39; this.btnSchedule.TextAlign = ContentAlignment.MiddleLeft; this.btnSchedule.Padding = new Padding(12,0,4,0); this.btnSchedule.BackColor = Color.FromArgb(13,82,49); this.btnSchedule.ForeColor = Color.White; this.btnSchedule.FlatStyle = FlatStyle.Flat; this.btnSchedule.FlatAppearance.BorderColor = Color.FromArgb(225,238,230); this.btnSchedule.Font = new Font("Segoe UI",9.5F,FontStyle.Bold); this.btnSchedule.Margin = new Padding(0,3,0,3);
            this.flpMenu.Controls.Add(this.btnSchedule);
            this.btnReports.Text = "Reports"; this.btnReports.Width = 205; this.btnReports.Height = 39; this.btnReports.TextAlign = ContentAlignment.MiddleLeft; this.btnReports.Padding = new Padding(12,0,4,0); this.btnReports.BackColor = Color.FromArgb(13,82,49); this.btnReports.ForeColor = Color.White; this.btnReports.FlatStyle = FlatStyle.Flat; this.btnReports.FlatAppearance.BorderColor = Color.FromArgb(225,238,230); this.btnReports.Font = new Font("Segoe UI",9.5F,FontStyle.Bold); this.btnReports.Margin = new Padding(0,3,0,3);
            this.flpMenu.Controls.Add(this.btnReports);
            this.btnStaff.Text = "Staff Management"; this.btnStaff.Width = 205; this.btnStaff.Height = 39; this.btnStaff.TextAlign = ContentAlignment.MiddleLeft; this.btnStaff.Padding = new Padding(12,0,4,0); this.btnStaff.BackColor = Color.FromArgb(13,82,49); this.btnStaff.ForeColor = Color.White; this.btnStaff.FlatStyle = FlatStyle.Flat; this.btnStaff.FlatAppearance.BorderColor = Color.FromArgb(225,238,230); this.btnStaff.Font = new Font("Segoe UI",9.5F,FontStyle.Bold); this.btnStaff.Margin = new Padding(0,3,0,3);
            this.flpMenu.Controls.Add(this.btnStaff);
            this.btnLogout.Text = "Logout"; this.btnLogout.Width = 205; this.btnLogout.Height = 39; this.btnLogout.TextAlign = ContentAlignment.MiddleLeft; this.btnLogout.Padding = new Padding(12,0,4,0); this.btnLogout.BackColor = Color.FromArgb(13,82,49); this.btnLogout.ForeColor = Color.White; this.btnLogout.FlatStyle = FlatStyle.Flat; this.btnLogout.FlatAppearance.BorderColor = Color.FromArgb(225,238,230); this.btnLogout.Font = new Font("Segoe UI",9.5F,FontStyle.Bold); this.btnLogout.Margin = new Padding(0,3,0,3);
            this.flpMenu.Controls.Add(this.btnLogout);
            this.pnlContent.Controls.Add(this.tlpCards);
            this.Controls.Add(this.pnlContent); this.Controls.Add(this.pnlHeader); this.Controls.Add(this.pnlSidebar);

            this.Name = "DashboardForm";
            this.Text = "Loan Management System - Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.ClientSize = new Size(1180, 760);
            this.MinimumSize = new Size(1050, 650);
            this.BackColor = Color.FromArgb(248, 249, 246);
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            this.ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
    }
}
