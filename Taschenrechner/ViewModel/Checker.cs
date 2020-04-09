﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.Model.Helper
{
    /// <summary>
    /// This class checks for several constraints
    /// </summary>
    public class Checker
    {
        int bracketLeft = 0;
        int bracketRight = 0;

        /// <summary>
        /// Checks if there's an equal amount of brackets in the calculation
        /// </summary>
        /// <param name="s"></param>
        /// <returns>bool</returns>
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

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool checkFunctions(string s)
        {
            // TODO: Implement
            return true;
        }

        /// <summary>
        /// Checks if there's an operation at the last character.
        /// PURPOSE: We don't want any calculations like "5++5"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Does the same thing like checkOperations
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool checkComma(string s)
        {
            if (checkOperations(s))
            {
                return true;
            }

            else
            { return false; }
        }

        /// <summary>
        /// Checks the common rules for setting a right bracket
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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

        /// <summary>
        /// It's a helper method for the delete-button
        /// PURPOSE: The user doesn't want to delete each character of for instance "cosh".
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool checkDeleteForFunctionFive(string s)
        {
            if (s.Length >= 5 &&
                (s.Substring(s.Length - 5, 5).Contains("cosh(")
                || s.Substring(s.Length - 5, 5).Contains("sinh(")
                || s.Substring(s.Length - 5, 5).Contains("tanh(")))
            {
                return true;
            }

            else { return false; }
        }

        /// <summary>
        /// It's a helper method for the delete-button.
        /// PURPOSE: The user doesn't want to delete each character of for instance "cos".
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Same helper method but for function with 3 characters
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool checkDeleteForFunctionsThree(string s) 
        {
            if (s.Length >= 3 && (s.Substring(s.Length - 3, 3).Contains("ln(")))
            {
                return true;
            }

            else { return false; }
        }

        /// <summary>
        /// Same helper method but for function with 3 characters
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool checkDeleteForFunctionsTwo(string s) {

            if (s.Length >= 2 && (s.Substring(s.Length - 2, 2).Contains("√(")))
            {
                return true;
            }

            else { return false; }
        }

        /// <summary>
        /// Helper-method for autocompleting the multiplication symbol, if the user writes something like "5(6+1)".
        /// So the autocompletion-method converts it to "5×(6+1)"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool autoCompleteMultiply(string s)
        {
            if (checkOperations(s))
            {
                return true;
            }

            else { return false; }
        }

        /// <summary>
        /// Same helper-method for autocompletion but for numbers
        /// EXAMPLE: "(6+1)5" ---> "(6+1)×5"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool checkNumbersForAutoComplete(string s)
        {
            if(s != "" && (s[s.Length-1] == ')' || s[s.Length-1] == 'e' || s[s.Length - 1] == 'π'))
            {
                return true;
            }

            else { return false; }
        }

        public bool checkNumbersForAutoCompleteFunction(string s)
        {
            if(containsFunction(s) 
                && (s[s.Length - 2] == 'n'
                || s[s.Length - 2] == 's'
                || s[s.Length - 2] == 'h'
                || s[s.Length - 2] == 'g'
                || s[s.Length - 2] == 'n'
                || s[s.Length - 2] == '√'))
            {
                return false;
            }
            else { return true; }
        }
        public bool containsFunction(string s)
        {
            if(s.Contains("sin") 
                || s.Contains("sinh") 
                || s.Contains("cos") 
                || s.Contains("cosh") 
                || s.Contains("tan") 
                || s.Contains("tanh") 
                || s.Contains("log") 
                || s.Contains("ln") 
                || s.Contains("√"))
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Checks if there's a comma and if there is one, calls the helper-method below
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool checkZero(string s)
        {
            int comma = s.LastIndexOf(',');
            Console.WriteLine($"[CHECKER]: Last Index of Comma is: {comma}");

            if(comma != -1 && checkForLastOperation(s.Substring(comma)))
            {
                Console.WriteLine("[CHECKZERO]: TRUE1");
                return true;
            }

            else {
                Console.WriteLine("[CHECKZERO]: FALSE");
                return false; }
        }


        /// <summary>
        /// Checks if there's a operation from the last comma on and returns true if there isn't any
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool checkForLastOperation(string s)
        {
            if (!s.Contains('+')
                && !s.Contains('-')
                && !s.Contains('×')
                && !s.Contains('÷')
                && !s.Contains('^')
                && !s.Contains('(')
                && !s.Contains(')'))
            {
                return true;
            }

            else {
                return false; }
        }

        /// <summary>
        /// Checks if the user can set another comma
        /// PURPOSE: Without this method the user could set a number like "1,05086509,6568"
        /// This method prevents the user from setting a second comma within one number
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool checkForDuplicateComma(string s)
        {
            int comma = s.LastIndexOf(',');

            if(comma != -1 && !checkForLastOperation(s.Substring(comma)))
            {
                return true;
            }

            else if(comma == -1) { return true; }

            else { return false; }
        }

        /// <summary>
        /// Checks if there's not an operation on the second last position of the input string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool checkForLastNumber(string s)
        {
            if(s[s.Length-1] != '+'
               && s[s.Length - 1] != '-'
               && s[s.Length - 1] != '×'
               && s[s.Length - 1] != '÷'
               && s[s.Length - 1] != '^')
            {
                return true;
            }

            else { return false; }
        }
    }
}
