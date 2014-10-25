using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanjoos
{
    // table for Balance
    public sealed class Balance
    {
        public double amount { get; set; }

        public override string ToString()
        {
            return amount.ToString();
        }
    }
}
