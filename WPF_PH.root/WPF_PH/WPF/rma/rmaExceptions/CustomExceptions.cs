using System;

namespace Core.Exceptions
{
    [Serializable]
    public class _ErrorException : Exception
    {
        public _ErrorException(string errorMessage)
            : base(errorMessage)
        {
        }

        public _ErrorException(string errorMessage, Exception innerEx)
            : base(errorMessage, innerEx)
        {
        }

        public string ErrorMessage
        {
            get { return base.Message; }
        }
    }

    public class FieldException : _ErrorException
    {
        public FieldException(string errorMessage)
            : base(errorMessage)
        {
        }

        public FieldException(string errorMessage, Exception innerEx)
            : base(errorMessage, innerEx)
        {
        }
    }
}