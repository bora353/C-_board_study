using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Board.Model;

namespace Board
{
    public class DatabaseConext : DbContext
    {
        public DbSet<Board123> Board123s { get; set; }

        public DatabaseConext(DbContextOptions<DatabaseConext> options) : base(options) { }


    }
}
