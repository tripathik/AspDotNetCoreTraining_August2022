using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfmDomainModel.Models;

namespace WfmDataContext
{
    public class WfmDbContext : DbContext
    {
        public DbSet<employees> Employees { get; set; }
        public DbSet<skillmap> Skillmap { get; set; }
        public DbSet<skills> Skills { get; set; }
        public DbSet<softlock> Softlock { get; set; }
        public DbSet<users> Users { get; set; }
        
        public WfmDbContext() 
        {

        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"server=ISTLP100\KRISHNATRIPATHI;Integrated security=true;Database=WFM_DB;Trusted_Connection=True;");
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsetting.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DBConnectionString");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            configureModels(modelBuilder);
        }



        private void configureModels(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<employees>(entity =>
            {
                entity.Property(e => e.Employee_id).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Manager)
                    .HasMaxLength(30);

                entity.Property(e => e.Wfm_manager)
                    .HasMaxLength(30);

                entity.Property(e => e.Email)
                    .HasMaxLength(100);

                entity.Property(e => e.Lockstatus)
                    .HasMaxLength(30);

                entity.Property(e => e.Experience);
                entity.Property(e => e.Profile_id);

            });

            modelBuilder.Entity<users>(entity =>
            {
                entity.HasKey(e => e.UserName);
                entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(30);

                entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsRequired();

                entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsRequired();

                entity.Property(e => e.Role)
                .HasMaxLength(30)
                .IsRequired();

                entity.Property(e => e.Email)
                .HasMaxLength(30);
            });

            modelBuilder.Entity<skills>(entity =>
            {
                entity.HasKey(e => e.Skillid);
                entity.Property(e => e.Skillid)
                .IsRequired();

                entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsRequired();
            });

            modelBuilder.Entity<skillmap>(entity =>
            {
                entity.Property(e => e.Skillid);
                entity.Property(e => e.Employee_id);
                entity.HasNoKey();
                entity.HasOne(e => e.employees)
                .WithMany()
                .HasForeignKey(d => d.Employee_id)
                .HasConstraintName("FK_EmployeeId");

                entity.HasOne(e => e.skills)
                .WithMany()
                .HasForeignKey(d => d.Skillid)
                .HasConstraintName("FK_SkillId");
            });

            modelBuilder.Entity<softlock>(entity =>
            {
                entity.HasKey(e => e.LockId);
                entity.Property(e => e.LockId)
                .IsRequired()
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Employee_id);

                entity.Property(e => e.Manager)
                .HasMaxLength(30);

                entity.Property(e => e.ReqDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                .HasMaxLength(30);

                entity.Property(e => e.Lastupdated).HasColumnType("datetime");

                entity.Property(e => e.RequestMessage)
                .HasMaxLength(100);

                entity.Property(e => e.WfmRemark)
                .HasMaxLength(100);

                entity.Property(e => e.ManagerStatus)
                .HasMaxLength(30);

                entity.Property(e => e.MgrStatusComment)
                .HasMaxLength(100);

                entity.Property(e => e.MgrLastUpdate).HasColumnType("datetime");
            });
        }
    }
}