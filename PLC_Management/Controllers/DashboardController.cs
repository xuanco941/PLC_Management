using Microsoft.AspNetCore.Mvc;
using PLC_Management.Models.ActivityModel;


namespace PLC_Management.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index([FromQuery(Name = "timeSaveData")] int? timeSaveData)
        {
            if ((timeSaveData != null) && (timeSaveData > 2) && (timeSaveData * 1000 != InsertResultInterval.timeSaveData))
            {
                InsertResultInterval.timeSaveData = (int)timeSaveData * 1000;
                if (InsertResultInterval.TimerInsertResult.Enabled == true)
                {
                    InsertResultInterval.Clear();
                    InsertResultInterval.Run();
                }
            }
            ViewBag.timeSaveData = InsertResultInterval.timeSaveData / 1000;
            return View();
        }

        public IActionResult UpdateDataPLC()
        {
            MainPLC.GetData();
            return Json(new
            {
                //btn
                btn_batdau = CurrentValuePLC.btn_batdau,
                btn_laymau = CurrentValuePLC.btn_laymau,
                btn_luu = CurrentValuePLC.btn_luu,
                btn_tudong = CurrentValuePLC.btn_tudong,
                btn_xoa = CurrentValuePLC.btn_xoa,
                btn_doph = CurrentValuePLC.btn_doph,
                btn_dotss = CurrentValuePLC.btn_dotss,
                btn_docod = CurrentValuePLC.btn_docod,
                btn_donh4 = CurrentValuePLC.btn_donh4,
                btn_doluuluongtong = CurrentValuePLC.btn_doluuluongtong,
                btn_doluuluongvao = CurrentValuePLC.btn_doluuluongvao,
                Btn_doluuluongra = CurrentValuePLC.btn_doluuluongra,


                //parameter
                ph = Math.Round(CurrentValuePLC.pH, 4, MidpointRounding.AwayFromZero),
                cod = Math.Round(CurrentValuePLC.COD, 4, MidpointRounding.AwayFromZero),
                tss = Math.Round(CurrentValuePLC.TSS, 4, MidpointRounding.AwayFromZero),
                temp = Math.Round(CurrentValuePLC.Temp, 4, MidpointRounding.AwayFromZero),
                nh4 = Math.Round(CurrentValuePLC.NH4, 4, MidpointRounding.AwayFromZero),

                //luu luong
                luuluongtong = Math.Round(CurrentValuePLC.luuLuongTong, 4, MidpointRounding.AwayFromZero),
                luuluongvao = Math.Round(CurrentValuePLC.luuLuongVao, 4, MidpointRounding.AwayFromZero),
                luuluongra = Math.Round(CurrentValuePLC.luuLuongRa, 4, MidpointRounding.AwayFromZero),


                //status position DB17
                status_position_DB17_1 = CurrentValuePLC.status_position_DB17_1,
                status_position_DB17_2 = CurrentValuePLC.status_position_DB17_2,
                status_position_DB17_3 = CurrentValuePLC.status_position_DB17_3,
                status_position_DB17_4 = CurrentValuePLC.status_position_DB17_4,
                status_position_DB17_5 = CurrentValuePLC.status_position_DB17_5,
                status_position_DB17_6 = CurrentValuePLC.status_position_DB17_6,
                status_position_DB17_7 = CurrentValuePLC.status_position_DB17_7,
                status_position_DB17_8 = CurrentValuePLC.status_position_DB17_8,
                status_position_DB17_9 = CurrentValuePLC.status_position_DB17_9,
                status_position_DB17_10 = CurrentValuePLC.status_position_DB17_10,
                status_position_DB17_11 = CurrentValuePLC.status_position_DB17_11,
                status_position_DB17_12 = CurrentValuePLC.status_position_DB17_12,
                status_position_DB17_13 = CurrentValuePLC.status_position_DB17_13,
                status_position_DB17_14 = CurrentValuePLC.status_position_DB17_14,
                status_position_DB17_15 = CurrentValuePLC.status_position_DB17_15,
                status_position_DB17_16 = CurrentValuePLC.status_position_DB17_16,
                status_position_DB17_17 = CurrentValuePLC.status_position_DB17_17,
                status_position_DB17_18 = CurrentValuePLC.status_position_DB17_18,
                status_position_DB17_19 = CurrentValuePLC.status_position_DB17_19,
                status_position_DB17_20 = CurrentValuePLC.status_position_DB17_20,
                status_position_DB17_21 = CurrentValuePLC.status_position_DB17_21,
                status_position_DB17_22 = CurrentValuePLC.status_position_DB17_22,
                status_position_DB17_23 = CurrentValuePLC.status_position_DB17_23,
                status_position_DB17_24 = CurrentValuePLC.status_position_DB17_24,


                //status position DB17
                status_position_DB18_1 = CurrentValuePLC.status_position_DB18_1,
                status_position_DB18_2 = CurrentValuePLC.status_position_DB18_2,
                status_position_DB18_3 = CurrentValuePLC.status_position_DB18_3,
                status_position_DB18_4 = CurrentValuePLC.status_position_DB18_4,
                status_position_DB18_5 = CurrentValuePLC.status_position_DB18_5,
                status_position_DB18_6 = CurrentValuePLC.status_position_DB18_6,
                status_position_DB18_7 = CurrentValuePLC.status_position_DB18_7,
                status_position_DB18_8 = CurrentValuePLC.status_position_DB18_8,
                status_position_DB18_9 = CurrentValuePLC.status_position_DB18_9,
                status_position_DB18_10 = CurrentValuePLC.status_position_DB18_10,
                status_position_DB18_11 = CurrentValuePLC.status_position_DB18_11,
                status_position_DB18_12 = CurrentValuePLC.status_position_DB18_12,
                status_position_DB18_13 = CurrentValuePLC.status_position_DB18_13,
                status_position_DB18_14 = CurrentValuePLC.status_position_DB18_14,
                status_position_DB18_15 = CurrentValuePLC.status_position_DB18_15,
                status_position_DB18_16 = CurrentValuePLC.status_position_DB18_16,
                status_position_DB18_17 = CurrentValuePLC.status_position_DB18_17,
                status_position_DB18_18 = CurrentValuePLC.status_position_DB18_18,
                status_position_DB18_19 = CurrentValuePLC.status_position_DB18_19,
                status_position_DB18_20 = CurrentValuePLC.status_position_DB18_20,
                status_position_DB18_21 = CurrentValuePLC.status_position_DB18_21,
                status_position_DB18_22 = CurrentValuePLC.status_position_DB18_22,
                status_position_DB18_23 = CurrentValuePLC.status_position_DB18_23,
                status_position_DB18_24 = CurrentValuePLC.status_position_DB18_24,


                //position_current
                position_current_batdau = CurrentValuePLC.position_current_batdau,
                position_current_laymau = CurrentValuePLC.position_current_laymau,
                position_current_luu = CurrentValuePLC.position_current_luu,


                message = CurrentValuePLC.message,
                messageErrorConnectPLC = CurrentValuePLC.messageErrorConnectPLC
            });
        }



        [HttpPost]
        public IActionResult ReConnectPLC([FromBody] bool disconnect)
        {
            ActivityBusiness.AddActivity("Mất kết nối tới PLC.");
            if (disconnect == true)
            {
                MainPLC.Start();
                if (InsertResultInterval.TimerInsertResult.Enabled == true)
                {
                    InsertResultInterval.Clear();
                    InsertResultInterval.Run();
                }
            }

            return Json(new {disconnect});
        }



        //btn bat dau
        public IActionResult Btn_batdau([FromQuery(Name = "position")] uint position)
        {
            MainPLC.plc.Write("M200.2", 1);
            MainPLC.plc.Write("MW10", position.ToString());
            ActivityBusiness.AddActivity($"Bắt đầu trên mẫu thử số: {position}.");
            CurrentValuePLC.position_current_batdau = position;
            return Json(new
            {
                status = $"Bắt đầu trên mẫu thử số: {position}."
            });
        }

        public IActionResult Btn_laymau()
        {
            MainPLC.plc.Write("M200.7", 1);
            if (CurrentValuePLC.position_current_batdau != 0)
            {
                CurrentValuePLC.position_current_laymau = CurrentValuePLC.position_current_batdau;
                ActivityBusiness.AddActivity($"Lấy mẫu tại vị trí: {CurrentValuePLC.position_current_laymau}.");
                CurrentValuePLC.position_current_batdau = 0;
            }

            return Json(new
            {
                status = $"Lấy mẫu tại vị trí: {CurrentValuePLC.position_current_batdau}."
            });
        }

        public IActionResult Btn_luu([FromQuery(Name = "position")] uint position)
        {
            if (CurrentValuePLC.position_current_laymau != 0)
            {
                CurrentValuePLC.position_current_luu = CurrentValuePLC.position_current_laymau;
                ActivityBusiness.AddActivity($"Lưu tại vị trí: {CurrentValuePLC.position_current_luu}.");
                CurrentValuePLC.position_current_laymau = 0;
            }
            MainPLC.plc.Write("M200.1", 1);

            return Json(new
            {
                status = $"Lưu tại vị trí: {CurrentValuePLC.position_current_luu}."
            });
        }


        public IActionResult Btn_xoa([FromQuery(Name = "position")] uint position)
        {
            MainPLC.plc.Write("M200.0", 1);
            MainPLC.plc.Write("MW12", position.ToString());
            ActivityBusiness.AddActivity($"Xóa tại vị trí: {position}.");

            return Json(new
            {
                status = $"Xóa tại vị trí: {position}"
            });
        }





        public IActionResult Btn_tudong()
        {
            if (CurrentValuePLC.btn_tudong == false)
            {
                ActivityBusiness.AddActivity("Chuyển sang chế độ tự động.");
                MainPLC.plc.Write("M200.6", 1);
                CurrentValuePLC.btn_tudong = true;
            }
            else
            {
                ActivityBusiness.AddActivity("Tắt chế độ tự động.");
                MainPLC.plc.Write("M200.6", 0);
                CurrentValuePLC.btn_tudong = false;
            }

            return Json(new
            {
                status = CurrentValuePLC.btn_tudong
            });
        }



        public IActionResult Btn_doph()
        {
            MainPLC.plc.Write("M200.4", 1);
            return Json(new
            {
                status = "M200.4"
            });
        }

        public IActionResult Btn_doTSS()
        {
            MainPLC.plc.Write("M200.5", 1);
            return Json(new
            {
                status = "M200.5"
            });
        }

        public IActionResult Btn_doCOD()
        {
            MainPLC.plc.Write("M201.2", 1);

            return Json(new
            {
                status = "M201.2"
            });
        }
        public IActionResult Btn_doNH4()
        {
            MainPLC.plc.Write("M201.3", 1);

            return Json(new
            {
                status = "M201.3"
            });
        }

        public IActionResult Btn_doluuluongtong()
        {
            MainPLC.plc.Write("M200.3", 1);
            return Json(new
            {
                status = "OK M200.3"
            });
        }
        public IActionResult Btn_doluuluongvao()
        {
            MainPLC.plc.Write("M201.0", 1);
            return Json(new
            {
                status = "OK M201.0"
            });
        }
        public IActionResult Btn_doluuluongra()
        {
            MainPLC.plc.Write("M201.1", 1);
            return Json(new
            {
                status = "OK M201.1"
            });
        }

    }
}
