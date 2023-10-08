using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EventPass.Models;

namespace EventPass.Models
{
   
        public class AppDbContext : DbContext
        {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<EventPass.Models.Gestor> Gestor { get; set; }
        }
    }
