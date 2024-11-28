using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassFunction.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassFunction.Presentations
{
    public class EduDbContext : DbContext
{
        public EduDbContext():base()
        {
            
        }
        public EduDbContext(DbContextOptions<EduDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Class>();
            modelBuilder.Entity<Student>();
        }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

    }
}