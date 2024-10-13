using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entity;

namespace Persistence.Context
{
    public class MyContext : DbContext
    {

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        

        public DbSet<Human> Persons { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Img> Images { get; set; }

    }
}
