using Microsoft.EntityFrameworkCore;
using Shared;

namespace EfcDataAccess;

public class PostContext:DbContext

{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/Post.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>().HasKey(todo => todo.Id);
        modelBuilder.Entity<User>().HasKey(user => user.Id);
    }
}