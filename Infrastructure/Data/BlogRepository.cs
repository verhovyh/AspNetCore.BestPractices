using AspNetCore.BestPractices.ApplicationCore.Entities;
using AspNetCore.BestPractices.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.BestPractices.Infrastructure.Data
{
    public class BlogRepository : EfRepository<Blog>, IBlogRepository
    {
        public BlogRepository(BloggingContext dbContext) : base(dbContext)
        {
        }

        public Blog GetByIdWithRecords(int id)
        {
            return _dbContext.Blogs
                .Include(b => b.Posts)
                .FirstOrDefault();
        }

        public Task<Blog> GetByIdWithRecordsAsync(int id)
        {
            return _dbContext.Blogs
                .Include(b => b.Posts)
                .FirstOrDefaultAsync();
        }
    }
}
