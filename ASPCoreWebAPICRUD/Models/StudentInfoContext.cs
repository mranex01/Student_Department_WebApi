using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace ASPCoreWebAPICRUD.Models;

public partial class StudentInfoContext : DbContext
{
    public StudentInfoContext()
    {
    }

    public StudentInfoContext(DbContextOptions<StudentInfoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Students");

            entity.HasKey(e => e.StudentId);

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(e => e.MiddleName)
                .HasMaxLength(50);

            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsRequired();

            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(e => e.Standard)
                .HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
