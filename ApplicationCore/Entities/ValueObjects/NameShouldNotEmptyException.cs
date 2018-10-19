using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.BestPractices.ApplicationCore.Entities.ValueObjects
{
    public class NameShouldNotBeEmptyException : Exception
    {
        public NameShouldNotBeEmptyException(string message) : base(message)
        {
        }

        public NameShouldNotBeEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NameShouldNotBeEmptyException()
        {
        }
    }
}
