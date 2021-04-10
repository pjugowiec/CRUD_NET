using System;
namespace server.Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationException() : base("Validation Exception")
        {
        }
    }
}
