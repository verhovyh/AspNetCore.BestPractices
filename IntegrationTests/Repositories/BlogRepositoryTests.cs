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
            // possible issue here - db is not cleaned between tests. 
            // may be use _bloggingContext.Database.EnsureDeleted; after every test
            //or close/reopen connection in scope of each test method
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
            _output.WriteLine($"Blog Id: {blog.Id}");
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
