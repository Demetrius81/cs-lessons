using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8;
internal class CalculatorException : Exception
{
    public CalculatorException() : base() { }
    public CalculatorException(string message) : base(message) { }
    public CalculatorException(string message, Exception ex) : base(message, ex) { }
}
