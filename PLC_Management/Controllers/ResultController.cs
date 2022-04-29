using Microsoft.AspNetCore.Mvc;
using PLC_Management.Models.EmployeeModel;

namespace PLC_Management.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
