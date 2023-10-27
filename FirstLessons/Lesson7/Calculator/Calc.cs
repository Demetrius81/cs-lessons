using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7;
internal class Calc : ICalc
{
    private Stack<double> _lastStack;

    internal Calc()
    {
        Result = 0;
        _lastStack = new Stack<double>();
    }

    public event EventHandler<EventArgs> CalcEventHandler;

    public double Result { get; private set; }

    public void Sum(double x)
    {
        _lastStack.Push(Result);
        Result += x;
        PrintResult();
    }

    public void Sub(double x)
    {
        _lastStack.Push(Result);
        Result -= x;
        PrintResult();
    }

    public void Div(double x)
    {
        if (x == 0)
        {
            throw new ArithmeticException("Divide by zero");
        }

        _lastStack.Push(Result);
        Result /= x;
        PrintResult();
    }

    public void Mult(double x)
    {
        _lastStack.Push(Result);
        Result *= x;
        PrintResult();
    }

    public void CancelLast()
    {
        if (_lastStack.TryPop(out double x))
        {
            Result = x;
            PrintResult();
        }
    }

    private void PrintResult()
    {
        CalcEventHandler?.Invoke(this, new EventArgs());
    }

}
