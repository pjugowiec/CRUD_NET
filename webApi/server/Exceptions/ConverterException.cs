using System;
namespace server.Exceptions
{
    [Serializable]
    public class ConverterException : Exception
    {
        public ConverterException(): base("Problem with mapping values")
        {
        }
    }
}
