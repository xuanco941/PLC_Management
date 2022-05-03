using Microsoft.AspNetCore.Mvc;
using PLC_Management.Models.ResultModel;

namespace PLC_Management.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Index([FromQuery(Name = "tungay")] string tungay, [FromQuery(Name = "toingay")] string toingay)
        {
            ResultBusiness resultBusiness = new ResultBusiness();



            var today = DateTime.Now.ToString("yyyy-MM-dd");

            if (tungay == null && toingay == null)
            {
                tungay = today;
                toingay = today;
                try
                {
                    ViewBag.listResults = resultBusiness.GetAllResults();
                }
                catch
                {
                    //Lỗi
                }
            }
            else
            {
                DateTime dateTime1 = Convert.ToDateTime(tungay);
                DateTime dateTime2 = Convert.ToDateTime(toingay);
                string strDatime1 = dateTime1.Year + "-" + dateTime1.Month + "-" + dateTime1.Day;
                string strDatime2 = dateTime2.Year + "-" + dateTime2.Month + "-" + dateTime2.Day;

                try
                {
                    ViewBag.listResults = resultBusiness.GetResultByDay(strDatime1, strDatime2);
                }
                catch
                {
                    //Lỗi
                }
            }

            ViewBag.tungay = tungay;
            ViewBag.toingay = toingay;

            return View();
        }
    }
}
