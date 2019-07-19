using System;

namespace ExpensesManaging.project.Exceptions
{
    public class AppException : Exception
    {
        public AppException() : base() {}
        public AppException(string message) : base(message) {}
    }
}