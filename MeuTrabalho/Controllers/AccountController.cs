using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeuTrabalho.Models;
using System.Data.SqlClient;
using Dapper;

namespace MeuTrabalho.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginViewModel model)
        {
            SqlConnection connection = new SqlConnection("Server=martedb.database.windows.net;Database=db2022;User=aclogin;Password=homework-mar22");

            var ret = connection.Query($"SELECT username FROM tbLogin WHERE email=@email AND pwd=@pwd", 
                new { email = model.Email, pwd = model.Password });

            string username = ret.FirstOrDefault();

            if (username != null)
            {
                // autenticado
                return Redirect($"/Home/Dashboard?name={username}");
            }

            // sem autenticacao
            return Redirect($"/Error/NotAuthenticated");
        }
    }
}
