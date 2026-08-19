using System;

class Program
{
    static string EvaluateExpression(string expression)
    {
        // Check for null/empty expression
        if (string.IsNullOrWhiteSpace(expression))
            return "Error:InvalidExpression";

        // Spaces are required, so split by space
        string[] parts = expression.Split(' ');

        // Expected format: a op b
        if (parts.Length != 3 || parts[0] == "" || parts[1] == "" || parts[2] == "")
            return "Error:InvalidExpression";

        string a = parts[0];
        string op = parts[1];
        string b = parts[2];

        // Check whether a and b are integers
        if (!int.TryParse(a, out int num1) ||
            !int.TryParse(b, out int num2))
        {
            return "Error:InvalidNumber";
        }

        // Check operator
        if (op != "+" && op != "-" && op != "*" && op != "/")
            return "Error:UnknownOperator";

        // Division by zero
        if (op == "/" && num2 == 0)
            return "Error:DivideByZero";

        int result;

        switch (op)
        {
            case "+":
                result = num1 + num2;
                break;

            case "-":
                result = num1 - num2;
                break;

            case "*":
                result = num1 * num2;
                break;

            case "/":
                result = num1 / num2;
                break;

            default:
                return "Error:UnknownOperator";
        }

        return result.ToString();
    }

    static void Main()
    {
        string expression = Console.ReadLine();

        Console.WriteLine(EvaluateExpression(expression));
    }
}