﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8;
internal class CalculatorResultIsLessThanZeroException : CalculatorException
{
    public CalculatorResultIsLessThanZeroException() : base() { }
    public CalculatorResultIsLessThanZeroException(string message) : base(message) { }
}
