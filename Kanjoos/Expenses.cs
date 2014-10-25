using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanjoos
{
    // table schema for expenses table
    public sealed class Expenses
    {
        // schema is [id, date, month, category, amount, detail]

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public DateTime date { get; set; }
        public int month { get; set; }
        public string category { get; set; }
        public double amount { get; set; }
        public string detail { get; set; }

        //public override string ToString()
        //{
        //    return category + ": " + amount.ToString();
        //}

        public static string GetMonthName(int month)
        {
            Dictionary<int, string> month_names = new Dictionary<int, string>();
            month_names.Add(1, "january");
            month_names.Add(2, "february");
            month_names.Add(3, "march");
            month_names.Add(4, "april");
            month_names.Add(5, "may");
            month_names.Add(6, "june");
            month_names.Add(7, "july");
            month_names.Add(8, "august");
            month_names.Add(9, "september");
            month_names.Add(10, "october");
            month_names.Add(11, "november");
            month_names.Add(12, "december");

            return month_names[month];
        }
    }

}
