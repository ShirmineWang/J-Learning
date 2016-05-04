using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using J_LearingSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace J_LearningSystem.Data
{
    public class SystemContext : IdentityDbContext
    {
        public SystemContext()
            :base()
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Student>().ToTable("Students");

            base.OnModelCreating(modelBuilder);
        }

        public static SystemContext Create() {
            return new SystemContext();
        }

    }
}
