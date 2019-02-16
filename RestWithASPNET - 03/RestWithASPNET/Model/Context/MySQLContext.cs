using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {
        }
        public MySQLContext(DbContextOptions<MySQLContext> options): base (options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
    }
}
