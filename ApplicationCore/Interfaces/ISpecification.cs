using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AspNetCore.BestPractices.ApplicationCore.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, bool>>> Includes { get; }
        List<string> IncludeStrings { get;}

    }
}
