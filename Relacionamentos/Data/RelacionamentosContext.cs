using Relacionamentos.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection.Metadata;

namespace Relacionamentos.Data
{
    public class RelacionamentosContext : DbContext
    {
        public RelacionamentosContext(DbContextOptions<RelacionamentosContext> options)
            : base(options)
        { }
        public DbSet<Blog> ?Blogs { get; set; }
        public DbSet<Post> ?Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Blog>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<Post>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Posts)
                .WithOne(p => p.Blogs)
                .HasForeignKey(p => p.BlogId);
        }
    }
}
