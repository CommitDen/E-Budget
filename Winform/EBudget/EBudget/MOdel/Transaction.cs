using System;
using System.ComponentModel;

namespace EBudget.Model
{
    public class Transaction
    {
        private string type;
        private int trans_id;
        private string category;
        private double amount;
        private string currency;
        private DateTime date;
        private string comment;
        private string subcategory;

        public Transaction()
        {
        }

        public Transaction(string type, int trans_id, string category, string subcategory, double amount, string currency, DateTime date, string comment)
        {
            this.type = type;
            this.trans_id = trans_id;
            this.category = category;
            this.subcategory = subcategory;
            this.amount = amount;
            this.currency = currency;
            this.date = date;
            this.comment = comment;
        }

        public string Category { get => category; }
        public string Subcategory { get => subcategory; }
        public double Amount { get => amount; }
        public string Currency { get => currency; }
        public DateTime Date { get => date; }
        public string Comment { get => comment; }
        [Browsable(false)]
        public int Trans_id { get => trans_id; }
        [Browsable(false)]
        public string Type { get => type; }
    }
}
