
using Lesson5.Lection;

namespace Lesson5;

internal class Program
{
    static void Main(string[] args)
    {
        //ExampleStack.Run(args);

        //List<int> ints = new List<int> { 0, 1, 1, -1, 101, 102, 101, 11, 1111, 11 };

        //ints.Distinct().ToList().ForEach(i => Console.Write(i + " "));
        //Console.WriteLine();

        //RemoveDubles1(ints);
        //RemoveDubles2(ints);


        List<int> ints = new List<int> { 1, 2, 2, 2, 3, 4, 4, 5, 5, 5, 5, 6, 7, 0 };

        Task2(ints);
        

    }

    private static void Task2(List<int> ints)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();

        foreach (var x in ints)
        {
            if (dic.ContainsKey(x))
            {
                dic[x]++;
            }
            else
            {
                dic.Add(x, 1);
            }
        }
        var intsN = new List<int>();

        var dict2 = dic.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        foreach (var item in dict2.Keys)
        {
            for (int i = 0; i < dict2[item]; i++)
            {
                intsN.Add(item);
            }
        }

        intsN.ForEach(x => { Console.WriteLine(x); });
    }

    private static void RemoveDubles1(List<int> ints)
    {
        HashSet<int> set = new HashSet<int>(ints);
        List<int> result = new List<int>(set);
        result.ForEach(i => Console.Write(i + " "));
        Console.WriteLine();
    }

    private static void RemoveDubles2(List<int> ints)
    {
        for (int i = 0; i < ints.Count; i++)
            for (int j = i + 1; j < ints.Count; j++)
                if (ints[i] == ints[j])
                    ints.RemoveAt(j);

        ints.ForEach(i => Console.Write(i + " "));
        Console.WriteLine();

    }

    //Дан список целых чисел(числа не последовательны), в котором некоторые числа повторяются.Выведите список чисел на экран, расположив их в порядке возрастания частоты повторения

}
