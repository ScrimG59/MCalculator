using NUnit.Framework;
using System.Collections.Generic;
using Taschenrechner.Logic.TokenApproach;

namespace MCalculator.Test.Logic.Test.TokenApproach.Test
{ 
    public class ShuntingYardTokenTest
    {
        ShuntingYardToken shuntingYard = new ShuntingYardToken();
        
        [Test]
        public void toPolishNotation_Test()
        {
            string input = "3+4×2÷(1−5)^2^3";

            List<Token> expectedOutput = new List<Token>()
            {
                new Token(TokenType.Number, 0, 0, "3"),
                new Token(TokenType.Number, 0, 0, "4"),
                new Token(TokenType.Number, 0, 0, "2"),
                new Token(TokenType.Operator, 3, -1, "×"),
                new Token(TokenType.Number, 0, 0, "1"),
                new Token(TokenType.Number, 0, 0, "5"),
                new Token(TokenType.Operator, 2, -1, "-"),
                new Token(TokenType.Number, 0, 0, "2"),
                new Token(TokenType.Number, 0, 0, "3"),
                new Token(TokenType.Operator, 4, 1, "^"),
                new Token(TokenType.Operator, 4, 1, "^"),
                new Token(TokenType.Operator, 3, -1, "÷"),
                new Token(TokenType.Operator, 2, -1, "+"),
            };

            List<Token> actualOutput = shuntingYard.toPolishNotation(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
