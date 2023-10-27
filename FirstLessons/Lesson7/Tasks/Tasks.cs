
using System;
using System.Threading.Channels;

namespace Lesson7;
internal class Tasks
{
    internal delegate void MyDelegade(string message);

    internal void Task1()
    {
        List<Action> list = new();
        for (int i = 0; i < 10; i++)
        {
            int j = i + 1;
            list.Add(() => Console.WriteLine("Delegate action is run " + j));
        }

        RunDelegadeList(list);

        List<MyDelegade> listMy = new()
        {
            (msg) => Console.WriteLine($"1 delegade {msg}"),
            (msg) => Console.WriteLine($"2 delegade {msg}")
        };
        RunMyDelegadeList(listMy);

    }

    internal void RunDelegadeList(List<Action> list)
    {
        list.ForEach(x => x.Invoke());
    }

    internal void RunMyDelegadeList(List<MyDelegade> list)
    {
        list.ForEach(x => x.Invoke("test"));
    }

    internal void Task2()
    {
        Calc calc = new Calc();
        calc.CalcEventHandler += Calc_CalcEventHandler;
        calc.Sum(7);
        calc.Sub(3);
        calc.Div(2);
        calc.Mult(3);
        calc.CancelLast();
        calc.CancelLast();
        calc.CancelLast();
        calc.CancelLast();
    }

    private void Calc_CalcEventHandler(object? sender, EventArgs e)
    {
        if (sender is Calc)
        {
            Console.WriteLine((sender as Calc)?.Result);
        }
    }

    internal void Task3()
    {
        // Описание: Создайте метод, который принимает
        // список строк,
        // функцию(делегат Func) для преобразования строк в числа
        // и действие(делегат Action) для выполнения какого - либо действия с числами.

        List<string> strings = new List<string>() { "1", "2", "3", "4"};
        CalculateWithStrings(strings, int.Parse, Console.WriteLine);
    }

    private void CalculateWithStrings(List<string> list, Func<string, int> func, Action<int> action)
    {
        list.ForEach((x) => action(func(x)));
    }

    internal void Task4()
    {
        //Описание: Создайте метод, который принимает
        //список чисел
        //и предикат(делегат Predicate), который определяет, соответствует ли каждое число какому-либо условию.

        List<string> strings = new List<string>() { "17", "21", "30", "40", "5" };
        IsAdult(strings, int.Parse, x => x >= 18,  Console.WriteLine);
    }

    private void IsAdult(List<string> strings, Func<string, int> func, Predicate<int> predicate, Action<int> action)
    {
        foreach (string str in strings)
        {
            int num = func(str);
            if (predicate(num))
            {
                action(num);
            }
        }
    }
}
