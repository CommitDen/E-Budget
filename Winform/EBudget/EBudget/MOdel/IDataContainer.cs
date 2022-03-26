using System.Collections.Generic;
using System.Windows.Forms;

namespace EBudget.Model
{
    internal interface IDataContainer
    {
        Transaction T { get; set; }
        int Id { get; set; }
        string Def_Currency { get; set; }
        Dictionary<string, int> Currencies { get; set; }
        Dictionary<string, int> Categories { get; set; }
        Dictionary<string, int> CategoriesExpense { get; set; }
        Dictionary<string, int> CategoriesIncome { get; set; }
        Dictionary<string, int> Subcategories { get; set; }
        List<Transaction> Incomes { get; set; }
        List<Transaction> Expenses { get; set; }
        List<Transaction> Alltransactions { get; set; }
        List<string> TransactionTableHeader { get; set; }
        string CurrentSortColumn { get; set; }
        SortOrder CurrentSortOrder { get; set; }
        List<QueryFilter> QueryFilters { get; set; }
        int CurrentPage { get; set; }
        string LBCatSelectedItem { get; set; }
        string LBSubcatSelectedItem { get; set; }
    }
}
