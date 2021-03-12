using System;
using System.Text.RegularExpressions;

namespace Taschenrechner.Logic.TokenApproach
{

    public class TokenRule
    {
        private Regex _regex;
        private readonly TokenType _tokenType;

        /// <summary>
        /// A token Rule will have a Tokentype (such as Operator, Function etc.)
        /// and a regex-pattern which defines how a Tokentype looks like
        /// </summary>
        /// <param name="tokenType"></param>
        /// <param name="regexPattern"></param>
        public TokenRule(TokenType tokenType, string regexPattern)
        {
            _regex = new Regex(regexPattern);
            _tokenType = tokenType;
        }

        /// <summary>
        /// Determines if something matched a regex pattern or not
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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
