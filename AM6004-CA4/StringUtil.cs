using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM6004_CA4
{
    class StringUtil
    {
        public static string BuildTable(string[] headings, double[] t, double[,] result)
        {
            string table = "";
            for (int i = 0; i < result.GetLength(0); i++)
            {
                table += "\n" + string.Format("{0,20}{1,20}{2,20}", t[i], result[i, 0], result[i, 1]);
            }

            string title = new string('=', 80) + "\n"
                + string.Format("{0,20}{1,20}{2,20}", headings[0], headings[1], headings[2])
                + "\n"
                + new string('=', 80) + "\n";

            return title + table;
        }
    }
}
