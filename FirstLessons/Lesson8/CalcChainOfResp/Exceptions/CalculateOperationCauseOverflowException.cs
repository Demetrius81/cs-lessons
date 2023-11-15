using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.CalcChainOfResp.Exceptions;
internal class CalculateOperationCauseOverflowException : CalculatorException
{
    public CalculateOperationCauseOverflowException() : base() { }
    public CalculateOperationCauseOverflowException(string message) : base(message) { }
}
