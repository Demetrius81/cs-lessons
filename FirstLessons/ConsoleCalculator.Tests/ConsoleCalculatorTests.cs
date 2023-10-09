namespace ConsoleCalculator.Tests;

public class Tests
{
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
       _calculator = new Calculator();
    }

    //[TestCase(new string[] { "2", "+", "3", "*", "5", "/", "5", "-", "4" }, ExpectedResult = true)]
    //[TestCase(new string[] { "2", "r", "3", "*", "5", "/", "5", "-", "4" }, ExpectedResult = false)]
    //public bool ValidateArgs_CorrectExpressions_ExpectTrue_Test1(string[] str) => _calculator.ValidateArgs(str);
}