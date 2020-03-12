using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.Model.TokenApproach
{
    public class ShuntingYardToken
    {
        private List<Token> tokens = new List<Token>();
        private TokenRuleList trl = new TokenRuleList();
        private Stack<Token> operatorStack = new Stack<Token>();
        private List<Token> result = new List<Token>();

        /// <summary>
        /// Takes a string and converts it into polish notation
        /// </summary>
        /// <param name="s">A normal calculation</param>
        /// <returns>A list of tokens in polish notation</returns>
        public List<Token> toPolishNotation(string s)
        {
            Console.WriteLine($"[SHUNTING YARD] Input String: {s}");
            tokens.Clear();
            operatorStack.Clear();
            tokens = trl.Tokenize(s);


            foreach(var token in tokens)
            {
                if (token.TokenType.ToString().Equals("Number") || token.TokenType.ToString().Equals("Constant"))
                {
                    Console.WriteLine($"[SHUNTING YARD]Is a Number or a Constant: {token.Value}");
                    result.Add(token);
                }

                else if (token.TokenType.ToString().Equals("Function"))
                {
                    Console.WriteLine($"[SHUNTING YARD]: Is a function: {token.Value}");
                    operatorStack.Push(token);
                }

                else if (token.TokenType.ToString().Equals("Operator"))
                {
                    Console.WriteLine($"[SHUNTING YARD]: Is a Operator: {token.Value}");
                    while (operatorStack.Count != 0 && (operatorStack.Peek().TokenType.Equals("Function") 
                        || operatorStack.Peek().Precedence > token.Precedence 
                        || (operatorStack.Peek().Precedence == token.Precedence && token.Associativity == -1))
                        && operatorStack.Peek().Value != "(")
                    {
                        Console.WriteLine($"[SHUNTING YARD]: Popping operator into output queue: {token.Value}");
                        result.Add(operatorStack.Pop());
                    }

                    Console.WriteLine($"[SHUNTING YARD]: Pushing operator onto the operator stack: {token.Value}");
                    operatorStack.Push(token);
                }

                else if (token.Value.Equals("("))
                {
                    Console.WriteLine($"[SHUNTING YARD]: Is a left paren: {token.Value}");
                    operatorStack.Push(token);
                }

                else if (token.Value.Equals(")"))
                {
                    Console.WriteLine($"[SHUNTING YARD]: Is a right paren: {token.Value}");

                    while (operatorStack.Peek().Value != "(")
                    {
                        result.Add(operatorStack.Pop());
                    }

                    if(operatorStack.Peek().Value == "(")
                    {
                        operatorStack.Pop();
                    }
                }
            }
            while(operatorStack.Count != 0)
            {
                Console.WriteLine($"[SHUNTING YARD]: Popping remaining tokens out of the operator stack");
                result.Add(operatorStack.Pop());
            }

            return result;
        }
    }
}
