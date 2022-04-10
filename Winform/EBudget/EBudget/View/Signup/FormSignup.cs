using EBudget.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBudget.View.Signup
{
    public partial class FormSignup : Form, IFormSignup
    {
        Thread th;
        SignupPresenter presenter;
        public string signup_email { get => textbox_signup_email.Text; }
        public string signup_password1 { get => textbox_signup_password1.Text; }
        public string signup_name { get => textbox_signup_name.Text; }
        public string signup_currency { get => combobox_signup_currency.SelectedItem.ToString(); }
        public FormSignup()
        {
            InitializeComponent();
        }
        private void Form_Change_Login()
        {
            this.Close();
            th = new Thread(presenter.OpenLogin);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void FormSignup_Load(object sender, EventArgs e)
        {
            presenter = new SignupPresenter(this);
            
            presenter.LoadCBCurrencyItems(combobox_signup_currency);
            combobox_signup_currency.SelectedItem = "EUR";
        }

        private void button_Signup_Click(object sender, EventArgs e)
        {
            if (textbox_signup_name.Text != "" && textbox_signup_email.Text != "" && textbox_signup_password1.Text != "" && textbox_signup_password2.Text != "" && check_if_same(textbox_signup_password1.Text, textbox_signup_password2.Text))
            {
                SignupPresenter.PasswordScore score = presenter.CheckStrength(textbox_signup_password1.Text);
                if (score == SignupPresenter.PasswordScore.Blank || score == SignupPresenter.PasswordScore.VeryWeak || score == SignupPresenter.PasswordScore.Weak) {
                    MessageBox.Show("Weak password,\nPassword must be atleast \n  8 character long \nMust contain atleast:\n  1 lowercase character\n  1 uppercase character \n  1 number \n  1 special character", "Weak password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    presenter.RegisterUser();
                    Form_Change_Login();
                }
            }
            else MessageBox.Show("Missing data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            Form_Change_Login();
        }
        private void Textbox_email_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textbox_signup_email.Text, "[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+[A-Za-z]{2,}", RegexOptions.ECMAScript).Success)
            {
                MessageBox.Show("Please enter a valid email adress!", "Incorrect email format.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Password1_textbox_Leave(object sender, EventArgs e)
        {
            SignupPresenter.PasswordScore score = presenter.CheckStrength(textbox_signup_password1.Text);
            if (score == SignupPresenter.PasswordScore.Blank || score == SignupPresenter.PasswordScore.VeryWeak || score == SignupPresenter.PasswordScore.Weak)
            {
                MessageBox.Show("Weak password,\nPassword must be atleast \n  8 character long \nMust contain atleast:\n  1 lowercase character\n  1 uppercase character \n  1 number \n  1 special character", "Weak password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Password2_textbox_Leave(object sender, EventArgs e)
        {
            if (!check_if_same(textbox_signup_password1.Text, textbox_signup_password2.Text))
            {
                MessageBox.Show("Password and Password-confirmation not matching!", "Wrong Password!", MessageBoxButtons.OK);
            }
        }
        private bool check_if_same(string str1, string str2)
        {
            if (str1 == str2) return true;
            else return false;
        }
    }
}
