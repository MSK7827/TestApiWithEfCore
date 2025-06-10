using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace TestApiWithEfCore.NewFolder
{
    public class SchoolContext :DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<BasketModel> Basket { get; set; }
        public DbSet<BasketLoanItem> BasketLoanItems {  get; set; } 
        public DbSet<Customer> Customer { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            // One-to-One with separate PK and FK
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Basket)
                .WithOne(b => b.Customer)
                .HasForeignKey<BasketModel>(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many for BasketLoanItems
            modelBuilder.Entity<BasketModel>()
                .HasMany(b => b.BasketLoanItems)
                .WithOne(i => i.BasketModel)
                .HasForeignKey(i => i.BasketId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
