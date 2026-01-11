namespace Bank.Domain.Exceptions
{
    public class CustomerException : Exception
    {
        public CustomerException() { }

        public CustomerException(string message)
            : base(message) { }

        public CustomerException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}