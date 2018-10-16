using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.BestPractices.ApplicationCore.Entities
{
    public class Blog : BaseEntity
    {
        public string Url { get; set; }
        public string Author { get; set; }

        public ICollection<Post> Posts { get; set; }
    }

    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
