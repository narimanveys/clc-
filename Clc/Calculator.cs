using System;
using System.Collections;
using System.Collections.Generic;

namespace Clc
{
    public class Calculator
    {
        #region Methods

        public Tuple<List<string>, bool> CreateReversePolishNotationList(string receivedExpression)
        {
            var itsOk = true;
            var outputPolishNotationList = new List<string>();

            var operatorsStack = new Stack();

            var tokens = new TokensCreator(receivedExpression);

            foreach (Token token in tokens)
            {
                var tokenValue = token.GetValue().Trim();
                if (tokenValue.Length == 0)
                    continue;
                if (!Helper.IsOperator(tokenValue))
                {
                    var operand = Helper.CreateOperand(tokenValue);
                    outputPolishNotationList.Add(operand.ToString());
                    continue;
                }

                if (tokenValue == "(")
                {
                    operatorsStack.Push(tokenValue);
                }
                else if (tokenValue == ")")
                {
                    string stackTopValue;
                    while ((stackTopValue = (string) operatorsStack.Pop()) != "(")
                    {
                        var currentOperator = new Operator(stackTopValue);

                        outputPolishNotationList.Add(currentOperator.ToString());

                        if (operatorsStack.Count == 0)
                            itsOk = false;
                    }
                }
                else
                {
                    if (operatorsStack.Count == 0 || (string) operatorsStack.Peek() == "("
                                                  || Helper.IsHigherOperator(tokenValue,
                                                      (string) operatorsStack.Peek()))
                    {
                        operatorsStack.Push(tokenValue);
                    }
                    else
                    {
                        while (operatorsStack.Count != 0)
                            if (Helper.IsLowerOperator(tokenValue, (string) operatorsStack.Peek())
                                || Helper.IsEqualOperator(tokenValue, (string) operatorsStack.Peek()))
                            {
                                var stackTopValue = (string) operatorsStack.Peek();
                                if (stackTopValue == "(")
                                    break;
                                stackTopValue = (string) operatorsStack.Pop();

                                var oprtr = Helper.CreateOperator(stackTopValue);
                                outputPolishNotationList.Add(oprtr.ToString());
                            }
                            else
                            {
                                break;
                            }

                        operatorsStack.Push(tokenValue);
                    }
                }
            }


            while (operatorsStack.Count != 0)
            {
                var stackTopValue = (string) operatorsStack.Pop();
                if (stackTopValue == "(")
                    itsOk = false;

                var currentOperator = Helper.CreateOperator(stackTopValue);
                outputPolishNotationList.Add(currentOperator.ToString());
            }

            return Tuple.Create(outputPolishNotationList, itsOk);
        }


        public Tuple<double, bool> Evaluate(List<string> rpnExpression)
        {
            var _stack = new Stack<double>();
            var itsOk = true;
            double evaluationResult = 0;

            try
            {
                foreach (var itm in rpnExpression)
                {
                    var isNum = double.TryParse(itm, out var num);
                    if (isNum)
                        _stack.Push(num);

                    else
                        switch (itm)
                        {
                            case "*":
                            {
                                _stack.Push(_stack.Pop() * _stack.Pop());
                                break;
                            }
                            case "/":
                            {
                                num = _stack.Pop();
                                _stack.Push(_stack.Pop() / num);
                                break;
                            }
                            case "+":
                            {
                                _stack.Push(_stack.Pop() + _stack.Pop());
                                break;
                            }
                            case "-":
                            {
                                num = _stack.Pop();
                                _stack.Push(_stack.Pop() - num);
                                break;
                            }
                        }
                }

                evaluationResult = _stack.Pop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                itsOk = false;
            }

            return Tuple.Create(evaluationResult, itsOk);
            ;
        }

        #endregion
    }
}