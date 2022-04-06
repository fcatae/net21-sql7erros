using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeuTrabalho.Models;
using System.Data.SqlClient;
using Dapper;
using MeuTrabalho.Repositories;

namespace MeuTrabalho.Controllers
{
    public class AccountController : Controller
    {
        readonly ILoginRepository _loginRepository;

        public AccountController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository; 
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginViewModel model)
        {
            // valida email e password
            string username = _loginRepository.FindUsername(model.Email, model.Password);

            if (username == null)
            {
                // sem autenticacao
                return Redirect($"/");
            }

            // autenticado
            return Redirect($"/Home/Dashboard?name={username}");
        }
    }
}
