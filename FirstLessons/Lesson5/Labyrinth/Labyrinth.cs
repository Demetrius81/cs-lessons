namespace Lesson5;

public class Labyrinth
{
    private const bool @true = true;

    protected Labyrinth()
    {

    }

    /// <summary>
    /// Homework is strictly according to the conditions
    /// </summary>
    public static int HasExit(int startY, int startX, int[,] array)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (array.GetLength(0) == 0 || array.GetLength(1) == 0)
        {
            throw new ArgumentException(nameof(array));
        }

        if (startY < 0 || startY > array.GetLength(0))
        {
            throw new ArgumentOutOfRangeException(nameof(startY));
        }

        if (startX < 0 || startX > array.GetLength(1))
        {
            throw new ArgumentOutOfRangeException(nameof(startX));
        }

        int[,] arrayLabyrinth = (int[,])array.Clone();

        if (array[startY, startX] == 1)
        {
            return -1;
        }

        Stack<Tuple<int, int>> stackOfCoords = new Stack<Tuple<int, int>>();
        stackOfCoords.Push(new Tuple<int, int>(startY, startX));
        int count = 0;

        while (stackOfCoords.Count > 0)
        {
            var temp = stackOfCoords.Pop();

            if (arrayLabyrinth[temp.Item1, temp.Item2] == 2)
            {
                count++;
            }

            arrayLabyrinth[temp.Item1, temp.Item2] = 1;

            if (temp.Item2 - 1 >= 0 && arrayLabyrinth[temp.Item1, temp.Item2 - 1] != 1)
            {
                stackOfCoords.Push(new(temp.Item1, temp.Item2 - 1));
            }

            if (temp.Item2 + 1 < arrayLabyrinth.GetLength(1) && arrayLabyrinth[temp.Item1, temp.Item2 + 1] != 1)
            {
                stackOfCoords.Push(new(temp.Item1, temp.Item2 + 1));
            }

            if (temp.Item1 - 1 >= 0 && arrayLabyrinth[temp.Item1 - 1, temp.Item2] != 1)
            {
                stackOfCoords.Push(new(temp.Item1 - 1, temp.Item2));
            }

            if (temp.Item1 + 1 < arrayLabyrinth.GetLength(0) && arrayLabyrinth[temp.Item1 + 1, temp.Item2] != 1)
            {
                stackOfCoords.Push(new(temp.Item1 + 1, temp.Item2));
            }
        }

        return count;
    }

    /// <summary>
    /// Homework, advanced method
    /// </summary>
    public static (int exitsCount, List<Point>? coordinates) HasExitPromoutedHW(int startY, int startX, int[,] array)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (array.GetLength(0) == 0 || array.GetLength(1) == 0)
        {
            throw new ArgumentException(nameof(array));
        }

        if (startY < 0 || startY > array.GetLength(0))
        {
            throw new ArgumentOutOfRangeException(nameof(startY));
        }

        if (startX < 0 || startX > array.GetLength(1))
        {
            throw new ArgumentOutOfRangeException(nameof(startX));
        }

        int[,] arrayLabyrinth = (int[,])array.Clone();

        if (arrayLabyrinth[startY, startX] == 1)
        {
            return (-1, null);
        }

        Stack<Point> stackOfCoords = new Stack<Point>();
        List<Point> exitPoints = new List<Point>();
        stackOfCoords.Push(new Point(startY, startX));
        int count = 0;


        while (stackOfCoords.Count > 0)
        {
            var temp = stackOfCoords.Pop();

            if (arrayLabyrinth[temp.coordY, temp.coordX] == 2)
            {
                count++;
                exitPoints.Add(temp);
            }

            arrayLabyrinth[temp.coordY, temp.coordX] = 1;

            if (temp.coordX - 1 >= 0 && arrayLabyrinth[temp.coordY, temp.coordX - 1] != 1)
            {
                stackOfCoords.Push(new(temp.coordY, temp.coordX - 1));
            }

            if (temp.coordX + 1 < arrayLabyrinth.GetLength(1) && arrayLabyrinth[temp.coordY, temp.coordX + 1] != 1)
            {
                stackOfCoords.Push(new(temp.coordY, temp.coordX + 1));
            }

            if (temp.coordY - 1 >= 0 && arrayLabyrinth[temp.coordY - 1, temp.coordX] != 1)
            {
                stackOfCoords.Push(new(temp.coordY - 1, temp.coordX));
            }

            if (temp.coordY + 1 < arrayLabyrinth.GetLength(0) && arrayLabyrinth[temp.coordY + 1, temp.coordX] != 1)
            {
                stackOfCoords.Push(new(temp.coordY + 1, temp.coordX));
            }

        }

        return (count, exitPoints);
    }

    /// <summary>
    /// Advanced method from seminar
    /// </summary>
    public static (bool hasExit, Point? coordinates) HasExitPromouted(int startY, int startX, int[,] array)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (array.GetLength(0) == 0 || array.GetLength(1) == 0)
        {
            throw new ArgumentException(nameof(array));
        }

        if (startY < 0 || startY > array.GetLength(0))
        {
            throw new ArgumentOutOfRangeException(nameof(startY));
        }

        if (startX < 0 || startX > array.GetLength(1))
        {
            throw new ArgumentOutOfRangeException(nameof(startX));
        }

        int[,] arrayLabyrinth = (int[,])array.Clone();

        switch (true)
        {
            case true when arrayLabyrinth[startY, startX] == 1:
                return (false, null);
            case true when arrayLabyrinth[startY, startX] == 2:
                return (true, new Point(startY, startX));
            default:
                break;
        }

        Stack<Point> stackOfCoords = new Stack<Point>();
        stackOfCoords.Push(new Point(startY, startX));

        while (stackOfCoords.Count > 0)
        {
            var temp = stackOfCoords.Pop();

            if (arrayLabyrinth[temp.coordY, temp.coordX] == 2)
            {
                return (true, temp);
            }

            arrayLabyrinth[temp.coordY, temp.coordX] = 1;

            if (temp.coordX - 1 >= 0 && arrayLabyrinth[temp.coordY, temp.coordX - 1] != 1)
            {
                stackOfCoords.Push(new(temp.coordY, temp.coordX - 1));
            }

            if (temp.coordX + 1 < arrayLabyrinth.GetLength(1) && arrayLabyrinth[temp.coordY, temp.coordX + 1] != 1)
            {
                stackOfCoords.Push(new(temp.coordY, temp.coordX + 1));
            }

            if (temp.coordY - 1 >= 0 && arrayLabyrinth[temp.coordY - 1, temp.coordX] != 1)
            {
                stackOfCoords.Push(new(temp.coordY - 1, temp.coordX));
            }

            if (temp.coordX + 1 < arrayLabyrinth.GetLength(0) && arrayLabyrinth[temp.coordY + 1, temp.coordX] != 1)
            {
                stackOfCoords.Push(new(temp.coordY + 1, temp.coordX));
            }

        }

        return (false, null);
    }

    private static int[,] TurnLeft(int[,] array)
    {
        int[,] result = new int[array.GetLength(0), array.GetLength(1)];

        for (int y = 0; y < array.GetLength(1); y++)
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                result[x, array.GetLength(1) - 1 - y] = array[y, x];
            }
        }

        return result;
    }

    private static int[,] TurnRight(int[,] array)
    {
        int[,] result = new int[array.GetLength(0), array.GetLength(1)];

        for (int y = 0; y < array.GetLength(1); y++)
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                result[array.GetLength(1) - 1 - x, y] = array[y, x];
            }
        }

        return result;
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int y = 0; y < matrix.GetLength(1); y++)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                Console.Write(matrix[y, x] + " ");
            }
            Console.WriteLine();
        }
    }
}
