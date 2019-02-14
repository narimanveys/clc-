using System.Collections;

namespace Clc
{
    public class TokenEnumerator : IEnumerator
    {
        #region Constructors

        public TokenEnumerator(string[] tokens)
        {
            _tokens = tokens;
            Reset();
        }

        #endregion

        #region Fields

        private int _id;
        private Token _token;
        private readonly string[] _tokens;

        #endregion

        #region Methods and Properties 

        public object Current => _token;

        public bool MoveNext()
        {
            if (_id >= _tokens.Length)
                return false;

            _token = new Token(_tokens[_id]);
            _id++;
            return true;
        }

        public void Reset()
        {
            _id = 0;
        }

        #endregion
    }
}