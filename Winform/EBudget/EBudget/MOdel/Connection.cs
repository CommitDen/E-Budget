using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace EBudget.Model
{
    class Connection
    {
        static MySqlConnection con;
        private IDataContainer data = new DataContainer();
        int id = -1;

        public void Connect()
        {
            string server = "localhost";
            string database = "e-budget";
            string user = "root";
            string password = "";
            string port = "3306";
            string sslM = "none";

            string connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}; convert zero datetime=true", server, port, user, password, database, sslM);
            con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                string message = "Sql connection error!";
                string caption = "Error Detected";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
            }
        }
        public void NonQuery(MySqlCommand cmd)
        {
            cmd.ExecuteNonQuery();
        }
        public int Login(string email, string password)
        {
            string sanitisedemail = email.Replace("'", "''").Trim();
            if (!CheckIfEmailIsAvailable(sanitisedemail))
            {
                if (sha256_verify(password, GetHashKeyByEmail(sanitisedemail), sanitisedemail))
                {
                    Connect();
                    string query = String.Format("SELECT id FROM `users` WHERE email = '{0}';", sanitisedemail);
                    id = Convert.ToInt32(Cmd(query).ExecuteScalar());
                    Close();
                }
                else
                {
                    string message = "Incorrect password.";
                    string caption = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                }
            }
            else
            {
                string message = "Incorrect email.";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
            return id;
        }
        public void ReturnDeffaultCurrency()
        {
            Connect();
            string query = String.Format("SELECT currencies.currency_code FROM currencies INNER JOIN users ON currencies.id=users.currency_id WHERE users.id={0}", data.Id);
            MySqlDataReader reader = Cmd(query).ExecuteReader();
            reader.Read();
            data.Def_Currency = reader.GetString(0).ToUpper();
        }
        public string GetHashKeyByEmail(string email)
        {
            Connect();
            string query = String.Format("SELECT `users`.`password` FROM users WHERE `users`.`email`='{0}';", email);

            string result = Convert.ToString(Cmd(query).ExecuteScalar());
            Close();
            return result;
        }
        public void Close()
        {
            con.Close();
        }
        public List<Transaction> QueryTransactions(MySqlCommand cmd)
        {
            MySqlDataReader reader = cmd.ExecuteReader();

            List<Transaction> transactions = new List<Transaction>();
            while (reader.Read())
            {
                Transaction t = new Transaction(reader.GetValue(1).ToString(), Convert.ToInt32(reader.GetValue(2)), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), Convert.ToDouble(reader.GetValue(5)), reader.GetValue(6).ToString().ToUpper(), Convert.ToDateTime(reader.GetValue(7)), reader.GetValue(8).ToString());
                transactions.Add(t);
            }
            reader.Close();
            return transactions;
        }
        public MySqlCommand Cmd(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, con);
            return cmd;
        }
        public Dictionary<string, int> ReturnDictionary(MySqlCommand cmd)
        {
            Dictionary<string, int> categories = new Dictionary<string, int>();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.FieldCount == 2)
            {
                while (reader.Read())
                {
                    categories.Add(reader.GetString(1), reader.GetInt32(0));
                }
            }
            else return categories;
            reader.Close();
            return categories;
        }
        public Dictionary<string, int> ReturnCurrencyDictionary(MySqlCommand cmd)
        {
            Dictionary<string, int> categories = new Dictionary<string, int>();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.FieldCount == 2)
            {
                while (reader.Read())
                {
                    categories.Add(reader.GetString(1).ToUpper(), reader.GetInt32(0));
                }
            }
            else return categories;
            reader.Close();
            return categories;
        }
        public string CreateSalt(string email) {
            byte[] userBytes = Encoding.UTF8.GetBytes(email);

            string salt = "";

            foreach (byte b in userBytes) {
                salt += b.ToString();
            }

            return salt;
        }
        public String sha256_hash(string password, string salt)
        {
            StringBuilder Sb = new StringBuilder();
            byte[] result = GenerateSaltedHash(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt));

            foreach (byte b in result) Sb.Append(b.ToString("x2"));
            return Sb.ToString();
        }
        public byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
        public bool sha256_verify(string password, string hashkey, string email)
        {
            string salt = CreateSalt(email);
            string vhash = sha256_hash(password, salt);

            if (hashkey == vhash) return true;
            else return false;
        }
        public void AddUser(User user)
        {

            if (CheckIfEmailIsAvailable(user.Email))
            {
                string query = String.Format("INSERT INTO users VALUES (NULL, '{0}', '{1}', '{2}', '{3}');", user.Name, user.Email, user.Pwd_hashed, user.Def_currency_id);
                Connect();
                NonQuery(Cmd(query));
            }
            else
            {
                MessageBox.Show("This Email is already in use!", "Email taken!", MessageBoxButtons.OK);
            }
            Close();
        }
        internal List<Transaction> QueryAllTransactions(MySqlCommand cmd)
        {
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Transaction> transactions = new List<Transaction>();
            int i = 1;
            while (reader.Read())
            {
                Transaction t = new Transaction();
                if (i == 1)
                {
                    data.TransactionTableHeader = new List<string>();
                    for (int j = 1; j < 9; j++)
                    {
                        data.TransactionTableHeader.Add(reader.GetName(j));
                    }
                    i--;
                }

                t = new Transaction(reader.GetValue(1).ToString(), Convert.ToInt32(reader.GetValue(2)), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), Convert.ToDouble(reader.GetValue(5)), reader.GetValue(6).ToString().ToUpper(), Convert.ToDateTime(reader.GetValue(7)), reader.GetValue(8).ToString());

                transactions.Add(t);
            }
            return transactions;
        }
        public Dictionary<string, int> ReturnSubcategoriesOfCategory(int cat_id)
        {
            string query = String.Format("SELECT s.id, s.name FROM subcategories_expense AS s INNER JOIN categories_expense AS c ON s.categories_expense_id=c.id WHERE (c.user_id='{0}' OR c.user_id IS NULL) AND s.categories_expense_id='{1}'", data.Id, cat_id);
            Connect();
            MySqlCommand cm = Cmd(query);
            Dictionary<string, int> dic = ReturnDictionary(cm);
            return dic;
        }
        public bool IsUserOwned(string table, string name)
        {
            Connect();
            string query = String.Format("SELECT IF(`{1}`.`user_id`={0}, 'true', 'false') FROM `{1}` WHERE `{1}`.`name`='{2}';", data.Id, table, name);

            bool result = Convert.ToBoolean(Cmd(query).ExecuteScalar());

            Close();
            return result;
        }
        public bool CheckIfEmailIsAvailable(string email)
        {
            Connect();
            string query = String.Format("SELECT count(*) FROM users WHERE users.email='{0}';", email);
            bool result = (Convert.ToInt32(Cmd(query).ExecuteScalar()) == 0);
            Close();
            return result;
        }
        public bool CheckIfExists(string table, string name)
        {
            Connect();
            string query = String.Format("SELECT IF(`{0}`.name='{1}', 'true', 'false') FROM `{0}`;", table, name);
            MySqlDataReader reader = Cmd(query).ExecuteReader();
            reader.Read();
            bool result = reader.GetBoolean(0);
            reader.Close();
            Close();
            return result;
        }

        internal string GetEmailByUserId()
        {
            Connect(); 
            string email = Cmd(String.Format("SELECT `users`.`email` FROM `users` WHERE `users`.`id`={0}", data.Id)).ExecuteScalar().ToString();
            Close();
            return email;
        }

        public DataTable GetData(string query)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=E-Budget;User Id=root;password=";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
    }
}
