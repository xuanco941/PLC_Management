using Microsoft.AspNetCore.Mvc;
using PLC_Management.Models.ActivityModel;
namespace PLC_Management.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index([FromQuery(Name = "tungay")] string tungay, [FromQuery(Name = "toingay")] string toingay, [FromQuery(Name = "page")] int page)
        {
            List<Activity> activities = new List<Activity>();
            ActivityBusiness activityBusiness = new ActivityBusiness();
            var today = DateTime.Now.ToString("yyyy-MM-dd");
            if (tungay == null && toingay == null)
            {
                ViewBag.host = $"activity?page=";
                tungay = today;
                toingay = today;
                try
                {
                    activities = activityBusiness.GetAllActivities(page);
                }
                catch
                {
                    // Lỗi
                }
            }
            else
            {
                ViewBag.host = $"activity?tungay={tungay}&toingay={toingay}&page=";
                DateTime dateTime1 = Convert.ToDateTime(tungay);
                DateTime dateTime2 = Convert.ToDateTime(toingay);
                string strDatime1 = dateTime1.Year + "-" + dateTime1.Month + "-" + dateTime1.Day;
                string strDatime2 = dateTime2.Year + "-" + dateTime2.Month + "-" + dateTime2.Day;

                try
                {
                    activities = activityBusiness.GetActivityByDay(strDatime1, strDatime2);
                }
                catch
                {
                    //Lỗi
                }
            }

            ViewBag.listActivities = activities;
            int countPage = (activities.Count / Common.NUMBER_ELM_ON_PAGE);
            if (activities.Count % Common.NUMBER_ELM_ON_PAGE != 0)
            {
                countPage = countPage + 1;
            }
            ViewBag.countPage = countPage;
            //ViewBag.host = $"activity?tungay={tungay}&toingay={toingay}&page=";

            ViewBag.tungay = tungay;
            ViewBag.toingay = toingay;

            return View();
        }

    }
}
