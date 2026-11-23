#nullable disable
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LoanManagementSystem.Views
{
    public partial class LoginForm
    {
        private IContainer components = null;
        private Panel pnlBrand;
        private Label lblBrandMark;
        private Label lblBrandName;
        private Label lblBrandDescription;
        private Panel pnlLogin;
        private Label lblHeading;
        private Label lblSubtitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private CheckBox chkShowPassword;
        private Button btnLogin;
        private Button btnSystemSetup;

        private void InitializeComponent()
        {
            pnlBrand = new Panel();
            lblBrandMark = new Label();
            lblBrandName = new Label();
            lblBrandDescription = new Label();
            pnlLogin = new Panel();
            lblHeading = new Label();
            lblSubtitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            chkShowPassword = new CheckBox();
            btnLogin = new Button();
            btnSystemSetup = new Button();
            pnlBrand.SuspendLayout();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBrand
            // 
            pnlBrand.BackColor = Color.FromArgb(13, 82, 49);
            pnlBrand.Controls.Add(lblBrandMark);
            pnlBrand.Controls.Add(lblBrandName);
            pnlBrand.Controls.Add(lblBrandDescription);
            pnlBrand.Dock = DockStyle.Left;
            pnlBrand.Location = new Point(0, 0);
            pnlBrand.Name = "pnlBrand";
            pnlBrand.Size = new Size(250, 440);
            pnlBrand.TabIndex = 1;
            // 
            // lblBrandMark
            // 
            lblBrandMark.Font = new Font("Segoe UI Symbol", 38F);
            lblBrandMark.ForeColor = Color.FromArgb(196, 151, 55);
            lblBrandMark.Location = new Point(78, 55);
            lblBrandMark.Name = "lblBrandMark";
            lblBrandMark.Size = new Size(94, 94);
            lblBrandMark.TabIndex = 0;
            lblBrandMark.Text = "◆";
            lblBrandMark.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBrandName
            // 
            lblBrandName.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblBrandName.ForeColor = Color.White;
            lblBrandName.Location = new Point(3, 163);
            lblBrandName.Name = "lblBrandName";
            lblBrandName.Size = new Size(220, 140);
            lblBrandName.TabIndex = 1;
            lblBrandName.Text = "LOAN\nMANAGEMENT\nSYSTEM";
            lblBrandName.TextAlign = ContentAlignment.MiddleCenter;
            lblBrandName.Click += lblBrandName_Click;
            // 
            // lblBrandDescription
            // 
            lblBrandDescription.Font = new Font("Segoe UI", 10F);
            lblBrandDescription.ForeColor = Color.White;
            lblBrandDescription.Location = new Point(12, 320);
            lblBrandDescription.Name = "lblBrandDescription";
            lblBrandDescription.Size = new Size(210, 44);
            lblBrandDescription.TabIndex = 2;
            lblBrandDescription.Text = "Microfinance loan records";
            lblBrandDescription.TextAlign = ContentAlignment.TopCenter;
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.White;
            pnlLogin.Controls.Add(lblHeading);
            pnlLogin.Controls.Add(lblSubtitle);
            pnlLogin.Controls.Add(lblUsername);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(lblPassword);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Controls.Add(chkShowPassword);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(btnSystemSetup);
            pnlLogin.Dock = DockStyle.Fill;
            pnlLogin.Location = new Point(250, 0);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Padding = new Padding(30);
            pnlLogin.Size = new Size(570, 440);
            pnlLogin.TabIndex = 0;
            // 
            // lblHeading
            // 
            lblHeading.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHeading.ForeColor = Color.FromArgb(13, 82, 49);
            lblHeading.Location = new Point(34, 48);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(500, 61);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Loan Management System";
            lblHeading.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = Color.DimGray;
            lblSubtitle.Location = new Point(38, 109);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(247, 28);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Sign in to your account";
            // 
            // lblUsername
            // 
            lblUsername.Font = new Font("Segoe UI", 10F);
            lblUsername.Location = new Point(38, 164);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(120, 28);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(165, 163);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(330, 34);
            txtUsername.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.Location = new Point(38, 211);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(120, 28);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(165, 210);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(330, 34);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9.5F);
            chkShowPassword.Location = new Point(165, 250);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(169, 29);
            chkShowPassword.TabIndex = 6;
            chkShowPassword.Text = "Show password";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(13, 82, 49);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(165, 296);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 36);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Sign In";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // btnSystemSetup
            // 
            btnSystemSetup.BackColor = Color.White;
            btnSystemSetup.FlatStyle = FlatStyle.Flat;
            btnSystemSetup.Font = new Font("Segoe UI", 9.5F);
            btnSystemSetup.ForeColor = Color.FromArgb(150, 110, 30);
            btnSystemSetup.Location = new Point(325, 296);
            btnSystemSetup.Name = "btnSystemSetup";
            btnSystemSetup.Size = new Size(170, 36);
            btnSystemSetup.TabIndex = 8;
            btnSystemSetup.Text = "System Account Setup";
            btnSystemSetup.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(820, 440);
            Controls.Add(pnlLogin);
            Controls.Add(pnlBrand);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loan Management System";
            pnlBrand.ResumeLayout(false);
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
    }
}
