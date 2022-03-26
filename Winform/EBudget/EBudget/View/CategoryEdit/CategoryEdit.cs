using EBudget.Presenter;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EBudget.View.CategoryEdit
{
    public partial class FormCategoryEdit : Form, ICategoryEdit
    {
        private CategoryEditPresenter presenter;

        public string NameLabel { set => label_name.Text = value; }
        public string NameForm { set => this.Text = value; }
        string ICategoryEdit.NameTB { get => textBox_name.Text; set => textBox_name.Text = value; }
        public string Type { set => type = value; }
        public string Table => table;
        public string OriginalName => original_name;

        string type;
        string table;
        string original_name;
        public FormCategoryEdit(string name, string type)
        {
            InitializeComponent();
            presenter = new CategoryEditPresenter(this);
            presenter.SetType(name, type);
            original_name = name;
            if (type == "Category")
            {
                if (presenter.IsExpense(name)) table = "categories_expense";
                else table = "categories_income";
            }
            else table = "subcategories_expense";
        }

        private void CategoryEdit_Load(object sender, EventArgs e)
        {

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox_name.Text, "[A-Za-z]{5,}", RegexOptions.ECMAScript).Success)
            {
                MessageBox.Show(type + " name must be atleast 5 characters long!", "Invalid name!", MessageBoxButtons.OK);
            }
            else
            {
                if (original_name == textBox_name.Text)
                {
                    MessageBox.Show("New name of the " + type + " can't be the same as the original!", "Invalid " + type + " name!", MessageBoxButtons.OK);
                }
                else if (presenter.CheckIfExists(table, textBox_name.Text))
                {
                    MessageBox.Show("This " + type + " name already exists!", "Duplicate error!", MessageBoxButtons.OK);
                }
                else
                {
                    presenter.EditCategory();
                    this.Close();
                }
            }
        }
    }
}
