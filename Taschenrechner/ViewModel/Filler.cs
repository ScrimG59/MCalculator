using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taschenrechner.Model.Helper;
using Taschenrechner.Model.TokenApproach;

namespace Taschenrechner.ViewModel
{
    public class Filler
    {
        Checker c = new Checker();
        ShuntingYardToken syt = new ShuntingYardToken();
        EvaluateInfixToken eit = new EvaluateInfixToken();
        ShuntingYard sy = new ShuntingYard();
        EvaluateInfix ei = new EvaluateInfix();
        string substring = "";
        List<Token> tempToken = new List<Token>();
        string result = "";

        public string setSubstringForDelete(string s)
        {
            if (c.checkDeleteForFunctionsFour(s))
            {
                substring = s.Substring(0, s.Length - 4);
                return substring;
            }

            else if (s.Length >= 3 && (s.Substring(s.Length - 3, 3).Contains("ln(")))
            {
                substring = s.Substring(0, s.Length - 3);
                return substring;
            }

            else if (s.Length >= 2 && (s.Substring(s.Length - 2, 2).Contains("√(")))
            {
                substring = s.Substring(0, s.Length - 2);
                return substring;
            }
            else
            {
                substring = s.Substring(0, s.Length - 1);
                return substring;
            }
        }

        public string calculateToken(string s)
        {
            Console.WriteLine($"[FILLER]: Content: {s}");

                result = "";
                tempToken = syt.toPolishNotation(s);
                foreach (var token in tempToken)
                {
                    result += token.Value + " ";
                    Console.WriteLine($"[FILLER]: Token: {token.Value}");
                }
                result = eit.evaluate(result);
                tempToken.Clear();
                return result;
        }

        public string calculateString(string s)
        {
            Console.WriteLine($"[FILLER]: Content: {s}");
            result = "";
            result = sy.stringToInfix(s);
            result = ei.evaluate(result);
            return result;
        }
    }
}
