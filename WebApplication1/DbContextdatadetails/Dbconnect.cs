using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.DbContextdatadetails
{
    public class Dbconnect : DbContext
    {
        public Dbconnect(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Entity> Learningtables { get; set; }
        public DbSet<CourseInfoEntity> CourseInfo { get; set; }
        public DbSet<SkillInfoEntity>skillInfo{ get; set; }
        public DbSet<WdlcompleteDataEntity> WdlcompleteDatas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillInfoEntity>()
                .HasNoKey(); // Marks this entity as keyless.
        }

    }
}
