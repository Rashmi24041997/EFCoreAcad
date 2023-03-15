using EFCoreAcad.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAcad
{
    public class AppDBContext : DbContext
    {
        public DbSet<Address> Addreses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Class> Classes { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> Opns):base(Opns) { 
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=EFCoreAcad.DB");
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// define the db schema
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasKey(e=> e.Id);
            modelBuilder.Entity<Student>().HasKey(e=> e.Id);
            modelBuilder.Entity<Professor>().HasKey(e=> e.Id);
            modelBuilder.Entity<Class>().HasKey(e=> e.Id);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasOne(e=> e.Address);
            modelBuilder.Entity<Professor>().HasOne(e=> e.Address);

            modelBuilder.Entity<Class>().HasMany(e=> e.Students).WithMany(e=>e.Classes);
            modelBuilder.Entity<Class>().HasOne(e=> e.Professor).WithMany(e=>e.Classes);






        }


    }
}
