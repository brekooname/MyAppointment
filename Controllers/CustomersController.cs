using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppointment.Data.Repository.IRepository;
using MyAppointment.Models;
using MyAppointment.Utility;
using System.Data;

namespace MyAppointment.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
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
        public ActionResult Create(Customer vm)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Customer.Add(vm);
                _unitOfWork.Save();
                TempData["success"] = "Customer created successfully";
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

            var customerFromDb = _unitOfWork.Customer.Get(m => m.Id == id);

            if (customerFromDb == null)
            {
                return NotFound();
            }
            return View(customerFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer vm)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Customer.Update(vm);
                _unitOfWork.Save();
                TempData["success"] = "Customer updated successfully";
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
            var customerFromDb = _unitOfWork.Customer
                .Get(m => m.Id == id);
            if (customerFromDb == null)
            {
                return NotFound();
            }
            return View(customerFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var customerFromDb = _unitOfWork.Customer.Get(u => u.Id == id);
            if (customerFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Customer.Remove(customerFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Customer Deleted successfully";
            return RedirectToAction("Index");

        }

        #region
        [HttpGet]
        public IActionResult GetAll()
        {
            var objFromDb = _unitOfWork.Customer.GetAll();
            return Json(new { data = objFromDb });
        }

        [HttpDelete]
        public IActionResult DeletePart(int? id)
        {
            var objFromDb = _unitOfWork.Customer.Get(c => c.Id == id);

            if (objFromDb == null)
            {
                TempData["Error"] = "Error Deleting Customer";
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _unitOfWork.Customer.Remove(objFromDb);
            _unitOfWork.Save();
            TempData["Success"] = "Customer successfully deleted";
            return Json(new { success = true, message = "Delete successfully" });
        }

        #endregion
    }
}
