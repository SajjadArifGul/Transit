﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transit.Commons;
using Transit.Entities;
using Transit.Services;
using Transit.Web.Models;

namespace Transit.Web.Controllers
{
    public class VehicleTypesController : Controller
    {
        // GET: VehicleTypes
        public ActionResult Index()
        {
            VehicleTypeViewModels model = new VehicleTypeViewModels();

            model.Title = "Vehicle Types";
            model.BreadCrumbs = new List<Link>{
                new Link() { Text="Vehicle Types" },
                new Link() { Text="Home", URL="~home" },
                new Link() { Text="Vehicle Types" },
            };

            model.VehicleTypes = new List<VehicleTypeViewModel>();
            foreach (VehicleType vehicleType in VehicleTypesService.Instance.GetAllVehicleTypes())
            {
                model.VehicleTypes.Add(new VehicleTypeViewModel()
                {
                    ID = vehicleType.ID,
                    Name = vehicleType.Name,
                    IsActive = vehicleType.IsActive,
                    CreatedBy = vehicleType.CreatedBy,
                    CreatedOn = vehicleType.CreatedOn,
                    ModifiedBy = vehicleType.ModifiedBy,
                    ModifiedOn = vehicleType.ModifiedOn
                });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult AddNewVehicleType()
        {
            return View("_AddNewVehicleType", "_NoLayout", new VehicleTypeViewModel());
        }

        [HttpPost]
        public ActionResult AddNewVehicleType(VehicleTypeViewModel model)
        {
            return View();
        }
    }
}