using Microsoft.AspNetCore.Mvc;
using MyAppointment.Data.Repository.IRepository;
using MyAppointment.Models;
using System.Collections.Generic;

namespace MyAppointment.Controllers
{
    public class WorkTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<WorkType> objWorkTypeList = _unitOfWork.WorkType.GetAll();
            return View(objWorkTypeList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WorkType obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.WorkType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "WorkType created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var workTypeFromDbFirst = _unitOfWork.WorkType.Get(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (workTypeFromDbFirst == null)
            {
                return NotFound();
            }

            return View(workTypeFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WorkType obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.WorkType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "WorkType updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _unitOfWork.WorkType.Get(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.WorkType.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.WorkType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
