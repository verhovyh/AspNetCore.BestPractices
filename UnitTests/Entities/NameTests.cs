using AspNetCore.BestPractices.ApplicationCore.Entities;
using AspNetCore.BestPractices.ApplicationCore.Entities.ValueObjects;
using System;
using System.Linq;
using UnitTests.Builders;
using Xunit;

namespace UnitTests.Entities
{
    public class NameTests
    {
        [Fact]
        public void FulNameShouldBeCreated()
        {
            Name name = new Name("Full Name");
            Assert.Equal("Full Name", name.Text);
        }
    }
}
