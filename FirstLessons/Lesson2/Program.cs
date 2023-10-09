using System.Text;

namespace Lesson2;

internal class Program
{
    static void Main(string[] args)
    {
        Tasks tasks = new Tasks();
        tasks.Task7();
    }


}

class Tasks
{
    //    Написать программу, подсчитывающую количество чисел от 0 до 1000, делящихся на 3 без остатка.
    //  Вывести результат на печать.

    public int Task1()
    {
        int count = 0;

        for (int i = 1; i <= 1000; i++)
        {
            if (i % 3 == 0)
            {
                count++;
            }
        }

        return count;
    }

    //Написать программу, выводящую количество единиц в двоичном представлении числа.
    public int Task2(int num)
    {
        string str = Convert.ToString(num, 2);
        int count = 0;
        Console.WriteLine(str);
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i].Equals('1'))
            {
                count++;
            }
        }

        return count;
    }

    //Даны массивы a и b, заполненные случайными числами.
    //Необходимо создать массив c длиной, равной сумме длин массивов a и b,
    //заполнить его элементами массивов a и b, отсортированными по возрастанию.
    public void Task3()
    {
        int[] a = { 9, 3, 4, 4, 5, 6, 1, 4, 7, 9, 0 };
        int[] b = { 1, 2, 3, 3, 9, 9, 1, 9, 9, 0, 0, 1, 1, 7 };

        int[] c = new int[a.Length + b.Length];

        for (int i = 0; i < c.Length; i++)
        {
            c[i] = i < a.Length ? a[i] : b[i - a.Length];
        }

        Sort(c);

        Console.Write(string.Join(" ", c));
    }

    private void Sort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i; j < arr.Length; j++)
            {
                if (arr[i] > arr[j])
                {
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
        }
    }

    //    Практическая работа #4
    //Найти в строке с текстом подстроку с числами(такая подстрока всего одна).
    public void Task4()
    {
        string s = "Эта строка содержит числа 12345 в своей середине";
        var sb = new StringBuilder();
        bool isTrue = false;

        foreach (var item in s)
        {
            if (char.IsDigit(item) || isTrue)
            {
                sb.Append(item);
                isTrue = true;
            }
        }

        Console.WriteLine(sb.ToString());
    }

    //    Дан двумерный массив.
    //123
    //456
    //789
    //Выведите его на печать перевернутым на 90 градусов
    //741
    //852
    //963
    public void Task5()
    {
        int[,] arr = new int[3, 3];
        int count = 1;

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = count++;
            }
        }


        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j]}".PadLeft(5));
            }
            Console.WriteLine();
        }

        count = 1;

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = arr.GetLength(1) - 1; j >= 0; j--)
            {
                arr[j, i] = count++;

            }
        }

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j]}".PadLeft(5));
            }
            Console.WriteLine();
        }
    }

    //Дана подстрока с числами. Создайте новую строку с тем же содержанием, но без чисел.Используйте класс StringBuilder.
    //string s = "Эта ст1рока не долж2на содерж345ать цифры67";
    public void Task6()
    {
        var str = "ThisStringInCamelCase";
        var sb = new StringBuilder();

        foreach (var sym in str)
        {
            if (sym >= 65 && sym <= 90)
            {
                sb.Append('_');
                sb.Append((char)(sym + (byte)32));
            }
            else
            {
                sb.Append(sym);
            }
        }

        Console.WriteLine(sb.ToString());
    }

    //    Дан двумерный массив.
    //  741
    //  852
    //  963
    //  отсортировать его по возрастанию
    //  123
    //  456
    //  789
    public void Task7()
    {
        int[,] arr = new int[,]
        {
            { 7, 4, 1 },
            { 8, 5, 2 },
            { 9, 6, 3 }
        };

        Queue<int> nums = new Queue<int>();

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                nums.Enqueue(arr[i, j]);
            }
        }

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j]}".PadLeft(5));
            }

            Console.WriteLine();
        }

        Console.WriteLine();

        int[] arr2 = nums.ToArray();
        Sort(arr2);
        nums = new Queue<int>(arr2.ToList());

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = nums.Dequeue();
            }
        }

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j]}".PadLeft(5));
            }

            Console.WriteLine();
        }
    }

}
