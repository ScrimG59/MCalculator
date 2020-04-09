using System;
using System.Collections.Generic;
using Taschenrechner.Model.Helper;
using Taschenrechner.Model.TokenApproach;

namespace Taschenrechner.ViewModel
{

    /// <summary>
    /// This class fills the textblock with characters
    /// </summary>
    public class Printer
    {
        Checker c = new Checker();
        ShuntingYardToken syt = new ShuntingYardToken();
        EvaluateInfixToken eit = new EvaluateInfixToken();
        ShuntingYard sy = new ShuntingYard();
        EvaluateInfix ei = new EvaluateInfix();
        string substring = "";
        List<Token> tempToken = new List<Token>();
        string result = "";

        /// <summary>
        /// Deletes the textbox text according to some rules
        /// PURPOSE:If something gets deleted like "sin(", the user wants to get it deleted at once and not char per char
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string setSubstringForDelete(string s)
        {
            if (c.checkDeleteForFunctionFive(s))
            {
                substring = s.Substring(0, s.Length - 5);
                return substring;
            }
            else if (c.checkDeleteForFunctionsFour(s))
            {
                substring = s.Substring(0, s.Length - 4);
                return substring;
            }

            else if (c.checkDeleteForFunctionsThree(s))
            {
                substring = s.Substring(0, s.Length - 3);
                return substring;
            }

            else if (c.checkDeleteForFunctionsTwo(s))
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

        /// <summary>
        /// Prints the result of the calculation with the token approach into the textbox
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string calculateToken(string s, string mode)
        {
            Console.WriteLine($"[FILLER]: Content: {s}");

            result = "";
            tempToken = syt.toPolishNotation(s);

            foreach (var token in tempToken)
            {
                result += token.Value + " ";
                Console.WriteLine($"[FILLER]: Token: {token.Value}");
            }

            result = eit.evaluate(result, mode);
            tempToken.Clear();
            return result;
        }

        /// <summary>
        /// Prints the result of the calculation with the string approach into the textbox
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string calculateString(string s)
        {
            Console.WriteLine($"[FILLER]: Content: {s}");
            result = "";
            result = sy.stringToInfix(s);
            result = ei.evaluate(result);
            return result;
        }

        /// <summary>
        /// Prints a number into the input textbox according to some rules (except number 0)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public string printNumber(string s, int number)
        {
            switch(number){
                case 1:
                    if (c.checkNumbersForAutoComplete(s))
                    {
                       return "×1";
                    }
                    else { return "1"; }
                case 2:
                    if (c.checkNumbersForAutoComplete(s))
                    {
                        return "×2";
                    }
                    else { return "2"; }
                case 3:
                    if (c.checkNumbersForAutoComplete(s))
                    {
                        return "×3";
                    }
                    else { return "3"; }
                case 4:
                    if (c.checkNumbersForAutoComplete(s))
                    {
                        return "×4";
                    }
                    else { return "4"; }
                case 5:
                    if (c.checkNumbersForAutoComplete(s))
                    {
                        return "×5";
                    }
                    else { return "5"; }
                case 6:
                    if (c.checkNumbersForAutoComplete(s))
                    {
                        return "×6";
                    }
                    else { return "6"; }
                case 7:
                    if (c.checkNumbersForAutoComplete(s))
                    {
                        return "×7";
                    }
                    else { return "7"; }
                case 8:
                    if (c.checkNumbersForAutoComplete(s))
                    {
                        return "×8";
                    }
                    else { return "8"; }
                case 9:
                    if (c.checkNumbersForAutoComplete(s))
                    {
                        return "×9";
                    }
                    else { return "9"; }
                default:
                    return "";
            }
        }

        /// <summary>
        /// Prints the number zero with its according rules
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string printZero(string s)
        {
            if (c.checkNumbersForAutoComplete(s))
            {
                return "×0";
            }

            // allows a zero right at the start
            else if (s == "") { return "0"; }
            // allows a zero after an operator
            else if (!c.checkOperations(s)) { return "0"; }
            // checks other constraints
            else if (c.checkZero(s)) { return "0"; }
            else { return ""; }
        }

        /// <summary>
        /// Prints an operator into the input textbox according to some rules
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string printOperator(string s, string op)
        {
            switch (op)
            {
                case "+":
                    if (c.checkOperations(s))
                    {
                        return "+";
                    }
                    else { return ""; }
                case "-":
                    if (c.checkOperations(s))
                    {
                        return "-";
                    }
                    else { return ""; }
                case "×":
                    if (c.checkOperations(s))
                    {
                        return "×";
                    }
                    else { return ""; }
                case "÷":
                    if (c.checkOperations(s))
                    {
                        return "÷";
                    }
                    else { return ""; }
                case "^":
                    if (c.checkOperations(s))
                    {
                        return "^";
                    }
                    else { return ""; }
                default:
                    return "";
            }
        }

        /// <summary>
        /// Prints a constant into the input textbox according to some rules
        /// </summary>
        /// <param name="s"></param>
        /// <param name="constant"></param>
        /// <returns></returns>
        public string printConstant(string s, string constant)
        {
            switch (constant)
            {
                case "e":
                    if (s != "" && (c.checkNumbersForAutoComplete(s) || c.checkForLastNumber(s)))
                    {
                        return "×e";
                    }
                    else { return "e"; }
                case "pi":
                    if (s != "" && (c.checkNumbersForAutoComplete(s) || c.checkForLastNumber(s)))
                    {
                        return "×π";
                    }
                    else { return "π"; }
                default:
                    return "";
            }
        }

        /// <summary>
        /// Prints a comma into the input textbox according to some rules
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string printComma(string s)
        {
            if (c.checkOperations(s) && c.checkForDuplicateComma(s))
            {
                return ",";
            }
            else { return ""; }
        }

        /// <summary>
        /// Prints a function into the input textbox according to some rules
        /// </summary>
        /// <param name="s"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public string printFunction(string s, string func)
        {
            switch (func)
            {
                case "sin":
                    if (s != "" && (c.checkNumbersForAutoCompleteFunction(s) && (c.checkNumbersForAutoComplete(s) || c.checkForLastNumber(s))))
                    {
                        return "×sin(";
                    }
                    else { return "sin("; }
                case "sinh":
                    if (s != "" && (c.checkNumbersForAutoCompleteFunction(s) && (c.checkNumbersForAutoComplete(s) || c.checkForLastNumber(s))))
                    {
                        return "×sinh(";
                    }
                    else { return "sinh("; }
                case "cos":
                    if (s != "" && (c.checkNumbersForAutoCompleteFunction(s) && (c.checkNumbersForAutoComplete(s) || c.checkForLastNumber(s))))
                    {
                        return "×cos(";
                    }
                    else { return "cos("; }
                case "cosh":
                    if (s != "" && (c.checkNumbersForAutoCompleteFunction(s) && (c.checkNumbersForAutoComplete(s) || c.checkForLastNumber(s))))
                    {
                        return "×cosh(";
                    }
                    else { return "cosh("; }
                case "tan":
                    if (s != "" && (c.checkNumbersForAutoCompleteFunction(s) && (c.checkNumbersForAutoComplete(s) || c.checkForLastNumber(s))))
                    {
                        return "×tan(";
                    }
                    else { return "tan("; }
                case "tanh":
                    if (s != "" && (c.checkNumbersForAutoCompleteFunction(s) && (c.checkNumbersForAutoComplete(s) || c.checkForLastNumber(s))))
                    {
                        return "×tanh(";
                    }
                    else { return "tanh("; }
                case "exp":
                    if (s != "" && (c.checkNumbersForAutoCompleteFunction(s) && (c.checkNumbersForAutoComplete(s) || c.checkForLastNumber(s))))
                    {
                        return "×e^";
                    }
                    else { return "e^"; }
                case "log":
                    if (s != "" && (c.checkNumbersForAutoCompleteFunction(s) && (c.checkNumbersForAutoComplete(s) || c.checkForLastNumber(s))))
                    {
                        return "×log(";
                    }
                    else { return "log("; }
                case "ln":
                    if (s != "" && (c.checkNumbersForAutoCompleteFunction(s) && (c.checkNumbersForAutoComplete(s) || c.checkForLastNumber(s))))
                    {
                        return "×ln(";
                    }
                    else { return "ln("; }
                case "sqrt":
                    if (s != "" && (c.checkNumbersForAutoCompleteFunction(s) && (c.checkNumbersForAutoComplete(s) || c.checkForLastNumber(s))))
                    {
                        return "×√(";
                    }
                    else { return "√("; }
                default:
                    return "";
            }
        }

        /// <summary>
        /// Prints a left parenthesis into the input textbox according to some rules
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string printLeftParen(string s)
        {
            if (c.autoCompleteMultiply(s))
            {
                return "×(";
            }
            else
            {
                return "(";
            }
        }

        /// <summary>
        /// Prints a right parenthesis into the input textbox according to some rules
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string printRightParen(string s)
        {
            if (c.checkRightParen(s))
            {
                return ")";
            }
            else { return ""; }
        }
    }
}
