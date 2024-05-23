using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace gestionabscence.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Absences> Absences { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ProfessorSubjectAssignment> ProfessorSubjectAssignments { get; set; }
        public DbSet<GroupSubject> GroupSubjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.FullName).HasConversion<string>();
                entity.Property(e => e.IdCard).HasConversion<string>();
                entity.Property(e => e.Email).HasConversion<string>();
                entity.Property(e => e.Password).HasConversion<string>();
                entity.Property(e => e.BirthDate).HasConversion<DateTime>();
                entity.Property(e => e.Address).HasConversion<string>();
                entity.Property(e => e.Phone).HasConversion<string>();
                entity.Property(e => e.Role).HasConversion<string>().HasDefaultValue("Student");
                entity.Property(e => e.Gender).HasConversion<string>();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Students)
                      .HasForeignKey(e => e.UserId);

                entity.HasMany(e => e.Absences)
                      .WithOne(a => a.Student)
                      .HasForeignKey(a => a.StudentId);
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.ProfessorId);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Professors)
                      .HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminId);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Admins)
                      .HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.GroupId);
            });

            modelBuilder.Entity<Absences>(entity =>
            {
                entity.HasKey(e => e.AbsenceId);
                entity.HasOne(e => e.Student)
                      .WithMany(s => s.Absences)
                      .HasForeignKey(e => e.StudentId)
                      .HasForeignKey(e => e.SubjectId);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubjectId);
                entity.HasMany(e => e.ProfessorSubjectAssignments)
                      .WithOne(p => p.Subject)
                      .HasForeignKey(p => p.SubjectId);

                entity.HasMany(e => e.GroupSubjects)
                      .WithOne(gs => gs.Subject)
                      .HasForeignKey(gs => gs.SubjectId);
            });

            modelBuilder.Entity<ProfessorSubjectAssignment>(entity =>
            {
                entity.HasKey(e => e.AssignmentId);
                entity.HasOne(e => e.Subject)
                      .WithMany(s => s.ProfessorSubjectAssignments)
                      .HasForeignKey(e => e.SubjectId);
                entity.HasOne(e => e.Professor)
                      .WithMany(p => p.ProfessorSubjectAssignments)
                      .HasForeignKey(e => e.ProfessorId);
            });

            modelBuilder.Entity<GroupSubject>(entity =>
            {
                entity.HasKey(e => e.GroupSubjectId);
                entity.HasOne(e => e.Subject)
                      .WithMany(s => s.GroupSubjects)
                      .HasForeignKey(e => e.SubjectId);
                entity.HasOne(e => e.Group)
                      .WithMany(g => g.GroupSubjects)
                      .HasForeignKey(e => e.GroupId);
            });
        }
    }
    
}
