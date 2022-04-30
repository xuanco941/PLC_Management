using Microsoft.AspNetCore.Mvc;
using PLC_Management.Models.EmployeeModel;
namespace PLC_Management.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpdateDataPLC()
        {
            CurrentValuePLC.pH = CurrentValuePLC.pH + 2.09;
            CurrentValuePLC.COD = CurrentValuePLC.COD + 1.5;
            CurrentValuePLC.TSS = CurrentValuePLC.TSS + 3.1;
            CurrentValuePLC.Temp = CurrentValuePLC.Temp + 1.3;

            return Json(new
            {
                ph = Math.Round(CurrentValuePLC.pH,4, MidpointRounding.AwayFromZero),
                COD = Math.Round(CurrentValuePLC.COD, 4, MidpointRounding.AwayFromZero),
                TSS = Math.Round(CurrentValuePLC.TSS, 4, MidpointRounding.AwayFromZero),
                Temp = Math.Round(CurrentValuePLC.Temp, 4, MidpointRounding.AwayFromZero),
                message = CurrentValuePLC.message
            });
        }
    }
}
