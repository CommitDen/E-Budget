using EBudget.Presenter;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace EBudget.View.Login
{
    public partial class FormLogin : Form, IFormLogin
    {
        Thread th1, th2;
        int id;
        LoginPresenter presenter;
        public string login_email { get => textbox_login_email.Text; }
        public string login_password { get => textbox_login_password.Text; }
        
        public int Id { get => id; set => id = value; }

        public FormLogin()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            presenter = new LoginPresenter(this);
            presenter.GetCurrencyList();
        }
        private void Form_Change_Main()
        {
            this.Close();
            th1 = new Thread(presenter.Openmain);
            th1.SetApartmentState(ApartmentState.STA);
            th1.Start();
        }
        private void Form_Change_Signup()
        {
            this.Close();
            th2 = new Thread(presenter.Opensingnup);
            th2.SetApartmentState(ApartmentState.STA);
            th2.Start();
        }
        private void button_login_Click(object sender, EventArgs e)
        {
            presenter.IdSave();
            if (id != -1)
            {
                Form_Change_Main();
            }

        }
        private void linkLabel_signup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_Change_Signup();
        }
        
       
    }
}
