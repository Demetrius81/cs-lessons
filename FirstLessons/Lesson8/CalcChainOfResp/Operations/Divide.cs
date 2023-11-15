using Lesson8.CalcChainOfResp.Exceptions;

namespace Lesson8;
internal sealed class Divide : Operation
{
    public Divide(
        Operation operation,
        ICalc calc,
        Func<Action<double>?, Action?, Func<bool>?, bool> func,
        Func<bool> quit,
        Func<bool> error
        ) : base(operation, calc, func, quit, error)
    {
        actParam = Calc.Div;
        operationToExecList.Add(ConsoleKey.Divide);
    }
}
