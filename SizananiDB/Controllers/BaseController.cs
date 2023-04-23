using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SizananiDB.Controllers
{
    public class BaseController : Controller
    {
        public readonly string InvalidInput = "Please fill in all the fields";

        /// <summary>
        /// This handles successful results and the sorts
        /// </summary>
        /// <param name="view"></param>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public IActionResult SetupPostBack(string view, bool success, string message)
        {
            TempData["Message"] = message;
            TempData["Success"] = success;

            return RedirectToAction(view);
        }
    }
}
