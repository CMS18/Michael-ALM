﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ALM_Uppg_01.Models;
using ALM_Uppg_01.Models.Entities;
using ALM_Uppg_01.Models.ViewModels;

namespace ALM_Uppg_01.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new BankRepositoryViewModel());
        }
    }
}
