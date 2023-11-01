namespace Lesson7;

internal class Program
{
    static void Main(string[] args)
    {
        //ConsoleKeyInfo item = Console.ReadKey(true);
        //Console.WriteLine(item.Key);
        //Console.ReadKey(true);

        //Tasks tasks = new Tasks();
        //tasks.Task2();

        CalcApp calcApp = new();
        calcApp.RunApp();
    }
}
