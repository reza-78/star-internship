using SimpleCalculator.Business;
using SimpleCalculator.Business.Enums;

namespace SimpleCalculator.Tests;

public class CalculatorTest
{
    [Theory]
    [InlineData(23, 32, OperatorEnum.sum, 55)]
    [InlineData(33, 23, OperatorEnum.sub, 10)]
    [InlineData(10, 10, OperatorEnum.multiply, 100)]
    [InlineData(20, 5, OperatorEnum.division, 4)]
    public void TestTrueResults(int firstNum, int secNum, OperatorEnum oprType, int expected)
    {
        var calculator = new Calculator();
        
        Assert.Equal(expected, calculator.Calculate(firstNum, secNum, oprType));
    }

    [Theory]
    [InlineData(23, 0, OperatorEnum.division, typeof(DivideByZeroException))]
    public void TestExceptions(int firstNum, int secNum, OperatorEnum oprType, Type exceptionType)
    {
        var calculator = new Calculator();
        Assert.Throws(exceptionType, () => calculator.Calculate(firstNum, secNum, oprType));
    }
}