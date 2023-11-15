using Lesson8.CalcChainOfResp.Exceptions;

namespace Lesson8;
internal sealed class ErrorMessage : Operation
{
    public ErrorMessage(Operation operation,
        ICalc calc,
        Func<Action<double>?, Action?, Func<bool>?, bool> func,
        Func<bool> quit,
        Func<bool> error)
        : base(operation, calc, func, quit, error)
    {
        funct = this.Error;
        operationToExecList.Add(ConsoleKey.F24);
    }
}
