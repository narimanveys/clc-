namespace Clc
{
    public class Operand
    {
        #region Fields

        protected string Value;

        #endregion

        #region Constructors

        public Operand(string value)
        {
            Value = value;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return Value;
        }

        #endregion
    }
}