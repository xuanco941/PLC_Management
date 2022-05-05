using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            //gui data ve client 

            //MainPLC.GetData();
            return Json(new
            {
                ph = Math.Round(CurrentValuePLC.pH, 4, MidpointRounding.AwayFromZero),
                COD = Math.Round(CurrentValuePLC.COD, 4, MidpointRounding.AwayFromZero),
                TSS = Math.Round(CurrentValuePLC.TSS, 4, MidpointRounding.AwayFromZero),
                Temp = Math.Round(CurrentValuePLC.Temp, 4, MidpointRounding.AwayFromZero),
                message = CurrentValuePLC.message
            });
        }


        public IActionResult Btn_batdau()
        {

            CurrentValuePLC.btn_batdau = !CurrentValuePLC.btn_batdau;

            return Json(new
            {
                status = CurrentValuePLC.btn_batdau
            });
        }

        public IActionResult Btn_laymau()
        {
            CurrentValuePLC.btn_laymau = !CurrentValuePLC.btn_laymau;
            return Json(new
            {
                status = CurrentValuePLC.btn_laymau
            });
        }

        public IActionResult Btn_luu()
        {
            CurrentValuePLC.btn_luu = !CurrentValuePLC.btn_luu;
            return Json(new
            {
                status = CurrentValuePLC.btn_luu
            });
        }

        public IActionResult Btn_xoa()
        {
            CurrentValuePLC.btn_xoa = !CurrentValuePLC.btn_xoa;
            return Json(new
            {
                status = CurrentValuePLC.btn_xoa
            });
        }

        //[HttpPost]
        //public async Task<IActionResult> Btn_chonmau()
        //{
        //    string strRequestBody;
        //    using (StreamReader reader = new StreamReader(Request.Body, System.Text.Encoding.UTF8))
        //    {
        //        strRequestBody = await reader.ReadToEndAsync();
        //    }
        //    Employee? employee = JsonConvert.DeserializeObject<Employee>(strRequestBody);
        //    return Json(
        //        ""
        //        );
        //}


    }
}
