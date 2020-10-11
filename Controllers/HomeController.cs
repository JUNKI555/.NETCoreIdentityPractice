using Dapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using DotNETCoreIdentityPractice.Models;
using DotNETCoreIdentityPractice.Models.Core;
using DotNETCoreIdentityPractice.Models.Database.Tables;

namespace DotNETCoreIdentityPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Database Connection Test
            var ConnectionString = AppConfiguration.Current.ConnectionString;

            News[] news;
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                news = connection.Query<News>("SELECT * FROM News;").ToArray();
                connection.Close();
            }

            ViewData["Message"] = news.FirstOrDefault().Title;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
