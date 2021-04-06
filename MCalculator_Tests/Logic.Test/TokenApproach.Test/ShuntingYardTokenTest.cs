using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Taschenrechner.Logic.TokenApproach;

namespace MCalculator_Tests.Logic.Test.TokenApproach.Test
{
    [TestClass]
    public class ShuntingYardTokenTest
    {
        private ShuntingYardToken shuntingYard = new ShuntingYardToken();

        [TestMethod]
        public void toPolishNotation_Test()
        {
            string input = "3+4×2÷(1-5)^2^3";

            List<Token> expectedOutput = createExpectedOutput(input);

            List<Token> actualOutput = shuntingYard.toPolishNotation(input);

            for (int  i = 0; i < expectedOutput.Count; i++)
            {
                Assert.AreEqual(expectedOutput[i].Value, actualOutput[i].Value);
            }

            //Assert.AreEqual(expectedOutput.Count, actualOutput.Count);
        }

        private List<Token> createExpectedOutput(string input)
        {
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

            return expectedOutput;
        }
    }
}
