using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeuTrabalho.Models;
using MeuTrabalho.Repositories;

namespace MeuTrabalho.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        readonly ILogRepository logRepository;

        public HomeController(ILogRepository logRepository)
        {
            this.logRepository = logRepository;
        }

        public IActionResult Index()
        {
            return RedirectToActionPermanent("Index", "Account");
        }

        public IActionResult Dashboard(string name)
        {
            if( name == null )
            {
                throw new ArgumentNullException(name);
            }

            ViewBag.Name = name;
            return View();
        }

        public IActionResult About([FromQuery]string teste = "")
        {
            if (teste == "")
            {
                teste = logRepository.TotalRegistros().ToString();
            }

            ViewData["Message"] = "Total de acessos: " + teste;

            logRepository.InsereLog("about");

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            logRepository.InsereLog("contact");

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
