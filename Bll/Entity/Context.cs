using Bll.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Bll.Entity
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }
        public DbSet<Author> Author { get; set; }

        public DbSet<Article> Article { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData
                (
                    new UserRole() { Id = 1, Role = "Admin", Code = "1" }
                );
            modelBuilder.Entity<User>().HasData
                (
                    new User() { Id = 1, UserRoleId = 1, EmailAddress = "admin@admin.com", Name = "admin", Surname = "admin", Password = "C4CA4238A0B923820DCC509A6F75849B", IsActive = true, IsDeleted = false } /* Password MD5 1 karşılığıdır. */
                );

        }

    }
}
