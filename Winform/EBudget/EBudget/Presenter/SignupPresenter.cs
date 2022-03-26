using EBudget.Model;
using EBudget.View.Login;
using EBudget.View.Signup;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBudget.Presenter
{
    internal class SignupPresenter
    {
        private IFormSignup view;
        private IDataContainer data = new DataContainer();
        public SignupPresenter(IFormSignup view)
        {
            this.view = view;
        }
        public void LoadCBCurrencyItems(ComboBox cb)
        {
            foreach (var item in data.Currencies)
            {
                cb.Items.Add(item.Key.ToUpper());
            }
        }
        public void RegisterUser()
        {
            Connection c = new Connection();
            User user = new User(view.signup_name, view.signup_email, c.sha256_hash(view.signup_password1, c.CreateSalt(view.signup_email)), data.Currencies[view.signup_currency.ToUpper()]);
            c.AddUser(user);
        }

        public void OpenLogin(object obj)
        {
            Application.Run(new FormLogin());
        }

        public enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }
        public PasswordScore CheckStrength(string password)
        {
            int score = 0;

            if (password.Length < 1) return PasswordScore.Blank;
            if (password.Length < 4) return PasswordScore.VeryWeak;

            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, @"[a-z]", RegexOptions.ECMAScript).Success && Regex.Match(password, @"[A-Z]", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"[0-9]", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript).Success)
                score++;

            return (PasswordScore)score;
        }
        
    }
}
