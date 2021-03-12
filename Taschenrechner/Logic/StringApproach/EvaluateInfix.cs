using System;
using System.Collections.Generic;

namespace Taschenrechner.Logic.StringApproach
{
    public class EvaluateInfix
    {
        private Stack<string> stack = new Stack<string>();
        private string result = "";
        private double tempDouble;
        private string tempString = "";
        private string operand_1 = "";
        private string operand_2 = "";
        private string number = "";
        
        public string evaluate(String s)
        {
            Console.WriteLine($"[EVALUATION]: Polish Notation: {s}");
            result = "";
            int j;
            for(int i = 0; i < s.Length; i++)
            {
                // if the character is a space, just skip through it
                if(s[i].Equals(" "))
                {
                    continue;
                }

                // if the character is an operator, take the two operands and execute the operation with the operator
                else if (isOperator(s[i]))
                {
                    operand_2 += stack.Pop();
                    operand_1 = stack.Pop();
                    Console.WriteLine($"[EVALUATION]: Operand 1: {operand_1}\n Operand2: {operand_2}");  

                    switch (s[i])
                    {
                        case '+':
                            tempDouble = Convert.ToDouble(operand_1) + Convert.ToDouble(operand_2);
                            tempString = tempDouble.ToString();
                            stack.Push(tempString);
                            break;
                        case '-':
                            tempDouble = Convert.ToDouble(operand_1) - Convert.ToDouble(operand_2);
                            tempString = tempDouble.ToString();
                            stack.Push(tempString);
                            break;
                        case '×':
                            tempDouble = Convert.ToDouble(operand_1) * Convert.ToDouble(operand_2);
                            tempString = tempDouble.ToString();
                            stack.Push(tempString);
                            break;
                        case '÷':
                            tempDouble = Convert.ToDouble(operand_1) / Convert.ToDouble(operand_2);
                            tempString = tempDouble.ToString();
                            stack.Push(tempString);
                            break;
                        case '^':
                            tempDouble = Math.Pow(Convert.ToDouble(operand_1), Convert.ToDouble(operand_2));
                            tempString = tempDouble.ToString();
                            stack.Push(tempString);
                            break;
                        default:
                            Console.WriteLine("[EVALUATION]: ERROR");
                            break;
                    }
                    operand_1 = "";
                    operand_2 = "";
                }

                else if (Char.IsNumber(s[i]) || s[i] == ',')
                {
                    for(j = 0; j < s.Length-i; j++)
                    {
                        if(s[i + j] == ' ' || isOperator(s[i + j]))
                        {
                            j--;
                            break;
                        }

                        else if ((Char.IsNumber(s[i + j]) || s[i + j] == ','))
                        {
                            number += s[i + j];
                        }
                    }
                    stack.Push(number);
                    number = "";
                    i = i + j;
                }

            }
            while(stack.Count != 0)
            {
                result += stack.Pop();
            }
            return result;
        }

        private static bool isOperator(Char c)
        {
            if (c == '+' || c == '-' || c == '×' || c == '÷' || c == '^')
            {
                Console.WriteLine("[EVALUATION]: It's an operator.");
                return true;
            }
            else
            {
                Console.WriteLine("[EVALUATION]: It isn't an operator.");
                return false;
            }
        }

    }
}
