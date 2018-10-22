using AspNetCore.BestPractices.ApplicationCore.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.BestPractices.ApplicationCore.Entities.ValueObjects
{
    public sealed class Name : ValueObject
    {
        public Name() { }
        public Name(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                throw new NameShouldNotBeEmptyException("The 'Name' field is required");
            }
            Text = text;
        }

        public string Text { get; private set; }
    }
}
