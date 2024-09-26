using Greenovative.Identity.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityManager.Data;


public partial class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
{
    public ApplicationDbContext() { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=172.18.16.1,1432;Initial Catalog=Db_Greenovative_Dev;User ID=sa;Password=nebula!123;Encrypt=True;TrustServerCertificate=True;");

    //protected override void OnConfiguring(DbContextOptionsBuilder options) =>
    //options.UseSqlite("DataSource = identityDb; Cache=Shared");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("identity");
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}