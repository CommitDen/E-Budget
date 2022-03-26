namespace EBudget.View.CategoryEdit
{
    internal interface ICategoryEdit
    {
        string NameLabel { set; }
        string NameForm { set; }
        string NameTB { get; set; }
        string Type { set; }
        string Table { get; }
        string OriginalName { get; }
    }
}
