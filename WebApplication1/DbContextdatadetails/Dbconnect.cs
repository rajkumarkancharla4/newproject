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
    }
}
