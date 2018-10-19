using AspNetCore.BestPractices.Infrastructure.Data;
using System;
using Xunit;
using UnitTests.Builders;
using Xunit.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace IntegrationTests
{
    public class BlogRepositoryTests : IDisposable
    {

        private readonly BloggingContext _bloggingContext;
        private readonly BlogRepository _blogRepository;
        private BlogBuilder BlogBuilder { get; } = new BlogBuilder();
        private readonly ITestOutputHelper _output;


        public void Dispose()
        {
            _bloggingContext.Database.CloseConnection();
        }

        public BlogRepositoryTests(ITestOutputHelper output)
        {
            _output = output;


            var connection = new SqliteConnection("DataSource=:memory:");

            var dbOptions = new DbContextOptionsBuilder<BloggingContext>()
                .UseSqlite(connection)
                .Options;

            _bloggingContext = new BloggingContext(dbOptions);
            _blogRepository = new BlogRepository(_bloggingContext);

            _bloggingContext.Database.OpenConnection();
            _bloggingContext.Database.EnsureCreated();

        }



        [Fact]
        public void GetExistingBlog()
        {
            var blog = BlogBuilder.WithDefaultValues().Build();
            _blogRepository.Add(blog);
            var receivedBlog = _blogRepository.GetById(blog.Id);
            Assert.Equal(blog.Id, receivedBlog.Id);
        }

        [Fact]

        public void GetByIdWithRecordsTest()
        {
            var blog = BlogBuilder.WithDefaultValues().Build();
            _blogRepository.Add(blog);
            var receivedBlog = _blogRepository.GetByIdWithRecords(blog.Id);
            Assert.Equal(blog.Posts.First(), receivedBlog.Posts.First());

        }

    }

}
