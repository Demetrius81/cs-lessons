using Lesson8.CalcChainOfResp.Exceptions;

namespace Lesson8;
internal sealed class CancelLast : Operation
{
    
    public CancelLast(
        Operation operation,
        ICalc calc,
        Func<Action<double>?, Action?, Func<bool>?, bool> func,
        Func<bool> quit,
        Func<bool> error
        ) : base(operation, calc, func, quit, error)
    {
        act = Calc.CancelLast;
        operationToExecList.Add(ConsoleKey.Backspace);
    }
    
}
