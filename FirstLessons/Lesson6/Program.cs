namespace Lesson6;

internal class Program
{
    static void Main(string[] args)
    {
        List<int> ints = new List<int> { 1, 2, 3, 14, 5, 46, 7, 8, 9, 10, 4, 18, 6, };
        int target = 78;

        var result = FindNumbers.FindThreeNumbersHashSet(ints, target);
        Console.WriteLine($"{result.firstNumber} + {result.secondNumber} + {result.thirdNumber} = {target}");

        var result2 = FindNumbers.FindThreeNumbersFromChatGPT(ints, target);
        Console.WriteLine($"{result2.firstNumber} + {result2.secondNumber} + {result2.thirdNumber} = {target}");

        var result3 = FindNumbers.FindThreeNumbersLoop(ints, target);
        Console.WriteLine($"{result3.firstNumber} + {result3.secondNumber} + {result3.thirdNumber} = {target}");

    }
}
