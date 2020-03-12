using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Taschenrechner.Model;

namespace Taschenrechner
{

    public class TokenRule
    {
        private Regex _regex;
        private readonly TokenType _tokenType;

        public TokenRule(TokenType tokenType, string regexPattern)
        {
            _regex = new Regex(regexPattern);
            _tokenType = tokenType;
        }

        public TokenMatch Match(string s)
        {
            var match = _regex.Match(s);
            if (match.Success)
            {
                string tempString = "";
                if (match.Length != s.Length)
                {
                    tempString = s.Substring(match.Length);
                    Console.WriteLine($"[TOKENMATCH] Remaining text: {tempString}");
                }

                return new TokenMatch()
                {
                    IsMatching = true,
                    Type = _tokenType,
                    Value = match.Value,
                    TempString = tempString
                };
            }
            else
            {
                return new TokenMatch()
                {
                    IsMatching = false
                };
            }
        }
    }
}
