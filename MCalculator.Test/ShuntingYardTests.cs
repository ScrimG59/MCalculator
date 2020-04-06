using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taschenrechner.Model.TokenApproach;

namespace MCalculator.Test
{
    [TestClass]
    public class ShuntingYardTests
    {
        private ShuntingYardToken _shuntingYardToken = new ShuntingYardToken();

        [TestMethod]
        public void toPolishNotationTestPlus()
        {
            // arrange
            string input = "236 + 69,453545353453";

            // act
            var result = _shuntingYardToken.toPolishNotation(input);
            var endResult = "";

            foreach (var token in result)
            {
                endResult += token.Value + " ";
            }

            // assert
            Assert.AreEqual("236 69,453545353453 + ", endResult);
        }

        [TestMethod]
        public void toPolishNotationTestMinus()
        {
            // arrange
            string input = "36476 - (47756 - 2)";

            // act
            var result = _shuntingYardToken.toPolishNotation(input);
            var endResult = "";

            foreach (var token in result)
            {
                endResult += token.Value + " ";
            }

            // assert
            Assert.AreEqual("36476 47756 2 - - ", endResult);
        }

        [TestMethod]
        public void toPolishNotationTestMulti()
        {
            // arrange
            string input = "32323 × 2,5776";

            // act
            var result = _shuntingYardToken.toPolishNotation(input);
            var endResult = "";

            foreach (var token in result)
            {
                endResult += token.Value + " ";
            }

            // assert
            Assert.AreEqual("32323 2,5776 × ", endResult);
        }

        [TestMethod]
        public void toPolishNotationTestDiv()
        {
            // arrange
            string input = "3434,856685 ÷ 38,65678";

            // act
            var result = _shuntingYardToken.toPolishNotation(input);
            var endResult = "";

            foreach (var token in result)
            {
                endResult += token.Value + " ";
            }

            // assert
            Assert.AreEqual("3434,856685 38,65678 ÷ ", endResult);
        }

        [TestMethod]
        public void toPolishNotationTestMixed()
        {
            // arrange
            string input = "cos(3453,3434 ÷ 232) ÷ sin(2)^(2,56544^(π+e))";

            // act
            var result = _shuntingYardToken.toPolishNotation(input);
            var endResult = "";

            foreach (var token in result)
            {
                endResult += token.Value + " ";
            }

            // assert
            Assert.AreEqual("3453,3434 232 ÷ 2 2,56544 π e + ^ ^ sin ÷ cos ", endResult);
        }
    }
}
