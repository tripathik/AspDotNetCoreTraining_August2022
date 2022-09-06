using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreDBFirst.Models
{
    public partial class wfmContext : DbContext
    {
        public wfmContext()
        {
        }

        public wfmContext(DbContextOptions<wfmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<Skillmap> Skillmaps { get; set; } = null!;
        public virtual DbSet<Softlock> Softlocks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ISTLP100\\KRISHNATRIPATHI;Database=wfm;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(x => x.EmployeeId);

                entity.ToTable("employees");

                entity.Property(e => e.Email).HasColumnType("text");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.Experience).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Lockstatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Manager)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileId).HasColumnName("Profile_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WfmManager)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Wfm_manager");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("skills");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Skillid).HasColumnType("decimal(5, 0)");
            });

            modelBuilder.Entity<Skillmap>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("skillmap");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.Skillid).HasColumnType("decimal(5, 0)");
            });

            modelBuilder.Entity<Softlock>(entity =>
            {
                entity.HasKey(e => e.LockId)
                    .HasName("PK__softlock__E7C1E232822B7CD1");

                entity.ToTable("softlock");

                entity.Property(e => e.LockId).ValueGeneratedNever();

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.Lastupdated).HasColumnType("date");

                entity.Property(e => e.Manager)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MgrLastUpdate).HasColumnType("date");

                entity.Property(e => e.MgrStatusComment).HasColumnType("text");

                entity.Property(e => e.ReqDate).HasColumnType("date");

                entity.Property(e => e.RequestMessage).HasColumnType("text");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WfmRemark).HasColumnType("text");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("users");

                entity.Property(e => e.Email).HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
