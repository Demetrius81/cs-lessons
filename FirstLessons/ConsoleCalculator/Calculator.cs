using System.Data;

namespace ConsoleCalculator;

public class Calculator
{
    public (string expression, double result) Calculate(string[] args)
    {
        string expression = string.Join(" ", args);
        return (expression, Evaluate(expression));
    }

    /// <summary>Calculate expression</summary>
    private double Evaluate(string expression)
    {
        DataTable table = new DataTable();
        table.Columns.Add("expression", typeof(string), expression);
        DataRow row = table.NewRow();
        table.Rows.Add(row);
        return double.Parse((string)row["expression"]);
    }

    /// <summary>Validate argumenta</summary>
    public bool ValidateArgs(string[] args)
    {
        List<string> operatorsList = new List<string>() { "+", "-", "*", "/" };

        for (int i = 0; i < args.Length; i++)
        {
            if (!int.TryParse(args[i], out _) && !operatorsList.Contains(args[i]))
            {
                return false;
            }
        }

        return true;
    }
}
