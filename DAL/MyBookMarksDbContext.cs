using Microsoft.EntityFrameworkCore;
using MyBookMarks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.DAL
{
    public class MyBookMarksDbContext : DbContext
    {
        public MyBookMarksDbContext(DbContextOptions<MyBookMarksDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<BookMark> BookMarks { get; set; }
    }
}
