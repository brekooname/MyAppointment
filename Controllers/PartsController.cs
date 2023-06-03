using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppointment.Data.Repository.IRepository;
using MyAppointment.Models;
using MyAppointment.Utility;
using System.Data;

namespace MyAppointment.Controllers
{
    public class PartsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PartsController(IUnitOfWork unitOfWork)
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
        public IActionResult Create()
        {
            return View();
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Part vm)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Part.Add(vm);
                _unitOfWork.Save();
                TempData["success"] = "Part created successfully";
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        //GET
        //GET
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var partFromDb = _unitOfWork.Part.Get(m => m.Id == id);

            if (partFromDb == null)
            {
                return NotFound();
            }
            return View(partFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Part vm)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Part.Update(vm);
                _unitOfWork.Save();
                TempData["success"] = "Part updated successfully";
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var partFromDb = _unitOfWork.Part
                .Get(m => m.Id == id);
            if (partFromDb == null)
            {
                return NotFound();
            }
            return View(partFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var partFromDb = _unitOfWork.Part.Get(u => u.Id == id);
            if (partFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Part.Remove(partFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Part Deleted successfully";
            return RedirectToAction("Index");

        }

        #region
        [HttpGet]
        public IActionResult GetAll()
        {
            var objFromDb = _unitOfWork.Part.GetAll();
            return Json(new { data = objFromDb });
        }

        [HttpDelete]
        public IActionResult DeletePart(int? id)
        {
            var objFromDb = _unitOfWork.Part.Get(c => c.Id == id);

            if (objFromDb == null)
            {
                TempData["Error"] = "Error Deleting Part";
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _unitOfWork.Part.Remove(objFromDb);
            _unitOfWork.Save();
            TempData["Success"] = "Part successfully deleted";
            return Json(new { success = true, message = "Delete successfully" });
        }

        #endregion
    }
}
