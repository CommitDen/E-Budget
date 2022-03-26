using EBudget.Model;
using EBudget.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EBudget.Presenter
{
    class TransInputPresenter
    {
        int cat_id;
        int sub_cat_id;
        double value;
        int currency_id;
        string date;
        string comment;

        private IFormTransInput view;
        private IDataContainer data = new DataContainer();

        public TransInputPresenter(IFormTransInput view)
        {
            this.view = view;
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
            if (data.CategoriesExpense.ContainsKey(view.CategoryName))
            {
                int cat_id = data.CategoriesExpense[view.CategoryName];
                string query = String.Format("SELECT s.id, s.name FROM subcategories_expense AS s INNER JOIN categories_expense AS c ON s.categories_expense_id=c.id WHERE (c.user_id='{0}' OR c.user_id IS NULL) AND s.categories_expense_id='{1}'", data.Id, cat_id);
                MySqlCommand cmd = c.Cmd(query);
                data.Subcategories = c.ReturnDictionary(cmd);
                c.Close();
                return data.Subcategories;
            }
            c.Close();
            return new Dictionary<string, int>();
        }
        internal void GetDefDictionaries()
        {
            view.DefCurrency = data.Def_Currency;
            view.Categories = data.Categories;
            view.Currencies = data.Currencies;
        }
        internal void GetCatId(string category_name)
        {
            if (data.CategoriesExpense.ContainsKey(category_name))
            {
                cat_id = data.CategoriesExpense[category_name];
            }
            else
            {
                cat_id = data.CategoriesIncome[category_name];
            }
        }
        internal void AddTransaction()
        {
            bool datacheck;
            if (data.CategoriesExpense.ContainsKey(view.CategoryName)) datacheck = TransExpense();
            else datacheck = TransIncome();


            Connection c = new Connection();
            c.Connect();
            DialogResult result = DialogResult.None;
            if (datacheck)
            {
                if (data.CategoriesExpense.ContainsKey(view.CategoryName))
                {
                    if (data.T == null) AddNewTrans(c, "transactions_expense");
                    else
                    {
                        if (CheckIfSameType(data.T.Category, view.CategoryName)) UpdateExistingTrans(c, "transactions_expense");
                        else
                        {
                            result = MessageBox.Show("Can't assign an income type category to an expense type transaction!", "Type error!");
                        }
                    }
                }
                else
                {
                    if (data.T == null) AddNewTrans(c, "transactions_income");
                    else
                    {
                        if (CheckIfSameType(data.T.Category, view.CategoryName)) UpdateExistingTrans(c, "transactions_income");
                        else
                        {
                            result = MessageBox.Show("Can't assign an expense type category to an income type transaction!", "Type error!");
                        }
                    }
                }
            }
            c.Close();

        }
        private bool CheckIfSameType(string categoryold, string categorynew)
        {
            bool type = false;
            if (data.CategoriesExpense.ContainsKey(categoryold)) type = true;
            if (type)
            {
                if (data.CategoriesExpense.ContainsKey(categoryold) && data.CategoriesExpense.ContainsKey(categorynew)) return true;
            }
            else
            {
                if (data.CategoriesIncome.ContainsKey(categoryold) && data.CategoriesIncome.ContainsKey(categorynew)) return true;
            }
            return false;
        }
        internal bool CheckIfTypeExpense(string v)
        {
            return data.CategoriesExpense.ContainsKey(v);
        }
        private bool TransIncome()
        {
            try
            {
                string valuetext = view.Amount.ToString().Replace(".", ",");
                currency_id = data.Currencies[view.Currency.ToString().ToUpper()];
                value = Convert.ToDouble(valuetext);
                date = view.Date.ToString("yyyy-MM-dd");
                comment = view.Comment;
                return true;
            }
            catch (Exception)
            {
                string message = "Missing data!";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return false;
            }
        }
        private bool TransExpense()
        {
            try
            {
                string valuetext = view.Amount.ToString().Replace(".", ",");
                sub_cat_id = data.Subcategories[view.SubcategoryName];
                currency_id = data.Currencies[view.Currency.ToUpper()];
                value = Convert.ToDouble(valuetext);
                date = view.Date.ToString("yyyy-MM-dd");
                comment = view.Comment;
                return true;
            }
            catch (Exception)
            {
                string message = "Missing data!";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return false;
            }
        }
        private void UpdateExistingTrans(Connection c, string table)
        {
            string query = "";
            string cat_sup = "";
            if (table == "transactions_expense")
            {
                cat_sup = "_expense";
                query = String.Format("UPDATE {8} SET `date`='{1}', `categories{9}_id` = '{2}', `subcategories{9}_id`='{3}', `amount` = '{4}', `comment` = '{5}', `currency_id` = '{6}' WHERE {8}.`id` = '{0}' AND {8}.`user_id`='{7}';", data.T.Trans_id, date, cat_id, sub_cat_id, value.ToString().Replace(",", "."), comment, currency_id, data.Id, table, cat_sup);
            }
            else
            {
                cat_sup = "_income";
                query = String.Format("UPDATE {7} SET `date`='{1}', `categories{8}_id` = '{2}', `subcategories{8}_id`= NULL, `amount` = '{3}', `comment` = '{4}', `currency_id` = '{5}' WHERE {7}.`id` = '{0}' AND {7}.`user_id`='{6}';", data.T.Trans_id, date, cat_id, value.ToString().Replace(",", "."), comment, currency_id, data.Id, table, cat_sup);
            }


            MySqlCommand cmd = c.Cmd(query);

            try
            {
                c.NonQuery(cmd);
            }
            catch (Exception)
            {

                string message = "Sql ERROR!";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
        }
        private void AddNewTrans(Connection c, string table)
        {
            string query = "";
            if (view.SubcategoryName is null)
            {
                query = String.Format("INSERT INTO {6} VALUES (NULL, '{0}', '{1}', '{2}', NULL, '{3}', '{4}', '{5}');", data.Id, date, cat_id, value.ToString().Replace(",", "."), currency_id, comment, table);
            }
            else
            {
                query = String.Format("INSERT INTO {7} VALUES (NULL, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');", data.Id, date, cat_id, sub_cat_id, value.ToString().Replace(",", "."), currency_id, comment, table);
            }
            MySqlCommand cmd = c.Cmd(query);
            try
            {
                c.NonQuery(cmd);
            }
            catch (Exception)
            {

                string message = "Sql ERROR!";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }

        }
    }
}
