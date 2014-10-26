using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanjoos
{
    public class CatExpenses
    {
        public int percent { get; set; }
        public string color { get; set; }
        public string category { get; set; }
        public double amount { get; set; }

        public static string GetColor(int index)
        {
            List<string> colors = new List<string>();
            colors.Add("CornflowerBlue");
            colors.Add("Teal");
            colors.Add("Orange");
            colors.Add("MidnightBlue");
            colors.Add("HotPink");
            colors.Add("Salmon");
            colors.Add("SaddleBrown");

            if (index < colors.Count)
                return colors[index];
            else
                return "Blue";
        }
    }
}
