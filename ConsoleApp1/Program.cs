// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;


Calculator.Calc();

public static class Calculator
{
    public static void Calc()
    {
        while (true)
        {
            Console.WriteLine("Enter a expression to calculate (or type 'exit' to quit):");
            string? input = Console.ReadLine();

            input ??= "";

            // exit if the user types 'exit' or just presses enter
            if (input.ToLower() == "exit" || input == "")
                break;

            try
            {
                double result = Evaluate(input);
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    
    static double Evaluate(string expression)
    {
        // get the expression parts
        var parts = expression.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // stack collection for values & operators
        var values = new Stack<double>();
        var operators = new Stack<char>();

        for (int i = 0; i < parts.Length; i++)
        {
            if (double.TryParse(parts[i], out double number))
            {
                values.Push(number);
            }
            else if (IsOperator(parts[i][0]))
            {
                while (operators.Count > 0
                    && Precedence(parts[i][0]) <= Precedence(operators.Peek()))
                {
                    values.Push(ApplyOperator(operators.Pop(), values.Pop(), values.Pop()));
                }
                operators.Push(parts[i][0]);
            }
        }

        while (operators.Count > 0)
        {
            values.Push(ApplyOperator(operators.Pop(), values.Pop(), values.Pop()));
        }

        return values.Pop();
    }

    static bool IsOperator(char op)
    {
        // list of operators, extend as needed
        return op == '+' || op == '-' || op == '*' || op == '/';
    }

    static int Precedence(char op)
    {
        // identify the precedence of the operators
        switch (op)
        {
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
                return 2;
            default:
                return 0;
        }
    }

    static double ApplyOperator(char op, double b, double a)
    {
        return op switch
        {
            '+' => a + b,
            '-' => a - b,
            '*' => a * b,
            '/' => a / b,
            _ => throw new ArgumentException("Invalid operator"),
        };
    }
}