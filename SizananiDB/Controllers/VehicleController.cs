using Microsoft.AspNetCore.Mvc;
using SizananiDB.Data;
using SizananiDB.Helper;
using SizananiDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SizananiDB.Controllers
{
    public class VehicleController : BaseController
    {
        public VehicleManagementContext _context;
        public DataHelper dataHelper;

        public VehicleController(VehicleManagementContext context)
        {
            _context = context;
            dataHelper = new DataHelper(_context);
        }

        public IActionResult Index()
        {
            var model = dataHelper.GetVehicles();

            return View(model);
        }

        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public IActionResult Create(CreateVehicleViewModel createVehicle)
        {
            if (!ModelState.IsValid)
                return SetupPostBack(nameof(Index), false, InvalidInput);

            var result = dataHelper.AddVehicle(createVehicle.RegistrationNumber, createVehicle.Model, createVehicle.Weight);

            if (!result)
            {
                return SetupPostBack(nameof(Index), false, "Failed to add vehicle");
            }

            return SetupPostBack(nameof(Index), true, "Successfully added a vehicle");
        }
    }
}
