using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7;
internal class CalcApp
{
    private ICalc _calc;
    private const string FIRST_NUMBER_MSG = "first";
    private const string SECOND_NUMBER_MSG = "second";
    private double? firstNumber;
    private double secondNumber;
    public CalcApp()
    {
    }

    internal void RunApp()
    {
        firstNumber = InputNumber(FIRST_NUMBER_MSG);
        _calc = new Calc(firstNumber);
        bool run = true;
        _calc.CalcAdvancedEventHandler += _calc_CalcAdvancedEventHandler;

        while (run)
        {
            ConsoleKey operation = RequestToOperation();

            switch (true)
            {
                case true when (operation == ConsoleKey.Add || operation == ConsoleKey.OemPlus):
                    _ = CalculateNums(_calc.Sum, null, null);
                    break;
                case true when (operation == ConsoleKey.Subtract || operation == ConsoleKey.OemMinus):
                    _ = CalculateNums(_calc.Sub, null, null);
                    break;
                case true when (operation == ConsoleKey.Divide):
                    _ = CalculateNums(_calc.Div, null, null);
                    break;
                case true when (operation == ConsoleKey.Multiply):
                    _ = CalculateNums(_calc.Mult, null, null);
                    break;
                case true when (operation == ConsoleKey.Escape || operation == ConsoleKey.Spacebar):
                    run = CalculateNums(null, null, RequestToExit);
                    break;
                case true when (operation == ConsoleKey.Backspace):
                    _ = CalculateNums(null, _calc.CancelLast, null);
                    break;
                default:
                    run = CalculateNums(null, null, ErrorMessage);
                    break;
            }

        }
    }

    private void _calc_CalcAdvancedEventHandler(object? sender, string e)
    {
        if (sender is Calc)
        {
            double? temp = (sender as Calc)?.Result;
            Console.WriteLine($"{firstNumber} {e} {secondNumber} = {temp}");
            firstNumber = temp;
        }
    }

    private bool CalculateNums(Action<double>? action, Action? simpleAction, Func<bool>? func)
    {
        if (action is not null)
        {
            secondNumber = InputNumber(SECOND_NUMBER_MSG);
        }

        action?.Invoke(secondNumber);
        simpleAction?.Invoke();
        bool? isFunc = func?.Invoke();
        return isFunc ?? true;
    }

    private bool ErrorMessage()
    {
        Console.WriteLine("Waring! Something wrong! Push any button to exit program.");
        Console.ReadKey(true);
        return false;
    }

    private bool RequestToExit()
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

    private ConsoleKey RequestToOperation()
    {
        Console.WriteLine("Push operation symbol. This is a test project, supported only [+, -. *, /] symbols.");
        Console.WriteLine("Push Backspace to remove last operation.");
        Console.WriteLine("To exit push ESC or Spacebar.");
        ConsoleKey operation = Console.ReadKey(true).Key;

        bool isSupportedKey = (
            operation == ConsoleKey.Add ||
            operation == ConsoleKey.OemPlus ||
            operation == ConsoleKey.Subtract ||
            operation == ConsoleKey.OemMinus ||
            operation == ConsoleKey.Divide ||
            operation == ConsoleKey.Multiply ||
            operation == ConsoleKey.Escape ||
            operation == ConsoleKey.Backspace ||
            operation == ConsoleKey.Spacebar
            );

        if (isSupportedKey)
        {
            return operation;
        }
        else
        {
            throw new KeyNotFoundException("This key not supported.");
        }
    }

    private double InputNumber(string message)
    {
        Console.WriteLine($"Input {message} number and press enter:");
        Console.Write(">");

        if (double.TryParse(Console.ReadLine(), out double result))
        {
            return result;
        }
        else
        {
            throw new InvalidCastException("You enter not a number");
        }
    }
}
