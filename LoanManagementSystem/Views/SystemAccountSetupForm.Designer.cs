#nullable disable
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LoanManagementSystem.Views
{
    public partial class SystemAccountSetupForm
    {
        private IContainer components = null;
        private Panel pnlBrand;
        private Label lblBrand;
        private Panel pnlMain;
        private Label lblHeading;
        private Label lblIntro;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnCreateAccount;
        private Button btnBack;

        private void InitializeComponent()
        {
            pnlBrand = new Panel();
            lblBrand = new Label();
            pnlMain = new Panel();
            lblHeading = new Label();
            lblIntro = new Label();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnCreateAccount = new Button();
            btnBack = new Button();
            pnlBrand.SuspendLayout();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBrand
            // 
            pnlBrand.BackColor = Color.FromArgb(13, 82, 49);
            pnlBrand.Controls.Add(lblBrand);
            pnlBrand.Dock = DockStyle.Left;
            pnlBrand.Location = new Point(0, 0);
            pnlBrand.Name = "pnlBrand";
            pnlBrand.Size = new Size(190, 460);
            pnlBrand.TabIndex = 1;
            // 
            // lblBrand
            // 
            lblBrand.Dock = DockStyle.Fill;
            lblBrand.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblBrand.ForeColor = Color.White;
            lblBrand.Location = new Point(0, 0);
            lblBrand.Name = "lblBrand";
            lblBrand.Padding = new Padding(12);
            lblBrand.Size = new Size(190, 460);
            lblBrand.TabIndex = 0;
            lblBrand.Text = "LOAN\nMANAGEMENT\nSYSTEM";
            lblBrand.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(lblHeading);
            pnlMain.Controls.Add(lblIntro);
            pnlMain.Controls.Add(lblFullName);
            pnlMain.Controls.Add(txtFullName);
            pnlMain.Controls.Add(lblUsername);
            pnlMain.Controls.Add(txtUsername);
            pnlMain.Controls.Add(lblPassword);
            pnlMain.Controls.Add(txtPassword);
            pnlMain.Controls.Add(lblConfirmPassword);
            pnlMain.Controls.Add(txtConfirmPassword);
            pnlMain.Controls.Add(btnCreateAccount);
            pnlMain.Controls.Add(btnBack);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(190, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(570, 460);
            pnlMain.TabIndex = 0;
            // 
            // lblHeading
            // 
            lblHeading.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblHeading.ForeColor = Color.FromArgb(13, 82, 49);
            lblHeading.Location = new Point(28, 30);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(500, 58);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "System Account Setup";
            // 
            // lblIntro
            // 
            lblIntro.Font = new Font("Segoe UI", 10F);
            lblIntro.ForeColor = Color.DimGray;
            lblIntro.Location = new Point(30, 88);
            lblIntro.Name = "lblIntro";
            lblIntro.Size = new Size(500, 39);
            lblIntro.TabIndex = 1;
            lblIntro.Text = "Create the first Administrator account to get started.";
            // 
            // lblFullName
            // 
            lblFullName.Font = new Font("Segoe UI", 10F);
            lblFullName.Location = new Point(30, 130);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(130, 28);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Full Name";
            lblFullName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(170, 130);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(340, 34);
            txtFullName.TabIndex = 3;
            // 
            // lblUsername
            // 
            lblUsername.Font = new Font("Segoe UI", 10F);
            lblUsername.Location = new Point(30, 183);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(130, 28);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(170, 183);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(340, 34);
            txtUsername.TabIndex = 5;
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.Location = new Point(30, 236);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(130, 28);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password";
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(170, 236);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(340, 34);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Font = new Font("Segoe UI", 10F);
            lblConfirmPassword.Location = new Point(30, 289);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(130, 28);
            lblConfirmPassword.TabIndex = 8;
            lblConfirmPassword.Text = "Confirm Password";
            lblConfirmPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(170, 289);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(340, 34);
            txtConfirmPassword.TabIndex = 9;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.BackColor = Color.FromArgb(13, 82, 49);
            btnCreateAccount.FlatStyle = FlatStyle.Flat;
            btnCreateAccount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCreateAccount.ForeColor = Color.White;
            btnCreateAccount.Location = new Point(170, 355);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(165, 36);
            btnCreateAccount.TabIndex = 10;
            btnCreateAccount.Text = "Create Administrator";
            btnCreateAccount.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 9.5F);
            btnBack.Location = new Point(345, 355);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(165, 36);
            btnBack.TabIndex = 11;
            btnBack.Text = "Back to Login";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // SystemAccountSetupForm
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(760, 460);
            Controls.Add(pnlMain);
            Controls.Add(pnlBrand);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SystemAccountSetupForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "System Account Setup";
            pnlBrand.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
    }
}
