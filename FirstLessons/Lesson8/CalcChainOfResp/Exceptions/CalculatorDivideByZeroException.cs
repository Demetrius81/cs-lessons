namespace Lesson8.CalcChainOfResp.Exceptions;
internal class CalculatorDivideByZeroException : CalculatorException
{
    public CalculatorDivideByZeroException() : base() { }
    public CalculatorDivideByZeroException(string message) : base(message) { }
}
