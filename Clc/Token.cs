namespace Clc
{
    public class Token
    {
        #region Fields

        private readonly string _value;

        #endregion

        #region Constructors

        public Token(string value)
        {
            _value = value;
        }

        #endregion

        #region Methods

        public string GetValue()
        {
            return _value;
        }

        #endregion
    }
}