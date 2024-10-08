﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Greenovative.Clients.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Greenovative.Clients.Infrastructure;

public partial class ClientDbContext : DbContext
{
    public ClientDbContext()
    {
    }

    public ClientDbContext(DbContextOptions<ClientDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<BusinessCategory> BusinessCategories { get; set; }

    public virtual DbSet<BusinessType> BusinessTypes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<UserClientRole> UserClientRoles { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        => optionsBuilder.UseSqlServer("Data Source=localhost,1432;Initial Catalog=Db_Greenovative_dev;User ID=sa;Password=nebula!123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address", "Client");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.Addr1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Addr2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Zip)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BusinessCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BusinessCategory", "Client");

            entity.Property(e => e.BusinessCategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
        });

        modelBuilder.Entity<BusinessType>(entity =>
        {
            entity.ToTable("BusinessType", "Client");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.BusinessTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client", "Client");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.AddressId).HasMaxLength(50);
            entity.Property(e => e.ClientFName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClientLName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClientMName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactId).HasMaxLength(50);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Address).WithMany(p => p.Clients)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_Client_Address");

            entity.HasOne(d => d.Contact).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK_Client_Contact");

            entity.HasMany(d => d.Stores).WithOne(p => p.Client)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_Client_Store");

        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contact", "Client");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.CellPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OfficePhone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.ToTable("Store", "Client");

            entity.Property(e => e.AddressId).HasMaxLength(50);
            entity.Property(e => e.ClientId).HasMaxLength(50);
            entity.Property(e => e.ContactId).HasMaxLength(50);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegisteredName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StoreName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StoreNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TINNo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Address).WithMany(p => p.Stores)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_Store_Address");

            entity.HasOne(d => d.Client).WithMany(p => p.Stores)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_Store_Client");

            entity.HasOne(d => d.Contact).WithMany(p => p.Stores)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK_Store_Contact");
        });

        modelBuilder.Entity<UserClientRole>(entity =>
        {
            entity.ToTable("UserClientRole", "Client");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}