namespace Lesson8;

internal class Program
{
    static void Main(string[] args)
    {
        CalcApp app = new CalcApp();
        try
        {
            app.RunApp();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            // выводим сообщение об ошибке, ожидаем корректирующих действий пользователя, перезапускаем или завершаем приложение
        }
        finally
        {
            // освобождает ресурсы, чистим память, закрываем сокеты и так далее.
        }
    }
}
