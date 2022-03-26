namespace EBudget.View.TransInput
{
    partial class FormTransInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTransInput));
            this.comboBox_categories = new System.Windows.Forms.ComboBox();
            this.comboBox_subcategories = new System.Windows.Forms.ComboBox();
            this.comboBox_currency = new System.Windows.Forms.ComboBox();
            this.textBox_amount = new System.Windows.Forms.TextBox();
            this.richTextBox_comment = new System.Windows.Forms.RichTextBox();
            this.dateTimePicker_trans_date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_categories
            // 
            this.comboBox_categories.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox_categories.FormattingEnabled = true;
            this.comboBox_categories.Location = new System.Drawing.Point(33, 39);
            this.comboBox_categories.Name = "comboBox_categories";
            this.comboBox_categories.Size = new System.Drawing.Size(262, 23);
            this.comboBox_categories.TabIndex = 0;
            this.comboBox_categories.SelectedIndexChanged += new System.EventHandler(this.comboBox_categories_SelectedIndexChanged);
            // 
            // comboBox_subcategories
            // 
            this.comboBox_subcategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox_subcategories.FormattingEnabled = true;
            this.comboBox_subcategories.Location = new System.Drawing.Point(33, 84);
            this.comboBox_subcategories.Name = "comboBox_subcategories";
            this.comboBox_subcategories.Size = new System.Drawing.Size(262, 23);
            this.comboBox_subcategories.TabIndex = 1;
            // 
            // comboBox_currency
            // 
            this.comboBox_currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox_currency.FormattingEnabled = true;
            this.comboBox_currency.Location = new System.Drawing.Point(33, 173);
            this.comboBox_currency.Name = "comboBox_currency";
            this.comboBox_currency.Size = new System.Drawing.Size(262, 23);
            this.comboBox_currency.TabIndex = 3;
            // 
            // textBox_amount
            // 
            this.textBox_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_amount.Location = new System.Drawing.Point(33, 128);
            this.textBox_amount.Name = "textBox_amount";
            this.textBox_amount.Size = new System.Drawing.Size(262, 21);
            this.textBox_amount.TabIndex = 2;
            // 
            // richTextBox_comment
            // 
            this.richTextBox_comment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox_comment.Location = new System.Drawing.Point(33, 266);
            this.richTextBox_comment.Name = "richTextBox_comment";
            this.richTextBox_comment.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_comment.Size = new System.Drawing.Size(262, 106);
            this.richTextBox_comment.TabIndex = 5;
            this.richTextBox_comment.Text = "";
            // 
            // dateTimePicker_trans_date
            // 
            this.dateTimePicker_trans_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker_trans_date.Location = new System.Drawing.Point(33, 220);
            this.dateTimePicker_trans_date.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_trans_date.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_trans_date.Name = "dateTimePicker_trans_date";
            this.dateTimePicker_trans_date.Size = new System.Drawing.Size(212, 21);
            this.dateTimePicker_trans_date.TabIndex = 4;
            this.dateTimePicker_trans_date.Value = new System.DateTime(2022, 1, 3, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(30, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Category: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(30, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Subcategory:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(30, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(30, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Currency:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(30, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Comment:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(30, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Date:";
            // 
            // button_add
            // 
            this.button_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_add.Location = new System.Drawing.Point(135, 393);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(57, 30);
            this.button_add.TabIndex = 6;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // FormTransInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 450);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker_trans_date);
            this.Controls.Add(this.richTextBox_comment);
            this.Controls.Add(this.textBox_amount);
            this.Controls.Add(this.comboBox_currency);
            this.Controls.Add(this.comboBox_subcategories);
            this.Controls.Add(this.comboBox_categories);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTransInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Budget";
            this.Load += new System.EventHandler(this.Form_trans_input_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_categories;
        private System.Windows.Forms.ComboBox comboBox_subcategories;
        private System.Windows.Forms.ComboBox comboBox_currency;
        private System.Windows.Forms.TextBox textBox_amount;
        private System.Windows.Forms.RichTextBox richTextBox_comment;
        private System.Windows.Forms.DateTimePicker dateTimePicker_trans_date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_add;
    }
}