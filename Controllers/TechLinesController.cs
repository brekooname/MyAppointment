using Microsoft.AspNetCore.Mvc;
using MyAppointment.Data;
using MyAppointment.Data.Repository.IRepository;
using MyAppointment.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyAppointment.Controllers
{
    public class TechLinesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TechLinesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return View("Index");
            return View("ReadOnlyList");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Techline obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Techline.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "TechLine created successfully";
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

            Techline? techlineFromDb = _unitOfWork.Techline.Get(u => u.Id == id);

            if (techlineFromDb == null)
            {
                return NotFound();
            }
            return View(techlineFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Techline obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Techline.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        #region
        [HttpGet]
        public IActionResult GetAll()
        {
            var objFromDb = _unitOfWork.Techline.GetAll();
            return Json(new { data = objFromDb });
        
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var objFromDb = _unitOfWork.Techline.Get(c => c.Id == id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error Deleting Techline";
                return Json(new { success = false, message = "Error While Deleting" });
            }
            _unitOfWork.Techline.Remove(objFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Part successfully deleted";
            return Json(new { success = true, message = "Delete Successfully" });
        }
        #endregion
    }
}
