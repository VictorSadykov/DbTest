using DbTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTest
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("DbConnection")
        {
           /* Database.Delete();
            Database.Create();*/
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}
