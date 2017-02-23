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
    [Authorize(Roles = "Admin")]
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
        
        public ActionResult Index()
        {
            return View(GetVehicleTypesModel());
        }

        [HttpGet]
        public JsonResult GetAllVehicleTypesAJAX()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = VehicleTypesService.Instance.GetAllVehicleTypes();

            return result;
        }
        
        [HttpPost]
        public JsonResult AddNewVehicleTypeAJAX(VehicleTypeViewModel model)
        {
            JsonResult result = new JsonResult();

            VehicleTypeRecord record = new VehicleTypeRecord();

            if (VerifyModel(model))
            {
                if (VehicleTypesService.Instance.GetVehicleTypeByName(model.Name) != null)
                {
                    record.Successful = false;
                    record.Exception = "Vehicle Type with name " + model.Name + " already exists.";
                }
                else
                {
                    VehicleType newVehicleType = new VehicleType()
                    {
                        Name = model.Name,
                        IsActive = model.IsActive,
                        CreatedBy = User.Identity.GetUserName(),
                        CreatedOn = DateTime.Now,
                        ModifiedBy = User.Identity.GetUserName(),
                        ModifiedOn = DateTime.Now
                    };

                    if (VehicleTypesService.Instance.AddNewVehicleType(newVehicleType))
                    {
                        record.Successful = true;
                        record.VehicleType = VehicleTypesService.Instance.GetVehicleTypeByName(newVehicleType.Name);
                    }
                    else
                    {
                        record.Successful = false;
                        record.Message = "An error occurred while adding "+newVehicleType.Name+" Vehicle Type record.";
                    }
                }
            }
            else
            {
                record.Successful = false;
                record.Exception = "Vehicle Type Data is incomplete.";
            }

            result.Data = record;
            return result;
        }
        
        [HttpPost]
        public JsonResult UpdateVehicleTypeAJAX(VehicleTypeViewModel model)
        {
            JsonResult result = new JsonResult();

            VehicleTypeRecord record = new VehicleTypeRecord();

            if (VerifyModel(model) && model.ID != 0)
            {
                if (VehicleTypesService.Instance.IsUpdateAllowed(model.ID, model.Name))
                {
                    VehicleType updateVehicleType = new VehicleType()
                    {
                        ID = model.ID,
                        Name = model.Name,
                        IsActive = model.IsActive,
                        ModifiedBy = User.Identity.GetUserName(),
                        ModifiedOn = DateTime.Now
                    };

                    if (VehicleTypesService.Instance.UpdateVehicleType(updateVehicleType))
                    {
                        record.Successful = true;
                        record.VehicleType = VehicleTypesService.Instance.GetVehicleTypeByID(model.ID);
                    }
                    else
                    {
                        record.Successful = false;
                        record.Message = "An error occurred while updating Vehicle Type record.";
                    }
                }
                else
                {
                    record.Successful = false;
                    record.Exception = "Vehicle Type with name " + model.Name + " already exists.";
                }
            }
            else
            {
                record.Successful = false;
                record.Exception = "Vehicle Type Data is incomplete.";
            }

            result.Data = record;
            return result;
        }
        
        [HttpPost]
        public JsonResult DeleteVehicleTypeAJAX(int ID)
        {
            JsonResult result = new JsonResult();

            VehicleTypeRecord record = new VehicleTypeRecord();

            if (ID > 0)
            {
                if (VehicleTypesService.Instance.DeleteVehicleTypeByID(ID))
                {
                    record.Successful = true;
                }
                else
                {
                    record.Successful = false;
                    record.Message = "An error occurred while deleting Vehicle Type record.";
                }
            }
            else
            {
                record.Successful = false;
                record.Exception = "Vehicle Type Data is incomplete.";
            }

            result.Data = record;
            return result;
        }
    }
}