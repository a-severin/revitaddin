using System;

namespace ColorRevitAddIn
{
    public class SetSemitoneException : ApplicationException
    {
        public SetSemitoneException(string message) : base(message)
        {
        }

        public SetSemitoneException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}