using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sql;

public partial class RentalDbContext : DbContext
{
    public RentalDbContext()
    {
    }

    public RentalDbContext(DbContextOptions<RentalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarsTbl> CarsTbls { get; set; }

    public virtual DbSet<CustomerTbl> CustomerTbls { get; set; }

    public virtual DbSet<EmployeePayTbl> EmployeePayTbls { get; set; }

    public virtual DbSet<EmployeeTbl> EmployeeTbls { get; set; }

    public virtual DbSet<RentalsTbl> RentalsTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-4G5A9E;Database=Rental_db;Trusted_connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarsTbl>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__Cars_tbl__68A0340E138739CD");

            entity.ToTable("Cars_tbl");

            entity.Property(e => e.CarId)
                .ValueGeneratedNever()
                .HasColumnName("CarID");
            entity.Property(e => e.Company)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PricePerKm)
                .HasColumnType("money")
                .HasColumnName("PricePerKM");
            entity.Property(e => e.PricePerMonth).HasColumnType("money");
        });

        modelBuilder.Entity<CustomerTbl>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK__Customer__049E3A8964C4522D");

            entity.ToTable("Customer_tbl");

            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.CustAddress)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CustCity)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CustFax)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CustName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CustPhone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EmpID");

            entity.HasOne(d => d.Emp).WithMany(p => p.CustomerTbls)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__Customer___EmpID__3C69FB99");
        });

        modelBuilder.Entity<EmployeePayTbl>(entity =>
        {
            entity.HasKey(e => new { e.EmpId, e.Position }).HasName("PK__Employee__2A850FF26F5BCB9F");

            entity.ToTable("Employee_pay_tbl");

            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EmpID");

            entity.HasOne(d => d.Emp).WithMany(p => p.EmployeePayTbls)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee___EmpID__398D8EEE");
        });

        modelBuilder.Entity<EmployeeTbl>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBA79B2ED754C");

            entity.ToTable("Employee_tbl");

            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EmpID");
            entity.Property(e => e.Address)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RentalsTbl>(entity =>
        {
            entity.HasKey(e => e.RentalNum).HasName("PK__Rentals___86CACCB88F6D0CF4");

            entity.ToTable("Rentals_tbl");

            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.Km).HasColumnName("KM");

            entity.HasOne(d => d.Car).WithMany(p => p.RentalsTbls)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__Rentals_t__CarID__4222D4EF");

            entity.HasOne(d => d.Cust).WithMany(p => p.RentalsTbls)
                .HasForeignKey(d => d.CustId)
                .HasConstraintName("FK__Rentals_t__CustI__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
