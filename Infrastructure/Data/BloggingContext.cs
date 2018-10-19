using AspNetCore.BestPractices.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.BestPractices.Infrastructure.Data
{
    public class BloggingContext : DbContext
    {
        public BloggingContext()
        {

        }
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>(ConfigurePostTag);
        }

        private void ConfigurePostTag(EntityTypeBuilder<PostTag> entity)
        {
            entity.HasKey(e => new { e.PostId, e.TagId });

            entity.HasOne(pt => pt.Post)
                .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId);

            entity.HasOne(pt => pt.Tag)
                .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.TagId);
        }
    }
}
