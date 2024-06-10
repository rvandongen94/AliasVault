﻿namespace AliasDb;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

/// <summary>
/// The AliasDbContext class.
/// </summary>
public class AliasDbContext : IdentityDbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AliasDbContext"/> class.
    /// </summary>
    public AliasDbContext()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AliasDbContext"/> class.
    /// </summary>
    /// <param name="options">DbContextOptions.</param>
    public AliasDbContext(DbContextOptions<AliasDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the Identities DbSet.
    /// </summary>
    public DbSet<Identity> Identities { get; set; }

    /// <summary>
    /// Gets or sets the Logins DbSet.
    /// </summary>
    public DbSet<Login> Logins { get; set; }

    /// <summary>
    /// Gets or sets the Passwords DbSet.
    /// </summary>
    public DbSet<Password> Passwords { get; set; }

    /// <summary>
    /// Gets or sets the Services DbSet.
    /// </summary>
    public DbSet<Service> Services { get; set; }

    /// <summary>
    /// Gets or sets the AspNetUserRefreshTokens DbSet.
    /// </summary>
    public DbSet<AspNetUserRefreshTokens> AspNetUserRefreshTokens { get; set; }

    /// <summary>
    /// Sets up the connection string if it is not already configured.
    /// </summary>
    /// <param name="optionsBuilder">DbContextOptionsBuilder instance.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // If the options are not already configured, use the appsettings.json file.
        // Tip: the E2E tests will provide a different connection string directly
        // which will override this default config.
        /*if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder
                .UseSqlite(configuration.GetConnectionString("AliasDbContext"))
                .UseLazyLoadingProxies();
        }    */
    }

    /// <summary>
    /// The OnModelCreating method.
    /// </summary>
    /// <param name="modelBuilder">ModelBuilder instance.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                // TODO: This is a workaround for SQLite. Add conditional check if SQLite is used.
                // TODO: SQL server doesn't need this override.
                // SQLite does not support varchar(max) so we use TEXT.
                if (property.ClrType == typeof(string) && property.GetMaxLength() == null)
                {
                    property.SetColumnType("TEXT");
                }
            }
        }

        // Configure Identity - Login relationship
        modelBuilder.Entity<Login>()
            .HasOne(l => l.Identity)
            .WithMany()
            .HasForeignKey(l => l.IdentityId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the Login - UserId entity
        modelBuilder.Entity<Login>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .IsRequired();

        // Configure Login - Service relationship
        modelBuilder.Entity<Login>()
            .HasOne(l => l.Service)
            .WithMany()
            .HasForeignKey(l => l.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Login - Password relationship
        modelBuilder.Entity<Login>()
            .HasMany(l => l.Passwords)
            .WithOne(p => p.Login)
            .HasForeignKey(p => p.LoginId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Identity - DefaultPassword relationship
        modelBuilder.Entity<Identity>()
            .HasOne(i => i.DefaultPassword)
            .WithMany()
            .HasForeignKey(i => i.DefaultPasswordId)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure the Login - UserId entity
        modelBuilder.Entity<AspNetUserRefreshTokens>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .IsRequired();
    }
}
