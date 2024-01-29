using Microsoft.EntityFrameworkCore;
using MultiprojectWithDB.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.DataAccessLayer
{
    public class MultiprojectDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public MultiprojectDbContext(DbContextOptions<MultiprojectDbContext> options) : base(options)
        {

        }
    }
}
