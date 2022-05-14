using Microsoft.AspNetCore.Mvc;
using PLC_Management.Models.ResultModel;

namespace PLC_Management.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Index([FromQuery(Name = "tungay")] string tungay, [FromQuery(Name = "toingay")] string toingay, [FromQuery(Name = "page")] int? page, [FromQuery(Name = "pH")] string pH,
            [FromQuery(Name = "Temp")] string Temp, [FromQuery(Name = "TSS")] string TSS, [FromQuery(Name = "COD")] string COD, [FromQuery(Name = "NH4")] string NH4, [FromQuery(Name = "numberResult")] int numberResult)
        {

            if (numberResult>0)
            {
                Common.NUMBER_ELM_ON_PAGE = numberResult;
            }

            ResultBusiness resultBusiness = new ResultBusiness();
            List<Result> results = new List<Result>();


            var today = DateTime.Now;
            if (page == null || page == 0)
            {
                page = 1;
            }
            if (tungay == null && toingay == null)
            {
                ViewBag.host = $"result?page=";
                tungay = today.AddDays(-365).ToString("yyyy-MM-dd");
                toingay = today.AddDays(1).ToString("yyyy-MM-dd");
                int sumResult = ResultBusiness.CountResult();

                int countPage = (sumResult / Common.NUMBER_ELM_ON_PAGE);
                if (sumResult % Common.NUMBER_ELM_ON_PAGE != 0)
                {
                    countPage = countPage + 1;
                }
                ViewBag.countPage = countPage;
                try
                {
                    results = resultBusiness.GetAllResults(page);
                }
                catch
                {
                    //Lỗi
                }
                ViewBag.listResults = results;

            }
            else if (tungay != null && toingay != null && (pH == null && Temp == null && TSS == null && COD == null && NH4 == null))
            {

                ViewBag.host = $"result?tungay={tungay}&toingay={toingay}&page=";
                DateTime dateTime1 = Convert.ToDateTime(tungay);
                DateTime dateTime2 = Convert.ToDateTime(toingay).AddDays(1);
                string strDatime1 = dateTime1.Year + "-" + dateTime1.Month + "-" + dateTime1.Day;
                string strDatime2 = dateTime2.Year + "-" + dateTime2.Month + "-" + dateTime2.Day;

                int sumResult = ResultBusiness.CountResultByDay(strDatime1, strDatime2);
                int countPage = (sumResult / Common.NUMBER_ELM_ON_PAGE);
                if (sumResult % Common.NUMBER_ELM_ON_PAGE != 0)
                {
                    countPage = countPage + 1;
                }
                ViewBag.countPage = countPage;

                try
                {
                    results = resultBusiness.GetResultByDay(strDatime1, strDatime2, page);
                }
                catch
                {
                    //Lỗi
                }
                ViewBag.listResults = results;



            }
            else
            {
                string idpH = "pH";
                string idTemp = "Temp";
                string idTSS = "TSS";
                string idCOD = "COD";
                string idNH4 = "NH4";

                idpH = pH != null ? "pH" : "null";
                idTemp = Temp != null ? "Temp" : "null";
                idTSS = TSS != null ? "TSS" : "null";
                idCOD = COD != null ? "COD" : "null";
                idNH4 = NH4 != null ? "NH4" : "null";

                DateTime dateTime1 = Convert.ToDateTime(tungay);
                DateTime dateTime2 = Convert.ToDateTime(toingay).AddDays(1);
                string strDatime1 = dateTime1.Year + "-" + dateTime1.Month + "-" + dateTime1.Day;
                string strDatime2 = dateTime2.Year + "-" + dateTime2.Month + "-" + dateTime2.Day;
                int sumResult = ResultBusiness.CountResultByParameterAndDay(strDatime1, strDatime2, idpH, idTemp, idTSS, idCOD,idNH4);
                int countPage = (sumResult / Common.NUMBER_ELM_ON_PAGE);
                if (sumResult % Common.NUMBER_ELM_ON_PAGE != 0)
                {
                    countPage = countPage + 1;
                }
                ViewBag.countPage = countPage;

                string? hostpH = "";
                string? hostTemp = "";
                string? hostTSS = "";
                string? hostCOD = "";
                string? hostNH4 = "";
                if (pH != null)
                {
                    hostpH = "pH=on&";
                }
                if (Temp != null)
                {
                    hostTemp = "Temp=on&";
                }
                if (TSS != null)
                {
                    hostTSS = "TSS=on&";
                }
                if (COD != null)
                {
                    hostCOD = "COD=on&";
                }
                if(NH4 != null)
                {
                    hostNH4 = "NH4=on&";
                }
                ViewBag.host = $"result?{hostpH}{hostTemp}{hostTSS}{hostCOD}{hostNH4}tungay={tungay}&toingay={toingay}&page=";


                try
                {
                    results = resultBusiness.GetResultByDayAndParameter(strDatime1, strDatime2, idpH,idTemp,idTSS,idCOD,idNH4, page);
                }
                catch
                {
                    //Lỗi
                }
                ViewBag.listResults = results;

            }

            ViewBag.checkpH = pH != null ? "checked" : null;
            ViewBag.checkTemp = Temp != null ? "checked" : null;
            ViewBag.checkTSS = TSS != null ? "checked" : null;
            ViewBag.checkCOD = COD != null ? "checked" : null;
            ViewBag.checkNH4 = NH4 != null ? "checked" : null;


            if (pH == null && Temp == null && TSS == null && COD == null && NH4 == null)
            {
                ViewBag.checkpH = "checked";
                ViewBag.checkTemp = "checked";
                ViewBag.checkTSS = "checked";
                ViewBag.checkCOD = "checked";
                ViewBag.checkNH4 = "checked";
            }
            ViewBag.tungay = tungay;
            ViewBag.toingay = toingay;
            ViewBag.pageCurrent = page;

            return View();
        }
    }
}
