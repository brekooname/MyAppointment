using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAppointment.Data;
using MyAppointment.Data.Repository.IRepository;
using MyAppointment.Models;
using MyAppointment.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if (User.IsInRole("Admin"))
                return View("Index");
            return View("ReadOnlyList");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var part = _unitOfWork.Part.Get(u =>u.Id == id);
            if (part == null)
            {
                return NotFound();
            }
            return View(part);
        
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Part obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Part.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Part created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partFromDb = _unitOfWork.Part.Get(u =>u.Id== id);

            if (partFromDb == null)
            {
                return NotFound();
            }
            return View(partFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Part obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Part.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Part updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

      /*  public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Part? partFromDb = _unitOfWork.Part.Get(u => u.Id == id);
            if (partFromDb == null)
            {
                return NotFound();
            }
            return View(partFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Part? obj = _unitOfWork.Part.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Part.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Part deleted successfully";
            return RedirectToAction("Index");
        }*/

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Part> objPartList = _unitOfWork.Part.GetAll().ToList();
            return Json(new { data = objPartList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var partToBeDeleted = _unitOfWork.Part.Get(u => u.Id == id);
            if (partToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Part.Remove(partToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
