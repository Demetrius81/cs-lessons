using Lesson8.CalcChainOfResp.Exceptions;

namespace Lesson8;
internal sealed class Quit : Operation
{
    public Quit(
        Operation operation,
        ICalc calc,
        Func<Action<double>?, Action?, Func<bool>?, bool> func,
        Func<bool> quit,
        Func<bool> error
        ) : base(operation, calc, func, quit, error)
    {
        funct = Quit;
        operationToExecList.Add(ConsoleKey.Escape);
        operationToExecList.Add(ConsoleKey.Spacebar);
    }
}
