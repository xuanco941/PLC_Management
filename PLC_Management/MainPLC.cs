using PROFINET_STEP_7.Profinet;
using PLC_Management.Models.ActivityModel;

namespace PLC_Management
{
    public class MainPLC
    {
        public static PLC plc;
        public static ExceptionCode errCode;

        public static System.Timers.Timer TimerRefreshData;


        public static void Start()
        {
            string ip = "192.168.0.1";
            CPU_Type cpu = CPU_Type.S71200;
            Int16 rack = 0;
            Int16 slot = 1;

            plc = new PLC(cpu, ip, rack, slot);
            try
            {
                if (string.IsNullOrEmpty(plc.IP))
                {
                    CurrentValuePLC.message = "*Thiếu địa chỉ IP";
                    throw new Exception("Xin vui lòng nhập địa chỉ IP");
                }
                if (!plc.IsAvailable)
                {
                    CurrentValuePLC.message = "*Không tìm thấy PLC cần kết nối!";
                    throw new Exception("Không tìm thấy PLC cần kết nối!");
                }
                errCode = plc.Open();
                if (errCode != ExceptionCode.ExceptionNo)
                {
                    CurrentValuePLC.message = "*Lỗi: " + plc.lastErrorString.ToString();
                    throw new Exception(plc.lastErrorString);
                }

                // success
                CurrentValuePLC.message = null;
                CurrentValuePLC.messageErrorConnectPLC = null;
                ActivityBusiness.AddActivity("Kết nối máy PLC thành công.");
            }
            catch (Exception ex)
            {
                CurrentValuePLC.message = "Không thể kết nối";
            }
        }


        public static void Stop()
        {
            try
            {
                plc.Close();
            }
            catch (Exception ex)
            {
                CurrentValuePLC.message = "*Lỗi đóng máy: " + ex.Message;
            }
        }


        public static void GetData()
        {
            //(READ)
            //parameter
            CurrentValuePLC.pH = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD0"));
            CurrentValuePLC.COD = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD4"));
            CurrentValuePLC.TSS = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD8"));
            CurrentValuePLC.Temp = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD12"));
            CurrentValuePLC.NH4 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD28"));

            //luu luong
            CurrentValuePLC.luuLuongTong = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD16"));
            CurrentValuePLC.luuLuongVao = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD20"));
            CurrentValuePLC.luuLuongRa = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD24"));



            ////status_position DB17
            CurrentValuePLC.status_position_DB17_1 = (ushort)plc.Read("DB17.DBW0");
            CurrentValuePLC.status_position_DB17_2 = (ushort)plc.Read("DB17.DBW2");
            CurrentValuePLC.status_position_DB17_3 = (ushort)plc.Read("DB17.DBW4");
            CurrentValuePLC.status_position_DB17_4 = (ushort)plc.Read("DB17.DBW6");
            CurrentValuePLC.status_position_DB17_5 = (ushort)plc.Read("DB17.DBW8");
            CurrentValuePLC.status_position_DB17_6 = (ushort)plc.Read("DB17.DBW10");
            CurrentValuePLC.status_position_DB17_7 = (ushort)plc.Read("DB17.DBW12");
            CurrentValuePLC.status_position_DB17_8 = (ushort)plc.Read("DB17.DBW14");
            CurrentValuePLC.status_position_DB17_9 = (ushort)plc.Read("DB17.DBW16");
            CurrentValuePLC.status_position_DB17_10 = (ushort)plc.Read("DB17.DBW18");
            CurrentValuePLC.status_position_DB17_11 = (ushort)plc.Read("DB17.DBW20");
            CurrentValuePLC.status_position_DB17_12 = (ushort)plc.Read("DB17.DBW22");
            CurrentValuePLC.status_position_DB17_13 = (ushort)plc.Read("DB17.DBW24");
            CurrentValuePLC.status_position_DB17_14 = (ushort)plc.Read("DB17.DBW26");
            CurrentValuePLC.status_position_DB17_15 = (ushort)plc.Read("DB17.DBW28");
            CurrentValuePLC.status_position_DB17_16 = (ushort)plc.Read("DB17.DBW30");
            CurrentValuePLC.status_position_DB17_17 = (ushort)plc.Read("DB17.DBW32");
            CurrentValuePLC.status_position_DB17_18 = (ushort)plc.Read("DB17.DBW34");
            CurrentValuePLC.status_position_DB17_19 = (ushort)plc.Read("DB17.DBW36");
            CurrentValuePLC.status_position_DB17_20 = (ushort)plc.Read("DB17.DBW38");
            CurrentValuePLC.status_position_DB17_21 = (ushort)plc.Read("DB17.DBW40");
            CurrentValuePLC.status_position_DB17_22 = (ushort)plc.Read("DB17.DBW42");
            CurrentValuePLC.status_position_DB17_23 = (ushort)plc.Read("DB17.DBW44");
            CurrentValuePLC.status_position_DB17_24 = (ushort)plc.Read("DB17.DBW46");

            ////status_position DB18
            CurrentValuePLC.status_position_DB18_1 = (ushort)plc.Read("DB18.DBW0");
            CurrentValuePLC.status_position_DB18_2 = (ushort)plc.Read("DB18.DBW2");
            CurrentValuePLC.status_position_DB18_3 = (ushort)plc.Read("DB18.DBW4");
            CurrentValuePLC.status_position_DB18_4 = (ushort)plc.Read("DB18.DBW6");
            CurrentValuePLC.status_position_DB18_5 = (ushort)plc.Read("DB18.DBW8");
            CurrentValuePLC.status_position_DB18_6 = (ushort)plc.Read("DB18.DBW10");
            CurrentValuePLC.status_position_DB18_7 = (ushort)plc.Read("DB18.DBW12");
            CurrentValuePLC.status_position_DB18_8 = (ushort)plc.Read("DB18.DBW14");
            CurrentValuePLC.status_position_DB18_9 = (ushort)plc.Read("DB18.DBW16");
            CurrentValuePLC.status_position_DB18_10 = (ushort)plc.Read("DB18.DBW18");
            CurrentValuePLC.status_position_DB18_11 = (ushort)plc.Read("DB18.DBW20");
            CurrentValuePLC.status_position_DB18_12 = (ushort)plc.Read("DB18.DBW22");
            CurrentValuePLC.status_position_DB18_13 = (ushort)plc.Read("DB18.DBW24");
            CurrentValuePLC.status_position_DB18_14 = (ushort)plc.Read("DB18.DBW26");
            CurrentValuePLC.status_position_DB18_15 = (ushort)plc.Read("DB18.DBW28");
            CurrentValuePLC.status_position_DB18_16 = (ushort)plc.Read("DB18.DBW30");
            CurrentValuePLC.status_position_DB18_17 = (ushort)plc.Read("DB18.DBW32");
            CurrentValuePLC.status_position_DB18_18 = (ushort)plc.Read("DB18.DBW34");
            CurrentValuePLC.status_position_DB18_19 = (ushort)plc.Read("DB18.DBW36");
            CurrentValuePLC.status_position_DB18_20 = (ushort)plc.Read("DB18.DBW38");
            CurrentValuePLC.status_position_DB18_21 = (ushort)plc.Read("DB18.DBW40");
            CurrentValuePLC.status_position_DB18_22 = (ushort)plc.Read("DB18.DBW42");
            CurrentValuePLC.status_position_DB18_23 = (ushort)plc.Read("DB18.DBW44");
            CurrentValuePLC.status_position_DB18_24 = (ushort)plc.Read("DB18.DBW46");

        }
    }
}
