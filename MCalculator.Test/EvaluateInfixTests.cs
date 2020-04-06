using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taschenrechner.Model.TokenApproach;

namespace MCalculator.Test
{
    [TestClass]
    public class EvaluateInfixTests
    {
        private EvaluateInfixToken _evaluateInfixToken = new EvaluateInfixToken();

        [TestMethod]
        public void evaluatePlus()
        {
            // arrange
            string input = "236 69,453545353453 + ";
            string mode = "degree";

            // act
            var result = _evaluateInfixToken.evaluate(input, mode);

            // assert
            Assert.AreEqual("305,45355454", result);
        }

        [TestMethod]
        public void evaluateMinus()
        {
            // arrange
            string input = "36476 - (47756 - 2)";
            string mode = "degree";

            // act
            var result = _evaluateInfixToken.evaluate(input, mode);

            // assert
            Assert.AreEqual("-11278", result);
        }

        [TestMethod]
        public void evaluateMulti()
        {
            // arrange
            string input = "32323 2,5776 × ";
            string mode = "degree";

            // act
            var result = _evaluateInfixToken.evaluate(input, mode);

            // assert
            Assert.AreEqual("83315,7648", result);
        }

        [TestMethod]
        public void evaluateDiv()
        {
            // arrange
            string input = "3434,856685 38,65678 ÷ ";
            string mode = "degree";

            // act
            var result = _evaluateInfixToken.evaluate(input, mode);

            // assert
            Assert.AreEqual("88,85521983", result);
        }

        [TestMethod]
        public void evaluateMixedDegree()
        {
            // arrange
            string input = "3 4 2 × 1 5 − 2 3 ^ ^ ÷ +";
            string mode = "degree";

            // act
            var result = _evaluateInfixToken.evaluate(input, mode);

            // assert
            Assert.AreEqual("3,00012207", result);
        }

        [TestMethod]
        public void evaluateMixedRadiant()
        {
            // arrange
            string input = "3453,3434 232 ÷ 2 2,56544 π e + ^ ^ sin ÷ cos ";
            string mode = "radiant";

            // act
            var result = _evaluateInfixToken.evaluate(input, mode);

            // assert
            Assert.AreEqual("305,45355454", result);
        }
    }
}
