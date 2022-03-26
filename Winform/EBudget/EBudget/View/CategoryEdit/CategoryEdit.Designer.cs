namespace EBudget.View.CategoryEdit
{
    partial class FormCategoryEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCategoryEdit));
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.button_edit = new System.Windows.Forms.Button();
            this.label_name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_name.Location = new System.Drawing.Point(27, 65);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(177, 22);
            this.textBox_name.TabIndex = 0;
            // 
            // button_edit
            // 
            this.button_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_edit.Location = new System.Drawing.Point(91, 105);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(56, 24);
            this.button_edit.TabIndex = 1;
            this.button_edit.Text = "Edit";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_name.Location = new System.Drawing.Point(24, 46);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(41, 16);
            this.label_name.TabIndex = 2;
            this.label_name.Text = "name";
            // 
            // FormCategoryEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 157);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.textBox_name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(248, 196);
            this.MinimumSize = new System.Drawing.Size(248, 196);
            this.Name = "FormCategoryEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CategoryEdit";
            this.Load += new System.EventHandler(this.CategoryEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Label label_name;
    }
}