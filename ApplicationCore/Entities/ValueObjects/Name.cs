using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.BestPractices.ApplicationCore.Entities.ValueObjects
{
    public sealed class Name : BaseEntity
    {
        
        public Name()
        {

        }
        public Name(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                throw new NameShouldNotBeEmptyException("The 'Name' field is required");
            }
            Text = text;
        }

        public string Text { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is string)
            {
                return obj.ToString() == Text;
            }

            return ((Name)obj).Text == Text;
        }
    }
}
