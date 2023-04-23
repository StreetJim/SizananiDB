using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SizananiDB.Data;
using SizananiDB.Helper;
using SizananiDB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SizananiDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public VehicleManagementContext _context;
        public DataHelper dataHelper;

        public HomeController(ILogger<HomeController> logger, VehicleManagementContext context)
        {
            _context = context;
            _logger = logger;
            dataHelper = new DataHelper(_context);
        }

        public IActionResult Index()
        {
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
