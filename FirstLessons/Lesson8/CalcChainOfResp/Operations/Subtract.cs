using Lesson8.CalcChainOfResp.Exceptions;

namespace Lesson8;
internal sealed class Subtract : Operation
{
    public Subtract(
        Operation operation,
        ICalc calc,
        Func<Action<double>?, Action?, Func<bool>?, bool> func,
        Func<bool> quit,
        Func<bool> error
        ) : base(operation, calc, func, quit, error)
    {
        actParam = Calc.Sub;
        operationToExecList.Add(ConsoleKey.Subtract);
        operationToExecList.Add(ConsoleKey.OemMinus);
    }
}
