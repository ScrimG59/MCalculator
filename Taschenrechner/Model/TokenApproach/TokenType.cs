using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    public enum TokenType
    {
        Number,
        Operator,
        Constant,
        Function,
        Parenthesis,
        Space
    }
}
