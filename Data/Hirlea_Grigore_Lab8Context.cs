using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hirlea_Grigore_Lab8.Models;

namespace Hirlea_Grigore_Lab8.Data
{
    public class Hirlea_Grigore_Lab8Context : DbContext
    {
        public Hirlea_Grigore_Lab8Context (DbContextOptions<Hirlea_Grigore_Lab8Context> options)
            : base(options)
        {
        }

        public DbSet<Hirlea_Grigore_Lab8.Models.Book> Book { get; set; }

        public DbSet<Hirlea_Grigore_Lab8.Models.Publisher> Publisher { get; set; }

        public DbSet<Hirlea_Grigore_Lab8.Models.Category> Category { get; set; }

        public DbSet<Hirlea_Grigore_Lab8.Models.BookCategory> BookCategory { get; set; }
    }
}
