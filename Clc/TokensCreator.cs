using System.Collections;
using System.Text.RegularExpressions;

namespace Clc
{
    public class TokensCreator : IEnumerable
    {
        #region Constructors

        public TokensCreator(string expression)
        {
            _regEx = new Regex(ArithmeticOpsRegEx);
            _tokens = SplitExpression(expression);
        }

        #endregion

        #region Fields

        private const string ArithmeticOpsRegEx = @"([+\-*/%()]{1})";
        private readonly Regex _regEx;
        private readonly string[] _tokens;

        #endregion

        #region Methods

        public IEnumerator GetEnumerator()
        {
            return new TokenEnumerator(_tokens);
        }

        public string[] SplitExpression(string expression)
        {
            return _regEx.Split(expression);
        }

        #endregion
    }
}