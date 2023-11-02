using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5;
internal class Tasks
{
    internal static void Task3(List<int> ints)
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

        dic = dic.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        foreach (var item in dic.Keys)
        {
            for (int i = 0; i < dic[item]; i++)
            {
                intsN.Add(item);
            }
        }

        intsN.ForEach(x => { Console.Write(x + " "); });
        Console.WriteLine();
    }

    internal static void Task2(List<int> ints)
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

        dic = dic.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        foreach (var item in dic.Keys)
        {
            for (int i = 0; i < dic[item]; i++)
            {
                intsN.Add(item);
            }
        }

        intsN.ForEach(x => { Console.Write(x + " "); });
        Console.WriteLine();
    }

    internal static void Task1()
    {
        List<int> ints = new List<int> { 0, 1, 1, -1, 101, 102, 101, 11, 1111, 11 };

        ints.Distinct().ToList().ForEach(i => Console.Write(i + " "));
        Console.WriteLine();
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

    internal static void Task4()
    {
        //        Есть лабиринт описанный в виде двумерного массива где 1 это стены, 0 - проход, 2 - искомая цель.
        //Пример лабиринта:
        //1 1 1 1 1 1 1
        //1 0 0 0 0 0 1
        //1 0 1 1 1 0 1
        //0 0 0 0 1 0 2
        //1 1 0 0 1 1 1
        //1 1 1 1 1 1 1
        //1 1 1 1 1 1 1
        //Напишите алгоритм определяющий наличие выхода из лабиринта и выводящий на экран координаты точки выхода если таковые имеются.
        int[,] labirynth1 = new int[,]
        {
            {1, 1, 1, 2, 1, 1, 1 },// 0 +------------>
            {1, 0, 0, 0, 0, 0, 1 },//   |            X
            {1, 0, 1, 1, 1, 0, 1 },//   |
            {0, 0, 0, 0, 1, 0, 2 },//   |
            {1, 1, 0, 0, 1, 1, 1 },//   |
            {1, 1, 0, 1, 1, 1, 1 },//   |
            {1, 1, 2, 1, 1, 1, 1 }//  Y V
        };


        var result0 = Labyrinth.HasExit(1, 1, labirynth1);
        Console.WriteLine($"Count = {result0}");

        var result = Labyrinth.HasExitPromoutedHW(1, 1, labirynth1);

        if (result.exitsCount > 0)
        {
            Console.WriteLine($"Count = {result.exitsCount}");
            Console.WriteLine("Coordinates:");

            foreach (var item in result.coordinates)
            {
                Console.WriteLine(item);
            }

        }
        else
        {
            Console.WriteLine("No exit");
        }

        //var result2 = Labyrinth.HasExitPromouted(1, 1, labirynth1);
        //string error = "No exit";
        //Console.WriteLine($"{result2.hasExit}, {(result2.hasExit ? result2.coordinates : error)}");
    }
}
