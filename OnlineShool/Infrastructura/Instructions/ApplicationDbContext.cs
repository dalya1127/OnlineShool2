using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Infrastructura.Sql_Server;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<HomeWork> HomeWorks { get; set; }

    public virtual DbSet<ImplementingHomeWork> ImplementingHomeWorks { get; set; }

    public virtual DbSet<ImplementingLesson> ImplementingLessons { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<LinksLessonsHomeWork> LinksLessonsHomeWorks { get; set; }

    public virtual DbSet<LinksVideoLesson> LinksVideoLessons { get; set; }

    public virtual DbSet<PurchasedCourse> PurchasedCourses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<StatusHomeWork> StatusHomeWorks { get; set; }

    public virtual DbSet<StatusLesson> StatusLessons { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=master;User Id=sa;Password=Password1!;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC07C9E1CE2E");

            entity.Property(e => e.Text).HasMaxLength(500);

            entity.HasOne(d => d.IdLessonsNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdLessons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_CommentsLessons");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_CommentsUser");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC07F5DF98C9");

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.LinkPic).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(70);
        });

        modelBuilder.Entity<HomeWork>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HomeWork__3214EC07D7EF6449");

            entity.ToTable("HomeWork");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.LinkFile).HasMaxLength(250);
        });

        modelBuilder.Entity<ImplementingHomeWork>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Implemen__3214EC07867E0644");

            entity.ToTable("ImplementingHomeWork");

            entity.Property(e => e.LinkFile).HasMaxLength(250);
            entity.Property(e => e.Score).HasColumnName("SCORE");

            entity.HasOne(d => d.IdHomeWorkNavigation).WithMany(p => p.ImplementingHomeWorks)
                .HasForeignKey(d => d.IdHomeWork)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_ImplementingHomeWorkHomeWork");

            entity.HasOne(d => d.IdStatusHomeWorkNavigation).WithMany(p => p.ImplementingHomeWorks)
                .HasForeignKey(d => d.IdStatusHomeWork)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_ImplementingHomeworkStatusHomework");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.ImplementingHomeWorks)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_ImplementingHomeworkUser");
        });

        modelBuilder.Entity<ImplementingLesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Implemen__3214EC07E6BAFC2B");

            entity.Property(e => e.Description).HasMaxLength(200);

            entity.HasOne(d => d.IdLessonsNavigation).WithMany(p => p.ImplementingLessons)
                .HasForeignKey(d => d.IdLessons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_ImplementingLessonsLesson");

            entity.HasOne(d => d.IdStatusLessonsNavigation).WithMany(p => p.ImplementingLessons)
                .HasForeignKey(d => d.IdStatusLessons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_ImplementingLessonsStatusLessons");

            entity.HasOne(d => d.IdUsersNavigation).WithMany(p => p.ImplementingLessons)
                .HasForeignKey(d => d.IdUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_ImplementingLessonsUser");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lessons__3214EC07F64578FA");

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.LinkFile).HasMaxLength(250);
            entity.Property(e => e.LinkPic).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(70);

            entity.HasOne(d => d.IdCoursesNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.IdCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_LessonsCourse");
        });

        modelBuilder.Entity<LinksLessonsHomeWork>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LinksLes__3214EC07A39CED2E");

            entity.ToTable("LinksLessonsHomeWork");

            entity.HasOne(d => d.IdHomeworkNavigation).WithMany(p => p.LinksLessonsHomeWorks)
                .HasForeignKey(d => d.IdHomework)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_LinksLessonsHomeWorkHomeWork");

            entity.HasOne(d => d.IdLessonsNavigation).WithMany(p => p.LinksLessonsHomeWorks)
                .HasForeignKey(d => d.IdLessons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_LinksLessonsHomeWorkLessons");
        });

        modelBuilder.Entity<LinksVideoLesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LinksVid__3214EC07550C28B9");

            entity.HasOne(d => d.IdLessonsNavigation).WithMany(p => p.LinksVideoLessons)
                .HasForeignKey(d => d.IdLessons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_LinksVideoLessonsLesson");

            entity.HasOne(d => d.IdVideosNavigation).WithMany(p => p.LinksVideoLessons)
                .HasForeignKey(d => d.IdVideos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_LinksVideoLessonsVideo");
        });

        modelBuilder.Entity<PurchasedCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purchase__3214EC0774E012D9");

            entity.HasOne(d => d.IdCoursesNavigation).WithMany(p => p.PurchasedCourses)
                .HasForeignKey(d => d.IdCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_PurchasedCoursesCourse");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.PurchasedCourses)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_PurchasedCoursesUser");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07ABCA2149");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<StatusHomeWork>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StatusHo__3214EC0712DCCEE0");

            entity.ToTable("StatusHomeWork");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(70);
        });

        modelBuilder.Entity<StatusLesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StatusLe__3214EC074EE1623E");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0775CA0001");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Login).HasMaxLength(30);
            entity.Property(e => e.Password).HasMaxLength(40);
            entity.Property(e => e.Patronymic).HasMaxLength(20);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_UsersRoles");
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Video__3214EC075656D910");

            entity.ToTable("Video");

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.LinkFile).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(70);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
