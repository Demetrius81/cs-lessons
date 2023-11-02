namespace Lesson6;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Faculty { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Age} - {Faculty}";
    }
}
