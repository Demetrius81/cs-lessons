namespace Lesson8;

internal abstract class CalcAppBase
{
    protected const string FIRST_NUMBER_MSG = "first";
    protected const string SECOND_NUMBER_MSG = "second";
    protected readonly List<ConsoleKey> _supportedConsoleKeys;
    protected ICalc? _calc;
    protected double? _firstNumber;
    protected double _secondNumber;

    protected CalcAppBase()
    {
        _supportedConsoleKeys = new List<ConsoleKey>()
        {
            ConsoleKey.Add,
            ConsoleKey.OemPlus,
            ConsoleKey.Subtract,
            ConsoleKey.OemMinus,
            ConsoleKey.Divide,
            ConsoleKey.Multiply,
            ConsoleKey.Escape,
            ConsoleKey.Spacebar,
            ConsoleKey.Backspace
        };
    }

    internal abstract void RunApp();

    protected static double InputNumber(string message)
    {
        Console.WriteLine($"Input {message} number and press enter:");
        Console.Write(">");

        if (DoubleTryPars(Console.ReadLine(), out double result) && result >= 0)
        {
            return result;
        }
        else
        {
            throw new CalculatorWrongArgumentException("You enter wrong argument");
        }
    }

    protected static bool DoubleTryPars(string value, out double result)
    {
        double parced = default;
        bool isCorrect = false;
        try
        {
            parced = Convert.ToDouble(value);
            isCorrect = true;
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.ToString());
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            result = parced;
        }

        return isCorrect;
    }

    protected bool CalculateNums(Action<double>? action, Action? simpleAction, Func<bool>? func)
    {
        if (action is not null)
        {
            _secondNumber = InputNumber(SECOND_NUMBER_MSG);
        }

        action?.Invoke(_secondNumber);
        simpleAction?.Invoke();
        bool? isFunc = func?.Invoke();
        return isFunc ?? true;
    }

    protected void Calc_CalcAdvancedEventHandler(object? sender, string e)
    {
        if (sender is Calc)
        {
            double? temp = (sender as Calc)?.Result;
            Console.WriteLine($"{_firstNumber} {e} {_secondNumber} = {temp}");
            _firstNumber = temp;
        }
    }

    protected bool ErrorMessage()
    {
        Console.WriteLine("Waring! Something wrong! Push any button to exit program.");
        Console.ReadKey(true);
        return false;
    }

    protected bool RequestToExit()
    {
        while (true)
        {
            Console.Write("Do you really want to quit this wonderful program?\r\nPress Y button to exit and N button to continue >");
            var key = Console.ReadKey(true).Key;
            Console.WriteLine();

            if (key == ConsoleKey.Y)
            {
                return false;
            }
            else if (key == ConsoleKey.N)
            {
                return true;
            }

            Console.WriteLine("You miss the button");
        }
    }

    protected ConsoleKey RequestToOperation()
    {
        Console.WriteLine("Push operation symbol. This is a test project, supported only [+, -. *, /] symbols.");
        Console.WriteLine("Push Backspace to remove last operation.");
        Console.WriteLine("To exit push ESC or Spacebar.");
        ConsoleKey operation = Console.ReadKey(true).Key;

        if (_supportedConsoleKeys.Contains(operation))
        {
            return operation;
        }
        else
        {
            throw new KeyNotFoundException("This key not supported.");
        }
    }
}