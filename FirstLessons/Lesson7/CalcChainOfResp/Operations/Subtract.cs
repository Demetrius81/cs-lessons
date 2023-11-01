using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.CalcChainOfResp.Operations;
internal class Subtract : Operation
{
    public Subtract(Operation operation) : base(operation)
    {
    }

    public override void Execute(ConsoleKey operation, ICalc calc, double x)
    {
        if (operation == ConsoleKey.Subtract || operation == ConsoleKey.OemMinus)
        {
            calc.Sub(x);
        }
        else
        {
            NextInstance?.Execute(operation, calc, x);
        }
    }
}
