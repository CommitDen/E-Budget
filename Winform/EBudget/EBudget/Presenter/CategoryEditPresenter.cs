using EBudget.Model;
using EBudget.View.CategoryEdit;
using System;

namespace EBudget.Presenter
{

    internal class CategoryEditPresenter
    {
        private ICategoryEdit view;
        private IDataContainer data = new DataContainer();

        public CategoryEditPresenter(ICategoryEdit view)
        {
            this.view = view;
        }

        internal void SetType(string name, string type)
        {
            view.NameLabel = type + " name:";
            view.NameForm = type + " edit";
            view.NameTB = name;
            view.Type = type;
        }

        internal bool CheckIfExists(string table, string name)
        {
            Connection c = new Connection();
            bool result = c.CheckIfExists(table, name);
            return result;
        }
        public bool IsExpense(string categoryname)
        {
            if (data.CategoriesExpense.ContainsKey(categoryname)) return true;
            return false;
        }

        internal void EditCategory()
        {
            Connection c = new Connection();
            c.Connect();
            c.NonQuery(c.Cmd(String.Format("UPDATE `{1}` SET `{1}`.`name`='{2}' WHERE `{1}`.`name` = '{3}' AND {1}.`user_id`='{0}';", data.Id, view.Table, view.NameTB, view.OriginalName)));
            c.Close();
        }
    }

}
