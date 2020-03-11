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
        public TokenRuleList()
        {
            tokenRules.Add(new TokenRule(TokenType.Constant, "^e|^π"));
            tokenRules.Add(new TokenRule(TokenType.Function, "^sin|^cos|^exp"));
            tokenRules.Add(new TokenRule(TokenType.Number, "^\\d+,\\d+|^\\d+")); 
            tokenRules.Add(new TokenRule(TokenType.Operator, "^\\+|^\\-|^×|^÷|^\\^"));
            tokenRules.Add(new TokenRule(TokenType.Parenthesis, "^\\(|^\\)"));
            tokenRules.Add(new TokenRule(TokenType.Space, "\\s"));
        }

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
                    if (type.Equals("Operation"))
                    {
                        switch (val)
                        {
                            case "+":
                                tokens.Add(new Token(match.Type, 2, -1, val));
                                tempString = match.TempString;
                                break;
                            case "-":
                                tokens.Add(new Token(match.Type, 2, -1, val));
                                tempString = match.TempString;
                                break;
                            case "*":
                                tokens.Add(new Token(match.Type, 3, -1, val));
                                tempString = match.TempString;
                                break;
                            case "/":
                                tokens.Add(new Token(match.Type, 3, -1, val));
                                tempString = match.TempString;
                                break;
                            case "^":
                                tokens.Add(new Token(match.Type, 4, 1, val));
                                tempString = match.TempString;
                                break;
                        }
                    }
                    else if(type.Equals("Space"))
                    {
                        tempString = match.TempString;
                    }
                    else
                    {
                        tokens.Add(new Token(match.Type, 0, 0, val));
                        tempString = match.TempString;
                    }
                }
                else
                {
                    tempString = tempString.Substring(1);
                }
            }
            return tokens;
        }

        public TokenMatch FindMatch(string tempString)
        {
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
