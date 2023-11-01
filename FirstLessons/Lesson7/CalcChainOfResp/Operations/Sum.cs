﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.CalcChainOfResp.Operations;
internal sealed class Sum : Operation
{
    public Sum(Operation operation) : base(operation)
    {
    }

    public override void Execute(ConsoleKey operation, ICalc calc, double x)
    {
        if (operation == ConsoleKey.Add || operation == ConsoleKey.OemPlus)
        {
            calc.Sum(x);
        } 
        else
        { 
            NextInstance?.Execute(operation, calc, x);
        }
    }
}
