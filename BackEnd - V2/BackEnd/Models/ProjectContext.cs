using BackEnd.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models
{
    public class ProjectContext : IdentityDbContext<ApplicationUser>
    {
        public ProjectContext()
        {

        }
        public ProjectContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=eLearning8Project; Integrated Security=True");
        }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        public virtual DbSet<StudentCertificate> StudentCertificates { get; set; }
    }

    
}

