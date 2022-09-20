using EmployeeDataCore;
using EmployeeDomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDomainModel
{
    public class EmployeeDataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public EmployeeDataContext()
        {

        }

        public EmployeeDataContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("data source=ISTLP100\\KRISHNATRIPATHI;Integrated security=true;Database=Employee_DB;Trusted_Connection=True");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            configureModels(modelBuilder);
        }
        private void configureModels(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Employee_Id);
                entity.Property(e => e.Employee_Id).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Manager)
                    .HasMaxLength(30);

                entity.Property(e => e.WFM_Manager)
                    .HasMaxLength(30);

                entity.Property(e => e.Email)
                    .HasMaxLength(100);

                entity.Property(e => e.Lockstatus)
                    .HasMaxLength(30);

                entity.Property(e => e.Experience);

            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(s => s.Skill_Id);
                entity.Property(s => s.Skill_Id).IsRequired();

                entity.Property(s => s.Name).IsRequired()
                .HasMaxLength(50);

            });
        }

    }
}
