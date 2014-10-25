using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanjoos
{
    // table schema for reminders
    public sealed class Reminders
    {
        // schema is [id, deadline, amount, detail, finished]

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public DateTime deadline { get; set; }
        public double amount { get; set; }
        public string detail { get; set; }
        public bool finished { get; set; }

    }
}
