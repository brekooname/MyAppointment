using Microsoft.AspNetCore.Mvc;

namespace MyAppointment.Controllers
{
	public class PanelController : Controller
	{
		public IActionResult FrontPage()
		{
			return View();
		}
	}
}
