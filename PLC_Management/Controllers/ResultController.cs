using Microsoft.AspNetCore.Mvc;
using PLC_Management.Models.ResultModel;
using System.Collections.Generic;
using System.Linq;

namespace PLC_Management.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Index([FromQuery(Name = "tungay")] string tungay, [FromQuery(Name = "toingay")] string toingay, [FromQuery(Name = "page")] int? page, [FromQuery(Name = "pH")] string pH,
            [FromQuery(Name = "Temp")] string Temp, [FromQuery(Name = "TSS")] string TSS, [FromQuery(Name = "COD")] string COD)
        {
            ResultBusiness resultBusiness = new ResultBusiness();
            List<Result> results = new List<Result>();


            var today = DateTime.Now.ToString("yyyy-MM-dd");
            if (page == null || page == 0)
            {
                page = 1;
            }
            if (tungay == null && toingay == null)
            {
                ViewBag.host = $"result?page=";
                tungay = today;
                toingay = today;
                int sumResult = ResultBusiness.CountResult();
                ViewBag.sumResult = sumResult;

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
            }
            else
            {

                ViewBag.host = $"result?tungay={tungay}&toingay={toingay}&page=";
                DateTime dateTime1 = Convert.ToDateTime(tungay);
                DateTime dateTime2 = Convert.ToDateTime(toingay);
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
            }

            //var idpH = pH!=null ? "pH" : "null" ;
            //var idTemp = Temp != null ? "Temp" : "null";
            //var idTSS = TSS != null ? "TSS" : "null";
            //var idCOD = COD != null ? "COD" : "null";


            //var newResultList = from result in results
            //                    where result.Parameter_ID == pH || result.Parameter_ID == Temp || result.Parameter_ID == TSS || result.Parameter_ID == COD
            //                    select result;



            //if (pH == null)
            //{
            //    newResultList = (List<Result>)(from result in results
            //                                   where result.Parameter_ID == "Temp" || result.Parameter_ID == "TSS" || result.Parameter_ID == "COD"
            //                                   select result);
            //}
            //else if (Temp == null)
            //{
            //    newResultList = (List<Result>)(from result in results
            //                                   where result.Parameter_ID == "pH" || result.Parameter_ID == "TSS" || result.Parameter_ID == "COD"
            //                                   select result);
            //}
            //else if (TSS == null)
            //{
            //    newResultList = (List<Result>)(from result in results
            //                                   where result.Parameter_ID == "pH" || result.Parameter_ID == "Temp" || result.Parameter_ID == "COD"
            //                                   select result);
            //}
            //else if (COD == null)
            //{
            //    newResultList = (List<Result>)(from result in results
            //                                   where result.Parameter_ID == "pH" || result.Parameter_ID == "TSS" || result.Parameter_ID == "Temp"
            //                                   select result);
            //}
            //else if (pH == null && Temp == null)
            //{
            //    newResultList = (List<Result>)(from result in results
            //                                   where result.Parameter_ID == "TSS" || result.Parameter_ID == "COD"
            //                                   select result);
            //}
            //else if (pH == null && Temp == null && TSS == null)
            //{
            //    newResultList = (List<Result>)(from result in results
            //                                   where result.Parameter_ID == "COD"
            //                                   select result);
            //}
            //else if (pH == null && Temp == null && COD == null)
            //{
            //    newResultList = (List<Result>)(from result in results
            //                                   where result.Parameter_ID == "TSS"
            //                                   select result);
            //}
            //else if (Temp == null)
            //{
            //    newResultList = (List<Result>)(from result in results
            //                                   where result.Parameter_ID == "pH" || result.Parameter_ID == "TSS" || result.Parameter_ID == "COD"
            //                                   select result);
            //}
            ViewBag.listResults = results;

            ViewBag.tungay = tungay;
            ViewBag.toingay = toingay;

            return View();
        }
    }
}
