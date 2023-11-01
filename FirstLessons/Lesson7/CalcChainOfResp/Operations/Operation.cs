using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.CalcChainOfResp.Operations;
internal abstract class Operation
{
    internal Operation NextInstance { get; private set; }

    public Operation(Operation operation)
    {
        NextInstance = operation;
    }

    public abstract void Execute(ConsoleKey operation, ICalc calc, double x);
}
