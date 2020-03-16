using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    /// <summary>
    /// Defines the various types that occur in mathematic calculations
    /// </summary>
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
