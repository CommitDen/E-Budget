using EBudget.Model;
using EBudget.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EBudget.Presenter
{
    public class MainPresenter
    {
        private IFormMain view;
        private IDataContainer data = new DataContainer();

        public MainPresenter(IFormMain view)
        {
            this.view = view;
            data.QueryFilters = new List<QueryFilter>();
            data.CurrentPage = 1;
        }

        #region Budget
        public void SetId(int id)
        {
            data.Id = id;
        }
        public void SetPageNumber(int i)
        {
            data.CurrentPage = i;
        }
        public void SetPageList()
        {
            int rowcount = view.GetDGVRowCount();
            List<int> pagelist = new List<int>();
            if (rowcount > data.Alltransactions.Count)
            {
                view.PageList = new List<int>() { 1 };
                view.SetPage(1);
                view.PageCount = "Page: 1 / ";
            }
            else
            {
                int page = (int)Math.Ceiling((double)data.Alltransactions.Count / (double)rowcount);
                for (int i = 1; i <= page; i++)
                {
                    pagelist.Add(i);
                }
                view.PageList = pagelist;
                view.PageCount = "Page: " + pagelist.Count.ToString() + " / ";
            }
            view.PageCountLocationX(view.PageSelectLocationX - view.PageCountWidth);
        }
        public void SetCurrentPage(int i)
        {
            if (data.CurrentPage > view.PageList.Count) {view.SetPage(1); data.CurrentPage = 1;}
            int page = data.CurrentPage;
            int rowcount = view.GetDGVRowCount();
            if (rowcount > data.Alltransactions.Count) rowcount = data.Alltransactions.Count;
            int x = (page - 1) * rowcount;
            int y = rowcount;
            if (y > data.Alltransactions.Count - x) y = data.Alltransactions.Count - x;
            view.DGVDataSource(data.Alltransactions.GetRange(x, y));
            view.SetPage(data.CurrentPage);
        }
        public string GetDefCurrency()
        {
            Connection c = new Connection();
            c.ReturnDeffaultCurrency();
            return data.Def_Currency;
        }
        public string[] GetCategoryKeys()
        {
            return data.Categories.Keys.ToArray();
        }
        public string QueryStringBuilder(bool filtered)
        {
            string queryfromview = String.Format("SELECT * FROM `view_alltransactions` WHERE `UserId`= {0} ", data.Id);

            if (filtered)
            {
                foreach (QueryFilter filter in data.QueryFilters)
                {
                    queryfromview += " " + filter.Querystring;
                }
                return queryfromview;
            }
            return queryfromview;
        }
        public void DatagridRefresh(bool filtered)
        {
            string query = QueryStringBuilder(filtered);
            GetAllTransactions(query);

            SetPageList();
            view.SetPageSelectItems();

            SetCurrentPage(data.CurrentPage);

            CalcSetBallance();

            Sort(data.CurrentSortColumn, data.CurrentSortOrder);
            view.UpdateFont();

            view.SetChartsView();
        }
        public void DeleteCreateAddFilter(string name, string item, string querystring) {
            data.QueryFilters = data.QueryFilters.Select(x => x).Where(x => x.Name != name).ToList();
            QueryFilter filter;
            QueryFilter.InOrEx inorex;
            switch (name) {
                case "Category":
                    if (IsExpense(item)) inorex = QueryFilter.InOrEx.Expense;
                    else inorex = QueryFilter.InOrEx.Income;
                    filter = new QueryFilter("Category", inorex, querystring);
                    break;
                case "Subcategory":
                    filter = new QueryFilter("Subcategory", QueryFilter.InOrEx.Expense, querystring);
                    break;
                default:
                    filter = new QueryFilter(name, QueryFilter.InOrEx.Both, querystring);
                    break;
            }
            data.QueryFilters.Add(filter);
        }
        public bool IsFiltered()
        {
            if (data.QueryFilters.Count > 0) return true;
            return false;
        }
        public void CalcSetBallance()
        {
            Connection c = new Connection();
            c.Connect();
            string queryfromview = String.Format("SELECT * FROM `view_alltransactions` WHERE `UserId`= {0} ", data.Id);
            List<Transaction> transactions = c.QueryTransactions(c.Cmd(queryfromview));
            double sum = 0;
            double rate;
            foreach (var t in transactions)
            {
                if (t.Currency == data.Def_Currency) rate = 1;
                else rate = Convert.ToDouble(new Exchangerate().CurrencyExchangeRate(t.Date, t.Currency, data.Def_Currency));
                if (t.Type == "income") sum += t.Amount * rate;
                else sum -= t.Amount * rate;
            }
            c.Close();
            CalcSetIncomeExpense();

            view.Ballance = "Balance: " + Math.Round(sum,2) + " " + data.Def_Currency[0].ToString().ToUpper() + data.Def_Currency[1].ToString().ToLower() + data.Def_Currency[2].ToString().ToLower();

        }
        public void CalcSetIncomeExpense()
        {
            Connection c = new Connection();
            c.Connect();
            double incomesum = 0;
            double expensesum = 0;
            double rate;
            bool filter;
            DateTime datefrom, dateto;
            filter = data.QueryFilters.Where(x => x.Name == "Date").Count() == 0 ? false : true;
            List<Transaction> transactions = c.QueryTransactions(c.Cmd(QueryStringBuilder(IsFiltered())));
            if (filter)
            {
                datefrom = view.DateFromFilter.AddDays(-1);
                dateto = new DateTime(view.DateToFilter.Year, view.DateToFilter.Month, view.DateToFilter.Day, 23, 59, 59);
            }
            else
            {
                datefrom = new DateTime(view.DateFromFilter.Year, view.DateFromFilter.Month, 1);
                dateto = new DateTime(view.DateToFilter.Year, view.DateToFilter.Month, DateTime.DaysInMonth(view.DateToFilter.Year, view.DateToFilter.Month), 23, 59, 59);
            }
            foreach (var t in transactions)
            {
                if (t.Date >= datefrom && t.Date <= dateto)
                {
                    if (t.Currency == data.Def_Currency) rate = 1;
                    else rate = Convert.ToDouble(new Exchangerate().CurrencyExchangeRate(t.Date, t.Currency, data.Def_Currency));
                    if (t.Type == "income") incomesum += t.Amount * rate;
                    else expensesum += t.Amount * rate;
                }
            }
            c.Close();
            view.TExpense = "Expense: " + Math.Round(expensesum) + " " + data.Def_Currency[0].ToString().ToUpper() + data.Def_Currency[1].ToString().ToLower() + data.Def_Currency[2].ToString().ToLower();
            view.TIncome = "Income: " + Math.Round(incomesum) + " " + data.Def_Currency[0].ToString().ToUpper() + data.Def_Currency[1].ToString().ToLower() + data.Def_Currency[2].ToString().ToLower();
        }
        public void LoadPageList(List<int> pagelist, ComboBox comboBox_pageSelect)
        {
            comboBox_pageSelect.Items.Clear();
            foreach (var page in pagelist)
            {
                comboBox_pageSelect.Items.Add(page);
            }
        }
        public void GetAllTransactions(string query)
        {
            Connection c = new Connection();
            c.Connect();
            MySqlCommand cmd = c.Cmd(query);
            data.Alltransactions = c.QueryAllTransactions(cmd).OrderByDescending(x => x.Date).ToList(); 
            foreach (var t in data.Alltransactions)
            {
                if (t.Type == "income")
                {
                    data.Incomes = new List<Transaction>();
                    data.Incomes.Add(t);
                }
                else
                {
                    data.Expenses = new List<Transaction>();
                    data.Expenses.Add(t);
                }
            }
            c.Close();
        }
        public Transaction SetT()
        {
            data.T = GetSelectedRow();
            return data.T;
        }
        public Transaction GetSelectedRow()
        {
            Transaction t = new Transaction(data.Alltransactions[view.SelectedRowIndex].Type, data.Alltransactions[view.SelectedRowIndex].Trans_id, view.SelectedCategory, view.SelectedSubcategory, view.SelectedAmount, view.SelectedCurrency, view.SelectedDate, view.SelectedComment);
            return t;
        }
        public void LoadCategoryDicts()
        {

            Connection c = new Connection();
            c.Connect();
            string query = String.Format("SELECT c.id, c.name FROM categories_income AS c, users WHERE users.id='{0}' OR users.id IS NULL", data.Id);
            MySqlCommand cmd = c.Cmd(query);
            data.CategoriesIncome = c.ReturnDictionary(cmd);
            data.CategoriesExpense = c.ReturnDictionary(c.Cmd(String.Format("SELECT c.id, c.name FROM categories_expense AS c, users WHERE users.id='{0}' OR users.id IS NULL", data.Id)));
            data.Categories = new Dictionary<string, int>();
            foreach (var cat in data.CategoriesExpense)
            {
                data.Categories.Add(cat.Key, cat.Value);
            }
            foreach (var cat in data.CategoriesIncome)
            {
                data.Categories.Add(cat.Key, cat.Value);
            }
            c.Close();
        }
        public void DeleteSelectedTransaction()
        {
            Connection c = new Connection();
            c.Connect();

            string query = "";
            if (data.CategoriesExpense.ContainsKey(data.Alltransactions[view.SelectedRowIndex].Category))
            {
                query = String.Format("DELETE FROM transactions_expense WHERE transactions_expense.id='{0}';", data.Alltransactions[view.SelectedRowIndex].Trans_id);
            }
            else
            {
                query = String.Format("DELETE FROM transactions_income WHERE transactions_income.id='{0}';", data.Alltransactions[view.SelectedRowIndex].Trans_id);
            }

            MySqlCommand cmd = c.Cmd(query);
            c.NonQuery(cmd);
            c.Close();
            DatagridRefresh(IsFiltered());
        }
        public void Sort(string column, SortOrder sortOrder)
        {
            switch (column)
            {
                case "Category":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            data.Alltransactions = data.Alltransactions.OrderBy(x => x.Category).ToList();
                            data.CurrentSortColumn = "Category";
                            data.CurrentSortOrder = SortOrder.Ascending;
                            SetCurrentPage(data.CurrentPage);
                        }
                        else
                        {
                            data.Alltransactions = data.Alltransactions.OrderByDescending(x => x.Category).ToList();
                            data.CurrentSortColumn = "Category";
                            data.CurrentSortOrder = SortOrder.Descending;
                            SetCurrentPage(data.CurrentPage);
                        }
                        break;
                    }
                case "Subcategory":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            data.Alltransactions = data.Alltransactions.OrderBy(x => x.Subcategory).ToList();
                            data.CurrentSortColumn = "Subcategory";
                            data.CurrentSortOrder = SortOrder.Ascending;
                            SetCurrentPage(data.CurrentPage);
                        }
                        else
                        {
                            data.Alltransactions = data.Alltransactions.OrderByDescending(x => x.Subcategory).ToList();
                            data.CurrentSortColumn = "Subcategory";
                            data.CurrentSortOrder = SortOrder.Descending;
                            SetCurrentPage(data.CurrentPage);
                        }
                        break;
                    }
                case "Amount":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            data.Alltransactions = data.Alltransactions.OrderBy(x => x.Amount).ToList();
                            data.CurrentSortColumn = "Amount";
                            data.CurrentSortOrder = SortOrder.Ascending;
                            SetCurrentPage(data.CurrentPage);
                        }
                        else
                        {
                            data.Alltransactions = data.Alltransactions.OrderByDescending(x => x.Amount).ToList();
                            data.CurrentSortColumn = "Amount";
                            data.CurrentSortOrder = SortOrder.Descending;
                            SetCurrentPage(data.CurrentPage);
                        }
                        break;
                    }
                case "Currency":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            data.Alltransactions = data.Alltransactions.OrderBy(x => x.Currency).ToList();
                            data.CurrentSortColumn = "Currency";
                            data.CurrentSortOrder = SortOrder.Ascending;
                            SetCurrentPage(data.CurrentPage);
                        }
                        else
                        {
                            data.Alltransactions = data.Alltransactions.OrderByDescending(x => x.Currency).ToList();
                            data.CurrentSortColumn = "Currency";
                            data.CurrentSortOrder = SortOrder.Descending;
                            SetCurrentPage(data.CurrentPage);
                        }
                        break;
                    }
                case "Date":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            data.Alltransactions = data.Alltransactions.OrderBy(x => x.Date).ToList();
                            data.CurrentSortColumn = "Date";
                            data.CurrentSortOrder = SortOrder.Ascending;
                            SetCurrentPage(data.CurrentPage);
                        }
                        else
                        {
                            data.Alltransactions = data.Alltransactions.OrderByDescending(x => x.Date).ToList();
                            data.CurrentSortColumn = "Date";
                            data.CurrentSortOrder = SortOrder.Descending;
                            SetCurrentPage(data.CurrentPage);
                        }
                        break;
                    }
                case "Comment":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            data.Alltransactions = data.Alltransactions.OrderBy(x => x.Comment).ToList();
                            data.CurrentSortColumn = "Comment";
                            data.CurrentSortOrder = SortOrder.Ascending;
                            SetCurrentPage(data.CurrentPage);
                        }
                        else
                        {
                            data.Alltransactions = data.Alltransactions.OrderByDescending(x => x.Comment).ToList();
                            data.CurrentSortColumn = "Comment";
                            data.CurrentSortOrder = SortOrder.Descending;
                            SetCurrentPage(data.CurrentPage);
                        }
                        break;
                    }
            }
            view.UpdateFont();
        }
        public void FilterListClear()
        {
            data.QueryFilters = new List<QueryFilter>();
        }
        public bool IsExpense(string categoryname)
        {
            if (data.CategoriesExpense.ContainsKey(categoryname)) return true;
            return false;
        }
        public void LoadComboboxItems(Dictionary<string, int> dic, ComboBox cb)
        {
            foreach (var item in dic)
            {
                cb.Items.Add(item.Key);
            }
        }
        public void LoadCBCurrencyItems(ComboBox cb)
        {
            foreach (var item in data.Currencies)
            {
                cb.Items.Add(item.Key.ToUpper());
            }
        }
        public Dictionary<string, int> ComboBoxSubcategoriesRefresh()
        {
            Connection c = new Connection();
            c.Connect();
            if (data.CategoriesExpense.ContainsKey(view.CategoryFilter))
            {
                int cat_id = data.CategoriesExpense[view.CategoryFilter];
                string query = String.Format("SELECT s.id, s.name FROM subcategories_expense AS s INNER JOIN categories_expense AS c ON s.categories_expense_id=c.id WHERE (c.user_id='{0}' OR c.user_id IS NULL) AND s.categories_expense_id='{1}'", data.Id, cat_id);
                MySqlCommand cmd = c.Cmd(query);
                data.Subcategories = c.ReturnDictionary(cmd);
                c.Close();
                return data.Subcategories;
            }
            c.Close();
            return new Dictionary<string, int>();
        }
        public void GetDefDictionaries()
        {
            //view.DefCurrency = data.Def_Currency;
            view.CategoriesFilterList = data.Categories;
            view.CurrenciesFilterList = data.Currencies;
        }
        #endregion
        #region Categories
        public Dictionary<string, int> GetSubcategories()
        {
            Dictionary<string, int> subcategory_listbox_ds = new Dictionary<string, int>();
            if (data.CategoriesExpense.ContainsKey(GetSelectedLBCatItem()))
            {
                int category_id = data.Categories[GetSelectedLBCatItem()];
                Connection c = new Connection();
                c.Connect();
                subcategory_listbox_ds = c.ReturnSubcategoriesOfCategory(category_id);
                c.Close();
            }
            return subcategory_listbox_ds;
        }
        public void AddCategory()
        {
            string category = view.LBAddCategory;
            string table = "categories_expense";
            if (data.Categories.ContainsKey(view.LBAddCategory))
            {
                MessageBox.Show("Category already exists.", "Duplicate error!", MessageBoxButtons.OK);
            }
            else
            {
                if (!view.RBExpense) table = "categories_income";
                Connection c = new Connection();
                c.Connect();
                c.NonQuery(c.Cmd(String.Format("INSERT INTO `{0}` VALUE (NULL, '{1}', {2});", table, category, data.Id)));
                c.Close();
            }
        }
        public int GetId()
        {
            return data.Id;
        }
        public void DeleteCategory(string query)
        {
            Connection c = new Connection();
            c.Connect();
            c.NonQuery(c.Cmd(query));
            c.Close();
        }
        public bool GetIfUserOwned(string table, string name)
        {
            Connection c = new Connection();
            bool result = c.IsUserOwned(table, name);
            return result;
        }
        public string[] GetExpenseCategoryKeys()
        {
            return data.CategoriesExpense.Keys.ToArray();
        }
        public int GetCategoryId(string v)
        {
            int id = 0;
            if (data.CategoriesIncome.ContainsKey(v)) id = data.CategoriesIncome[v];
            else if (data.CategoriesExpense.ContainsKey(v)) id = data.CategoriesExpense[v];
            return id;
        }
        public void DeleteSubcategory(string query)
        {
            Connection c = new Connection();
            c.Connect();
            c.NonQuery(c.Cmd(query));
            c.Close();
        }
        public void AddSubcategory()
        {
            string subcategory = view.LBAddSubcategory;
            string table = "subcategories_expense";
            if (view.LBSubcategoriesItems.Contains(subcategory))
            {
                MessageBox.Show("Subcategory already exists.", "Duplicate error!", MessageBoxButtons.OK);
            }
            else
            {
                Connection c = new Connection();
                c.Connect();
                c.NonQuery(c.Cmd(String.Format("INSERT INTO `{0}` VALUE (NULL, '{1}', {2}, {3});", table, subcategory, GetCategoryId(GetSelectedLBCatItem()), data.Id)));
                c.Close();
            }
        }
        public void SaveSelectedLBCatItem()
        {
            data.LBCatSelectedItem = view.LBSelectedCategory;
        }
        public string GetSelectedLBCatItem()
        {
            return data.LBCatSelectedItem;
        }
        public void SaveSelectedLBSubcatItem()
        {
            data.LBSubcatSelectedItem = view.LBSelectedSubcategory;
        }
        public string GetSelectedLBSubcatItem()
        {
            return data.LBSubcatSelectedItem;
        }
        internal void DeleteSelectedLBSubCatItem()
        {
            data.LBSubcatSelectedItem = null;
        }
        #endregion
        #region Reports
        public void SetMonthlyExpenseDataSource()
        {
            
            string query = String.Format("SELECT `Category`, SUM(`Amount`) AS 'Amount' FROM `view_alltransactions` WHERE `view_alltransactions`.`type`COLLATE utf8mb4_unicode_ci ='expense' AND `view_alltransactions`.`date` BETWEEN '{0}' AND '{1}' GROUP BY `Category`;",view.DateFromFilter.ToString("yyyy-MM-dd"),view.DateToFilter.ToString("yyyy-MM-dd"));
            
            Connection c = new Connection();
            
            DataTable dt = c.GetData(query);

            if (dt.Rows.Count==0)
            {
                query = String.Format("SELECT `Category`, SUM(`Amount`) AS 'Amount' FROM `view_alltransactions` WHERE `view_alltransactions`.`type`COLLATE utf8mb4_unicode_ci ='expense' AND `view_alltransactions`.`date` BETWEEN '{0}' AND '{1}' GROUP BY `Category`;", view.DateFromFilter.AddMonths(-1).ToString("yyyy-MM-dd"), view.DateToFilter.AddMonths(-1).ToString("yyyy-MM-dd"));

                c = new Connection();

                dt = c.GetData(query);
            }

            
            string[] x = (from p in dt.AsEnumerable()
                          orderby p.Field<string>("Category") ascending
                          select p.Field<string>("Category")).ToArray();

            
            double[] y = (from p in dt.AsEnumerable()
                       orderby p.Field<string>("Category") ascending
                       select p.Field<double>("Amount")).ToArray();

            view.Chart_monthly_expense_breakdown_categories = x.ToList();
            view.Chart_monthly_expense_breakdown_amounts = y.ToList();
        }
        public void SetYearlyExpenseIncomeDataSource()
        {
            string query = String.Format("SELECT `view_alltransactions`.`type`, SUM(`view_alltransactions`.`Amount`) AS 'Amount' FROM `view_alltransactions` WHERE `view_alltransactions`.`date` BETWEEN '{0}' AND '{1}' GROUP BY `type`;", new DateTime(DateTime.Now.Year, 01,01,0,0,0).ToString("yyyy-MM-dd"), new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59).ToString("yyyy-MM-dd"));

            Connection c = new Connection();

            DataTable dt = c.GetData(query);


            string[] x = (from p in dt.AsEnumerable()
                          orderby p.Field<string>("type") ascending
                          select p.Field<string>("type")).ToArray();


            double[] y = (from p in dt.AsEnumerable()
                          orderby p.Field<string>("type") ascending
                          select p.Field<double>("Amount")).ToArray();

            view.Chart_yearly_expense_income_categories = x.ToList();
            view.Chart_yearly_expense_income_amounts = y.ToList();
            
        }
        Dictionary<string, string> months = new Dictionary<string, string>()
{
                { "January", "01"},
                { "February", "02"},
                { "March", "03"},
                { "April", "04"},
                { "May", "05"},
                { "June", "06"},
                { "July", "07"},
                { "August", "08"},
                { "September", "09"},
                { "October", "10"},
                { "November", "11"},
                { "December", "12"},
        };
        public void SetMonthlyBreakdownIncomeExpense(Chart Chart1)
        {
            string query = String.Format("SELECT view_alltransactions.type, MONTHNAME(view_alltransactions.Date) AS 'Month', SUM(view_alltransactions.Amount) AS 'Amount' FROM view_alltransactions WHERE view_alltransactions.Date BETWEEN '{0}' AND '{1}' AND view_alltransactions.UserId={2} GROUP BY `view_alltransactions`.`type`, MONTHNAME(view_alltransactions.Date);", new DateTime(DateTime.Now.Year, 01, 01, 0, 0, 0).ToString("yyyy-MM-dd"), new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59).ToString("yyyy-MM-dd"), data.Id);

            Connection c = new Connection();

            DataTable dt = c.GetData(query);

            List<string> types = (from p in dt.AsEnumerable()
                                      select p.Field<string>("type")).Distinct().ToList();
            Chart1.Series.Clear();

            foreach (string type in types)
            {

                string[] x = (from p in dt.AsEnumerable()
                           where p.Field<string>("type") == type
                           orderby months[p.Field<string>("Month")] ascending
                           select p.Field<string>("Month")).ToArray();

                double[] y = (from p in dt.AsEnumerable()
                           where p.Field<string>("type") == type
                           orderby months[p.Field<string>("Month")] ascending
                           select p.Field<double>("Amount")).ToArray();

                Chart1.Series.Add(new Series(type));
                Chart1.Series[type].IsValueShownAsLabel = true;
                Chart1.Series[type].ChartType = SeriesChartType.Column;
                Chart1.Series[type].Points.DataBindXY(x, y);
            }

            Chart1.Legends[0].Enabled = true;
        }
        public void SetChartDatasources(Chart chart)
        {
            SetMonthlyExpenseDataSource();
            SetYearlyExpenseIncomeDataSource();
            SetMonthlyBreakdownIncomeExpense(chart);
        }
        #endregion
        #region Settings
        public void SetDefCurrency()
        {
            string newCurrency=view.GetNewDefCurrency().Replace("'", "''").Trim();
            if (data.Def_Currency != newCurrency)
            {
                Connection c = new Connection();
                c.Connect();
                c.NonQuery(c.Cmd(String.Format("UPDATE `users` SET `currency_id` = '{0}' WHERE `users`.`id` = {1};", data.Currencies[newCurrency], data.Id)));
                data.Def_Currency = newCurrency;
                c.Close();
            }
        }

        public void SetUsername()
        {
            string newUsername = view.NewName.Replace("'", "''").Trim();
            Connection c = new Connection();
            c.Connect();
            c.NonQuery(c.Cmd(String.Format("UPDATE `users` SET `name` = '{0}' WHERE `users`.`id` = {1};", newUsername, data.Id)));
            c.Close();
        }

        public void SetEmail()
        {
            string newEmail = view.NewEmail.Replace("'","''").Trim();
            Connection c = new Connection();
            c.Connect();
            c.NonQuery(c.Cmd(String.Format("UPDATE `users` SET `email` = '{0}' WHERE `users`.`id` = {1};", newEmail, data.Id)));
            c.Close();
        }

        public enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }
        public PasswordScore CheckStrength(string password)
        {
            int score = 0;

            if (password.Length < 1) return PasswordScore.Blank;
            if (password.Length < 4) return PasswordScore.VeryWeak;

            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, @"[a-z]", RegexOptions.ECMAScript).Success && Regex.Match(password, @"[A-Z]", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"[0-9]", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript).Success)
                score++;

            return (PasswordScore)score;
        }

        public void SetNewPassword()
        {
            string email = null;
            Connection c = new Connection();
            if (view.NewEmail=="" || view.NewEmail==null) email=c.GetEmailByUserId();
            else email=view.NewEmail;
            string newPass = view.NewPass.Replace("'", "''").Trim();
            string newHashkey = c.sha256_hash(newPass, c.CreateSalt(email));
            
            c.Connect();
            c.NonQuery(c.Cmd(String.Format("UPDATE `users` SET `password` = '{0}' WHERE `users`.`id` = {1};", newHashkey, data.Id)));
            c.Close();
        }

        public void DeleteAccount()
        {
            Connection c = new Connection();
            c.Connect();
            c.NonQuery(c.Cmd(String.Format("DELETE FROM `users` WHERE `users`.`id` = {0};",  data.Id)));
            c.NonQuery(c.Cmd(String.Format("DELETE FROM `categories_income` WHERE `categories_income`.`user_id` = {0};",  data.Id)));
            c.NonQuery(c.Cmd(String.Format("DELETE FROM `categories_expense` WHERE `categories_expense`.`user_id` = {0};", data.Id)));
            c.Close();
        }

        internal void Logout() {
            Application.Restart();
        }




        #endregion
    }
}
