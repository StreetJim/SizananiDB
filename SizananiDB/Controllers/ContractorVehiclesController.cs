using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SizananiDB.Data;
using SizananiDB.Helper;
using SizananiDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SizananiDB.Controllers
{
    public class ContractorVehiclesController : BaseController
    {
        public VehicleManagementContext _context;
        public DataHelper dataHelper;

        public ContractorVehiclesController(VehicleManagementContext context)
        {
            _context = context;
            dataHelper = new DataHelper(_context);
        }

        public IActionResult Index()
        {
            var contractors = dataHelper.GetContractors();

            var model = new ContractorVehicleIndexViewModel()
            {
                Contractors = contractors.Select(x => new SelectListItem()
                {
                    Text = x.Email,
                    Value = x.Id.ToString()
                })
            };

            return View(model);
        }

        public IActionResult GetContractorVehicles(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var model = dataHelper.GetContractorVehicles(id.Value);

            return PartialView("_ContractorVehicles", model);
        }

        public IActionResult LinkVehicle(int? id)
        {
            if (!id.HasValue)
                return NotFound();
            
            var vehicles = dataHelper.GetVehicles();

            var model = new LinkContractorViewModel()
            {
                Vehicles = vehicles.Select(x => new SelectListItem()
                {
                    Text = $"{x.Model} {x.RegistrationNumber}",
                    Value = x.Id.ToString()
                }),
                Contractor = id.Value.ToString(),
                ContractorId = id.Value
            };

            return PartialView("_LinkVehicle", model);
        }

        [HttpPost]
        public IActionResult LinkVehicle(LinkContractorViewModel model)
        {
            if (!ModelState.IsValid)
                return SetupPostBack(nameof(Index), false, InvalidInput);
            
            var result = dataHelper.LinkVehicleToContractor(model.VehicleId, model.ContractorId);

            if (!result)
            {
                return SetupPostBack(nameof(Index), false, "Failed to link vehicle");
            }

            return SetupPostBack(nameof(Index), true, "Successfully linked a vehicle");
        }
    }
}
