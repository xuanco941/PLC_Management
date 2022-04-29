using Microsoft.AspNetCore.Mvc;
using PLC_Management.Models.EmployeeModel;
namespace PLC_Management.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {


            ViewBag.pH = CurrentValuePLC.pH;
            ViewBag.COD = CurrentValuePLC.COD;
            ViewBag.TSS = CurrentValuePLC.TSS;
            ViewBag.Temp = CurrentValuePLC.Temp;
            return View();
        }

        public IActionResult UpdateDataPLC()
        {
            CurrentValuePLC.pH = CurrentValuePLC.pH + 2;
            return Json(new
            {
                ph = CurrentValuePLC.pH,
                COD = CurrentValuePLC.COD,
                TSS = CurrentValuePLC.TSS,
                Temp = CurrentValuePLC.Temp +1
            });
        }
    }
}
