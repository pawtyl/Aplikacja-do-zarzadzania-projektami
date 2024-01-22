using aspnet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = aspnet.Models.Task;

namespace aspnet.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Task> Tasks { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>().HasData(
            new User { UserId = 1, Username = "admin", Password = "$2y$10$j7O3QOmF.VxKC2/Soa8fxOAbhwDpx4jdH.usBczLUYlkpCl4EnpSi", Role = "admin" },
            new User { UserId = 2, Username = "stefan", Password = "$2y$10$SV/7bHckFd33AuLAyVJKg.1qtk1hV70zXx9Fjn15I8n5HX2YBUW1S", Role = "user" }
        );
    }
}
