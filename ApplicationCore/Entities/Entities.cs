using AspNetCore.BestPractices.ApplicationCore.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCore.BestPractices.ApplicationCore.Entities
{
    public class Blog : BaseEntity
    {
        public string Url { get; set; }
        public Name Author { get; set; }

        private readonly List<Post> _posts = new List<Post>();
        public IReadOnlyCollection<Post> Posts => _posts.AsReadOnly();
        public Blog()
        {

        }
        public Blog(string url, Name author, List<Post> posts)
        {
            Url = url;
            Author = author;
            _posts = posts;
        }
        public void AddPost(int postId, string title, string content)
        {
            if (!Posts.Any(p => p.Id == postId))
            {
                _posts.Add(new Post() { Id = postId, Title = title, Content = content });
            }
        }
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
