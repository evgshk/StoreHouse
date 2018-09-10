using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoreHouse.API.Data.StoreHouseStorage.Domain
{
    public partial class StoreHouseContext : DbContext
    {
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Stocks> Stocks { get; set; }
        public virtual DbSet<Warehouses> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StoreHouse;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Documents>(entity =>
            {
                entity.ToTable("documents");

                entity.HasIndex(e => e.StockId)
                    .HasName("NonClusteredIndex_stockId");

                entity.HasIndex(e => e.WarehouseFrom)
                    .HasName("NonClusteredIndex_warehouseFrom");

                entity.HasIndex(e => e.WarehouseTo)
                    .HasName("NonClusteredIndex_warehouseTo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.StockId).HasColumnName("stockId");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.Property(e => e.WarehouseFrom).HasColumnName("warehouseFrom");

                entity.Property(e => e.WarehouseTo).HasColumnName("warehouseTo");

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.StockId)
                    .HasConstraintName("FK_document_product");

                entity.HasOne(d => d.WarehouseFromNavigation)
                    .WithMany(p => p.DocumentsWarehouseFromNavigation)
                    .HasForeignKey(d => d.WarehouseFrom)
                    .HasConstraintName("FK_document_warehouseFrom");

                entity.HasOne(d => d.WarehouseToNavigation)
                    .WithMany(p => p.DocumentsWarehouseToNavigation)
                    .HasForeignKey(d => d.WarehouseTo)
                    .HasConstraintName("FK_document_warehouseTo");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Stocks>(entity =>
            {
                entity.ToTable("stocks");

                entity.HasIndex(e => e.ProductId)
                    .HasName("NonClusteredIndex_productId");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("NonClusteredIndex_warehouseId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.Property(e => e.WarehouseId).HasColumnName("warehouseId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_stocks_products");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("FK_stocks_warehouses");
            });

            modelBuilder.Entity<Warehouses>(entity =>
            {
                entity.ToTable("warehouses");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.Adress)
                    .HasColumnName("adress")
                    .HasMaxLength(255);

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(8);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });
        }
    }
}