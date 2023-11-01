using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.CalcChainOfResp.Operations;
internal class Quit : Operation
{
    public Quit(Operation operation) : base(operation)
    {
    }

    public override void Execute(ConsoleKey operation, ICalc calc, double x)
    {
        if (operation == ConsoleKey.Escape || operation == ConsoleKey.Spacebar)
        {
            //calc.Sum(x);
        }
        else
        {
            NextInstance?.Execute(operation, calc, x);
        }
    }
}
