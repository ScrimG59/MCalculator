namespace Taschenrechner.Logic.TokenApproach
{

    /// <summary>
    /// Each "Token" will either be a operator with a certain precedence and associativity, 
    /// a function, a number, a comma or a constant, which don't have any precedence or associativity
    /// </summary>
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
