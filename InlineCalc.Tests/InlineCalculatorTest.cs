using System;
using Xunit;
using InlineCalc;
namespace InlineCalc.Tests
{
    public class InlineCalculatorTest
    {
        [Theory]
        [InlineData("1+7/5+54*9-2", 486.4)]
        [InlineData("9*8+45*2/6", 87)]
        [InlineData("49-8*49*6+2/89+65", -2237.98)]
        [InlineData("45*54+21-98/145+98", 2548.32)]

        public void CalculatorMustReturnExcpectedData(string input, double expected)
        {
            Assert.Equal(InlineCalculator.StringCalculator(input), expected);
        }
    }
}
