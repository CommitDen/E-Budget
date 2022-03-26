using System;
using System.Collections.Generic;

namespace EBudget.View
{
    interface IFormTransInput
    {
        string CategoryName { get; set; }
        string SubcategoryName { get; set; }
        double Amount { get; set; }
        string Currency { get; set; }
        DateTime Date { get; set; }
        string Comment { get; set; }
        string DefCurrency { get; set; }

        Dictionary<string, int> Categories { get; set; }
        Dictionary<string, int> Subcategories { get; set; }
        Dictionary<string, int> Currencies { get; set; }
        //Dictionary<string, int> CategoriesExpense { get; set; }
        //Dictionary<string, int> CategoriesIncome { get; set; }
    }
}
