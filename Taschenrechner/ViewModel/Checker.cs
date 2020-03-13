using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.Model.Helper
{
    public class Checker
    {
        int bracketLeft = 0;
        int bracketRight = 0;

        public bool checkEqualBracketAmount(string s)
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

        public bool checkFunctions(string s)
        {
            // TODO: Implement
            return true;
        }

        public bool checkOperations(string s)
        {
            if(s != ""
               && (s[s.Length - 1] != '+'
               && s[s.Length - 1] != '-'
               && s[s.Length - 1] != '×'
               && s[s.Length - 1] != '÷'
               && s[s.Length - 1] != '^'
               && s[s.Length - 1] != '('
               && s[s.Length - 1] != ','))
            {
                return true;
            }

            else
            { return false; }
        }

        public bool checkComma(string s)
        {
            if (checkOperations(s))
            {
                return true;
            }

            else
            { return false; }
        }

        /*public bool checkLeftParen(string s)
        {
            if(s == ""
               || s[s.Length - 1] == '+'
               || s[s.Length - 1] == '-'
               || s[s.Length - 1] == '×'
               || s[s.Length - 1] == '÷'
               || s[s.Length - 1] == '^')
            {
                return true;
            }

            else
            { return false; }
        }*/

        public bool checkRightParen(string s)
        {
            if(s != ""
               && (s[s.Length - 1] != '+'
               && s[s.Length - 1] != '-'
               && s[s.Length - 1] != '×'
               && s[s.Length - 1] != '÷'
               && s[s.Length - 1] != '^'
               && s[s.Length - 1] != '('
               && s[s.Length - 1] != ',')
               && !checkEqualBracketAmount(s))
            {
                return true;
            }

            else
            { return false; }
        }

        public bool checkDeleteForFunctionsFour(string s)
        {
            if (s.Length >= 4 &&
                (s.Substring(s.Length - 4, 4).Contains("cos(")
                || s.Substring(s.Length - 4, 4).Contains("sin(")
                || s.Substring(s.Length - 4, 4).Contains("log(")
                || s.Substring(s.Length - 4, 4).Contains("tan(")))
            {
                return true;
            }

            else { return false; }
        }

        public bool checkDeleteForFunctionsThree(string s) 
        {
            if (s.Length >= 3 && (s.Substring(s.Length - 3, 3).Contains("ln(")))
            {
                return true;
            }

            else { return false; }
        }

        public bool checkDeleteForFunctionsTwo(string s) {

            if (s.Length >= 2 && (s.Substring(s.Length - 2, 2).Contains("√(")))
            {
                return true;
            }

            else { return false; }
        }
    }
}
