using AspNetCore.BestPractices.ApplicationCore.Entities;
using AspNetCore.BestPractices.ApplicationCore.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Builders
{
    public class BlogBuilder
    {
        private Blog _blog;

        public Blog Build()
        {
            return _blog;
        }
        public BlogBuilder WithDefaultValues()
        {
            var post = new Post() { Id = 1, Title = "Default Title", Content = "Default Content" };
            _blog = new Blog("www.default.com", new Name("Default Author Name"), new List<Post>() { post });
            return this;
        }
        public BlogBuilder WithUrl(string url)
        {
            _blog.Url = url;
            return this;
        }
    }
}
