﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2MR.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult VerPerfil()
        {
            return View();
        }
    }
}
