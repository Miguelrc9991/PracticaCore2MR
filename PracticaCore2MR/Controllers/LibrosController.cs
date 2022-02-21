using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaCore2MR.Extensions;
using PracticaCore2MR.Filters;
using PracticaCore2MR.Models;
using PracticaCore2MR.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2MR.Controllers
{
    public class LibrosController : Controller
    {
        private RepositoryLibros repoLibros;
        public LibrosController(RepositoryLibros repoLibros)
        {
            this.repoLibros = repoLibros;
        }

        public IActionResult GetLibros()
        {
            List<Libro> libros = this.repoLibros.GetLibros();
            return View(libros);
        }
        public IActionResult Detalles(int idLibro)
        {
            Libro libro = this.repoLibros.Detalles(idLibro);
            return View(libro);

        }
        [HttpPost]
        public IActionResult Detalles(int idLibro, int precio)
        {
            TempData["idLibro"] = idLibro;
            TempData["precio"] = precio;
            return RedirectToAction("Carrito");


        }
        public IActionResult LibrosGenero(int idGenero)
        {
            List<Libro> libros = this.repoLibros.GetLibrosGenero(idGenero);
            return View(libros);
        }
       

        [AuthorizeUsuarios]
        public IActionResult ComprarCarrito()
        {
            HttpContext.Session.Remove("CARRITO");
            return View();
        }
        [HttpPost]
        public IActionResult ComprarCarrito(int[] ids, int[] precios)
        {
            HttpContext.Session.Remove("CARRITO");
            foreach (int precio in precios)
            {
                string factura = "Id : " + ids + " Precio : " + precio;
            }
            return RedirectToAction("Libros", "GetLibros");
        }

        [HttpPost]
        public JsonResult InsertSession(int idLibro,int precio)
        {
            LibrosCarrito libro = new LibrosCarrito();
            libro.idLibro = idLibro;
            libro.precio = precio;
            List<LibrosCarrito> carrito;
            if (HttpContext.Session.GetString("CARRITO") == null)
            {
                //No existe nada en la session, creamos la coleccion
                carrito = new List<LibrosCarrito>();
            }
            else{
                carrito = HttpContext.Session.GetObject<List<LibrosCarrito>>("CARRITO");

            }
            carrito.Add(libro);
            HttpContext.Session.SetObject("CARRITO", carrito);
            return Json(new { result = "Redirect", url = Url.Action("Libros", "GetLibros") });

        }
        public IActionResult CarritoLibros()
        {
            return View();
        }
        public IActionResult PaginarRegistroVistaLibros(int? posicion)
        {
            if (posicion == null)
            {
                posicion = 1;
            }
            int numregistros = this.repoLibros.GetNumeroRegistros();
            int siguiente = posicion.Value + 1;
            if (siguiente > numregistros)
            {
                siguiente = numregistros;
            }
            int anterior = posicion.Value - 1;
            if (anterior < 1)
            {
                anterior = 1;
            }
            VistaLibros vistaLib =
            this.repoLibros.GetVistaLibro(posicion.Value);
            ViewData["ULTIMO"] = numregistros;
            ViewData["SIGUIENTE"] = siguiente;
            ViewData["ANTERIOR"] = anterior;
            return View(vistaLib);
        }



    }
}
