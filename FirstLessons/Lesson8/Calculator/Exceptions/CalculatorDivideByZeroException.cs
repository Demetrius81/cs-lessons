namespace Lesson8;
internal class CalculatorDivideByZeroException : CalculatorException
{
    public CalculatorDivideByZeroException() : base() { }
    public CalculatorDivideByZeroException(string message) : base(message) { }
}
