namespace Clc
{
    public class Operator
    {
        #region Fields

        protected string CurrentOperator;

        #endregion

        #region Constructors

        public Operator(string currentOperator)
        {
            CurrentOperator = currentOperator;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return CurrentOperator;
        }

        #endregion
    }
}