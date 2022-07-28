using _2_BUS.IBUS_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2_BUS.BUS_Service
{
    public class BUS_CheckEverything: IBUS_CheckEverything
    {
        public bool CheckNull(string nulllll)
        {
            if (string.IsNullOrWhiteSpace(nulllll))
            {
                return true;
            }
            return false;
        }
        public bool CheckSo(string so)
        {
            if (Regex.IsMatch(so, @"[a-zA-Z]") == true)
            {
                return true;
            }
            return false;
        }
        public bool CheckString(string input)
        {
            if (input.All(char.IsDigit))
            {
                return true;
            }
            return false;
        }
    }
}
