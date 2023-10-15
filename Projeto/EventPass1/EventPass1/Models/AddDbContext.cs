using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EventPass1.Models;
using EventPass.Models;

namespace EventPass1.Models
{
   
        public class AppDbContext : DbContext
        {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public DbSet<Usuario> Usuarios { get; set; }

            public DbSet<Evento> Eventos { get; set; }
    }
}
