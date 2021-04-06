using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taschenrechner.Logic.TokenApproach;

namespace MCalculator_Tests.Logic.Test.TokenApproach.Test
{
    [TestClass]
    public class EvaluateInfixTokenTest
    {
        EvaluateInfixToken evaluateInfixToken = new EvaluateInfixToken();

        [TestMethod]
        public void evaluateTest()
        {
            string input = "3 4 2 × 1 5 - 2 3 ^ ^ ÷ +";
            string mode = "radiant";

            string expectedOutput = "3,0001220703125";

            string actualOutput = evaluateInfixToken.evaluate(input, mode);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
