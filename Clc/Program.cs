using System;

namespace Clc
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string expressionArgument;
            while ((expressionArgument = Console.ReadLine()) != "exit")
            {
                var calc = new Calculator();
                var expressionInfo = calc.CreateReversePolishNotationList(expressionArgument);
                if (expressionInfo.Item2)
                {
                    var evaluation = calc.Evaluate(expressionInfo.Item1);
                    if (evaluation.Item2)
                        Console.WriteLine("\n Result: " + evaluation.Item1 + "\n");
                    else Helper.PrintErrorMessage();
                }
                else
                {
                    Helper.PrintErrorMessage();
                }
            }
        }
    }
}