using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.Model
{
    public class TokenMatch
    {
        public bool IsMatching { get; set; }
        public TokenType Type { get; set; }
        public string Value { get; set; }
        public string TempString { get; set; }
    }
}
