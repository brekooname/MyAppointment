using Microsoft.AspNetCore.Mvc;
using MyAppointment.Data;
using MyAppointment.Models;
using System.Linq;

namespace MyAppointment.Controllers
{
    public class TechLinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TechLinesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var techline = _context.Techlines.ToList();
            return View(techline);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Techline techline)
        {
            _context.Techlines.Add(techline);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        
        }


    }
}
