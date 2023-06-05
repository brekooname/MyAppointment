using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAppointment.Data.Repository.IRepository;
using MyAppointment.Models;
using MyAppointment.Models.ViewModels;
using MyAppointment.Utility;
using System.Data;
using System.Linq;

namespace MyAppointment.Controllers
{
    public class WorkOrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkOrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            if (User.IsInRole(Helper.Admin))
                return View("Index");
            else
                return View("ReadOnlyList");
        }

        //GET
        [Authorize(Roles = "Admin")]
        public IActionResult Upsert(int? id)
        {
            WorkOrderViewModel workOrderViewModel = new()
            {
                WorkOrder = new(),
                WorkTypeList = _unitOfWork.WorkType.GetAll()
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            if (id == null || id == 0)
            {
                return View(workOrderViewModel);
            }
            else
            {
                workOrderViewModel.WorkOrder = _unitOfWork.WorkOrder.Get(u => u.Id == id);
                return View(workOrderViewModel);
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(WorkOrderViewModel obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.WorkOrder.Id == 0)
                {
                    _unitOfWork.WorkOrder.Add(obj.WorkOrder);
                }
                else
                {
                    _unitOfWork.WorkOrder.Update(obj.WorkOrder);
                }
                _unitOfWork.Save();
                TempData["success"] = "WorkOrder Created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region
        [HttpGet]
        public IActionResult GetAll()
        {
            var objFromDb = _unitOfWork.WorkOrder.GetAll(includeProperties:"WorkType");
            return Json(new { data = objFromDb });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var objFromDb = _unitOfWork.WorkOrder.Get(c => c.Id == id);

            if (objFromDb == null)
            {
                TempData["Error"] = "Error Deleting Customer";
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _unitOfWork.WorkOrder.Remove(objFromDb);
            _unitOfWork.Save();
            TempData["Success"] = "Customer successfully deleted";
            return Json(new { success = true, message = "Delete successfully" });
        }

        #endregion
    }
}
