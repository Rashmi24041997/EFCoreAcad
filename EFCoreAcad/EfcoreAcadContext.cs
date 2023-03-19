using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAcad;

public partial class EfcoreAcadContext : DbContext
{
    public EfcoreAcadContext()
    {
    }

    public EfcoreAcadContext(DbContextOptions<EfcoreAcadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Addrese> Addreses { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("filename=EFCoreAcad.DB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasIndex(e => e.AddressId, "IX_Classes_AddressId");

            entity.HasIndex(e => e.ClassId, "IX_Classes_ClassId");

            entity.HasIndex(e => e.ProfessorId, "IX_Classes_ProfessorId");

            entity.HasOne(d => d.Address).WithMany(p => p.Classes).HasForeignKey(d => d.AddressId);

            entity.HasOne(d => d.ClassNavigation).WithMany(p => p.InverseClassNavigation).HasForeignKey(d => d.ClassId);

            entity.HasOne(d => d.Professor).WithMany(p => p.Classes).HasForeignKey(d => d.ProfessorId);

            entity.HasMany(d => d.Students).WithMany(p => p.Classes)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassStudent",
                    r => r.HasOne<Student>().WithMany().HasForeignKey("StudentsId"),
                    l => l.HasOne<Class>().WithMany().HasForeignKey("ClassesId"),
                    j =>
                    {
                        j.HasKey("ClassesId", "StudentsId");
                        j.ToTable("ClassStudent");
                        j.HasIndex(new[] { "StudentsId" }, "IX_ClassStudent_StudentsId");
                    });
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasIndex(e => e.AddressId, "IX_Professors_AddressId");

            entity.HasOne(d => d.Address).WithMany(p => p.Professors).HasForeignKey(d => d.AddressId);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasIndex(e => e.AddressId, "IX_Students_AddressId");

            entity.HasIndex(e => e.StudentId, "IX_Students_StudentId");

            entity.HasOne(d => d.Address).WithMany(p => p.Students).HasForeignKey(d => d.AddressId);

            entity.HasOne(d => d.StudentNavigation).WithMany(p => p.InverseStudentNavigation).HasForeignKey(d => d.StudentId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
