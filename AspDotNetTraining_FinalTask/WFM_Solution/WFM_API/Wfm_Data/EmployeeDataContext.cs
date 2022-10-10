using Microsoft.EntityFrameworkCore;
using WFM_API.Wfm_DomainModel;

namespace WFM_API.Wfm_Data
{
    public class EmployeeDataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillMap> SkillMaps { get; set; }
        public DbSet<SoftLock> SoftLocks { get; set; }
        public DbSet<User> Users { get; set; }

        public EmployeeDataContext(DbContextOptions<EmployeeDataContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillMap>().HasKey(sc => new { sc.EmployeeId, sc.SkillId });

            modelBuilder.Entity<SkillMap>()
                .HasOne<Employee>(sc => sc.Employees)
                .WithMany(s => s.SkillMaps)
                .HasForeignKey(sc => sc.EmployeeId);


            modelBuilder.Entity<SkillMap>()
                .HasOne<Skill>(sc => sc.Skills)
                .WithMany(s => s.SkillMaps)
                .HasForeignKey(sc => sc.SkillId);

            //Employees has one to many relationship with SoftLock
            modelBuilder.Entity<SoftLock>()
               .HasOne(bc => bc.Employees)
               .WithMany(b => b.SoftLocks)
               .HasForeignKey(bc => bc.EmployeeId);

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeID = 1,
                    Name = "Balkrishna Tripathi",
                    Status = "Active",
                    Manager = "Rajarajan",
                    Wfm_Manager = "Sabitha Balakrishnan",
                    Email = "bkt123@gmail.com",
                    LockStatus = "Not_Requested",
                    Experience = 2,
                    ProfileId = 1

                },
                new Employee
                {
                    EmployeeID = 2,
                    Name = "Rahul Mongia",
                    Status = "Active",
                    Manager = "Dheeraj Raj",
                    Wfm_Manager = "Sabithabalakrishnan",
                    Email = "rahulm@gmail.com",
                    LockStatus = "Not_Requested",
                    Experience = 2,
                    ProfileId = 1

                },
                new Employee
                {
                    EmployeeID = 3,
                    Name = "Raju Rastogi",
                    Status = "Active",
                    Manager = "Krishna Tripathi",
                    Wfm_Manager = "Raghuraj",
                    Email = "raju@gmail.com",
                    LockStatus = "Requested",
                    Experience = 2,
                    ProfileId = 1

                });
            modelBuilder.Entity<Skill>().HasData(

                new Skill
                {
                    Id = 1,
                    Name = "C#"
                },
                      new Skill
                      {
                          Id = 2,
                          Name = "Python"
                      },
                            new Skill
                            {
                                Id = 3,
                                Name = "React JS"
                            },
                                  new Skill
                                  {
                                      Id = 4,
                                      Name = "Mongo DB"
                                  });


        }
    }
}
