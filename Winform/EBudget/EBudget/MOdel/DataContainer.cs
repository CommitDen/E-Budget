using System.Collections.Generic;
using System.Windows.Forms;

namespace EBudget.Model
{
    class DataContainer : IDataContainer
    {
        private static Transaction t { get; set; }
        Transaction IDataContainer.T { get => t; set => t = value; }

        private static int id { get; set; }
        int IDataContainer.Id { get => id; set => id = value; }

        private static string def_currency { get; set; }
        string IDataContainer.Def_Currency { get => def_currency; set => def_currency = value; }

        private static Dictionary<string, int> currency { get; set; }
        Dictionary<string, int> IDataContainer.Currencies { get => currency; set => currency = value; }

        private static Dictionary<string, int> categories { get; set; }
        Dictionary<string, int> IDataContainer.Categories { get => categories; set => categories = value; }

        private static Dictionary<string, int> categories_expense { get; set; }
        Dictionary<string, int> IDataContainer.CategoriesExpense { get => categories_expense; set => categories_expense = value; }

        private static Dictionary<string, int> categories_income { get; set; }
        Dictionary<string, int> IDataContainer.CategoriesIncome { get => categories_income; set => categories_income = value; }

        private static Dictionary<string, int> subcategories { get; set; }
        Dictionary<string, int> IDataContainer.Subcategories { get => subcategories; set => subcategories = value; }

        private static List<Transaction> incomes { get; set; }
        List<Transaction> IDataContainer.Incomes { get => incomes; set => incomes = value; }

        private static List<Transaction> expenses { get; set; }
        List<Transaction> IDataContainer.Expenses { get => expenses; set => expenses = value; }

        private static List<Transaction> alltransactions { get; set; }
        List<Transaction> IDataContainer.Alltransactions { get => alltransactions; set => alltransactions = value; }

        private static List<string> transaction_table_header { get; set; }
        List<string> IDataContainer.TransactionTableHeader { get => transaction_table_header; set => transaction_table_header = value; }

        private static string currrent_sort_column { get; set; }
        string IDataContainer.CurrentSortColumn { get => currrent_sort_column; set => currrent_sort_column = value; }

        private static SortOrder current_sort_order { get; set; }
        SortOrder IDataContainer.CurrentSortOrder { get => current_sort_order; set => current_sort_order = value; }

        private static List<QueryFilter> query_filters { get; set; }
        public List<QueryFilter> QueryFilters { get => query_filters; set => query_filters = value; }

        private static int current_page { get; set; }
        public int CurrentPage { get => current_page; set => current_page = value; }

        private static string lbcatselecteditem { get; set; }
        public string LBCatSelectedItem { get => lbcatselecteditem; set => lbcatselecteditem = value; }

        private static string lbsubcatselecteditem { get; set; }
        public string LBSubcatSelectedItem { get => lbsubcatselecteditem; set => lbsubcatselecteditem = value; }
    }
}
