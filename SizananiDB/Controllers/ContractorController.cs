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
    public class ContractorController : BaseController
    {
        public VehicleManagementContext _context;
        public DataHelper dataHelper;

        public ContractorController(VehicleManagementContext context)
        {
            _context = context;
            dataHelper = new DataHelper(_context);
        }

        public IActionResult Index()
        {
            var model = dataHelper.GetContractors();

            return View(model);
        }

        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public IActionResult Create(CreateContractorViewModel model)
        {
            if (!ModelState.IsValid)
                return SetupPostBack(nameof(Index), false, InvalidInput);

            var result = dataHelper.AddContractor(model.Name, model.Email, model.PhoneNumber);
            if (!result)
            {
                return SetupPostBack(nameof(Index), false, "Failed to add contractor");
            }

            return SetupPostBack(nameof(Index), true, "Successfully added a contractor");
        }
    }
}
