using EBudget.Presenter;
using EBudget.View.CategoryEdit;
using EBudget.View.TransInput;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EBudget.View.Main
{
    public partial class FormMain : Form, IFormMain
    {

        private MainPresenter presenter;
        Dictionary<string, int> categories_filterlist = new Dictionary<string, int>();
        Dictionary<string, int> subcategories_filterlist = new Dictionary<string, int>();
        Dictionary<string, int> currencies_filterlist = new Dictionary<string, int>();
        List<string> chart_monthly_expense_breakdown_categories = new List<string>();
        List<double> chart_monthly_expense_breakdown_amounts = new List<double>();
        List<string> chart_yearly_expense_income_categories = new List<string>();
        List<double> chart_yearly_expense_income_amounts = new List<double>();
        List<int> pagelist = new List<int>();
        List<Action> tobecommited = new List<Action>();
        string previtem;
        //
        #region InterfaceImplementation
        public string Ballance { set => label_ballance.Text = value; }
        public string TIncome { set => label_incomes_total.Text = value; }
        public string TExpense { set => label_expense_total.Text = value; }
        public List<Model.Transaction> Transactions { set => dataGridView_transactions.DataSource = value; }
        public string SelectedCategory => (string)dataGridView_transactions.SelectedRows[0].Cells[0].Value;
        public string SelectedSubcategory => (string)dataGridView_transactions.SelectedRows[0].Cells[1].Value;
        public double SelectedAmount => Convert.ToDouble(dataGridView_transactions.SelectedRows[0].Cells[2].Value);
        public string SelectedCurrency => dataGridView_transactions.SelectedRows[0].Cells[3].Value.ToString().ToUpper();
        public DateTime SelectedDate => Convert.ToDateTime(dataGridView_transactions.SelectedRows[0].Cells[4].Value);
        public string SelectedComment => dataGridView_transactions.SelectedRows[0].Cells[5].Value.ToString();
        public int SelectedRowIndex => dataGridView_transactions.SelectedRows[0].Cells[0].RowIndex;
        public string LBSelectedCategory { get => listBox_categories.SelectedItem.ToString(); set => listBox_categories.SelectedItem = value; }
        public string LBSelectedSubcategory => listBox_subcategories.SelectedItem.ToString();
        public string LBAddCategory => textBox_category_input.Text;
        public string LBAddSubcategory => textBox_subcategory_input.Text;
        public List<string> Columns => GetDGVColumns();
        public string CategoryFilter => comboBox_categoryFilter.Text;
        public string SubcategoryFilter => comboBox_subcategoryFilter.Text;
        public string CurrencyFilter => comboBox_currencyFilter.Text;
        public DateTime DateFromFilter => dateTimePicker_FromDateFilter.Value;
        public DateTime DateToFilter => dateTimePicker_ToDateFilter.Value;
        public Dictionary<string, int> CategoriesFilterList { get => categories_filterlist; set => categories_filterlist = value; }
        public Dictionary<string, int> SubcategoriesFilterList { get => subcategories_filterlist; set => subcategories_filterlist = value; }
        public Dictionary<string, int> CurrenciesFilterList { get => currencies_filterlist; set => currencies_filterlist = value; }
        public List<int> PageList { get => pagelist; set => pagelist = value; }

        public bool RBExpense => radioButton_expense.Checked;

        public List<string> LBCategoriesItems => GetLBCategoriesItems();

        private List<string> GetLBCategoriesItems()
        {
            List<string> list = new List<string>();
            foreach (var item in listBox_categories.Items)
            {
                list.Add(item.ToString());
            }
            return list;
        }

        public List<string> LBSubcategoriesItems => GetLBSubcategoriesItems();

        public string PageCount { set => label_pagecount.Text = value; }

        public int PageSelectLocationX => comboBox_pageSelect.Location.X;

        public int PageCountWidth => label_pagecount.Width;

        public string NewName => textBox_settings_name.Text;

        public string NewEmail => textBox_settings_email.Text;

        public string NewPass => textBox_settings_password1.Text;

        public List<string> Chart_monthly_expense_breakdown_categories { get => chart_monthly_expense_breakdown_categories; set => chart_monthly_expense_breakdown_categories = value; }
        public List<double> Chart_monthly_expense_breakdown_amounts { get => chart_monthly_expense_breakdown_amounts; set => chart_monthly_expense_breakdown_amounts = value; }
        public List<string> Chart_yearly_expense_income_categories { get => chart_yearly_expense_income_categories; set => chart_yearly_expense_income_categories = value; }
        public List<double> Chart_yearly_expense_income_amounts { get => chart_yearly_expense_income_amounts; set => chart_yearly_expense_income_amounts = value; }

        
        #endregion
        //

        public FormMain(int id)
        {
            InitializeComponent();
            presenter = new MainPresenter(this);
            presenter.SetId(id);


            this.BringToFront();
            this.Focus();
            presenter.GetDefCurrency();

            dateTimePicker_FromDateFilter.ValueChanged -= dateTimePicker_FromDateFilter_ValueChanged;
            dateTimePicker_ToDateFilter.ValueChanged -= dateTimePicker_ToDateFilter_ValueChanged;
            dateTimePicker_FromDateFilter.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePicker_ToDateFilter.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59);
            dateTimePicker_FromDateFilter.ValueChanged += dateTimePicker_FromDateFilter_ValueChanged;
            dateTimePicker_ToDateFilter.ValueChanged += dateTimePicker_ToDateFilter_ValueChanged;


            presenter.LoadCategoryDicts();
            presenter.GetDefDictionaries();
            presenter.LoadComboboxItems(CategoriesFilterList, comboBox_categoryFilter);
            presenter.LoadCBCurrencyItems(comboBox_currencyFilter);
            presenter.LoadCBCurrencyItems(comboBox_settings_DefaultCurrency);
            comboBox_settings_DefaultCurrency.SelectedIndexChanged -= comboBox_settings_DefaultCurrency_SelectedIndexChanged;
            comboBox_settings_DefaultCurrency.SelectedItem = presenter.GetDefCurrency();
            comboBox_settings_DefaultCurrency.SelectedIndexChanged += comboBox_settings_DefaultCurrency_SelectedIndexChanged;


            listBox_categories.Items.AddRange(presenter.GetCategoryKeys());

            dateTimePicker_ToDateFilter.ValueChanged -= dateTimePicker_ToDateFilter_ValueChanged;
            dateTimePicker_ToDateFilter.MinDate = dateTimePicker_FromDateFilter.Value;
            dateTimePicker_ToDateFilter.ValueChanged += dateTimePicker_ToDateFilter_ValueChanged;

            presenter.FilterListClear();

            presenter.SetPageNumber(1);

            presenter.DatagridRefresh(false);

            WindowResize();

            comboBox_pageSelect.SelectedIndex = 0;


            dataGridView_transactions.Columns[5].Width = dataGridView_transactions.Width - 5 * dataGridView_transactions.Columns[0].Width;

        }

        private void WindowResize()
        {
            dataGridView_transactions.Height = Height - 200;

            chart_monthly_expense_breakdown.Width = ClientSize.Width/2;
            chart_monthly_expense_breakdown.Height = ClientSize.Height / 2;

            chart_yearly_expense_income.Width = ClientSize.Width / 2;
            chart_yearly_expense_income.Height = ClientSize.Height / 2;

            chart_monthly_breakdown.Height = ClientSize.Height / 2;

            dataGridView_transactions.Columns[5].Width = dataGridView_transactions.Width - (dataGridView_transactions.Columns[0].Width + dataGridView_transactions.Columns[1].Width + dataGridView_transactions.Columns[2].Width + dataGridView_transactions.Columns[3].Width + dataGridView_transactions.Columns[4].Width);
            presenter.DatagridRefresh(presenter.IsFiltered());
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            UpdateFont();
            Title title1 = new Title();
            Title title2 = new Title();
            Title title3 = new Title();
            title1.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            title1.Text = "Monthly expenses breakdown";
            chart_monthly_expense_breakdown.Titles.Add(title1);
            title2.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            title2.Text = "Income Expense breakdown / month";
            chart_monthly_breakdown.Titles.Add(title2);
            title3.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            title3.Text = "Monthly Income Expense breakdown";
            chart_yearly_expense_income.Titles.Add(title3);

        }

        private void SetCharts()
        {
            chart_monthly_expense_breakdown.Series[0].Points.DataBindXY(chart_monthly_expense_breakdown_categories, chart_monthly_expense_breakdown_amounts);
            chart_yearly_expense_income.Series[0].Points.DataBindXY(chart_yearly_expense_income_categories, chart_yearly_expense_income_amounts);

            chart_yearly_expense_income.Series[0].IsValueShownAsLabel = true;
            chart_yearly_expense_income.Series[0]["LabelStyle"] = "Bottom";

            chart_monthly_breakdown.Series["expense"]["LabelStyle"] = "Bottom";
            chart_monthly_breakdown.Series["income"]["LabelStyle"] = "Bottom";

        }

        private void button_addtransaction_Click(object sender, EventArgs e)
        {
            FormTransInput f = new FormTransInput();
            f.ShowDialog();
            presenter.DatagridRefresh(presenter.IsFiltered());
        }
        private void button_edit_Click(object sender, EventArgs e)
        {
            FormTransInput f = new FormTransInput(presenter.SetT());
            f.ShowDialog();
            presenter.DatagridRefresh(presenter.IsFiltered());
        }
        private void button_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete transaction?", "Delete Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                presenter.DeleteSelectedTransaction();
                presenter.DatagridRefresh(presenter.IsFiltered());
            }

        }
        private void dataGridView_transactions_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            SortOrder so = SortOrder.None;
            if (grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending)
            {
                so = SortOrder.Descending;
            }
            else
            {
                so = SortOrder.Ascending;
            }
            presenter.Sort(grid.Columns[e.ColumnIndex].Name, so);
            grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = so;
        }
        private void Form_main_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                WindowResize();
            }
        }
        private void dataGridView_transactions_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridView_transactions.Columns[5].Width = dataGridView_transactions.Width - 5 * dataGridView_transactions.Columns[0].Width;
        }
        private void listBox_categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.SaveSelectedLBCatItem();
            presenter.DeleteSelectedLBSubCatItem();
            listBox_subcategories.Items.Clear();

            Dictionary<string, int> subcategories = presenter.GetSubcategories();

            listBox_subcategories.Items.AddRange(subcategories.Keys.ToArray());

            if (!presenter.IsExpense(listBox_categories.SelectedItem.ToString())) button_subcategory_add.Enabled = false;
            if (presenter.IsExpense(listBox_categories.SelectedItem.ToString())) button_subcategory_add.Enabled = true;
        }
        private void listBox_subcategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.SaveSelectedLBSubcatItem();
        }
        private void comboBox_categoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_categoryFilter.SelectedItem != null && comboBox_categoryFilter.SelectedItem.ToString() != previtem)
            {
                comboBox_subcategoryFilter.SelectedItem = null;
                comboBox_subcategoryFilter.Items.Clear();
                string selecteditem = comboBox_categoryFilter.SelectedItem.ToString();
                string querystring = String.Format("AND `Category`='{0}'", selecteditem);
                presenter.DeleteCreateAddFilter("Category", selecteditem, querystring);
                presenter.DatagridRefresh(presenter.IsFiltered());
                subcategories_filterlist = presenter.ComboBoxSubcategoriesRefresh();
                presenter.LoadComboboxItems(SubcategoriesFilterList, comboBox_subcategoryFilter);
            }

        }
        private void comboBox_subcategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_subcategoryFilter.SelectedItem != null)
            {
                string selecteditem = comboBox_subcategoryFilter.SelectedItem.ToString();
                string querystring = String.Format("AND `Subcategory`='{0}'", selecteditem);
                presenter.DeleteCreateAddFilter("Subcategory", selecteditem, querystring);
                presenter.DatagridRefresh(presenter.IsFiltered());
            }
        }
        private void comboBox_currencyFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_currencyFilter.SelectedItem != null)
            {
                string selecteditem = comboBox_currencyFilter.SelectedItem.ToString();
                string querystring = String.Format("AND `Currency_code`='{0}'", selecteditem);
                presenter.DeleteCreateAddFilter("Currency", selecteditem, querystring);
                presenter.DatagridRefresh(presenter.IsFiltered());
            }
        }
        private void dateTimePicker_FromDateFilter_ValueChanged(object sender, EventArgs e)
        {
            DateFilter();
            dateTimePicker_ToDateFilter.ValueChanged -= dateTimePicker_ToDateFilter_ValueChanged;
            dateTimePicker_ToDateFilter.MinDate = new DateTime(dateTimePicker_FromDateFilter.Value.Year, dateTimePicker_FromDateFilter.Value.Month, dateTimePicker_FromDateFilter.Value.Day, 0, 0, 0);
            dateTimePicker_ToDateFilter.ValueChanged += dateTimePicker_ToDateFilter_ValueChanged;
        }
        private void dateTimePicker_ToDateFilter_ValueChanged(object sender, EventArgs e)
        {
            DateFilter();
        }
        private void DateFilter()
        {
            string selectedfrom = dateTimePicker_FromDateFilter.Value.ToString("yyyy-MM-dd");
            string selectedto = dateTimePicker_ToDateFilter.Value.ToString("yyyy-MM-dd");

            string querystring = String.Format("AND `Date` BETWEEN '{0}' AND '{1}'", selectedfrom, selectedto);
            presenter.DeleteCreateAddFilter("Date", selectedfrom, querystring);

            presenter.DatagridRefresh(presenter.IsFiltered());
        }
        private void button_filterclear_Click(object sender, EventArgs e)
        {
            comboBox_typeFilter.SelectedItem = null;
            comboBox_categoryFilter.SelectedItem = null;
            comboBox_subcategoryFilter.SelectedItem = null;
            comboBox_currencyFilter.SelectedItem = null;
            dateTimePicker_FromDateFilter.ValueChanged -= dateTimePicker_FromDateFilter_ValueChanged;
            dateTimePicker_ToDateFilter.ValueChanged -= dateTimePicker_ToDateFilter_ValueChanged;
            dateTimePicker_FromDateFilter.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
            dateTimePicker_ToDateFilter.MinDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
            dateTimePicker_ToDateFilter.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 1, 0, 0);
            dateTimePicker_FromDateFilter.ValueChanged += dateTimePicker_FromDateFilter_ValueChanged;
            dateTimePicker_ToDateFilter.ValueChanged += dateTimePicker_ToDateFilter_ValueChanged;
            presenter.FilterListClear();
            presenter.DatagridRefresh(false);
        }
        private void comboBox_typeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_typeFilter.SelectedItem != null)
            {
                string selecteditem = comboBox_typeFilter.SelectedItem.ToString();
                string querystring = String.Format("AND `type` COLLATE utf8mb4_general_ci = '{0}'", selecteditem);
                presenter.DeleteCreateAddFilter("Type", selecteditem, querystring);
                presenter.DatagridRefresh(presenter.IsFiltered());
            }
        }
        private void comboBox_pageSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.SetPageNumber(Convert.ToInt32(comboBox_pageSelect.SelectedItem));
            presenter.DatagridRefresh(presenter.IsFiltered());
        }


        public void UpdateFont()
        {
            foreach (DataGridViewColumn c in dataGridView_transactions.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
            }
            for (int i = 0; i < dataGridView_transactions.Rows.Count; i++)
            {
                if (i % 2 == 0) dataGridView_transactions.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }
        public void DGVColumnsClear()
        {
            dataGridView_transactions.Columns.Clear();
        }
        public void DGVDataSource(List<Model.Transaction> alltransactions)
        {
            dataGridView_transactions.DataSource = alltransactions;
        }
        public int GetDGVRowCount()
        {
            int height = dataGridView_transactions.Height - dataGridView_transactions.ColumnHeadersHeight;
            int rowheight = dataGridView_transactions.RowTemplate.Height;
            int rowcount = height / rowheight;
            return rowcount;
        }
        
        

        private void button_edit_categorysub_list_Click(object sender, EventArgs e)
        {
            string table = "categories_income";
            string[] categoriesexpense = presenter.GetExpenseCategoryKeys();
            if (categoriesexpense.Contains(presenter.GetSelectedLBCatItem())) table = "categories_expense";
            if (presenter.GetSelectedLBSubcatItem() == null)
            {
                if (presenter.GetIfUserOwned(table, presenter.GetSelectedLBCatItem()))
                {
                    FormCategoryEdit ce = new FormCategoryEdit(presenter.GetSelectedLBCatItem(), "Category");
                    ce.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Default Categories can't be edited!", "Edit Error!", MessageBoxButtons.OK);
                }
            }
            else
            {
                if (presenter.GetIfUserOwned("subcategories_expense", presenter.GetSelectedLBSubcatItem()))
                {
                    FormCategoryEdit ce = new FormCategoryEdit(presenter.GetSelectedLBSubcatItem(), "Subcategory");
                    ce.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Default Subcategories can't be edited!", "Edit Error!", MessageBoxButtons.OK);
                }
            }
            presenter.LoadCategoryDicts();
            presenter.GetDefDictionaries();

            listBox_categories.Items.Clear();
            listBox_categories.Items.AddRange(presenter.GetCategoryKeys());

            comboBox_categoryFilter.Items.Clear();
            presenter.LoadComboboxItems(CategoriesFilterList, comboBox_categoryFilter);

            listBox_subcategories.Items.Clear();
            Dictionary<string, int> subcategories = presenter.GetSubcategories();
            listBox_subcategories.Items.AddRange(subcategories.Keys.ToArray());

            //listBox_categories.SelectedItem = presenter.GetSelectedLBCatItem();
        }

        private void button_delete_categorysub_list_Click(object sender, EventArgs e)
        {
            string categorydelete = "DELETE FROM `{0}` WHERE `{0}`.`user_id`={1} AND `{0}`.`name`='{2}'";
            string subcategorydelete = "DELETE FROM `subcategories_expense` WHERE `subcategories_expense`.`user_id`={0} AND `subcategories_expense`.`categories_expense_id`={1} AND `subcategories_expense`.`name`='{2}'";
            string query;
            string table = "categories_income";
            string[] categoriesexpense = presenter.GetExpenseCategoryKeys();
            if (categoriesexpense.Contains(presenter.GetSelectedLBCatItem())) table = "categories_expense";
            if (presenter.GetSelectedLBSubcatItem() == null)
            {
                if (presenter.GetIfUserOwned(table, presenter.GetSelectedLBCatItem()))
                {
                    query = String.Format(categorydelete, table, presenter.GetId(), presenter.GetSelectedLBCatItem());
                    presenter.DeleteCategory(query);
                }
                else
                {
                    MessageBox.Show("Default Categories can't be deleted!", "Delete Error!", MessageBoxButtons.OK);
                }
            }
            else
            {
                if (presenter.GetIfUserOwned("subcategories_expense", presenter.GetSelectedLBSubcatItem()))
                {
                    query = String.Format(subcategorydelete, presenter.GetId(), presenter.GetCategoryId(presenter.GetSelectedLBCatItem()), presenter.GetSelectedLBSubcatItem());
                    presenter.DeleteSubcategory(query);
                }
                else
                {
                    MessageBox.Show("Default Subcategories can't be deleted!", "Delete Error!", MessageBoxButtons.OK);
                }
            }
            presenter.LoadCategoryDicts();
            presenter.GetDefDictionaries();

            listBox_categories.Items.Clear();
            listBox_categories.Items.AddRange(presenter.GetCategoryKeys());

            comboBox_categoryFilter.Items.Clear();
            presenter.LoadComboboxItems(CategoriesFilterList, comboBox_categoryFilter);

            listBox_subcategories.Items.Clear();
            Dictionary<string, int> subcategories = presenter.GetSubcategories();
            listBox_subcategories.Items.AddRange(subcategories.Keys.ToArray());

            listBox_categories.SelectedItem = presenter.GetSelectedLBCatItem();
        }

        private void button_category_add_Click(object sender, EventArgs e)
        {
            if (Regex.Match(textBox_category_input.Text, "[A-Za-z]{5,}", RegexOptions.ECMAScript).Success)
            {
                presenter.AddCategory();
                textBox_category_input.Text = null;

                presenter.LoadCategoryDicts();
                presenter.GetDefDictionaries();

                listBox_categories.Items.Clear();
                listBox_categories.Items.AddRange(presenter.GetCategoryKeys());

                comboBox_categoryFilter.Items.Clear();
                presenter.LoadComboboxItems(CategoriesFilterList, comboBox_categoryFilter);
            }
            else
            {
                MessageBox.Show("Category must have a name of atleast 5 characters!", "Empty name error!", MessageBoxButtons.OK);
            }
            listBox_categories.SelectedItem = presenter.GetSelectedLBCatItem();
        }

        private void button_subcategory_add_Click(object sender, EventArgs e)
        {
            if (Regex.Match(textBox_subcategory_input.Text, "[A-Za-z]{5,}", RegexOptions.ECMAScript).Success)
            {
                presenter.AddSubcategory();
                textBox_subcategory_input.Text = null;

                listBox_subcategories.Items.Clear();
                Dictionary<string, int> subcategories = presenter.GetSubcategories();
                listBox_subcategories.Items.AddRange(subcategories.Keys.ToArray());
            }
            else
            {
                MessageBox.Show("Subcategory must have a name of atleast 5 characters!", "Empty name error!", MessageBoxButtons.OK);
            }
            listBox_categories.SelectedItem = presenter.GetSelectedLBCatItem();
        }

        private void comboBox_categoryFilter_DropDown(object sender, EventArgs e)
        {
            if (comboBox_categoryFilter.SelectedItem != null)
            {
                previtem = comboBox_categoryFilter.SelectedItem.ToString();
            }
        }

        private void button_settings_save_Click(object sender, EventArgs e)
        {
            if (textBox_settings_name.Text!="" && textBox_settings_name.Text.Length<=50)
            {
                tobecommited.Add(presenter.SetUsername);
            }
            else if(textBox_settings_name.Text != "")
            {
                MessageBox.Show("The Username can't be longer than 50 characters.", "Format Error!", MessageBoxButtons.OK);
            }

            if (textBox_settings_email.Text!="" && Regex.Match(textBox_settings_email.Text, "[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+[A-Za-z]{2,}", RegexOptions.ECMAScript).Success && textBox_settings_email.Text.Length<=64)
            {
                if (textBox_settings_password1.Text != "")
                {
                    MainPresenter.PasswordScore score = presenter.CheckStrength(textBox_settings_password1.Text);
                    if (score == MainPresenter.PasswordScore.Blank || score == MainPresenter.PasswordScore.VeryWeak || score == MainPresenter.PasswordScore.Weak)
                    {
                        MessageBox.Show("Weak password,\nPassword must be atleast \n  8 character long \nMust contain atleast:\n  1 lowercase character\n  1 uppercase character \n  1 number \n  1 special character", "Weak password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (textBox_settings_password1.Text == textBox_settings_password2.Text)
                        {
                            tobecommited.Add(presenter.SetEmail);
                            tobecommited.Add(presenter.SetNewPassword);
                        }
                        else
                        {
                            MessageBox.Show("Passwords must match!", "Matching error!", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Updating email requires password confirmation!", "Missing data!", MessageBoxButtons.OK);
                }
                
            }
            else if(textBox_settings_email.Text != "")
            {
                MessageBox.Show("Incorrect Email format.", "Format Error!", MessageBoxButtons.OK);
            }

            if (!tobecommited.Contains(presenter.SetNewPassword) && textBox_settings_password1.Text!="")
            {
                MainPresenter.PasswordScore score = presenter.CheckStrength(textBox_settings_password1.Text);
                if (score == MainPresenter.PasswordScore.Blank || score == MainPresenter.PasswordScore.VeryWeak || score == MainPresenter.PasswordScore.Weak)
                {
                    MessageBox.Show("Weak password,\nPassword must be atleast \n  8 character long \nMust contain atleast:\n  1 lowercase character\n  1 uppercase character \n  1 number \n  1 special character", "Weak password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (textBox_settings_password1.Text==textBox_settings_password2.Text)
                    {
                        tobecommited.Add(presenter.SetNewPassword);
                    }
                    else
                    {
                        MessageBox.Show("Passwords must match!", "Matching error!", MessageBoxButtons.OK);
                    }
                }
            }

            foreach (Action func in tobecommited)
            {
                func();
            }
            textBox_settings_name.Text = "";
            textBox_settings_email.Text = "";
            textBox_settings_password1.Text = "";
            textBox_settings_password2.Text = "";
            if (tobecommited.Count > 0) MessageBox.Show("User information updated succesfully!", "Changes saved!", MessageBoxButtons.OK);
            tobecommited = new List<Action>();

        }

        private void comboBox_settings_DefaultCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            tobecommited.AddRange(new Action[]{ presenter.SetDefCurrency, presenter.CalcSetBallance});
        }

        private void button_account_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete your account?\nAll data will be deleted permanently!", "Account Delete Confirmation!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                presenter.DeleteAccount();
                MessageBox.Show("Your account has been deleted, you will be logged out.","Account Deleted!",MessageBoxButtons.OK);
                Application.Restart();
            }

        }






        public void PageCountLocationX(int x)
        {
            label_pagecount.Location = new Point(x, 105);
        }
        private List<string> GetLBSubcategoriesItems()
        {
            List<string> list = new List<string>();
            foreach (var item in listBox_subcategories.Items)
            {
                list.Add(item.ToString());
            }
            return list;
        }
        private List<string> GetDGVColumns()
        {
            List<string> columns = new List<string>();
            foreach (var c in dataGridView_transactions.Columns)
            {
                columns.Add(c.ToString());
            }
            return columns;
        }
        public void SetPageSelectItems()
        {
            comboBox_pageSelect.Items.Clear();
            foreach (var item in pagelist)
            {
                comboBox_pageSelect.Items.Add(item);
            }
            comboBox_pageSelect.SelectedIndexChanged -= comboBox_pageSelect_SelectedIndexChanged;
            comboBox_pageSelect.SelectedIndex = 0;
            comboBox_pageSelect.SelectedIndexChanged += comboBox_pageSelect_SelectedIndexChanged;

        }
        public string GetNewDefCurrency()
        {
            return comboBox_settings_DefaultCurrency.SelectedItem.ToString();
        }
        public int GetPage()
        {
            return Convert.ToInt32(comboBox_pageSelect.SelectedItem.ToString());
        }
        public void SetPage(int v)
        {
            comboBox_pageSelect.SelectedIndexChanged -= comboBox_pageSelect_SelectedIndexChanged;
            comboBox_pageSelect.SelectedItem = v;
            comboBox_pageSelect.SelectedIndexChanged += comboBox_pageSelect_SelectedIndexChanged;
        }
        public void SetChartsView()
        {
            presenter.SetChartDatasources(chart_monthly_breakdown);
            SetCharts();
        }
<<<<<<< HEAD

        private void button_logout_Click(object sender, EventArgs e) {
            presenter.Logout();
        }
=======
>>>>>>> f44819e0f87d828157da147546975710db0d0ea5
    }
}
