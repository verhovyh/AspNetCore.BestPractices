using AspNetCore.BestPractices.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.BestPractices.ApplicationCore.Interfaces
{
    public interface IBlogRepository : IRepository<Blog>, IAsyncRepository<Blog>
    {
        Blog GetByIdWithRecords(int id);
        Task<Blog> GetByIdWithRecordsAsync(int id);
    }
}
