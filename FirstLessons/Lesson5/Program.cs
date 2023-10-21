
using Lesson5.Lection;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters;

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

        Task4();



    }

    private static void Task4()
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
            {1, 1, 1, 1, 1, 1, 1 },// 0 +------------>
            {1, 0, 0, 0, 0, 0, 1 },//   |            X
            {1, 0, 1, 1, 1, 0, 1 },//   |
            {0, 0, 0, 0, 1, 0, 2 },//   |
            {1, 1, 0, 0, 1, 1, 1 },//   |
            {1, 1, 1, 1, 1, 1, 1 },//   |
            {1, 1, 1, 1, 1, 1, 1 }//  Y V
        };

        bool isCanMoveLeft, isCanMoveRight, isCanMoveForward;

        var point = (y: 3, x: 0, value: 0);

        while (point.value != 2)
        {
            var front = labirynth1[point.y, point.x + 1];
            var left = labirynth1[point.y - 1, point.x];
            var right = labirynth1[point.y + 1, point.x];



            isCanMoveForward = (point.x + 1) > (labirynth1.GetLength(1) - 1) ? false : front == 0 || front == 2;
            isCanMoveLeft = (point.y - 1) < 0 ? false : left == 0 || left == 2;
            isCanMoveRight = (point.y + 1) > (labirynth1.GetLength(0) - 1) ? false : right == 0 || right == 2;

            Console.WriteLine($"X : {point.x}, Y : {point.y}");

            if (isCanMoveLeft)
            {
                TurnLeft(labirynth1);
                point = (point.y, point.x + 1, labirynth1[point.y, point.x + 1]);
                continue;
            }
            else if (isCanMoveForward)
            {
                point = (point.y, point.x + 1, labirynth1[point.y, point.x + 1]);
                continue;
            }
            else if (isCanMoveRight)
            {
                TurnRight(labirynth1);
                point = (point.y, point.x + 1, labirynth1[point.y, point.x + 1]);
                continue;
            }
            else
            {
                TurnRight(labirynth1);
                point = (point.y, point.x + 1, labirynth1[point.y, point.x + 1]);
                continue;
            }

        }

        Console.WriteLine($"X : {point.x}, Y : {point.y}");
    }


    public bool HasExsit(int startI, int startJ, int[,] l)
    {
        if (l[startI, startJ] == 1)
        {
            return false;
        }

        if (l[startI, startJ] == 2)
        {
            return true;
        }

        Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();

        while (stack.Count > 0)
        {
            var temp = stack.Pop();
            if (l[temp.Item1, temp.Item2] == 2)
            {
                return true;
            }

            l[temp.Item1, temp.Item2] = 1;
            if (temp.Item2 - 1 >= 0)
            {
                stack.Push(new(temp.Item1, temp.Item2 - 1));
            }
            if (temp.Item2 + 1 < l.GetLength(1))
            {
                stack.Push(new(temp.Item1, temp.Item2 + 1));
            }
            if (temp.Item1 - 1 >= 0)
            {
                stack.Push(new(temp.Item1 - 1, temp.Item2));
            }
            if (temp.Item2 + 1 < l.GetLength(0))
            {
                stack.Push(new(temp.Item1 + 1, temp.Item2));
            }

        }


    }

    private static int[,] TurnLeft(int[,] array)
    {
        int[,] result = new int[array.GetLength(0), array.GetLength(1)];

        for (int y = 0; y < array.GetLength(1); y++)
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                result[x, array.GetLength(1) - 1 - y] = array[y, x];
            }
        }

        return result;
    }

    private static int[,] TurnAround(int[,] array)
    {
        int[,] result = new int[array.GetLength(0), array.GetLength(1)];

        result = TurnLeft(array);

        return TurnLeft(result);
    }

    private static int[,] TurnRight(int[,] array)
    {
        int[,] result = new int[array.GetLength(0), array.GetLength(1)];

        for (int y = 0; y < array.GetLength(1); y++)
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                result[array.GetLength(1) - 1 - x, y] = array[y, x];
            }
        }

        return result;
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int y = 0; y < matrix.GetLength(1); y++)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                Console.Write(matrix[y, x] + " ");
            }
            Console.WriteLine();
        }
    }

    private static void Task3(List<int> ints)
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
