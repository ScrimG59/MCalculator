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
        private Conversion c = new Conversion();

        /// <summary>
        /// Evaluates the polish notation the "ShuntingYardToken" class did
        /// </summary>
        /// <param name="s">Polish notation as a string</param>
        /// <returns>The result of an calculation as a string</returns>
        public string evaluate(string s, string mode)
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
                        numberStack.Push(Math.E);
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
                            if (mode.Equals("radiant")) 
                            {
                                Console.WriteLine("[EVALUATION] Radiant: Sinus");
                                tempDouble = Math.Sin(operand_1);
                                numberStack.Push(tempDouble);
                            }
                            else {
                                Console.WriteLine("[EVALUATION] Degree: Sinus");
                                tempDouble = Math.Sin(c.degreeToRadiant(operand_1));
                                numberStack.Push(tempDouble);
                            }
                            break;
                        case ("sinh"):
                            Console.WriteLine("[EVALUATION] Radiant: SinusH");
                            tempDouble = Math.Sinh(operand_1);
                            numberStack.Push(tempDouble);
                            break;
                        case ("cos"):
                            if (mode.Equals("radiant"))
                            {
                                Console.WriteLine("[EVALUATION]: Cosinus");
                                tempDouble = Math.Cos(operand_1);
                                numberStack.Push(tempDouble);
                            }
                            else
                            {
                                Console.WriteLine("[EVALUATION]: Cosinus");
                                tempDouble = Math.Cos(c.degreeToRadiant(operand_1));
                                numberStack.Push(tempDouble);
                            }
                            break;
                        case ("cosh"):
                            Console.WriteLine("[EVALUATION]: CosinusH");
                            tempDouble = Math.Cosh(operand_1);
                            numberStack.Push(tempDouble);
                            break;
                        case ("exp"):
                            Console.WriteLine("[EVALUATION]: Exponential");
                            tempDouble = Math.Exp(operand_1);
                            numberStack.Push(tempDouble);
                            break;
                        case ("tan"):
                            if (mode.Equals("radiant"))
                            {
                                Console.WriteLine("[EVALUATION]: Tangent");
                                tempDouble = Math.Tan(operand_1);
                                numberStack.Push(tempDouble);
                            }
                            else
                            {
                                Console.WriteLine("[EVALUATION]: Tangent");
                                tempDouble = Math.Tan(c.degreeToRadiant(operand_1));
                                numberStack.Push(tempDouble);
                            }
                            break;
                        case ("tanh"):
                            Console.WriteLine("[EVALUATION]: TangentH");
                            tempDouble = Math.Tanh(operand_1);
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
