
namespace EBudget.View.Login
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_login_email = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_login_password = new System.Windows.Forms.TextBox();
            this.button_login = new System.Windows.Forms.Button();
            this.linklabel_signup = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(64, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email:";
            // 
            // textbox_login_email
            // 
            this.textbox_login_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textbox_login_email.Location = new System.Drawing.Point(67, 71);
            this.textbox_login_email.Name = "textbox_login_email";
            this.textbox_login_email.Size = new System.Drawing.Size(163, 22);
            this.textbox_login_email.TabIndex = 1;
            this.textbox_login_email.Text = "user1@test.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(64, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // textbox_login_password
            // 
            this.textbox_login_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textbox_login_password.Location = new System.Drawing.Point(67, 134);
            this.textbox_login_password.Name = "textbox_login_password";
            this.textbox_login_password.PasswordChar = '*';
            this.textbox_login_password.Size = new System.Drawing.Size(163, 22);
            this.textbox_login_password.TabIndex = 3;
            this.textbox_login_password.Text = "Password01?";
            // 
            // button_login
            // 
            this.button_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_login.Location = new System.Drawing.Point(110, 192);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 26);
            this.button_login.TabIndex = 4;
            this.button_login.Text = "Log in";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // linklabel_signup
            // 
            this.linklabel_signup.AutoSize = true;
            this.linklabel_signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linklabel_signup.Location = new System.Drawing.Point(122, 221);
            this.linklabel_signup.Name = "linklabel_signup";
            this.linklabel_signup.Size = new System.Drawing.Size(48, 15);
            this.linklabel_signup.TabIndex = 5;
            this.linklabel_signup.TabStop = true;
            this.linklabel_signup.Text = "SignUp";
            this.linklabel_signup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_signup_LinkClicked);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 282);
            this.Controls.Add(this.linklabel_signup);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.textbox_login_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textbox_login_email);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(309, 321);
            this.MinimumSize = new System.Drawing.Size(309, 321);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Budget";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_login_email;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox_login_password;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.LinkLabel linklabel_signup;
    }
}

