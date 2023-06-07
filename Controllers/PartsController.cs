using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAppointment.Data;
using MyAppointment.Models;
using MyAppointment.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppointment.Controllers
{
    public class PartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return View("Index");
            return View("ReadOnlyList");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var part = await _context.Parts.FirstOrDefaultAsync(p => p.Id == id);
            if (part == null)
            {
                return NotFound();
            }
            return View(part);
        
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Part part)
        {
            if (ModelState.IsValid)
            {
                var viewModel = new PartViewModel
                {
                    Id = part.Id,
                    PartName = part.PartName,
                    PartNumber = part.PartNumber,
                    NumberInStock = part.NumberInStock,
                    PartPrice = part.PartPrice,
                };
                return View("New", viewModel);
            }

            if (part.Id == 0)
                _context.Parts.Add(part);
            else
            {
                var partInDb = _context.Parts.FirstOrDefault(p => p.Id == part.Id);
                partInDb.Id = part.Id;
                partInDb.PartName = part.PartName;
                partInDb.PartNumber = part.PartNumber;
                partInDb.PartDescription = part.PartDescription;
                partInDb.NumberInStock = part.NumberInStock;
                partInDb.PartPrice = part.PartPrice;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Parts");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.Parts.FindAsync(id);

            if (part == null)
            {
                return NotFound();
            }
            return View(part);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PartName,PartNumber,PartDescription, NumberInStock,PartPrice")]Part part)
        {
            if (id != part.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(part);
                    await _context.SaveChangesAsync();
                }
                catch 
                {
                    if (!PartExists(part.Id))
                    {
                        return NotFound();
                    }
                    else 
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(part);

        }

        private bool PartExists(int id)
        {
            return _context.Parts.Any(e => e.Id == id);
        }











    }
}
