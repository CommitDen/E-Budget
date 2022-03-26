using EBudget.Model;
using EBudget.View;
using EBudget.View.Main;
using EBudget.View.Signup;
using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EBudget.Presenter
{
    public class LoginPresenter
    {
        private IFormLogin view;
        private IDataContainer data = new DataContainer();
        public LoginPresenter(IFormLogin view)
        {
            this.view = view;
        }
        public void Openmain(object obj)
        {
            Application.Run(new FormMain(view.Id));
        }
        public void Opensingnup(object obj)
        {
            Application.Run(new FormSignup());
        }

        public void IdSave()
        {
            Connection c = new Connection();
            c.Connect();
            view.Id = c.Login(view.login_email, view.login_password);
            c.Close();
        }
        public void GetCurrencyList()
        {
            Connection c = new Connection();
            c.Connect();
            string query = String.Format("SELECT c.id, c.currency_code FROM currencies AS c");
            MySqlCommand cmd = c.Cmd(query);
            data.Currencies = c.ReturnCurrencyDictionary(cmd);
            c.Close();
        }

    }
}
