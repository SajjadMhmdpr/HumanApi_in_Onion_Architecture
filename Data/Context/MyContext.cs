using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
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
