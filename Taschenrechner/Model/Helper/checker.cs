using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.Model.Helper
{
    public class Checker
    {
        // test
        int bracketLeft = 0;
        int bracketRight = 0;
        public bool checkEqualBrackets(string s)
        {
            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] == '(')
                {
                    bracketLeft++;
                }
                else if(s[i] == ')')
                {
                    bracketRight++;
                }
            }

            if(bracketLeft == bracketRight)
            {
                bracketLeft = 0;
                bracketRight = 0;
                return true;
            }
            else
            {
                bracketLeft = 0;
                bracketRight = 0;
                return false;
            }
        }
    }
}
