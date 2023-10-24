using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6;
internal class FindNumbers
{
    public static (int firstNumber, int secondNumber) FindTwoNumbersLoop(List<int> numbersList, int target)
    {
        for (int i = 0; i < numbersList.Count; i++)
        {
            for (int j = i + 1; j < numbersList.Count; j++)
            {
                if (numbersList[i] + numbersList[j] == target)
                {
                    return (numbersList[i], numbersList[j]);
                }
            }
        }

        return (0, 0);
    }

    public static (int firstNumber, int secondNumber) FindTwoNumbersHashSet(List<int> numbersList, int target)
    {
        HashSet<int> set = new();

        foreach (var num in numbersList)
        {
            int firstNum = target - num;

            if (set.Contains(firstNum))
            {
                return (firstNum, num);
            }
            else
            {
                set.Add(num);
            }
        }

        return (0, 0);
    }

    public static (int firstNumber, int secondNumber, int thirdNumber) FindThreeNumbersLoop(List<int> numbersList, int target)
    {
        int iter = 0;

        for (int i = 0; i < numbersList.Count; i++)
        {
            for (int j = i + 1; j < numbersList.Count; j++)
            {
                for (int k = j + 1; k < numbersList.Count; k++)
                {
                    iter++;

                    if (numbersList[i] + numbersList[j] + numbersList[k] == target)
                    {
                        Console.WriteLine("Number of iterations = " + iter);
                        return (numbersList[i], numbersList[j], numbersList[k]);
                    }
                }

            }
        }

        return (0, 0, 0);
    }

    public static (int firstNumber, int secondNumber, int thirdNumber) FindThreeNumbersHashSet(List<int> numbersList, int target)
    {
        int iter = 0;
        HashSet<int> set = new();

        for (int i = 1; i < numbersList.Count; i++)
        {
            for (int j = i + 1; j < numbersList.Count; j++)
            {
                iter++;
                int firstNum = target - numbersList[i] - numbersList[j];

                if (set.Contains(firstNum))
                {
                    Console.WriteLine("Number of iterations = " + iter);
                    return (firstNum, numbersList[i], numbersList[i]);
                }
                else
                {
                    set.Add(numbersList[i]);
                }
            }

            set.Add(numbersList[i]);
        }

        return (0, 0, 0);
    }

    public static (int firstNumber, int secondNumber, int thirdNumber) FindThreeNumbersFromChatGPT(List<int> arr, int targetSum)
    {
        int iter = 0;
        // Сортируем массив
        arr.Sort();

        // Перебираем первое число
        for (int i = 0; i < arr.Count - 2; i++)
        {
            // Инициализируем указатели для второго и третьего чисел
            int left = i + 1;
            int right = arr.Count - 1;

            while (left < right)
            {
                iter++;
                int currentSum = arr[i] + arr[left] + arr[right];

                if (currentSum == targetSum)
                {
                    // Найдены три числа сумма которых равна заданному числу
                    Console.WriteLine("Number of iterations = " + iter);
                    return (arr[i], arr[left], arr[right]);

                }
                else if (currentSum < targetSum)
                {
                    // Увеличиваем сумму, двигая указатель left вправо
                    left++;
                }
                else
                {
                    // Уменьшаем сумму, двигая указатель right влево
                    right--;
                }
            }
        }

        return (0, 0, 0);
    }
}
