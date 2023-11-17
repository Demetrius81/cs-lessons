using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8;
internal class CalculatorWrongArgumentException : CalculatorException
{
    public CalculatorWrongArgumentException() : base() { }
    public CalculatorWrongArgumentException(string message) : base(message) { }
}
