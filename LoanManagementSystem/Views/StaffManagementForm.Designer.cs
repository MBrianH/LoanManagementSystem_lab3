#nullable disable
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LoanManagementSystem.Views
{
    public partial class StaffManagementForm
    {
        private IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlEntry;
        private TableLayoutPanel tlpEntry;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private ComboBox cboRole;
        private FlowLayoutPanel flpActions;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnClear;
        private Button btnChangeStatus;
        private DataGridView dgvStaff;

        private void InitializeComponent()
        {
            components = new Container();
            this.SuspendLayout();
            this.pnlHeader = new Panel(); this.lblTitle = new Label(); this.pnlEntry = new Panel(); this.tlpEntry = new TableLayoutPanel();
            this.lblFullName = new Label(); this.txtFullName = new TextBox(); this.lblUsername = new Label(); this.txtUsername = new TextBox();
            this.lblPassword = new Label(); this.txtPassword = new TextBox(); this.lblRole = new Label(); this.cboRole = new ComboBox();
            this.flpActions = new FlowLayoutPanel(); this.btnCreate = new Button(); this.btnUpdate = new Button(); this.btnClear = new Button(); this.btnChangeStatus = new Button(); this.dgvStaff = new DataGridView();
            this.pnlHeader.Dock = DockStyle.Top; this.pnlHeader.Height = 64; this.pnlHeader.BackColor = Color.FromArgb(13,82,49); this.pnlHeader.Padding = new Padding(22,8,18,8);
            this.lblTitle.Text = "Staff Management"; this.lblTitle.Dock = DockStyle.Fill; this.lblTitle.TextAlign = ContentAlignment.MiddleLeft; this.lblTitle.Font = new Font("Segoe UI",18,FontStyle.Bold); this.lblTitle.ForeColor = Color.White; this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlEntry.Dock = DockStyle.Top; this.pnlEntry.Height = 170; this.pnlEntry.BackColor = Color.White; this.pnlEntry.Padding = new Padding(12,8,12,4);
            this.tlpEntry.Dock = DockStyle.Top; this.tlpEntry.Height = 78; this.tlpEntry.ColumnCount = 4; this.tlpEntry.RowCount = 2; this.tlpEntry.RowStyles.Add(new RowStyle(SizeType.Percent,42F)); this.tlpEntry.RowStyles.Add(new RowStyle(SizeType.Percent,58F));
            this.tlpEntry.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,25F)); this.tlpEntry.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,25F)); this.tlpEntry.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,25F)); this.tlpEntry.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,25F));
            this.lblFullName.Text = "Full Name"; this.lblFullName.Dock = DockStyle.Fill; this.lblFullName.TextAlign = ContentAlignment.BottomLeft; this.lblFullName.Margin = new Padding(6,0,6,2);
            this.txtFullName.Dock = DockStyle.Fill; this.txtFullName.Margin = new Padding(6,3,6,4);
            this.lblUsername.Text = "Username"; this.lblUsername.Dock = DockStyle.Fill; this.lblUsername.TextAlign = ContentAlignment.BottomLeft; this.lblUsername.Margin = new Padding(6,0,6,2);
            this.txtUsername.Dock = DockStyle.Fill; this.txtUsername.Margin = new Padding(6,3,6,4);
            this.lblPassword.Text = "Temporary Password"; this.lblPassword.Dock = DockStyle.Fill; this.lblPassword.TextAlign = ContentAlignment.BottomLeft; this.lblPassword.Margin = new Padding(6,0,6,2);
            this.txtPassword.Dock = DockStyle.Fill; this.txtPassword.Margin = new Padding(6,3,6,4);
            this.lblRole.Text = "Role"; this.lblRole.Dock = DockStyle.Fill; this.lblRole.TextAlign = ContentAlignment.BottomLeft; this.lblRole.Margin = new Padding(6,0,6,2);
            this.cboRole.Dock = DockStyle.Fill; this.cboRole.Margin = new Padding(6,3,6,4);
            this.cboRole.DropDownStyle = ComboBoxStyle.DropDownList; this.cboRole.Items.AddRange(new object[] { "Loan Officer", "Loan Manager", "Cashier", "Administrator" });
            this.tlpEntry.Controls.Add(this.lblFullName, 0, 0); this.tlpEntry.Controls.Add(this.txtFullName, 0, 1);
            this.tlpEntry.Controls.Add(this.lblUsername, 1, 0); this.tlpEntry.Controls.Add(this.txtUsername, 1, 1);
            this.tlpEntry.Controls.Add(this.lblPassword, 2, 0); this.tlpEntry.Controls.Add(this.txtPassword, 2, 1);
            this.tlpEntry.Controls.Add(this.lblRole, 3, 0); this.tlpEntry.Controls.Add(this.cboRole, 3, 1);
            this.txtPassword.UseSystemPasswordChar = true;
            this.flpActions.Dock = DockStyle.Bottom; this.flpActions.Height = 48; this.flpActions.FlowDirection = FlowDirection.LeftToRight; this.flpActions.WrapContents = false; this.flpActions.Padding = new Padding(4,5,0,0);
            this.btnCreate.Text = "Create Account"; this.btnCreate.Size = new Size(135,34); this.btnCreate.BackColor = Color.FromArgb(13,82,49); this.btnCreate.ForeColor = Color.White; this.btnCreate.FlatStyle = FlatStyle.Flat;
            this.btnUpdate.Text = "Update Account"; this.btnUpdate.Size = new Size(135,34);
            this.btnClear.Text = "Clear"; this.btnClear.Size = new Size(95,34);
            this.btnChangeStatus.Text = "Activate / Deactivate"; this.btnChangeStatus.Size = new Size(170,34);
            this.flpActions.Controls.AddRange(new Control[] { this.btnCreate,this.btnUpdate,this.btnClear,this.btnChangeStatus });
            this.pnlEntry.Controls.Add(this.flpActions); this.pnlEntry.Controls.Add(this.tlpEntry);
            this.dgvStaff.Dock = DockStyle.Fill; this.dgvStaff.ReadOnly = true; this.dgvStaff.AllowUserToAddRows = false; this.dgvStaff.AllowUserToDeleteRows = false; this.dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect; this.dgvStaff.MultiSelect = false; this.dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; this.dgvStaff.RowHeadersVisible = false; this.dgvStaff.ColumnHeadersHeight = 34; this.dgvStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; this.dgvStaff.DefaultCellStyle.SelectionBackColor = Color.FromArgb(13,82,49); this.dgvStaff.DefaultCellStyle.SelectionForeColor = Color.White; this.dgvStaff.BackgroundColor = Color.White; this.dgvStaff.BorderStyle = BorderStyle.FixedSingle; this.dgvStaff.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13,82,49); this.dgvStaff.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; this.dgvStaff.EnableHeadersVisualStyles = false;
            this.Controls.Add(this.dgvStaff);
            this.Controls.Add(this.pnlEntry);
            this.Controls.Add(this.pnlHeader);
            this.Name = "StaffManagementForm";
            this.Text = "Loan Management System - Staff Management";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.ClientSize = new Size(1100, 700);
            this.MinimumSize = new Size(980, 620);
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
