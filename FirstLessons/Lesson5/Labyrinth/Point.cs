namespace Lesson5;

public record struct Point(int coordY, int coordX)
{
    public override string? ToString()
    {
        return $"X: {coordX}, Y: {coordY}";
    }
}
