using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FrostyBear.Models;

public partial class FrostyBearContext : DbContext
{
    public FrostyBearContext()
    {
    }

    public FrostyBearContext(DbContextOptions<FrostyBearContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartDetail> CartDetails { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SalesDaily> SalesDailies { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=FrostyBear;User ID=sa;Password=hello13;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brands__5E5A8E277B7F0A1A");

            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("brand_name");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__2EF52A2752437C0A");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.CartDate)
                .HasColumnType("datetime")
                .HasColumnName("cart_date");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.IsCheckedOut).HasColumnName("is_checked_out");
            entity.Property(e => e.TotalAmount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("total_amount");

            entity.HasOne(d => d.Customer).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Cart__customer_i__4CA06362");
        });

        modelBuilder.Entity<CartDetail>(entity =>
        {
            entity.HasKey(e => e.CartDetailId).HasName("PK__Cart_Det__0F08F529FFE7A5DB");

            entity.ToTable("Cart_Details");

            entity.Property(e => e.CartDetailId).HasColumnName("cart_detail_id");
            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("quantity");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartDetails)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK__Cart_Deta__cart___4D94879B");

            entity.HasOne(d => d.Product).WithMany(p => p.CartDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Cart_Deta__produ__4E88ABD4");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__D54EE9B4253AF942");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__CD65CB85DFB263E7");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customer_address");
            entity.Property(e => e.CustomerContact)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customer_contact");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customer_name");
            entity.Property(e => e.CustomerPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_password");
            entity.Property(e => e.CustomerUsername)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_username");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.DeliveryId).HasName("PK__Deliveri__1C5CF4F5F3323A4B");

            entity.Property(e => e.DeliveryId).HasColumnName("delivery_id");
            entity.Property(e => e.DeliveryDate)
                .HasColumnType("datetime")
                .HasColumnName("delivery_date");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");

            entity.HasOne(d => d.Sale).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__Deliverie__sale___4F7CD00D");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__C52E0BA8D495C3CA");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EmployeeContact)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employee_contact");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employee_name");
            entity.Property(e => e.EmployeePassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("employee_password");
            entity.Property(e => e.EmployeeUsername)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("employee_username");
            entity.Property(e => e.PositionId).HasColumnName("position_id");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Employees__posit__5070F446");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__Position__99A0E7A4E6754C19");

            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.PositionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("position_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__47027DF54FD19BBA");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Detail)
                .HasColumnType("text")
                .HasColumnName("detail");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("product_price");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__Products__brand___52593CB8");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__catego__5165187F");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sales__E1EB00B20631AABA");

            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SaleDate)
                .HasColumnType("datetime")
                .HasColumnName("sale_date");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Sales__customer___5441852A");

            entity.HasOne(d => d.Employee).WithMany(p => p.Sales)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Sales__employee___5535A963");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Sales__product_i__534D60F1");
        });

        modelBuilder.Entity<SalesDaily>(entity =>
        {
            entity.HasKey(e => e.SaleDate).HasName("PK__Sales_Da__387C7FF8F39F7425");

            entity.ToTable("Sales_Daily");

            entity.Property(e => e.SaleDate).HasColumnName("sale_date");
            entity.Property(e => e.TotalSale)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_sale");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__85C600AF430C59FE");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("transaction_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.SaleDate).HasColumnName("sale_date");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Transacti__custo__5812160E");

            entity.HasOne(d => d.Employee).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Transacti__emplo__571DF1D5");

            entity.HasOne(d => d.Sale).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__Transacti__sale___5629CD9C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
