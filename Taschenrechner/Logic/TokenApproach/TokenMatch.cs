namespace Taschenrechner.Logic.TokenApproach
{
    /// <summary>
    /// The token match class has the attribute "IsMatching" to determine on the main algorithm, 
    /// if something matched a Tokentype or not.
    /// TokenType and Value are self-explaining
    /// TempString is just the remaining text, after something matched
    /// </summary>
    public class TokenMatch
    {
        public bool IsMatching { get; set; }
        public TokenType Type { get; set; }
        public string Value { get; set; }
        public string TempString { get; set; }
    }
}
