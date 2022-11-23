using System;
using System.Linq;
using EFGetStarted.Models;
using Microsoft.EntityFrameworkCore;

using var db = new BloggingContext();

// // Create
// Console.WriteLine("Inserting a new blog");
// db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
// db.SaveChanges();
//
// // Read
// Console.WriteLine("Querying for a blog");
// var blog = db.Blogs
//     .OrderBy(b => b.BlogId)
//     .First();
//
// // Update
// Console.WriteLine("Updating the blog and adding a post");
// blog.Url = "https://devblogs.microsoft.com/dotnet";
// blog.Posts.Add(
//     new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
// db.SaveChanges();
//
// // Delete
// // Console.WriteLine("Delete the blog");
// // db.Remove(blog);
// // db.SaveChanges();
//
//
//
//
// create 
// var blog1 = new Blog()
// {
//     Url = "hello", Posts =
//     {
//         new Post()
//         {
//             Title = "lang", Content = "persian"
//         }
//     }
// };
// var addedBlog = db.Blogs.Add(blog1);
// await db.SaveChangesAsync();
//
// var blogs = new List<Blog>()
// {
//     new Blog() {Url = "url1"},
//     new Blog() {Url = "url2"}
// };
// var savedBlogs = db.Blogs.AddRangeAsync(blogs);
// await db.SaveChangesAsync();

// db.Blogs.Remove(new Blog(){BlogId = 2});
// await db.SaveChangesAsync();


// db.Teachers.Add(new Teacher()
// {
//     Name = "Bohlouli"
// });
//
// await db.SaveChangesAsync();

var teacher = db.Teachers.Include(t => t.Student).First();

//
// var students = new List<Student>()
// {
//     new Student() {Name = "ali goli"},
//     new Student() {Name = "reza mehtari"}
// };
// teacher.Student = students;
teacher.Student.Add(new Student(){Name = "sadra"});

await db.SaveChangesAsync();


