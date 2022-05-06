using Microsoft.AspNetCore.Mvc;
using PLC_Management.Models.ActivityModel;
namespace PLC_Management.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index([FromQuery(Name = "timeSaveData")] int? timeSaveData)
        {
            if(timeSaveData != null)
            {
                InsertResultInterval.timeSaveData = (int) timeSaveData * 1000;
            }
            ViewBag.timeSaveData = InsertResultInterval.timeSaveData/1000;
            return View();
        }

        public IActionResult UpdateDataPLC()
        {
            //gui data ve client 

            //MainPLC.GetData();
            return Json(new
            {
                //btn
                btn_batdau = CurrentValuePLC.btn_batdau,
                btn_doluuluong = CurrentValuePLC.btn_doluuluong,
                btn_doph = CurrentValuePLC.btn_doph,
                btn_doTSS = CurrentValuePLC.btn_dotss,
                btn_laymau = CurrentValuePLC.btn_laymau,
                btn_luu = CurrentValuePLC.btn_luu,
                btn_tudong = CurrentValuePLC.btn_tudongchaytay,
                btn_xoa = CurrentValuePLC.btn_xoa,


                //parameter
                ph = Math.Round(CurrentValuePLC.pH, 4, MidpointRounding.AwayFromZero),
                COD = Math.Round(CurrentValuePLC.COD, 4, MidpointRounding.AwayFromZero),
                TSS = Math.Round(CurrentValuePLC.TSS, 4, MidpointRounding.AwayFromZero),
                Temp = Math.Round(CurrentValuePLC.Temp, 4, MidpointRounding.AwayFromZero),

                //luu luong
                luuluong = Math.Round(CurrentValuePLC.luuLuong, 4, MidpointRounding.AwayFromZero),
                luuluongvao = Math.Round(CurrentValuePLC.luuLuongVao, 4, MidpointRounding.AwayFromZero),
                luuluongra = Math.Round(CurrentValuePLC.luuLuongRa, 4, MidpointRounding.AwayFromZero),

                //position
                position_1 = Math.Round(CurrentValuePLC.position_1, 4, MidpointRounding.AwayFromZero),
                position_2 = Math.Round(CurrentValuePLC.position_2, 4, MidpointRounding.AwayFromZero),
                position_3 = Math.Round(CurrentValuePLC.position_3, 4, MidpointRounding.AwayFromZero),
                position_4 = Math.Round(CurrentValuePLC.position_4, 4, MidpointRounding.AwayFromZero),
                position_5 = Math.Round(CurrentValuePLC.position_5, 4, MidpointRounding.AwayFromZero),
                position_6 = Math.Round(CurrentValuePLC.position_6, 4, MidpointRounding.AwayFromZero),
                position_7 = Math.Round(CurrentValuePLC.position_7, 4, MidpointRounding.AwayFromZero),
                position_8 = Math.Round(CurrentValuePLC.position_8, 4, MidpointRounding.AwayFromZero),
                position_9 = Math.Round(CurrentValuePLC.position_9, 4, MidpointRounding.AwayFromZero),
                position_10 = Math.Round(CurrentValuePLC.position_10, 4, MidpointRounding.AwayFromZero),
                position_11 = Math.Round(CurrentValuePLC.position_11, 4, MidpointRounding.AwayFromZero),
                position_12 = Math.Round(CurrentValuePLC.position_12, 4, MidpointRounding.AwayFromZero),
                position_13 = Math.Round(CurrentValuePLC.position_13, 4, MidpointRounding.AwayFromZero),
                position_14 = Math.Round(CurrentValuePLC.position_14, 4, MidpointRounding.AwayFromZero),
                position_15 = Math.Round(CurrentValuePLC.position_15, 4, MidpointRounding.AwayFromZero),
                position_16 = Math.Round(CurrentValuePLC.position_16, 4, MidpointRounding.AwayFromZero),
                position_17 = Math.Round(CurrentValuePLC.position_17, 4, MidpointRounding.AwayFromZero),
                position_18 = Math.Round(CurrentValuePLC.position_18, 4, MidpointRounding.AwayFromZero),
                position_19 = Math.Round(CurrentValuePLC.position_19, 4, MidpointRounding.AwayFromZero),
                position_20 = Math.Round(CurrentValuePLC.position_20, 4, MidpointRounding.AwayFromZero),
                position_21 = Math.Round(CurrentValuePLC.position_21, 4, MidpointRounding.AwayFromZero),
                position_22 = Math.Round(CurrentValuePLC.position_22, 4, MidpointRounding.AwayFromZero),
                position_23 = Math.Round(CurrentValuePLC.position_23, 4, MidpointRounding.AwayFromZero),
                position_24 = Math.Round(CurrentValuePLC.position_24, 4, MidpointRounding.AwayFromZero),

                position_absolute = Math.Round(CurrentValuePLC.position_absolute, 4, MidpointRounding.AwayFromZero),
                position_current = Math.Round(CurrentValuePLC.position_current, 4, MidpointRounding.AwayFromZero),
                velitical_absolute_jog = Math.Round(CurrentValuePLC.velitical_absolute_jog, 4, MidpointRounding.AwayFromZero),
                nhap_so_chai_lay_mau = CurrentValuePLC.nhap_so_chai_lay_mau,
                xoa_so_chai_lay_mau = CurrentValuePLC.xoa_so_chai_lay_mau,



                //status position
                status_position_1 = CurrentValuePLC.status_position_1,
                status_position_2 = CurrentValuePLC.status_position_2,
                status_position_3 = CurrentValuePLC.status_position_3,
                status_position_4 = CurrentValuePLC.status_position_4,
                status_position_5 = CurrentValuePLC.status_position_5,
                status_position_6 = CurrentValuePLC.status_position_6,
                status_position_7 = CurrentValuePLC.status_position_7,
                status_position_8 = CurrentValuePLC.status_position_8,
                status_position_9 = CurrentValuePLC.status_position_9,
                status_position_10 = CurrentValuePLC.status_position_10,
                status_position_11 = CurrentValuePLC.status_position_11,
                status_position_12 = CurrentValuePLC.status_position_12,
                status_position_13 = CurrentValuePLC.status_position_13,
                status_position_14 = CurrentValuePLC.status_position_14,
                status_position_15 = CurrentValuePLC.status_position_15,
                status_position_16 = CurrentValuePLC.status_position_16,
                status_position_17 = CurrentValuePLC.status_position_17,
                status_position_18 = CurrentValuePLC.status_position_18,
                status_position_19 = CurrentValuePLC.status_position_19,
                status_position_20 = CurrentValuePLC.status_position_20,
                status_position_21 = CurrentValuePLC.status_position_21,
                status_position_22 = CurrentValuePLC.status_position_22,
                status_position_23 = CurrentValuePLC.status_position_23,
                status_position_24 = CurrentValuePLC.status_position_24,


                message = CurrentValuePLC.message
            });
        }


        public IActionResult Btn_batdau()
        {
            if (CurrentValuePLC.btn_batdau == false)
            {
                ActivityBusiness.AddActivity("Bắt đầu !!!");
                MainPLC.plc.Write("M200.2", 1);
            }
            else
            {
                ActivityBusiness.AddActivity("Dừng lại !!!");
                MainPLC.plc.Write("M200.2", 0);
            }
            CurrentValuePLC.btn_batdau = !CurrentValuePLC.btn_batdau;
            return Json(new
            {
                status = CurrentValuePLC.btn_batdau
            });
        }

        public IActionResult Btn_laymau()
        {
            if (CurrentValuePLC.btn_laymau == false)
            {
                ActivityBusiness.AddActivity("Đã Lấy mẫu");
                MainPLC.plc.Write("M200.7", 1);
            }
            else
            {
                MainPLC.plc.Write("M200.7", 0);
            }
            CurrentValuePLC.btn_laymau = !CurrentValuePLC.btn_laymau;
            return Json(new
            {
                status = CurrentValuePLC.btn_laymau
            });
        }

        public IActionResult Btn_luu()
        {
            if (CurrentValuePLC.btn_luu == false)
            {
                MainPLC.plc.Write("M200.1", 1);
            }
            else
            {
                MainPLC.plc.Write("M200.1", 0);
            }
            CurrentValuePLC.btn_luu = !CurrentValuePLC.btn_luu;
            return Json(new
            {
                status = CurrentValuePLC.btn_luu
            });
        }

        public IActionResult Btn_xoa()
        {
            if (CurrentValuePLC.btn_xoa == false)
            {
                MainPLC.plc.Write("M200.0", 1);
            }
            else
            {
                MainPLC.plc.Write("M200.0", 0);
            }
            CurrentValuePLC.btn_xoa = !CurrentValuePLC.btn_xoa;
            return Json(new
            {
                status = CurrentValuePLC.btn_xoa
            });
        }

        public IActionResult Btn_tudong()
        {
            if (CurrentValuePLC.btn_tudongchaytay == false)
            {
                ActivityBusiness.AddActivity("Chuyển sang chế độ tự động.");
                MainPLC.plc.Write("M200.6", 1);
            }
            else
            {
                MainPLC.plc.Write("M200.6", 0);
            }
            CurrentValuePLC.btn_tudongchaytay = !CurrentValuePLC.btn_tudongchaytay;
            return Json(new
            {
                status = CurrentValuePLC.btn_tudongchaytay
            });
        }

        public IActionResult Btn_doph()
        {
            if (CurrentValuePLC.btn_doph == false)
            {
                MainPLC.plc.Write("M200.4", 1);
            }
            else
            {
                MainPLC.plc.Write("M200.4", 0);
            }
            CurrentValuePLC.btn_doph = !CurrentValuePLC.btn_doph;
            return Json(new
            {
                status = CurrentValuePLC.btn_doph
            });
        }

        public IActionResult Btn_doTSS()
        {
            if (CurrentValuePLC.btn_dotss == false)
            {
                MainPLC.plc.Write("M200.5", 1);
            }
            else
            {
                MainPLC.plc.Write("M200.5", 0);
            }
            CurrentValuePLC.btn_dotss = !CurrentValuePLC.btn_dotss;
            return Json(new
            {
                status = CurrentValuePLC.btn_dotss
            });
        }

        public IActionResult Btn_doluuluong()
        {
            if (CurrentValuePLC.btn_doluuluong == false)
            {
                MainPLC.plc.Write("M200.3", 1);
            }
            else
            {
                MainPLC.plc.Write("M200.3", 0);
            }
            CurrentValuePLC.btn_doluuluong = !CurrentValuePLC.btn_doluuluong;
            return Json(new
            {
                status = CurrentValuePLC.btn_doluuluong
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
