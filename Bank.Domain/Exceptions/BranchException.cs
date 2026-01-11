namespace Bank.Domain.Exceptions
{
    // This class defines a custom exception for branch-related errors and optionally includes an HTTP status code (default 400).
    public class BranchException : Exception
    {
        public int StatusCode { get; }

        public BranchException() { }

        public BranchException(string message)
            : base(message) { }

        // Use numeric default 400 instead of undefined StatusCode symbol
        public BranchException(string message, int statusCode = 400)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
