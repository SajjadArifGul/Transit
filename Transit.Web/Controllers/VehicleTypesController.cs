using Microsoft.AspNet.Identity;
using System;
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
        public bool VerifyModel(VehicleTypeViewModel model)
        {
            if (!string.IsNullOrEmpty(model.Name) && !string.IsNullOrWhiteSpace(model.Name))
            {
                return true;
            }
            return false;
        }

        public VehicleTypesViewModel GetVehicleTypesModel()
        {
            VehicleTypesViewModel model = new VehicleTypesViewModel();

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

            return model;
        }

        // GET: VehicleTypes
        public ActionResult Index()
        {
            return View(GetVehicleTypesModel());
        }

        [HttpGet]
        public ActionResult AddNewVehicleType()
        {
            return View("_AddNewVehicleType", "_NoLayout", new VehicleTypeViewModel());
        }

        [HttpPost]
        public ActionResult AddNewVehicleType(VehicleTypeViewModel model)
        {
            if (VerifyModel(model))
            {
                VehicleType vehicleType = new VehicleType()
                {
                    Name = model.Name,
                    IsActive = model.IsActive,
                    CreatedBy = User.Identity.GetUserName(),
                    CreatedOn = DateTime.Now,
                    ModifiedBy = User.Identity.GetUserName(),
                    ModifiedOn = DateTime.Now
                };

                VehicleTypesService.Instance.AddNewVehicleType(vehicleType);
            }

            return View("Index", GetVehicleTypesModel());
        }

        [HttpPost]
        public JsonResult AddNewVehicleTypeAJAX(VehicleTypeViewModel model)
        {
            JsonResult result = new JsonResult();

            if (VerifyModel(model))
            {
                List<VehicleType> VehicleTypes = VehicleTypesService.Instance.GetAllVehicleTypes();

                foreach (VehicleType vehicleType in VehicleTypes)
                {
                    if (vehicleType.Name.ToLower() == model.Name.ToLower())
                    {
                        result.Data = "Vehicle Type with name " + model.Name + " already exists.";

                        return result;
                    }
                }

                VehicleType newVehicleType = new VehicleType()
                {
                    Name = model.Name,
                    IsActive = model.IsActive,
                    CreatedBy = User.Identity.GetUserName(),
                    CreatedOn = DateTime.Now,
                    ModifiedBy = User.Identity.GetUserName(),
                    ModifiedOn = DateTime.Now
                };

                VehicleTypesService.Instance.AddNewVehicleType(newVehicleType);

                List<VehicleType> AllVehicleTypes = VehicleTypesService.Instance.GetAllVehicleTypes();

                result.Data = AllVehicleTypes;
            }
            else result.Data = "Vehicle Type Data is incomplete.";

            return result;
        }

        [HttpGet]
        public ActionResult EditVehicleType(int VehicleTypeID)
        {
            if (VehicleTypeID>0)
            {
                VehicleType vehicleType = VehicleTypesService.Instance.GetVehicleTypeByID(VehicleTypeID);

                if (vehicleType != null)
                {
                    VehicleTypeViewModel model = new VehicleTypeViewModel()
                    {
                        Title = "Update Vehicle Type",

                        ID = vehicleType.ID,
                        Name = vehicleType.Name,
                        IsActive = vehicleType.IsActive
                    };

                    return View("_EditVehicleType", "_NoLayout", model);
                }
                else return null;
            }
            else return null;
        }

        [HttpPost]
        public ActionResult EditVehicleType(VehicleTypeViewModel model)
        {
            if (VerifyModel(model))
            {
                VehicleType vehicleType = new VehicleType()
                {
                    Name = model.Name,
                    IsActive = model.IsActive,
                    ModifiedBy = User.Identity.GetUserName(),
                    ModifiedOn = DateTime.Now
                };

                VehicleTypesService.Instance.UpdateVehicleType(vehicleType);
            }

            return View("Index", GetVehicleTypesModel());
        }
    }
}