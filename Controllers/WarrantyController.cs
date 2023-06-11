using Microsoft.AspNetCore.Mvc;
using MyAppointment.Data.Repository.IRepository;
using MyAppointment.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyAppointment.Controllers
{
    public class WarrantyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WarrantyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return View("Index");
            else
                return View("ReadOnlyList");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Warranty obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Warranty.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Warranty created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Warranty warrantyFromDb = _unitOfWork.Warranty.Get(u => u.Id == id);
            if (warrantyFromDb == null)
            {
                return NotFound();
            }
            return View(warrantyFromDb);
        
        }
        [HttpPost]
        public IActionResult Edit(Warranty obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Warranty.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Warranty updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        #region

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Warranty> objWarrantyList = _unitOfWork.Warranty.GetAll().ToList();
            return Json(new { data = objWarrantyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var warrantyToBeDeleted = _unitOfWork.Warranty.Get(u => u.Id == id);
            if (warrantyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Warranty.Remove(warrantyToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successfully" });
        }

        #endregion

    }
}
