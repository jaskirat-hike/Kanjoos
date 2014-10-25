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

        public override string ToString()
        {
            return category + ": " + amount.ToString();
        }
    }

}
