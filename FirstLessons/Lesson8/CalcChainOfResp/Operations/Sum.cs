using Lesson8.CalcChainOfResp.Exceptions;

namespace Lesson8;
internal sealed class Sum : Operation
{
    public Sum(
        Operation operation,
        ICalc calc,
        Func<Action<double>?, Action?, Func<bool>?, bool> func,
        Func<bool> quit,
        Func<bool> error
        ) : base(operation, calc, func, quit, error)
    {
        actParam = Calc.Sum;
        operationToExecList.Add(ConsoleKey.Add);
        operationToExecList.Add(ConsoleKey.OemPlus);
    }
}
