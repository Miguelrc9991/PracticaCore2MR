using PracticaCore2MR.Data;
using PracticaCore2MR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2MR.Repositories
{
    public class RepositoryLibros
    {
         private TiendaLibrosContext context;

        public RepositoryLibros(TiendaLibrosContext context)
        {
            this.context = context;
        }

        public List<Libro> GetLibros()
        {
            var consulta = from datos in this.context.Libros.AsEnumerable()
                           select datos;
            return consulta.ToList();
        }
        public List<Genero> GetGeneros()
        {
            var consulta = from datos in this.context.Generos.AsEnumerable()
                           select datos;
            return consulta.ToList();
        }
        public Libro Detalles(int idLibro)
        {
            var consulta = from datos in this.context.Libros.AsEnumerable()
                           where datos.IdLibro == idLibro
                           select datos;
            return consulta.FirstOrDefault();
        }
        public List<Usuario> GetUsuarios()
        {
            return this.context.Usuarios.ToList();
        }
        public Usuario ExisteUsuario(string email, string password)
        {
            var consulta = from datos in this.context.Usuarios
                           where datos.Email == email
                           && datos.Pass == password
                           select datos;
            return consulta.SingleOrDefault();
        }
        public List<Libro> GetLibrosGenero(int idGenero)
        {
            var consulta = from datos in this.context.Libros.AsEnumerable()
                           where datos.IdGenero == idGenero
                           select datos;
            return consulta.ToList();
        }
        public int GetNumeroRegistros()
        {
            return this.context.VistaLibros.Count();
        }
        public VistaLibros GetVistaLibro(int posicion)
        {
            
            var consulta = from datos in this.context.VistaLibros
                           where datos.Posicion ==posicion  
                           select datos;
            return consulta.FirstOrDefault();
        }





    }
}
