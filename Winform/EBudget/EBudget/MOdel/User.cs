namespace EBudget.Model
{
    class User
    {
        private string name;
        private string email;
        private string pwd_hashed;
        private int def_currency_id;

        public User(string name, string email, string pwd_hashed, int def_currency_id)
        {
            this.name = name;
            this.email = email;
            this.pwd_hashed = pwd_hashed;
            this.def_currency_id = def_currency_id;
        }

        public string Name { get => name; }
        public string Email { get => email; }
        public string Pwd_hashed { get => pwd_hashed; }
        public int Def_currency_id { get => def_currency_id; }
    }
}
