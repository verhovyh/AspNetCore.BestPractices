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

        private readonly List<PostTag> _postTags = new List<PostTag>();
        public IReadOnlyCollection<PostTag> PostTags => _postTags.AsReadOnly();

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        private readonly List<PostTag> _postTags = new List<PostTag>();
        public IReadOnlyCollection<PostTag> PostTags => _postTags.AsReadOnly();
    }

    public class PostTag : BaseEntity
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}
