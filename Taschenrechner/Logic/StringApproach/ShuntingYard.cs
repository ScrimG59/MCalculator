using System;
using System.Collections.Generic;

namespace Taschenrechner.Logic.StringApproach
{
    public class ShuntingYard
    {
        private Stack<string> stack = new Stack<string>();
        private string outputQueue = "";
        private char c;

        // Doing the Shunting Yard Algorithm to put the input string into an infix notation
        public string stringToInfix(string s)
        {
            outputQueue = "";

            // Check for invalid input like a single Character or no Character
            if(s.Length == 0|| s.Length == 1 || s.Length == 2)
            {
                throw new Exception("[SHUNTING YARD EXCEPTION]: INVALID INPUT");
            }

            Console.WriteLine($"[SHUNTING YARD] Input: {s}");

            // Goes through every string character and check if it's a number or an operator
            for(int index = 0; index < s.Length; index++)
            {
                c = s[index];

                // If the string character is a number or a comma and there was an operator before (index-1) 
                // --> Put a space into the output queue and afterwards the number
                // Otherwise just put the number into the output queue
                if (Char.IsNumber(c) || c == ',')
                {
                    Console.WriteLine("[SHUNTING YARD] Number: " + c);
                    // To make sure that numbers with more than 1 digits are read properly
                    if ((index != 0 && index != 1) && (isOperator(s[index - 1]) || s[index-1] == '(' || s[index-1] == ')'))
                    {
                        Console.WriteLine("[SHUNTING YARD] Space added");
                        outputQueue += " ";
                    }
                    outputQueue += c.ToString();
                    Console.WriteLine(outputQueue);
                }

                // If the string character an operator do a while loop with a lot of constraints (check presence etc.) 
                // And pop the string characters out of the operator stack which match the constraints
                else if (isOperator(c))
                {
                    while (stack.Count != 0 && (checkGreaterPrecedence(s[index], Convert.ToChar(stack.Peek())) || (checkAssociative(c) && checkEqualPrecedence(c, Convert.ToChar(stack.Peek()))) && stack.Peek() != "("))
                    {
                        if (stack.Count == 0)
                        {
                            Console.WriteLine("[SHUNTING YARD] Stack empty");
                            break;
                        }
                        Console.WriteLine("[SHUNTING YARD] Pops operators from the operator stack onto the output queue");
                        outputQueue += stack.Pop();
                    }
                    // Push the operator onto the operator stack
                    stack.Push(c.ToString());
                }

                // If the string charcter is an open bracket, it'll be pushed onto the operator stack
                else if(c == '(')
                {
                    stack.Push(c.ToString());
                }

                // If the character string is a closed bracket, it will search for an open bracket in the stack
                // --> and pop all the characters into the output queue until the open bracket is found, popped and discarded 
                else if (c == ')')
                {
                    while(stack.Peek().ToString() != "(")
                    {
                            outputQueue += stack.Pop();
                    }
                    stack.Pop();
                }
            }
            // At the end, just pop all the remaining characters from the operator stack into the output queue 
            while(stack.Count != 0)
            {
                Console.WriteLine("[SHUNTING YARD]: Popping Stack");
                outputQueue += stack.Pop();
            }
            s = "";
            stack.Clear();
            return outputQueue;
        }
        // TODO: implement functions
        private string isFunction (String s)
        {
            if (s.Length == 3 && (s.Equals("cos") || s.Equals("sin") || s.Equals("exp")))
            {
                return s;
            } 
            else
            {
                throw new Exception("NOT a function!");
            }
        }

        // TODO: implement constants
        private string isConstant(String s)
        {
            if(s.Length == 2 && s.Equals("Pi"))
            {
                return "Pi";
            }
            else if(s.Length == 1 && s.Equals("e"))
            {
                return "e";
            }
            else
            {
                throw new Exception("[SHUNTING YARD EXCEPTION]NOT a constant!");
            }
        }

        // Helper method which checks if the given character is an operator
        private static bool isOperator (Char c)
        {
            if (c == '+' || c == '-' || c == '×' || c == '÷' || c == '^')
            {
                Console.WriteLine("[SHUNTING YARD]: It's an operator.");
                return true;
            }
            else
            {
                Console.WriteLine("[Shunting Yard]: It isn't an operator.");
                return false;
            }
        }

        // Helper method which checks the precedence
        private static bool checkGreaterPrecedence(char currentOperator, char stackOperator)
        {
            // Returns true if the stack operator has an greater precedence than the current operator
            // Returns false if the stack operator has an equal or less precedence than the current operator
            int a, b = 0;
            //Adding precedences
            Dictionary<string, int> precedence = new Dictionary<string, int>
            {
                { "+", 2 },
                { "-", 2 },
                { "*", 3 },
                { "/", 3 },
                { "^", 4 }
            };

            if (precedence.ContainsKey(currentOperator.ToString()) && precedence.ContainsKey(stackOperator.ToString()))
            {
                if (precedence.TryGetValue(currentOperator.ToString(), out a) && precedence.TryGetValue(stackOperator.ToString(), out b))
                {
                    if (a < b)
                    {
                        Console.WriteLine("[SHUNTING YARD]: Greater Precedence");
                        return true;
                    }
                }
            }
            return false;
        }

        // Helper method that checks the associativity of the given operator
        private static bool checkAssociative(char op)
        {
            // Returns true if the operator is left associative and false otherwise
            string value = "";
            // Adding associativity
            Dictionary<string, string> associativity = new Dictionary<string, string>
            {
                { "+", "left" },
                { "-", "left" },
                { "*", "left" },
                { "/", "left" },
                { "^", "right" }
            };
            if (associativity.ContainsKey(op.ToString()) && associativity.TryGetValue(op.ToString(), out value))
            {
                if(value == "left")
                {
                    return true;
                }
            }
            return false;
        }

        // Helper method that checks equal precedence
        private static bool checkEqualPrecedence(char currentOperator, char stackOperator)
        {
            // Returns true if the current operator and the stack operator have equal precedence
            int a, b = 0;
            //Adding precedences
            Dictionary<string, int> precedence = new Dictionary<string, int>
            {
                { "+", 2 },
                { "-", 2 },
                { "*", 3 },
                { "/", 3 },
                { "^", 4 }
            };
            if (precedence.ContainsKey(currentOperator.ToString()) && precedence.ContainsKey(stackOperator.ToString()))
            {
                if(precedence.TryGetValue(currentOperator.ToString(), out a) && precedence.TryGetValue(stackOperator.ToString(), out b))
                {
                    if (a == b)
                    {
                        Console.WriteLine("[SHUNTING YARD]: Equal Precedence");
                        return true;
                    }
                }
            }
            Console.WriteLine("[SHUNTING YARD]: Unequal Precedence");
            return false;
        }
    }
}
