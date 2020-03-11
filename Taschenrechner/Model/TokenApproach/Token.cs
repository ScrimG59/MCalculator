using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.Model.TokenApproach
{
    public class Token
    {
        public Token(TokenType tokenType, int precedence, int associativity, string value)
        {
            this.TokenType = tokenType;
            this.Precedence = precedence;
            this.Associativity = associativity;
            this.Value = value;
        }

        public TokenType TokenType { get; set; }
        public int Precedence { get; set; }
        public int Associativity { get; set; }
        public string Value { get; set; }
    }
}
