
using System;
using System.Threading.Channels;

namespace Lesson8;
internal class Tasks
{



    internal bool TryParseInt(string str, out int? num)
    {
        num = null;
        try
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str), "Argument is null!");
            }

            num = Convert.ToInt32(str);
            return true;
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

    }
    internal void Task1()
    {
        int i = -4;

        try
        {
            ProcessNumber(i);
        }
        catch (NegativeNumberException ex)
        {
            Console.WriteLine(ex.ToString());
            if (ex.InnerException != null)
            {
                Console.WriteLine(ex.InnerException.ToString());
            } 
            else 
            { 
                Console.WriteLine("ex.InnerException == null");
            }
        }


    }

    internal void ProcessNumber(int number)
    {
        if (number < 0)
        {
            throw new NegativeNumberException("Error. Number less than zero!", new Exception("<<< InnerException >>>"));
        }
    }


    internal void Task2()
    {

    }

    internal void Task3()
    {

    }

    internal void Task4()
    {

    }


}

public class NegativeNumberException : Exception
{
    public NegativeNumberException() : base() { }
    public NegativeNumberException(string message) : base(message) { }
    public NegativeNumberException(string message, Exception ex) : base(message, ex) { }

}