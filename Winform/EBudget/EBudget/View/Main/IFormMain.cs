using System;
using System.Collections.Generic;

namespace EBudget.View
{
    public interface IFormMain
    {
        #region Budget Components
        string Ballance { set; }
        string TIncome { set; }
        string TExpense { set; }
        List<Model.Transaction> Transactions { set; }
        string SelectedCategory { get; }
        string SelectedSubcategory { get; }
        double SelectedAmount { get; }
        string SelectedCurrency { get; }
        DateTime SelectedDate { get; }
        string SelectedComment { get; }
        int SelectedRowIndex { get; }
        List<string> Columns { get; }
        void UpdateFont();
        void DGVColumnsClear();
        void DGVDataSource(List<Model.Transaction> alltransactions);
        Dictionary<string, int> CategoriesFilterList { get; set; }
        string CategoryFilter { get; }
        Dictionary<string, int> SubcategoriesFilterList { get; set; }
        string SubcategoryFilter { get; }
        Dictionary<string, int> CurrenciesFilterList { get; set; }

        void SetPage(int v);
        string PageCount { set; }
        void PageCountLocationX(int x);
        int PageSelectLocationX { get; }
        int PageCountWidth { get; }
        void SetPageSelectItems();

        string CurrencyFilter { get; }
        DateTime DateFromFilter { get; }
        DateTime DateToFilter { get; }
        List<int> PageList { get; set; }
        int GetDGVRowCount();

        #endregion

        #region Categories Components
        List<string> LBCategoriesItems { get; }
        string LBSelectedCategory { get; set; }
        List<string> LBSubcategoriesItems { get; }
        string LBSelectedSubcategory { get; }
        string LBAddCategory { get; }
        string LBAddSubcategory { get; }
        bool RBExpense { get; }





        #endregion
        #region Reports

        List<string> Chart_monthly_expense_breakdown_categories { get; set; }
        List<double> Chart_monthly_expense_breakdown_amounts { get; set; }

        List<string> Chart_yearly_expense_income_categories { get; set; }
        List<double> Chart_yearly_expense_income_amounts { get; set; }

        #endregion

        #region Settings
        string NewName { get; }
        string NewEmail { get; }
        string NewPass { get; }

        int GetPage();
        string GetNewDefCurrency();
        void SetChartsView();

        #endregion
    }
}
