using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPICRUD.Models
{
    public partial class DepartmentContext : DbContext
    {
        public DepartmentContext()
        {
        }

        public DepartmentContext(DbContextOptions<DepartmentContext> options) : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Departments"); 

                entity.HasKey(e => e.DepartmentId); 

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(100)
                    .IsRequired(); 

                entity.Property(e => e.HeadOfDepartment)
                    .HasMaxLength(50); 

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
