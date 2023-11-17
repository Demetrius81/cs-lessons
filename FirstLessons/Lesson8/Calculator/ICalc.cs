namespace Lesson8;
internal interface ICalc
{
    public double Result { get; }
    void Sum(double x);
    void Sub(double x);
    void Div(double x);
    void Mult(double x);
    void CancelLast();

    void Sum(int x);
    void Sub(int x);
    void Div(int x);
    void Mult(int x);

    event EventHandler<EventArgs> CalcEventHandler;
    event EventHandler<string> CalcAdvancedEventHandler;
}
