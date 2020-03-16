using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.Model.TokenApproach
{
    public class TokenRuleList
    {
        public List<TokenRule> tokenRules = new List<TokenRule>();

        /// <summary>
        /// Adds what each TokenType "looks like" with an regex pattern into a list
        /// </summary>
        public TokenRuleList()
        {
            tokenRules.Add(new TokenRule(TokenType.Constant, "^e|^π"));
            tokenRules.Add(new TokenRule(TokenType.Function, "^sin|^cos|^exp|^log|^tan|^ln|^√"));
            tokenRules.Add(new TokenRule(TokenType.Number, "^\\d+,\\d+|^\\d+")); 
            tokenRules.Add(new TokenRule(TokenType.Operator, "^\\+|^\\-|^\\×|^\\÷|^\\^"));
            tokenRules.Add(new TokenRule(TokenType.Parenthesis, "^\\(|^\\)"));
            tokenRules.Add(new TokenRule(TokenType.Space, "\\s"));
        }

        /// <summary>
        /// The main algorithm that turns the input string into a List of Tokens 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public List<Token> Tokenize(string s)
        {
            List<Token> tokens = new List<Token>();
            string tempString = s;
            tokens.Clear();

            while (tempString != "")
            {
                var match = FindMatch(tempString);

                if (match.IsMatching)
                {
                    string val = match.Value;
                    string type = match.Type.ToString();
                    // If the match is a operator add a new token with given precedence and associativity
                    if (type.Equals("Operator"))
                    {
                        switch (val)
                        {
                            case "+":
                                tokens.Add(new Token(match.Type, 2, -1, val));
                                Console.WriteLine($"[TOKENIZER] TOKEN ADDED: {val} with PRECEDENCE: 2");
                                tempString = match.TempString;
                                break;
                            case "-":
                                tokens.Add(new Token(match.Type, 2, -1, val));
                                Console.WriteLine($"[TOKENIZER] TOKEN ADDED: {val} with PRECEDENCE: 2");
                                tempString = match.TempString;
                                break;
                            case "×":
                                tokens.Add(new Token(match.Type, 3, -1, val));
                                Console.WriteLine($"[TOKENIZER] TOKEN ADDED: {val} with PRECEDENCE: 3");
                                tempString = match.TempString;
                                break;
                            case "÷":
                                tokens.Add(new Token(match.Type, 3, -1, val));
                                Console.WriteLine($"[TOKENIZER] TOKEN ADDED: {val} with PRECEDENCE: 3");
                                tempString = match.TempString;
                                break;
                            case "^":
                                tokens.Add(new Token(match.Type, 4, 1, val));
                                Console.WriteLine($"[TOKENIZER] TOKEN ADDED: {val} with PRECEDENCE: 4");
                                tempString = match.TempString;
                                break;
                        }
                    }

                    // If it's a Space, just skip it
                    else if(type.Equals("Space"))
                    {
                        Console.WriteLine($"[TOKENIZER] TOKEN SKIPPED: {val}");
                        tempString = match.TempString;
                    }
                    // Otherwise it's a number, a constant, a function, a comma, or a (left/right) bracket
                    else
                    {
                        tokens.Add(new Token(match.Type, 0, 0, val));
                        Console.WriteLine($"[TOKENIZER] TOKEN ADDED: {val} with PRECEDENCE: 0");
                        tempString = match.TempString;
                    }
                }
                else
                {
                    // If "match" doesn't match any TokenType, just skip it and go on
                    tempString = tempString.Substring(1);
                }
            }
            return tokens;
        }

        /// <summary>
        /// Looks for a matching rule within the Rules-List for the input string
        /// </summary>
        /// <param name="tempString"></param>
        /// <returns></returns>
        public TokenMatch FindMatch(string tempString)
        {
            // goes through every rule in tokenRules and if there's a matching rule it'll be returned
            foreach (var tokenRule in tokenRules)
            {
                var match = tokenRule.Match(tempString);
                if (match.IsMatching)
                {
                    return match;
                }
            }

            return new TokenMatch()
            {
                IsMatching = false
            };
        }
    }
}
