using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StoreManagement.Data.Model.StoreManagement;

public partial class StoreManagementContext : DbContext
{
    public StoreManagementContext()
    {
    }

    public StoreManagementContext(DbContextOptions<StoreManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivityLog> ActivityLogs { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6IKOV6U;Initial Catalog=StoreManagement;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Activity__3214EC07B2F03272");

            entity.Property(e => e.Activity)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Module)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.User)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ErrorLog__3214EC0704B235D8");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.ErrorMessage)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Module)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.User)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC276B45E585");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProductCategory");

            entity.Property(e => e.Category)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
