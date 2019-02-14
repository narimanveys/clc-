using System;
using System.Collections.Generic;
using System.Globalization;

namespace Clc
{
    public class Helper
    {
        #region Fields

        private static readonly string[] AllOperators = {"+", "-", "*", "/", "(", ")"};

        #endregion

        #region Methods

        public static bool IsOperator(string currentItem)
        {
            var position = Array.IndexOf(AllOperators, currentItem.Trim());
            if (position != -1)
                return true;
            return false;
        }

        public static Operand CreateOperand(string operandItem)
        {
            return new Operand(operandItem);
        }

        public static Operator CreateOperator(string operatorItem)
        {
            return new Operator(operatorItem);
        }

        public static bool IsHigherOperator(string currentOperator, string previousOperator)
        {
            GetCurrentAndPreviousIndex(AllOperators, currentOperator, previousOperator, out var currentId,
                out var previousId);
            if (currentId > previousId) return true;
            return false;
        }

        public static bool IsLowerOperator(string currentOperator, string previousOperator)
        {
            GetCurrentAndPreviousIndex(AllOperators, currentOperator, previousOperator, out var currentId,
                out var previousId);
            if (currentId < previousId) return true;
            return false;
        }

        public static bool IsEqualOperator(string currentOperator, string previousOperator)
        {
            GetCurrentAndPreviousIndex(AllOperators, currentOperator, previousOperator, out var currentId,
                out var previousId);
            if (currentId == previousId) return true;
            return false;
        }

        private static void GetCurrentAndPreviousIndex(IReadOnlyList<string> allOps, string currentOperator,
            string previousOperator,
            out int currentId, out int previousId)
        {
            currentId = -1;
            previousId = -1;
            for (var i = 0; i < allOps.Count; i++)
            {
                if (allOps[i] == currentOperator) currentId = i;
                if (allOps[i] == previousOperator) previousId = i;
                if (previousId != -1 && currentId != -1) break;
            }
        }

        public static void PrintErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error in expression format");
            Console.ResetColor();
        }

        #endregion
    }
}