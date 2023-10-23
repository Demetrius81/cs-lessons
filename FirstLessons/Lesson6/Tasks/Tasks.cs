
using System.Threading.Channels;

namespace Lesson6;
internal class Tasks
{
    internal void Task1()
    {
        //Задача 1: Фильтрация и проекция данных с использованием LINQ
        //Предоставьте студентам некоторую коллекцию объектов(например, список студентов) и попросите их решить следующие задачи:

        //Найти всех студентов, чей возраст меньше 25 лет.
        //Вывести имена всех студентов в алфавитном порядке.
        //Выбрать студентов, обучающихся на факультете инженерии.
        //Посчитать средний возраст студентов.
        //Попросите студентов использовать LINQ для решения этих задач.

        List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", Age = 22, Faculty = "Engineering" },
            new Student { Name = "Bob", Age = 25, Faculty = "Science" },
            new Student { Name = "Charlie", Age = 19, Faculty = "Engineering" },
            new Student { Name = "David", Age = 30, Faculty = "Arts" },
            new Student { Name = "Eve", Age = 21, Faculty = "Science" },
            // Добавьте других студентов по вашему усмотрению
        };

        students.Where(x => x.Age > 25).ToList().ForEach(Console.WriteLine);
        students.OrderBy(x => x.Name).ToList().ForEach(x => Console.WriteLine(x.Name + " "));
        students.Where(x => x.Faculty == "Engineering").ToList().ForEach(Console.WriteLine);
        Console.WriteLine(students.Average(x => x.Age));
    }

    internal void Task2()
    {
        //Отсортировать заказы по сумме в убывающем порядке.
        //Сгруппировать заказы по клиентам и вывести количество заказов для каждого клиента.
        //Найти клиента с наибольшей суммой заказов.
        //Вывести список клиентов и общую сумму их заказов.
        //Попросите студентов использовать LINQ для сортировки и группировки данных.

        List<Order> orders = new List<Order>
        {
            new Order { OrderID = 1, CustomerName = "Alice", OrderDate = new DateTime(2023, 6, 1), TotalAmount = 150.0 },
            new Order { OrderID = 2, CustomerName = "Bob", OrderDate = new DateTime(2023, 6, 2), TotalAmount = 75.5 },
            new Order { OrderID = 3, CustomerName = "Charlie", OrderDate = new DateTime(2023, 6, 2), TotalAmount = 220.0 },
            new Order { OrderID = 4, CustomerName = "David", OrderDate = new DateTime(2023, 6, 3), TotalAmount = 100.0 },
            new Order { OrderID = 5, CustomerName = "Alice", OrderDate = new DateTime(2023, 6, 4), TotalAmount = 85.5 },
            // Добавьте другие заказы по вашему усмотрению
        };

        var orderedOrders = from order in orders
                            orderby order.TotalAmount
                            select order;

        orderedOrders.GroupBy(x => x.CustomerName).Select(x => new { name = x.Key, count = x.Count() }).ToList().ForEach(x => Console.WriteLine($"{x.name} - {x.count}"));

        var client = orders.GroupBy(x => x.CustomerName).Select(x => new { name = x.Key, total = x.Sum(y => y.TotalAmount) }).OrderByDescending(x => x.total).First();

        Console.WriteLine(client.name + " - " + client.total);

        orders.GroupBy(x => x.CustomerName).Select(x => new { name = x.Key, total = x.Sum(y => y.TotalAmount) }).ToList().ForEach(x => Console.WriteLine(x.name + " - " + x.total));
    }

    internal void Task3()
    {
        //В этой задаче у вас есть список строк, и ваша задача – отсортировать этот список в порядке возрастания длины строк, используя лямбда - выражение.Ниже приведены начальные данные и возможное решение:

        List<string> strings = new List<string>
        {
            "Apple",
            "Banana",
            "Cherry",
            "Date",
            "Fig",
            "Grapes"
        };

        strings.OrderBy(x => x.Length).ToList().ForEach(x => Console.WriteLine(x.Length));
    }

    internal void Task4()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 8, 9, 0, 7, 6, 5, 6, 34, 3, 2 };

        numbers.Sort((x, y) => x.CompareTo(y));

        numbers.ForEach(x => Console.WriteLine(x));
    }

    internal void Task5()
    {
        // Мы хотим выбрать все строки, содержащие определенную подстроку, с использованием лямбда - выражения.Вот начальные данные и решение задачи:

        List<string> words = new List<string>
        {
            "apple",
            "banana",
            "cherry",
            "dante",
            "grape",
            "kiwi",
            "lemon",
        };

        string searchTerm = "an";

        words.Where(x => x.Contains(searchTerm)).ToList().ForEach(x => Console.WriteLine(x));
    }

    internal void Task6()
    {
        //у нас есть список чисел, и мы хотим умножить каждое число в списке на 2, используя анонимный метод

        List<int> numbers = new List<int> { 1, 2, 3, 4, 8, 9, 0, 7, 6, 5, 6, 34, 3, 2 };

        numbers.Select(x => x *= 2).ToList().ForEach(x => Console.WriteLine(x));
    }

    internal void Task7()
    {
        //что у нас есть список объектов, и мы хотим отфильтровать этот список по определенному критерию, используя лямбда - выражение.Вот начальные данные и решение задачи:

        List<Order> orders = new List<Order>
        {
            new Order { OrderID = 1, CustomerName = "Alice", OrderDate = new DateTime(2023, 6, 1), TotalAmount = 150.0 },
            new Order { OrderID = 2, CustomerName = "Bob", OrderDate = new DateTime(2023, 6, 2), TotalAmount = 75.5 },
            new Order { OrderID = 3, CustomerName = "Charlie", OrderDate = new DateTime(2023, 6, 2), TotalAmount = 220.0 },
            new Order { OrderID = 4, CustomerName = "David", OrderDate = new DateTime(2023, 6, 3), TotalAmount = 100.0 },
            new Order { OrderID = 5, CustomerName = "Antuan", OrderDate = new DateTime(2023, 6, 4), TotalAmount = 85.5 },
            // Добавьте другие заказы по вашему усмотрению
        };

        orders.Where(x => x.TotalAmount > 100).ToList().ForEach(x => Console.WriteLine(x.ToString()));
        Console.WriteLine();
        orders.Where(x => x.CustomerName.StartsWith("A")).ToList().ForEach(x => Console.WriteLine(x));
    }

    internal void Task8()
    {
        //Поиск общих элементов в двух коллекциях

        HashSet<int> hashSet = new HashSet<int> { 1, 2, 3, 4, 5 };
        List<int> list = new List<int> { 3, 4, 5, 6, 7 };

        hashSet.Intersect(list).ToList().ForEach(Console.WriteLine);
    }
}
