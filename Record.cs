using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps
{
    public class Record
    {
        public string name;
        public decimal point;

        public Record(string argName, decimal argPoint)
        {
            name = argName;
            point = argPoint;
        }

        
    }

    public static class UtilityRecord
    {
        public static Decimal GetPoint(string line)
        {
            return Convert.ToDecimal(line.Substring(0, line.IndexOf(";")));
        }

        public static string GetName(string line)
        {
            return line.Substring(line.IndexOf(";") + 1);
        }
    }
}
