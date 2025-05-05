using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using QuanLyThuQuan.Web.Models;

namespace QuanLyThuQuan.Web.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Regulation> Regulations { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<ReservationDetail> ReservationDetails { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Violation> Violations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=LibraryDB;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.2.0-mysql"));
        //=> optionsBuilder.UseMySql("Server=localhost;Database=librarydb;Uid=root;Pwd=root;SslMode=none;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.2.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.DeviceId).HasName("PRIMARY");

            entity.ToTable("device");

            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PRIMARY");

            entity.ToTable("log");

            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.CheckinTime)
                .HasColumnType("datetime")
                .HasColumnName("checkin_time");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MemberId)
                .HasMaxLength(10)
                .HasColumnName("member_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PRIMARY");

            entity.ToTable("member");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "phone_number").IsUnique();

            entity.Property(e => e.MemberId)
                .ValueGeneratedNever()
                .HasColumnName("member_id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Class)
                .HasMaxLength(15)
                .HasColumnName("class");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Department)
                .HasMaxLength(15)
                .HasColumnName("department");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.Major)
                .HasMaxLength(15)
                .HasColumnName("major");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.Role)
                .HasColumnType("enum('member','admin')")
                .HasColumnName("role");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Regulation>(entity =>
        {
            entity.HasKey(e => e.RegulationId).HasName("PRIMARY");

            entity.ToTable("regulation");

            entity.Property(e => e.RegulationId).HasColumnName("regulation_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PRIMARY");

            entity.ToTable("reservation");

            entity.HasIndex(e => e.MemberId, "member_id");

            entity.HasIndex(e => e.SeatId, "seat_id");

            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DueTime)
                .HasColumnType("datetime")
                .HasColumnName("due_time");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.ReservationTime)
                .HasColumnType("datetime")
                .HasColumnName("reservation_time");
            entity.Property(e => e.ReservationType).HasColumnName("reservation_type");
            entity.Property(e => e.ReturnTime)
                .HasColumnType("datetime")
                .HasColumnName("return_time");
            entity.Property(e => e.SeatId).HasColumnName("seat_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");

            entity.HasOne(d => d.Member).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("reservation_ibfk_1");

            entity.HasOne(d => d.Seat).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.SeatId)
                .HasConstraintName("reservation_ibfk_2");
        });

        modelBuilder.Entity<ReservationDetail>(entity =>
        {
            entity.HasKey(e => e.ReservationDetailId).HasName("PRIMARY");

            entity.ToTable("reservation_detail");

            entity.HasIndex(e => e.DeviceId, "device_id");

            entity.HasIndex(e => e.ReservationId, "reservation_id");

            entity.Property(e => e.ReservationDetailId).HasColumnName("reservation_detail_id");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");

            entity.HasOne(d => d.Device).WithMany(p => p.ReservationDetails)
                .HasForeignKey(d => d.DeviceId)
                .HasConstraintName("reservation_detail_ibfk_1");

            entity.HasOne(d => d.Reservation).WithMany(p => p.ReservationDetails)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("reservation_detail_ibfk_2");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.SeatId).HasName("PRIMARY");

            entity.ToTable("seat");

            entity.Property(e => e.SeatId).HasColumnName("seat_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Violation>(entity =>
        {
            entity.HasKey(e => e.ViolationId).HasName("PRIMARY");

            entity.ToTable("violation");

            entity.HasIndex(e => e.MemberId, "member_id");

            entity.HasIndex(e => e.RegulationId, "regulation_id");

            entity.HasIndex(e => e.ReservationId, "reservation_id");

            entity.Property(e => e.ViolationId).HasColumnName("violation_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DueTime)
                .HasColumnType("datetime")
                .HasColumnName("due_time");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.Penalty)
                .HasMaxLength(255)
                .HasColumnName("penalty");
            entity.Property(e => e.RegulationId).HasColumnName("regulation_id");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnName("status");

            entity.HasOne(d => d.Member).WithMany(p => p.Violations)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("violation_ibfk_1");

            entity.HasOne(d => d.Regulation).WithMany(p => p.Violations)
                .HasForeignKey(d => d.RegulationId)
                .HasConstraintName("violation_ibfk_2");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Violations)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("violation_ibfk_3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
