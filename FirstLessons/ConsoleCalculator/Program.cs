namespace ConsoleCalculator;

internal class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();

        if (calculator.ValidateArgs(args))
        {
            var result = calculator.Calculate(args);
            Console.WriteLine($"{result.expression} = {result.result}");
        }
        else
        {
            Console.WriteLine("Entered bad arguments. Program is closed");
        }
    }
}
