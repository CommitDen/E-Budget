using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace EBudget.Model
{
    class Exchangerate
    {
        public string CurrencyExchangeRate(DateTime date, string fromCurrency, string toCurrency)
        {
            const string urlPattern = "https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/{0}/currencies/{1}/{2}.json";
            string url = string.Format(urlPattern, date.ToString("yyyy-MM-dd"), fromCurrency.ToLower(), toCurrency.ToLower());

            using (var wc = new WebClient())
            {
                string response;
                try
                {
                    response = wc.DownloadString(url);
                }
                catch (Exception)
                {
                    url = string.Format(urlPattern, "latest", fromCurrency.ToLower(), toCurrency.ToLower());
                    response = wc.DownloadString(url);
                }


                JavaScriptSerializer js = new JavaScriptSerializer();
                Dictionary<string, string> rates = new Dictionary<string, string>();
                rates = js.Deserialize<Dictionary<string, string>>(response);
                double exchangeRate = Convert.ToDouble(rates[toCurrency.ToLower()].Replace('.', ','));
                return (exchangeRate).ToString("N3");
            }
        }
        public static void CurrenciesUpload()
        {
            const string url = "https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies.json";
            using (var wc = new WebClient())
            {
                var response = wc.DownloadString(url);
                JavaScriptSerializer js = new JavaScriptSerializer();
                Dictionary<string, string> currencies = new Dictionary<string, string>();
                currencies = js.Deserialize<Dictionary<string, string>>(response);

                Connection c = new Connection();
                c.Connect();
                try
                {
                    foreach (var currency in currencies)
                    {
                        string query = String.Format("INSERT INTO currencies VALUES (NULL,'{0}','{1}');", currency.Key, currency.Value);
                        c.NonQuery(c.Cmd(query));
                    }
                }
                catch (Exception)
                {
                    string message = "Currency list already uploaded!";
                    string caption = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                }
                c.Close();

            }
        }
    }
}
