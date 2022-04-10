using EBudget.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EBudget.View.TransInput
{
    public partial class FormTransInput : Form, IFormTransInput
    {
        Model.Transaction T = null;

        string def_currency;
        TransInputPresenter presenter;
        Dictionary<string, int> categories = new Dictionary<string, int>();
        Dictionary<string, int> subcategories = new Dictionary<string, int>();
        Dictionary<string, int> currencies = new Dictionary<string, int>();
        //Dictionary<string, int> categoriesExpense = new Dictionary<string, int>();
        //Dictionary<string, int> categoriesIncome = new Dictionary<string, int>();


        public string CategoryName { get => comboBox_categories.SelectedItem.ToString(); set => comboBox_categories.SelectedItem = value; }
        public string SubcategoryName { get => ReturnSubcategory(); set => comboBox_subcategories.SelectedItem = value; }
        public double Amount { get => Convert.ToDouble(textBox_amount.Text.Replace(".", ",")); set => textBox_amount.Text = value.ToString(); }
        public string Currency { get => comboBox_currency.SelectedItem.ToString(); set => comboBox_currency.SelectedItem = value; }
        public DateTime Date { get => new DateTime(dateTimePicker_trans_date.Value.Year, dateTimePicker_trans_date.Value.Month, dateTimePicker_trans_date.Value.Day, 0, 0, 0); set => dateTimePicker_trans_date.Value = value; }
        public string Comment { get => richTextBox_comment.Text; set => richTextBox_comment.Text = value; }
        public Dictionary<string, int> Categories { get => categories; set => categories = value; }
        public Dictionary<string, int> Subcategories { get => subcategories; set => subcategories = value; }
        public Dictionary<string, int> Currencies { get => currencies; set => currencies = value; }
        public string DefCurrency { get => def_currency; set => def_currency = value; }

        //public Dictionary<string, int> CategoriesExpense { get => categoriesExpense; set => categoriesExpense = value; }
        //public Dictionary<string, int> CategoriesIncome { get => categoriesIncome; set => categoriesIncome = value; }


        public FormTransInput()
        {
            InitializeComponent();
            presenter = new TransInputPresenter(this);
            presenter.GetDefDictionaries();
            presenter.LoadComboboxItems(categories, comboBox_categories);
            presenter.LoadCBCurrencyItems(comboBox_currency);
            comboBox_currency.SelectedItem = def_currency;
            dateTimePicker_trans_date.Value = DateTime.Now;
        }
        public FormTransInput(Model.Transaction t)
        {
            InitializeComponent();
            presenter = new TransInputPresenter(this);
            presenter.GetDefDictionaries();
            presenter.LoadComboboxItems(categories, comboBox_categories);
            presenter.LoadCBCurrencyItems(comboBox_currency);
            T = t;
            comboBox_categories.SelectedItem = T.Category;
            comboBox_subcategories.SelectedIndex = Convert.ToInt32(subcategories.Keys.ToList().IndexOf(T.Subcategory));
            comboBox_currency.SelectedItem = T.Currency;
            textBox_amount.Text = T.Amount.ToString();
            richTextBox_comment.Text = T.Comment;
            dateTimePicker_trans_date.Value = T.Date;
            button_add.Text = "Update";
        }
        private void Form_trans_input_Load(object sender, EventArgs e)
        {

        }
        private string ReturnSubcategory()
        {
            if (comboBox_subcategories.SelectedItem is null)
            {
                return null;
            }
            else return comboBox_subcategories.SelectedItem.ToString();
        }
        private void comboBox_categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.GetCatId(comboBox_categories.SelectedItem.ToString());
            comboBox_subcategories.Items.Clear();
            comboBox_subcategories.SelectedItem = null;
            comboBox_subcategories.Text = "";
            if (presenter.CheckIfTypeExpense(comboBox_categories.SelectedItem.ToString())) comboBox_subcategories.Enabled = true;
            else comboBox_subcategories.Enabled = false;
            subcategories = presenter.ComboBoxSubcategoriesRefresh();
            presenter.LoadComboboxItems(subcategories, comboBox_subcategories);
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            if (comboBox_categories.SelectedItem!=null && comboBox_subcategories.SelectedItem!=null) {
                presenter.AddTransaction();
                this.Close();
            } else {
                MessageBox.Show("Missing data!", "Error", MessageBoxButtons.OK);
            }
           
        }


    }
}
