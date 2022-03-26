namespace EBudget.Model
{
    public class QueryFilter
    {
        public enum InOrEx
        {
            Income,
            Expense,
            Both,
        }

        private string name;
        private InOrEx type;
        private string querystring;

        internal InOrEx Type { get => type; }
        public string Querystring { get => querystring; }
        public string Name { get => name; set => name = value; }

        public QueryFilter(string name, InOrEx type, string querystring)
        {
            this.name = name;
            this.type = type;
            this.querystring = querystring;
        }

        public string GetAsString()
        {
            if (type == InOrEx.Income) return "Income";
            else if (type == InOrEx.Expense) return "Expense";
            else return "Both";
        }
    }
}
