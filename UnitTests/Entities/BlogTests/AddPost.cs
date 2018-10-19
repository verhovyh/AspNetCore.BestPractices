using AspNetCore.BestPractices.ApplicationCore.Entities;
using System;
using System.Linq;
using UnitTests.Builders;
using Xunit;

namespace UnitTests
{
    public class AddPost
    {
        [Fact]
        public void AddPostTest()
        {
            var blog = new BlogBuilder().WithDefaultValues().Build();

            blog.AddPost(333, "Title", "Some Content");

            var post = blog.Posts.Where(p => p.Id == 333).Single();
            Assert.Equal(2, blog.Posts.Count);
            Assert.Equal(333, post.Id);
            Assert.Equal("Title", post.Title);
            Assert.Equal("Some Content", post.Content);
        }
    }
}
