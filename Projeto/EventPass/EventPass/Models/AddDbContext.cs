using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EventPass.Models
{
   
        public class AppDbContext : DbContext
        {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public DbSet<Usuario> Usuarios { get; set; }
        }
    }
