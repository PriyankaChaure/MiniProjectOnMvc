using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniProjectMVC.Models
{
    public class MiniContext:DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet <Customer> Customers { get; set; }
        public DbSet <Sales> Sales { get; set; }
        public DbSet <Admin> Admins { get; set; }
    }
}