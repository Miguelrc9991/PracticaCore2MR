using Microsoft.EntityFrameworkCore;
using PracticaCore2MR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2MR.Data
{
    public class TiendaLibrosContext : DbContext
    {
        public TiendaLibrosContext(DbContextOptions<TiendaLibrosContext> options) : base(options) { }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<VistaLibros> VistaLibros { get; set; }
    }
}
