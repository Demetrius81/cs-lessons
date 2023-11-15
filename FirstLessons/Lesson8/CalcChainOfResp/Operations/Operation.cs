using Lesson8.CalcChainOfResp.Exceptions;

namespace Lesson8;
internal abstract class Operation
{
    internal Operation? NextInstance { get; init; }
    internal Func<Action<double>?, Action?, Func<bool>?, bool> Function { get; init; }
    internal ICalc Calc { get; init; }
    internal Func<bool> Quit { get; init; }
    internal Func<bool> Error { get; init; }
    protected Action? act = null;
    protected Action<double>? actParam = null;
    protected Func<bool>? funct = null;
    protected List<ConsoleKey> operationToExecList = new List<ConsoleKey>();

    protected Operation(Operation? operation,
                    ICalc calc,
                    Func<Action<double>?, Action?, Func<bool>?, bool> func,
                    Func<bool> quit,
                    Func<bool> error)
    {
        NextInstance = operation;
        Function = func;
        Quit = quit;
        Error = error;
        Calc = calc;
    }

    public virtual bool? Execute(ConsoleKey operation)
    {
        if (operationToExecList.Contains(operation))
        {
            try
            {
                return Function.Invoke(actParam, act, funct);
            }
            catch (CalculatorDivideByZeroException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            catch (CalculatorException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        else
        {
            return NextInstance?.Execute(operation);
        }
    }
}
