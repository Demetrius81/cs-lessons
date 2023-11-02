namespace Lesson6;

internal class Order
{
    public int OrderID { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }

    public override string ToString()
    {
        return $"{OrderID} - {CustomerName} - {OrderDate} - {TotalAmount}";
    }
}
