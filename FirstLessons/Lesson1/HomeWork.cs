using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1;
internal class HomeWork
{
    //    Написать программу-калькулятор, вычисляющую выражения вида
    //a + b, a - b, a / b, a* b,
    //введенные из командной строки, и выводящую результат выполнения на экран.
    //Пример вызова программы: 
    //program.exe 10 + 20 
    //Пример вывода результата:
    //10 + 20 = 30 
    //В результате операции сложения чисел 10 и 20 получился ответ 30.

    public int Result(string[] args)
    {
        return default;
    }

    private string[] ParseOperators(string[] args)
    {
        return default;
    }

    private int[] ParseInts(string[] args)
    {
        return default;
    }

    private int Sum(int num1, int num2) => num1 + num2;

    private int substract(int num1, int num2) => num1 - num2;

    private int Devide(int num1, int num2) => num2 == 0 ? throw new ArithmeticException("Devide by zero") : num1 / num2;

    private int Multiply(int num1, int num2) => num1 * num2;
}
