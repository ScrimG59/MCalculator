using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.Model.TokenApproach
{
    public class EvaluateInfixToken
    {
        private List<Token> tokens = new List<Token>();
        private TokenRuleList trl = new TokenRuleList();
        private Stack<double>numberStack = new Stack<double>();
        private string result = "";
        private double operand_1;
        string val = "";
        private double operand_2;
        private double tempDouble;

        /// <summary>
        /// Evaluates the polish notation the "ShuntingYardToken" did
        /// </summary>
        /// <param name="s">Polish notation as a string</param>
        /// <returns>The result of an calculation as a string</returns>
        public string evaluate(string s)
        {
            Console.WriteLine($"[EVALUATION]: Polish Notation: {s}");
            tokens.Clear();
            tokens = trl.Tokenize(s);
            result = "";

            foreach(var token in tokens)
            {

                if (token.TokenType.ToString().Equals("Operator"))
                {
                    Console.WriteLine($"[EVALUATION]: Is a Operator: {token.Value}");
                    val = token.Value;
                    operand_2 = numberStack.Pop();
                    operand_1 = numberStack.Pop();

                    switch (val)
                    {
                        case "+":
                            tempDouble = operand_1 + operand_2;
                            numberStack.Push(tempDouble);
                            break;
                        case "-":
                            tempDouble = operand_1 - operand_2;
                            numberStack.Push(tempDouble);
                            break;
                        case "×":
                            tempDouble = operand_1 * operand_2;
                            numberStack.Push(tempDouble);
                            break;
                        case "÷":
                            tempDouble = operand_1 / operand_2;
                            numberStack.Push(tempDouble);
                            break;
                        case "^":
                            tempDouble = Math.Pow(operand_1, operand_2);
                            numberStack.Push(tempDouble);
                            break;
                    }
                }

                else if (token.TokenType.ToString().Equals("Number"))
                {
                    Console.WriteLine($"[EVALUATION]: Is a Number: {token.Value}");
                    numberStack.Push(Convert.ToDouble(token.Value));
                }

                else if (token.TokenType.ToString().Equals("Constant"))
                {
                    Console.WriteLine($"[EVALUATION]: Is a Constant: {token.Value}");

                    if (token.Value.ToString().Equals("e"))
                    {
                        numberStack.Push(Math.Exp(1));
                    }
                    else
                    {
                        numberStack.Push(Math.PI);
                    }
                }

                else if (token.TokenType.ToString().Equals("Function"))
                {
                    Console.WriteLine($"[EVALUATION]: Is a Function: {token.Value}");
                    val = token.Value;
                    operand_1 = numberStack.Pop();

                    switch (val)
                    {
                        case ("sin"):
                            Console.WriteLine("[EVALUATION]: Sinus");
                            tempDouble = Math.Sin(operand_1);
                            numberStack.Push(tempDouble);
                            break;
                        case ("cos"):
                            Console.WriteLine("[EVALUATION]: Cosinus");
                            tempDouble = Math.Cos(operand_1);
                            numberStack.Push(tempDouble);
                            break;
                        case ("exp"):
                            Console.WriteLine("[EVALUATION]: Exponential");
                            tempDouble = Math.Exp(operand_1);
                            numberStack.Push(tempDouble);
                            break;
                        case ("tan"):
                            Console.WriteLine("[EVALUATION]: Tangent");
                            tempDouble = Math.Tan(operand_1);
                            numberStack.Push(tempDouble);
                            break;
                        case ("log"):
                            Console.WriteLine("[EVALUATION]: Logarithm (Base 10)");
                            tempDouble = Math.Log10(operand_1);
                            numberStack.Push(tempDouble);
                            break;
                        case ("ln"):
                            Console.WriteLine("[EVALUATION]: Logarithm-Naturalis");
                            tempDouble = Math.Log(operand_1);
                            numberStack.Push(tempDouble);
                            break;
                        case ("√"):
                            Console.WriteLine("[EVALUATION]: Square Root");
                            tempDouble = Math.Sqrt(operand_1);
                            numberStack.Push(tempDouble);
                            break;
                    }
                }
            }
            result += numberStack.Pop();
            Console.WriteLine(result);
            return result;
        }
    }
}
