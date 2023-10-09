
namespace Lesson1;

internal class Program
{
    protected Program()
    {
    }

    static void Main(string[] args)
    {
        Task1 task1 = new Task1();
        task1.Task(args);

    }

    

    /// <summary>Seminar tests</summary>
    private static void FunWitsArgs(string[] args)
    {
        if (args.Length > 1)
        {
            //int num1 = int.Parse(args[0]);
            //int num2 = int.Parse(args[1]);

            //int sum = num1 + num2;

            //Console.WriteLine($"{num1} + {num2} = {sum}");

            //for (int i = 0; i < args.Length; i++)
            //{
            //    Console.WriteLine($"args[{i}] = {args[i]}");
            //}

            //foreach (string arg in args)
            //{
            //    System.Console.WriteLine(arg);
            //}

            //Console.WriteLine(string.Join(", ", args));

            int[] array = Array.ConvertAll(args, int.Parse);

            int medium = array.Sum() / array.Length;

            //int sum = 0;

            //foreach (string arg in args)
            //{
            //    sum += int.Parse(arg);
            //}

            //int medium = sum / args.Length;

            Console.WriteLine($"medium = {medium}");
        }
        else
        {

            Console.WriteLine("test without args");
        }

        
    }
}
