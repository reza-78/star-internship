namespace EFGetStarted.Models;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("Host=localhost;Username=EFCore_user;Password=12345aA@;Database=EFCore");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasOne(p => p.Blog)
                .WithMany(b => b.Posts)
                .HasForeignKey(p => p.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Teacher>().HasMany(t => t.Student)
            .WithMany(t => t.Teacher)
            .UsingEntity(j => j.ToTable("TeacherStudent"));
    }
}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }

    public List<Post> Posts { get; } = new();
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Teacher> Teacher { get; set; } //collection navigation property
}

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Student> Student { get; set; } //collection navigation property
}