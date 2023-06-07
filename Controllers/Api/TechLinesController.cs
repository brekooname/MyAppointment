using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAppointment.Data;
using MyAppointment.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyAppointment.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechLinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TechLinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Techlines
        [HttpGet]
        public IEnumerable<Techline> GetTechlines()
        {
            return _context.Techlines.ToList();
        }
    }
}
