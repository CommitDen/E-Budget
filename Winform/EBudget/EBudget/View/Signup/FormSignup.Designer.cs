namespace EBudget.View.Signup
{
    partial class FormSignup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSignup));
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_signup_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_signup_email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textbox_signup_password1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textbox_signup_password2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.combobox_signup_currency = new System.Windows.Forms.ComboBox();
            this.button_Signup = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(97, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // textbox_signup_name
            // 
            this.textbox_signup_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textbox_signup_name.Location = new System.Drawing.Point(100, 70);
            this.textbox_signup_name.Name = "textbox_signup_name";
            this.textbox_signup_name.Size = new System.Drawing.Size(184, 22);
            this.textbox_signup_name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(97, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email:";
            // 
            // textbox_signup_email
            // 
            this.textbox_signup_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textbox_signup_email.Location = new System.Drawing.Point(100, 135);
            this.textbox_signup_email.Name = "textbox_signup_email";
            this.textbox_signup_email.Size = new System.Drawing.Size(184, 22);
            this.textbox_signup_email.TabIndex = 3;
            this.textbox_signup_email.Leave += new System.EventHandler(this.Textbox_email_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(97, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // textbox_signup_password1
            // 
            this.textbox_signup_password1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textbox_signup_password1.Location = new System.Drawing.Point(100, 199);
            this.textbox_signup_password1.Name = "textbox_signup_password1";
            this.textbox_signup_password1.PasswordChar = '*';
            this.textbox_signup_password1.Size = new System.Drawing.Size(184, 22);
            this.textbox_signup_password1.TabIndex = 5;
            this.textbox_signup_password1.Leave += new System.EventHandler(this.Password1_textbox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(97, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Confirm-password:";
            // 
            // textbox_signup_password2
            // 
            this.textbox_signup_password2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textbox_signup_password2.Location = new System.Drawing.Point(100, 261);
            this.textbox_signup_password2.Name = "textbox_signup_password2";
            this.textbox_signup_password2.PasswordChar = '*';
            this.textbox_signup_password2.Size = new System.Drawing.Size(184, 22);
            this.textbox_signup_password2.TabIndex = 7;
            this.textbox_signup_password2.Leave += new System.EventHandler(this.Password2_textbox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(97, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Default currency:";
            // 
            // combobox_signup_currency
            // 
            this.combobox_signup_currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.combobox_signup_currency.FormattingEnabled = true;
            this.combobox_signup_currency.Location = new System.Drawing.Point(100, 319);
            this.combobox_signup_currency.Name = "combobox_signup_currency";
            this.combobox_signup_currency.Size = new System.Drawing.Size(57, 24);
            this.combobox_signup_currency.TabIndex = 9;
            // 
            // button_Signup
            // 
            this.button_Signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Signup.Location = new System.Drawing.Point(155, 386);
            this.button_Signup.Name = "button_Signup";
            this.button_Signup.Size = new System.Drawing.Size(75, 27);
            this.button_Signup.TabIndex = 10;
            this.button_Signup.Text = "Sign up";
            this.button_Signup.UseVisualStyleBackColor = true;
            this.button_Signup.Click += new System.EventHandler(this.button_Signup_Click);
            // 
            // button_Back
            // 
            this.button_Back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Back.Location = new System.Drawing.Point(12, 12);
            this.button_Back.MaximumSize = new System.Drawing.Size(24, 23);
            this.button_Back.MinimumSize = new System.Drawing.Size(24, 23);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(24, 23);
            this.button_Back.TabIndex = 11;
            this.button_Back.Text = "<-";
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // FormSignup
            // 
            this.AcceptButton = this.button_Signup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Back;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.button_Signup);
            this.Controls.Add(this.combobox_signup_currency);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textbox_signup_password2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textbox_signup_password1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textbox_signup_email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textbox_signup_name);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 500);
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "FormSignup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EBudget";
            this.Load += new System.EventHandler(this.FormSignup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_signup_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox_signup_email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textbox_signup_password1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textbox_signup_password2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combobox_signup_currency;
        private System.Windows.Forms.Button button_Signup;
        private System.Windows.Forms.Button button_Back;
    }
}