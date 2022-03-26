using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBudget.View.Signup
{
    internal interface IFormSignup
    {
        string signup_email { get; }
        string signup_password1 { get; }
        string signup_name { get; }
        string signup_currency { get; }
    }
}
