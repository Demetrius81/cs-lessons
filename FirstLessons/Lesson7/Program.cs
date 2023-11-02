using Lesson7.ChainOfResp;

namespace Lesson7;

internal class Program
{
    protected Program()
    {
        
    }
    static void Main(string[] args)
    {
        CalcAppBase calcApp = new CalcAppChainOfResp();
        calcApp.RunApp();

        //CalcAppBase calcApp = new CalcApp();
        //calcApp.RunApp();
    }
}
