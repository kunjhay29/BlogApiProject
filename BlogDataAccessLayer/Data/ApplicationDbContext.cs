using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDomainLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogDataAccessLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,Role,string>
    {
        // type ctor then tab
        // Creating constructor for DBCONTEXT CLASS

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // This is the constructor
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Your_Connection_String_Here", b => b.MigrationsAssembly("BlogDataAccessLayer"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // define default roles
        List<Role> roles = new List<Role>
        {
            new Role { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" },
            new Role { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER" }
        };

        modelBuilder.Entity<Role>().HasData(roles);

        modelBuilder.Entity<User>()
        .HasIndex(u => u.Email)
        .IsUnique(); // ✅ Enforces unique emails

        // Define composite primary key for PostCategory
        modelBuilder.Entity<PostCategory>()
        .HasKey(pc => new { pc.PostId, pc.CategoryId });



        modelBuilder.Entity<PostCategory>()
            .HasOne(pc => pc.Post)
            .WithMany(p => p.PostCategories)
            .HasForeignKey(pc => pc.PostId)
            .OnDelete(DeleteBehavior.Cascade); // Ensures categories get removed when a post is deleted

        modelBuilder.Entity<PostCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.PostCategories)
            .HasForeignKey(pc => pc.CategoryId)
            .OnDelete(DeleteBehavior.Cascade); // Ensures posts are unlinked when a category is deleted

        // Prevent multiple cascade paths issue in Comments
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevents cascade delete to avoid multiple cascade paths

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);  // Ensures users cannot be deleted if they have comments

        // Define Likes entity with restricted delete behavior to prevent multiple cascade paths
        modelBuilder.Entity<Like>()
            .HasOne(l => l.Post)
            .WithMany(p => p.Likes)
            .HasForeignKey(l => l.PostId)
            .OnDelete(DeleteBehavior.Restrict); // Prevents multiple cascade paths error

        modelBuilder.Entity<Like>()
            .HasOne(l => l.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Restrict); // Ensures users cannot be deleted if they have likes
    }




        //creating the tables

        public DbSet<Post> posts { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Comment> comments { get; set; }

        public DbSet<Like> likes { get; set; }

        public DbSet<PostCategory> postCategories { get; set; }


    }
}
