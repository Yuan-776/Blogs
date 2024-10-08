using Microsoft.EntityFrameworkCore;
using Blogs.Models;


public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
     public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }
    
    public void AddBlog(Blog blog)
    {
        this.Add(blog);
        this.SaveChanges();
    }

    public void DeleteBlog(Blog blog)
    {
        this.Remove(blog);
        this.SaveChanges();
    }

    public void AddPost(Post post)
    {
        this.Add(post);
        this.SaveChanges();
    }

    public void DeletePost(Post post)
    {
        this.Remove(post);
        this.SaveChanges();
    }
}
