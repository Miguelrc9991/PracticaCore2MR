using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PracticaCore2MR.Models;
using PracticaCore2MR.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PracticaCore2MR.Controllers
{
    public class ManageController : Controller
    {
        private RepositoryLibros repo;

        public ManageController(RepositoryLibros repo)
        {
            this.repo = repo;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string email, string password)
        {
            Usuario user = this.repo.ExisteUsuario(email, password);
            if(user != null)
            {
                ClaimsIdentity identity =
                new ClaimsIdentity
                (CookieAuthenticationDefaults.AuthenticationScheme
                , ClaimTypes.Name, ClaimTypes.Role);
                Claim claimName = new Claim(ClaimTypes.Name, user.Nombre);
                Claim claimId =
                    new Claim("ID", user.IdUsuario.ToString());
                Claim claimEmail =
                    new Claim("Email", user.Email);
                Claim claimApellidos =
                   new Claim("Apellidos", user.Apellidos);
                Claim claimFoto =
                   new Claim("Foto", user.Foto);

                identity.AddClaim(claimName);
                identity.AddClaim(claimEmail);
                identity.AddClaim(claimApellidos);
                identity.AddClaim(claimFoto);
                ClaimsPrincipal userPrincipal =
new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync
(CookieAuthenticationDefaults.AuthenticationScheme
, userPrincipal);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewData["MENSAJE"] = "Usuario/Password incorrectos";
            }

            return View();
        }

        public IActionResult ErrorAcceso()
        {
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync
            (CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
