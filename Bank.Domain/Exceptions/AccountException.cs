namespace Bank.Domain.Exceptions
{
//This class defines a custom exception used to represent account-related errors in the domain layer.
    public class AccountException : Exception
    {
        public AccountException() { }

        public AccountException(string message)
            : base(message) { }

        public AccountException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}