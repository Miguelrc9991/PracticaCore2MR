using Microsoft.AspNetCore.Mvc;
using PracticaCore2MR.Models;
using PracticaCore2MR.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2MR.ViewComponents
{
    public class MenuGenerosViewComponent :ViewComponent 
    {
        private RepositoryLibros repo;

        public MenuGenerosViewComponent(RepositoryLibros repo)
        {
            this.repo = repo;
        }

        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Genero> Generos = this.repo.GetGeneros();
            return View(Generos);
        }

    }
}
