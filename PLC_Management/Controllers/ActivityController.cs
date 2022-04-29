using Microsoft.AspNetCore.Mvc;

namespace PLC_Management.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
