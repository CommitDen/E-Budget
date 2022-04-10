
using System;
using System.Windows.Forms;

namespace EBudget.View.Main
{
    partial class FormMain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabPage_settings = new System.Windows.Forms.TabPage();
            this.button_logout = new System.Windows.Forms.Button();
            this.button_account_delete = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_settings_password2 = new System.Windows.Forms.TextBox();
            this.textBox_settings_password1 = new System.Windows.Forms.TextBox();
            this.textBox_settings_email = new System.Windows.Forms.TextBox();
            this.textBox_settings_name = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button_settings_save = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_settings_DefaultCurrency = new System.Windows.Forms.ComboBox();
            this.tabPage_reports = new System.Windows.Forms.TabPage();
            this.chart_monthly_expense_income = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_monthly_expense_breakdown = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_monthly_breakdown = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage_categories = new System.Windows.Forms.TabPage();
            this.radioButton_expense = new System.Windows.Forms.RadioButton();
            this.radioButton_income = new System.Windows.Forms.RadioButton();
            this.label_category_list = new System.Windows.Forms.Label();
            this.button_category_add = new System.Windows.Forms.Button();
            this.button_subcategory_add = new System.Windows.Forms.Button();
            this.button_delete_categorysub_list = new System.Windows.Forms.Button();
            this.label_subcategory_list = new System.Windows.Forms.Label();
            this.textBox_subcategory_input = new System.Windows.Forms.TextBox();
            this.textBox_category_input = new System.Windows.Forms.TextBox();
            this.button_edit_categorysub_list = new System.Windows.Forms.Button();
            this.listBox_subcategories = new System.Windows.Forms.ListBox();
            this.listBox_categories = new System.Windows.Forms.ListBox();
            this.tabPage_budget = new System.Windows.Forms.TabPage();
            this.label_pagecount = new System.Windows.Forms.Label();
            this.comboBox_pageSelect = new System.Windows.Forms.ComboBox();
            this.dataGridView_transactions = new System.Windows.Forms.DataGridView();
            this.panel_flter = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_typeFilter = new System.Windows.Forms.ComboBox();
            this.button_filterclear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_currencyFilter = new System.Windows.Forms.ComboBox();
            this.comboBox_subcategoryFilter = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_categoryFilter = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_ToDateFilter = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_FromDateFilter = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_filter = new System.Windows.Forms.Label();
            this.label_expense_total = new System.Windows.Forms.Label();
            this.label_incomes_total = new System.Windows.Forms.Label();
            this.label_ballance = new System.Windows.Forms.Label();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_addtransaction = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_settings.SuspendLayout();
            this.tabPage_reports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_monthly_expense_income)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_monthly_expense_breakdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_monthly_breakdown)).BeginInit();
            this.tabPage_categories.SuspendLayout();
            this.tabPage_budget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_transactions)).BeginInit();
            this.panel_flter.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage_settings
            // 
            this.tabPage_settings.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage_settings.Controls.Add(this.button_logout);
            this.tabPage_settings.Controls.Add(this.button_account_delete);
            this.tabPage_settings.Controls.Add(this.label13);
            this.tabPage_settings.Controls.Add(this.textBox_settings_password2);
            this.tabPage_settings.Controls.Add(this.textBox_settings_password1);
            this.tabPage_settings.Controls.Add(this.textBox_settings_email);
            this.tabPage_settings.Controls.Add(this.textBox_settings_name);
            this.tabPage_settings.Controls.Add(this.label12);
            this.tabPage_settings.Controls.Add(this.button_settings_save);
            this.tabPage_settings.Controls.Add(this.label11);
            this.tabPage_settings.Controls.Add(this.label10);
            this.tabPage_settings.Controls.Add(this.label9);
            this.tabPage_settings.Controls.Add(this.label8);
            this.tabPage_settings.Controls.Add(this.comboBox_settings_DefaultCurrency);
            this.tabPage_settings.Location = new System.Drawing.Point(4, 25);
            this.tabPage_settings.Name = "tabPage_settings";
            this.tabPage_settings.Size = new System.Drawing.Size(951, 532);
            this.tabPage_settings.TabIndex = 2;
            this.tabPage_settings.Text = "Settings";
            // 
            // button_logout
            // 
            this.button_logout.BackColor = System.Drawing.Color.LightGray;
            this.button_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_logout.Location = new System.Drawing.Point(401, 31);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(68, 30);
            this.button_logout.TabIndex = 12;
            this.button_logout.Text = "Logout";
            this.button_logout.UseVisualStyleBackColor = false;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // button_account_delete
            // 
            this.button_account_delete.BackColor = System.Drawing.Color.Firebrick;
            this.button_account_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_account_delete.Location = new System.Drawing.Point(163, 359);
            this.button_account_delete.Name = "button_account_delete";
            this.button_account_delete.Size = new System.Drawing.Size(60, 29);
            this.button_account_delete.TabIndex = 7;
            this.button_account_delete.Text = "Delete";
            this.button_account_delete.UseVisualStyleBackColor = false;
            this.button_account_delete.Click += new System.EventHandler(this.button_account_delete_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(39, 365);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 16);
            this.label13.TabIndex = 11;
            this.label13.Text = "Delete account:";
            // 
            // textBox_settings_password2
            // 
            this.textBox_settings_password2.Location = new System.Drawing.Point(163, 164);
            this.textBox_settings_password2.Name = "textBox_settings_password2";
            this.textBox_settings_password2.PasswordChar = '*';
            this.textBox_settings_password2.Size = new System.Drawing.Size(187, 22);
            this.textBox_settings_password2.TabIndex = 4;
            // 
            // textBox_settings_password1
            // 
            this.textBox_settings_password1.Location = new System.Drawing.Point(162, 121);
            this.textBox_settings_password1.Name = "textBox_settings_password1";
            this.textBox_settings_password1.PasswordChar = '*';
            this.textBox_settings_password1.Size = new System.Drawing.Size(187, 22);
            this.textBox_settings_password1.TabIndex = 3;
            // 
            // textBox_settings_email
            // 
            this.textBox_settings_email.Location = new System.Drawing.Point(162, 77);
            this.textBox_settings_email.Name = "textBox_settings_email";
            this.textBox_settings_email.Size = new System.Drawing.Size(187, 22);
            this.textBox_settings_email.TabIndex = 2;
            // 
            // textBox_settings_name
            // 
            this.textBox_settings_name.Location = new System.Drawing.Point(162, 32);
            this.textBox_settings_name.Name = "textBox_settings_name";
            this.textBox_settings_name.Size = new System.Drawing.Size(187, 22);
            this.textBox_settings_name.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 16);
            this.label12.TabIndex = 9;
            this.label12.Text = "Confirm-password:";
            // 
            // button_settings_save
            // 
            this.button_settings_save.BackColor = System.Drawing.Color.White;
            this.button_settings_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_settings_save.Location = new System.Drawing.Point(163, 261);
            this.button_settings_save.Name = "button_settings_save";
            this.button_settings_save.Size = new System.Drawing.Size(60, 27);
            this.button_settings_save.TabIndex = 6;
            this.button_settings_save.Text = "Save";
            this.button_settings_save.UseVisualStyleBackColor = false;
            this.button_settings_save.Click += new System.EventHandler(this.button_settings_save_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Password:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Default currency:";
            // 
            // comboBox_settings_DefaultCurrency
            // 
            this.comboBox_settings_DefaultCurrency.FormattingEnabled = true;
            this.comboBox_settings_DefaultCurrency.Location = new System.Drawing.Point(163, 210);
            this.comboBox_settings_DefaultCurrency.Name = "comboBox_settings_DefaultCurrency";
            this.comboBox_settings_DefaultCurrency.Size = new System.Drawing.Size(72, 24);
            this.comboBox_settings_DefaultCurrency.TabIndex = 5;
            this.comboBox_settings_DefaultCurrency.SelectedIndexChanged += new System.EventHandler(this.comboBox_settings_DefaultCurrency_SelectedIndexChanged);
            // 
            // tabPage_reports
            // 
            this.tabPage_reports.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage_reports.Controls.Add(this.chart_monthly_expense_income);
            this.tabPage_reports.Controls.Add(this.chart_monthly_expense_breakdown);
            this.tabPage_reports.Controls.Add(this.chart_monthly_breakdown);
            this.tabPage_reports.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage_reports.Location = new System.Drawing.Point(4, 25);
            this.tabPage_reports.Name = "tabPage_reports";
            this.tabPage_reports.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_reports.Size = new System.Drawing.Size(951, 532);
            this.tabPage_reports.TabIndex = 1;
            this.tabPage_reports.Text = "Reports";
            // 
            // chart_monthly_expense_income
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_monthly_expense_income.ChartAreas.Add(chartArea1);
            this.chart_monthly_expense_income.Dock = System.Windows.Forms.DockStyle.Right;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart_monthly_expense_income.Legends.Add(legend1);
            this.chart_monthly_expense_income.Location = new System.Drawing.Point(487, 3);
            this.chart_monthly_expense_income.Name = "chart_monthly_expense_income";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_monthly_expense_income.Series.Add(series1);
            this.chart_monthly_expense_income.Size = new System.Drawing.Size(461, 226);
            this.chart_monthly_expense_income.TabIndex = 2;
            // 
            // chart_monthly_expense_breakdown
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_monthly_expense_breakdown.ChartAreas.Add(chartArea2);
            this.chart_monthly_expense_breakdown.Dock = System.Windows.Forms.DockStyle.Left;
            legend2.Name = "Legend1";
            this.chart_monthly_expense_breakdown.Legends.Add(legend2);
            this.chart_monthly_expense_breakdown.Location = new System.Drawing.Point(3, 3);
            this.chart_monthly_expense_breakdown.Name = "chart_monthly_expense_breakdown";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_monthly_expense_breakdown.Series.Add(series2);
            this.chart_monthly_expense_breakdown.Size = new System.Drawing.Size(488, 226);
            this.chart_monthly_expense_breakdown.TabIndex = 1;
            // 
            // chart_monthly_breakdown
            // 
            chartArea3.Name = "ChartArea1";
            this.chart_monthly_breakdown.ChartAreas.Add(chartArea3);
            this.chart_monthly_breakdown.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend3.Name = "Legend1";
            this.chart_monthly_breakdown.Legends.Add(legend3);
            this.chart_monthly_breakdown.Location = new System.Drawing.Point(3, 229);
            this.chart_monthly_breakdown.Name = "chart_monthly_breakdown";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart_monthly_breakdown.Series.Add(series3);
            this.chart_monthly_breakdown.Size = new System.Drawing.Size(945, 300);
            this.chart_monthly_breakdown.TabIndex = 0;
            // 
            // tabPage_categories
            // 
            this.tabPage_categories.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage_categories.Controls.Add(this.radioButton_expense);
            this.tabPage_categories.Controls.Add(this.radioButton_income);
            this.tabPage_categories.Controls.Add(this.label_category_list);
            this.tabPage_categories.Controls.Add(this.button_category_add);
            this.tabPage_categories.Controls.Add(this.button_subcategory_add);
            this.tabPage_categories.Controls.Add(this.button_delete_categorysub_list);
            this.tabPage_categories.Controls.Add(this.label_subcategory_list);
            this.tabPage_categories.Controls.Add(this.textBox_subcategory_input);
            this.tabPage_categories.Controls.Add(this.textBox_category_input);
            this.tabPage_categories.Controls.Add(this.button_edit_categorysub_list);
            this.tabPage_categories.Controls.Add(this.listBox_subcategories);
            this.tabPage_categories.Controls.Add(this.listBox_categories);
            this.tabPage_categories.Location = new System.Drawing.Point(4, 25);
            this.tabPage_categories.Name = "tabPage_categories";
            this.tabPage_categories.Size = new System.Drawing.Size(951, 532);
            this.tabPage_categories.TabIndex = 3;
            this.tabPage_categories.Text = "Categories";
            // 
            // radioButton_expense
            // 
            this.radioButton_expense.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton_expense.AutoSize = true;
            this.radioButton_expense.Checked = true;
            this.radioButton_expense.Location = new System.Drawing.Point(324, 375);
            this.radioButton_expense.Name = "radioButton_expense";
            this.radioButton_expense.Size = new System.Drawing.Size(79, 20);
            this.radioButton_expense.TabIndex = 21;
            this.radioButton_expense.TabStop = true;
            this.radioButton_expense.Text = "Expense";
            this.radioButton_expense.UseVisualStyleBackColor = true;
            // 
            // radioButton_income
            // 
            this.radioButton_income.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton_income.AutoSize = true;
            this.radioButton_income.Location = new System.Drawing.Point(249, 375);
            this.radioButton_income.Name = "radioButton_income";
            this.radioButton_income.Size = new System.Drawing.Size(70, 20);
            this.radioButton_income.TabIndex = 20;
            this.radioButton_income.Text = "Income";
            this.radioButton_income.UseVisualStyleBackColor = true;
            // 
            // label_category_list
            // 
            this.label_category_list.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_category_list.AutoSize = true;
            this.label_category_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_category_list.Location = new System.Drawing.Point(214, 123);
            this.label_category_list.Name = "label_category_list";
            this.label_category_list.Size = new System.Drawing.Size(90, 18);
            this.label_category_list.TabIndex = 12;
            this.label_category_list.Text = "Categories";
            // 
            // button_category_add
            // 
            this.button_category_add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_category_add.BackColor = System.Drawing.Color.White;
            this.button_category_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_category_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_category_add.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_category_add.Location = new System.Drawing.Point(294, 400);
            this.button_category_add.MaximumSize = new System.Drawing.Size(47, 25);
            this.button_category_add.MinimumSize = new System.Drawing.Size(47, 25);
            this.button_category_add.Name = "button_category_add";
            this.button_category_add.Size = new System.Drawing.Size(47, 25);
            this.button_category_add.TabIndex = 16;
            this.button_category_add.Text = "Add";
            this.button_category_add.UseVisualStyleBackColor = false;
            this.button_category_add.Click += new System.EventHandler(this.button_category_add_Click);
            // 
            // button_subcategory_add
            // 
            this.button_subcategory_add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_subcategory_add.BackColor = System.Drawing.Color.White;
            this.button_subcategory_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_subcategory_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_subcategory_add.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_subcategory_add.Location = new System.Drawing.Point(600, 375);
            this.button_subcategory_add.MaximumSize = new System.Drawing.Size(47, 25);
            this.button_subcategory_add.MinimumSize = new System.Drawing.Size(47, 25);
            this.button_subcategory_add.Name = "button_subcategory_add";
            this.button_subcategory_add.Size = new System.Drawing.Size(47, 25);
            this.button_subcategory_add.TabIndex = 17;
            this.button_subcategory_add.Text = "Add";
            this.button_subcategory_add.UseVisualStyleBackColor = false;
            this.button_subcategory_add.Click += new System.EventHandler(this.button_subcategory_add_Click);
            // 
            // button_delete_categorysub_list
            // 
            this.button_delete_categorysub_list.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_delete_categorysub_list.BackColor = System.Drawing.Color.White;
            this.button_delete_categorysub_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_delete_categorysub_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_delete_categorysub_list.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_delete_categorysub_list.Location = new System.Drawing.Point(445, 261);
            this.button_delete_categorysub_list.MaximumSize = new System.Drawing.Size(58, 23);
            this.button_delete_categorysub_list.MinimumSize = new System.Drawing.Size(58, 23);
            this.button_delete_categorysub_list.Name = "button_delete_categorysub_list";
            this.button_delete_categorysub_list.Size = new System.Drawing.Size(58, 23);
            this.button_delete_categorysub_list.TabIndex = 19;
            this.button_delete_categorysub_list.Text = "Delete";
            this.button_delete_categorysub_list.UseVisualStyleBackColor = false;
            this.button_delete_categorysub_list.Click += new System.EventHandler(this.button_delete_categorysub_list_Click);
            // 
            // label_subcategory_list
            // 
            this.label_subcategory_list.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_subcategory_list.AutoSize = true;
            this.label_subcategory_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_subcategory_list.Location = new System.Drawing.Point(521, 123);
            this.label_subcategory_list.Name = "label_subcategory_list";
            this.label_subcategory_list.Size = new System.Drawing.Size(116, 18);
            this.label_subcategory_list.TabIndex = 13;
            this.label_subcategory_list.Text = "Subcategories";
            // 
            // textBox_subcategory_input
            // 
            this.textBox_subcategory_input.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_subcategory_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_subcategory_input.Location = new System.Drawing.Point(524, 349);
            this.textBox_subcategory_input.MaximumSize = new System.Drawing.Size(209, 20);
            this.textBox_subcategory_input.MinimumSize = new System.Drawing.Size(209, 20);
            this.textBox_subcategory_input.Name = "textBox_subcategory_input";
            this.textBox_subcategory_input.Size = new System.Drawing.Size(209, 22);
            this.textBox_subcategory_input.TabIndex = 15;
            // 
            // textBox_category_input
            // 
            this.textBox_category_input.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_category_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_category_input.Location = new System.Drawing.Point(217, 349);
            this.textBox_category_input.MaximumSize = new System.Drawing.Size(209, 20);
            this.textBox_category_input.MinimumSize = new System.Drawing.Size(209, 20);
            this.textBox_category_input.Name = "textBox_category_input";
            this.textBox_category_input.Size = new System.Drawing.Size(209, 22);
            this.textBox_category_input.TabIndex = 14;
            // 
            // button_edit_categorysub_list
            // 
            this.button_edit_categorysub_list.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_edit_categorysub_list.BackColor = System.Drawing.Color.White;
            this.button_edit_categorysub_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_edit_categorysub_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_edit_categorysub_list.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_edit_categorysub_list.Location = new System.Drawing.Point(445, 202);
            this.button_edit_categorysub_list.MaximumSize = new System.Drawing.Size(58, 23);
            this.button_edit_categorysub_list.MinimumSize = new System.Drawing.Size(58, 23);
            this.button_edit_categorysub_list.Name = "button_edit_categorysub_list";
            this.button_edit_categorysub_list.Size = new System.Drawing.Size(58, 23);
            this.button_edit_categorysub_list.TabIndex = 18;
            this.button_edit_categorysub_list.Text = "Edit";
            this.button_edit_categorysub_list.UseVisualStyleBackColor = false;
            this.button_edit_categorysub_list.Click += new System.EventHandler(this.button_edit_categorysub_list_Click);
            // 
            // listBox_subcategories
            // 
            this.listBox_subcategories.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox_subcategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox_subcategories.FormattingEnabled = true;
            this.listBox_subcategories.ItemHeight = 16;
            this.listBox_subcategories.Location = new System.Drawing.Point(524, 144);
            this.listBox_subcategories.MaximumSize = new System.Drawing.Size(209, 199);
            this.listBox_subcategories.MinimumSize = new System.Drawing.Size(209, 199);
            this.listBox_subcategories.Name = "listBox_subcategories";
            this.listBox_subcategories.Size = new System.Drawing.Size(209, 196);
            this.listBox_subcategories.TabIndex = 11;
            this.listBox_subcategories.SelectedIndexChanged += new System.EventHandler(this.listBox_subcategories_SelectedIndexChanged);
            // 
            // listBox_categories
            // 
            this.listBox_categories.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox_categories.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox_categories.FormattingEnabled = true;
            this.listBox_categories.ItemHeight = 16;
            this.listBox_categories.Location = new System.Drawing.Point(217, 144);
            this.listBox_categories.MaximumSize = new System.Drawing.Size(209, 199);
            this.listBox_categories.MinimumSize = new System.Drawing.Size(209, 199);
            this.listBox_categories.Name = "listBox_categories";
            this.listBox_categories.Size = new System.Drawing.Size(209, 196);
            this.listBox_categories.TabIndex = 10;
            this.listBox_categories.SelectedIndexChanged += new System.EventHandler(this.listBox_categories_SelectedIndexChanged);
            // 
            // tabPage_budget
            // 
            this.tabPage_budget.BackColor = System.Drawing.Color.White;
            this.tabPage_budget.Controls.Add(this.label_pagecount);
            this.tabPage_budget.Controls.Add(this.comboBox_pageSelect);
            this.tabPage_budget.Controls.Add(this.dataGridView_transactions);
            this.tabPage_budget.Controls.Add(this.panel_flter);
            this.tabPage_budget.Controls.Add(this.label_expense_total);
            this.tabPage_budget.Controls.Add(this.label_incomes_total);
            this.tabPage_budget.Controls.Add(this.label_ballance);
            this.tabPage_budget.Controls.Add(this.button_delete);
            this.tabPage_budget.Controls.Add(this.button_addtransaction);
            this.tabPage_budget.Controls.Add(this.button_edit);
            this.tabPage_budget.Location = new System.Drawing.Point(4, 25);
            this.tabPage_budget.Name = "tabPage_budget";
            this.tabPage_budget.Size = new System.Drawing.Size(951, 532);
            this.tabPage_budget.TabIndex = 0;
            this.tabPage_budget.Text = "Budget";
            // 
            // label_pagecount
            // 
            this.label_pagecount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_pagecount.AutoSize = true;
            this.label_pagecount.Location = new System.Drawing.Point(839, 105);
            this.label_pagecount.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label_pagecount.Name = "label_pagecount";
            this.label_pagecount.Size = new System.Drawing.Size(64, 16);
            this.label_pagecount.TabIndex = 10;
            this.label_pagecount.Text = "Page: 1 / ";
            // 
            // comboBox_pageSelect
            // 
            this.comboBox_pageSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_pageSelect.FormattingEnabled = true;
            this.comboBox_pageSelect.Location = new System.Drawing.Point(902, 102);
            this.comboBox_pageSelect.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.comboBox_pageSelect.Name = "comboBox_pageSelect";
            this.comboBox_pageSelect.Size = new System.Drawing.Size(46, 24);
            this.comboBox_pageSelect.TabIndex = 9;
            this.comboBox_pageSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox_pageSelect_SelectedIndexChanged);
            // 
            // dataGridView_transactions
            // 
            this.dataGridView_transactions.AllowUserToAddRows = false;
            this.dataGridView_transactions.AllowUserToDeleteRows = false;
            this.dataGridView_transactions.AllowUserToResizeRows = false;
            this.dataGridView_transactions.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_transactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_transactions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView_transactions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_transactions.Location = new System.Drawing.Point(193, 132);
            this.dataGridView_transactions.MultiSelect = false;
            this.dataGridView_transactions.Name = "dataGridView_transactions";
            this.dataGridView_transactions.ReadOnly = true;
            this.dataGridView_transactions.RowHeadersVisible = false;
            this.dataGridView_transactions.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_transactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_transactions.Size = new System.Drawing.Size(758, 400);
            this.dataGridView_transactions.TabIndex = 8;
            this.dataGridView_transactions.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_transactions_ColumnHeaderMouseClick);
            // 
            // panel_flter
            // 
            this.panel_flter.BackColor = System.Drawing.Color.DarkGray;
            this.panel_flter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_flter.Controls.Add(this.label7);
            this.panel_flter.Controls.Add(this.comboBox_typeFilter);
            this.panel_flter.Controls.Add(this.button_filterclear);
            this.panel_flter.Controls.Add(this.label6);
            this.panel_flter.Controls.Add(this.comboBox_currencyFilter);
            this.panel_flter.Controls.Add(this.comboBox_subcategoryFilter);
            this.panel_flter.Controls.Add(this.label5);
            this.panel_flter.Controls.Add(this.comboBox_categoryFilter);
            this.panel_flter.Controls.Add(this.dateTimePicker_ToDateFilter);
            this.panel_flter.Controls.Add(this.dateTimePicker_FromDateFilter);
            this.panel_flter.Controls.Add(this.label4);
            this.panel_flter.Controls.Add(this.label3);
            this.panel_flter.Controls.Add(this.label2);
            this.panel_flter.Controls.Add(this.label1);
            this.panel_flter.Controls.Add(this.label_filter);
            this.panel_flter.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_flter.Location = new System.Drawing.Point(0, 0);
            this.panel_flter.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.panel_flter.Name = "panel_flter";
            this.panel_flter.Size = new System.Drawing.Size(193, 532);
            this.panel_flter.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Type:";
            // 
            // comboBox_typeFilter
            // 
            this.comboBox_typeFilter.FormattingEnabled = true;
            this.comboBox_typeFilter.Items.AddRange(new object[] {
            "income",
            "expense"});
            this.comboBox_typeFilter.Location = new System.Drawing.Point(11, 77);
            this.comboBox_typeFilter.Name = "comboBox_typeFilter";
            this.comboBox_typeFilter.Size = new System.Drawing.Size(167, 24);
            this.comboBox_typeFilter.TabIndex = 13;
            this.comboBox_typeFilter.SelectedIndexChanged += new System.EventHandler(this.comboBox_typeFilter_SelectedIndexChanged);
            // 
            // button_filterclear
            // 
            this.button_filterclear.BackColor = System.Drawing.Color.White;
            this.button_filterclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_filterclear.Location = new System.Drawing.Point(66, 457);
            this.button_filterclear.Name = "button_filterclear";
            this.button_filterclear.Size = new System.Drawing.Size(63, 26);
            this.button_filterclear.TabIndex = 12;
            this.button_filterclear.Text = "Clear";
            this.button_filterclear.UseVisualStyleBackColor = false;
            this.button_filterclear.Click += new System.EventHandler(this.button_filterclear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Currency:";
            // 
            // comboBox_currencyFilter
            // 
            this.comboBox_currencyFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_currencyFilter.FormattingEnabled = true;
            this.comboBox_currencyFilter.Location = new System.Drawing.Point(11, 242);
            this.comboBox_currencyFilter.Name = "comboBox_currencyFilter";
            this.comboBox_currencyFilter.Size = new System.Drawing.Size(167, 24);
            this.comboBox_currencyFilter.TabIndex = 10;
            this.comboBox_currencyFilter.SelectedIndexChanged += new System.EventHandler(this.comboBox_currencyFilter_SelectedIndexChanged);
            // 
            // comboBox_subcategoryFilter
            // 
            this.comboBox_subcategoryFilter.FormattingEnabled = true;
            this.comboBox_subcategoryFilter.Location = new System.Drawing.Point(11, 186);
            this.comboBox_subcategoryFilter.Name = "comboBox_subcategoryFilter";
            this.comboBox_subcategoryFilter.Size = new System.Drawing.Size(167, 24);
            this.comboBox_subcategoryFilter.TabIndex = 9;
            this.comboBox_subcategoryFilter.SelectedIndexChanged += new System.EventHandler(this.comboBox_subcategoryFilter_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Subcategory:";
            // 
            // comboBox_categoryFilter
            // 
            this.comboBox_categoryFilter.FormattingEnabled = true;
            this.comboBox_categoryFilter.Location = new System.Drawing.Point(11, 133);
            this.comboBox_categoryFilter.Name = "comboBox_categoryFilter";
            this.comboBox_categoryFilter.Size = new System.Drawing.Size(167, 24);
            this.comboBox_categoryFilter.TabIndex = 7;
            this.comboBox_categoryFilter.DropDown += new System.EventHandler(this.comboBox_categoryFilter_DropDown);
            this.comboBox_categoryFilter.SelectedIndexChanged += new System.EventHandler(this.comboBox_categoryFilter_SelectedIndexChanged);
            // 
            // dateTimePicker_ToDateFilter
            // 
            this.dateTimePicker_ToDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_ToDateFilter.Location = new System.Drawing.Point(11, 354);
            this.dateTimePicker_ToDateFilter.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_ToDateFilter.Name = "dateTimePicker_ToDateFilter";
            this.dateTimePicker_ToDateFilter.Size = new System.Drawing.Size(108, 22);
            this.dateTimePicker_ToDateFilter.TabIndex = 6;
            this.dateTimePicker_ToDateFilter.ValueChanged += new System.EventHandler(this.dateTimePicker_ToDateFilter_ValueChanged);
            // 
            // dateTimePicker_FromDateFilter
            // 
            this.dateTimePicker_FromDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_FromDateFilter.Location = new System.Drawing.Point(11, 298);
            this.dateTimePicker_FromDateFilter.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_FromDateFilter.Name = "dateTimePicker_FromDateFilter";
            this.dateTimePicker_FromDateFilter.Size = new System.Drawing.Size(108, 22);
            this.dateTimePicker_FromDateFilter.TabIndex = 5;
            this.dateTimePicker_FromDateFilter.ValueChanged += new System.EventHandler(this.dateTimePicker_FromDateFilter_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "To:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "From:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Category:";
            // 
            // label_filter
            // 
            this.label_filter.AutoSize = true;
            this.label_filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_filter.Location = new System.Drawing.Point(62, 16);
            this.label_filter.Name = "label_filter";
            this.label_filter.Size = new System.Drawing.Size(57, 24);
            this.label_filter.TabIndex = 0;
            this.label_filter.Text = "Filter";
            // 
            // label_expense_total
            // 
            this.label_expense_total.AutoSize = true;
            this.label_expense_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_expense_total.Location = new System.Drawing.Point(651, 3);
            this.label_expense_total.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label_expense_total.Name = "label_expense_total";
            this.label_expense_total.Size = new System.Drawing.Size(110, 18);
            this.label_expense_total.TabIndex = 6;
            this.label_expense_total.Text = "Total Expense: ";
            // 
            // label_incomes_total
            // 
            this.label_incomes_total.AutoSize = true;
            this.label_incomes_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_incomes_total.Location = new System.Drawing.Point(410, 3);
            this.label_incomes_total.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label_incomes_total.Name = "label_incomes_total";
            this.label_incomes_total.Size = new System.Drawing.Size(102, 18);
            this.label_incomes_total.TabIndex = 5;
            this.label_incomes_total.Text = "Total Income: ";
            // 
            // label_ballance
            // 
            this.label_ballance.AutoSize = true;
            this.label_ballance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_ballance.Location = new System.Drawing.Point(199, 3);
            this.label_ballance.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label_ballance.Name = "label_ballance";
            this.label_ballance.Size = new System.Drawing.Size(65, 18);
            this.label_ballance.TabIndex = 4;
            this.label_ballance.Text = "Balance:";
            // 
            // button_delete
            // 
            this.button_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_delete.Location = new System.Drawing.Point(300, 101);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(60, 25);
            this.button_delete.TabIndex = 3;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_addtransaction
            // 
            this.button_addtransaction.AllowDrop = true;
            this.button_addtransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addtransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_addtransaction.Location = new System.Drawing.Point(199, 101);
            this.button_addtransaction.Name = "button_addtransaction";
            this.button_addtransaction.Size = new System.Drawing.Size(44, 25);
            this.button_addtransaction.TabIndex = 1;
            this.button_addtransaction.Text = "Add";
            this.button_addtransaction.UseVisualStyleBackColor = true;
            this.button_addtransaction.Click += new System.EventHandler(this.button_addtransaction_Click);
            // 
            // button_edit
            // 
            this.button_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_edit.Location = new System.Drawing.Point(249, 101);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(45, 25);
            this.button_edit.TabIndex = 2;
            this.button_edit.Text = "Edit";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_budget);
            this.tabControl_main.Controls.Add(this.tabPage_categories);
            this.tabControl_main.Controls.Add(this.tabPage_reports);
            this.tabControl_main.Controls.Add(this.tabPage_settings);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(959, 561);
            this.tabControl_main.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 561);
            this.Controls.Add(this.tabControl_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(975, 600);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Budget";
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.SizeChanged += new System.EventHandler(this.Form_main_SizeChanged);
            this.tabPage_settings.ResumeLayout(false);
            this.tabPage_settings.PerformLayout();
            this.tabPage_reports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_monthly_expense_income)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_monthly_expense_breakdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_monthly_breakdown)).EndInit();
            this.tabPage_categories.ResumeLayout(false);
            this.tabPage_categories.PerformLayout();
            this.tabPage_budget.ResumeLayout(false);
            this.tabPage_budget.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_transactions)).EndInit();
            this.panel_flter.ResumeLayout(false);
            this.panel_flter.PerformLayout();
            this.tabControl_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabPage tabPage_settings;
        private Button button_logout;
        private Button button_account_delete;
        private Label label13;
        private TextBox textBox_settings_password2;
        private TextBox textBox_settings_password1;
        private TextBox textBox_settings_email;
        private TextBox textBox_settings_name;
        private Label label12;
        private Button button_settings_save;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private ComboBox comboBox_settings_DefaultCurrency;
        private TabPage tabPage_reports;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_monthly_expense_income;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_monthly_expense_breakdown;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_monthly_breakdown;
        private TabPage tabPage_categories;
        private RadioButton radioButton_expense;
        private RadioButton radioButton_income;
        private Label label_category_list;
        private Button button_category_add;
        private Button button_subcategory_add;
        private Button button_delete_categorysub_list;
        private Label label_subcategory_list;
        private TextBox textBox_subcategory_input;
        private TextBox textBox_category_input;
        private Button button_edit_categorysub_list;
        private ListBox listBox_subcategories;
        private ListBox listBox_categories;
        private TabPage tabPage_budget;
        private Label label_pagecount;
        private ComboBox comboBox_pageSelect;
        private DataGridView dataGridView_transactions;
        private Panel panel_flter;
        private Label label7;
        private ComboBox comboBox_typeFilter;
        private Button button_filterclear;
        private Label label6;
        private ComboBox comboBox_currencyFilter;
        private ComboBox comboBox_subcategoryFilter;
        private Label label5;
        private ComboBox comboBox_categoryFilter;
        private DateTimePicker dateTimePicker_ToDateFilter;
        private DateTimePicker dateTimePicker_FromDateFilter;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label_filter;
        private Label label_expense_total;
        private Label label_incomes_total;
        private Label label_ballance;
        private Button button_delete;
        private Button button_addtransaction;
        private Button button_edit;
        private TabControl tabControl_main;
    }
}