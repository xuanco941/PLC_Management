using PROFINET_STEP_7.Profinet;
using PROFINET_STEP_7.Types;
using System.Timers;

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
            }
            catch (Exception ex)
            {
                CurrentValuePLC.message = "*Gặp lỗi: " + ex.ToString();
                ReStart();
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

        public static void ReStart()
        {
            CurrentValuePLC.messageErrorConnectPLC = "(Đang tự động kết nối lại . . .)";
            Start();
        }

        public static void GetData()
        {
            //(READ)
            //parameter
            CurrentValuePLC.pH = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD0"));
            CurrentValuePLC.COD = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD4"));
            CurrentValuePLC.TSS = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD8"));
            CurrentValuePLC.Temp = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD12"));

            //luu luong
            CurrentValuePLC.luuLuong = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD16"));
            CurrentValuePLC.luuLuongVao = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD20"));
            CurrentValuePLC.luuLuongRa = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD24"));


            //value position
            CurrentValuePLC.position_1 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD0"));
            CurrentValuePLC.position_2 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD4"));
            CurrentValuePLC.position_3 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD8"));
            CurrentValuePLC.position_4 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD12"));
            CurrentValuePLC.position_5 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD16"));
            CurrentValuePLC.position_6 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD20"));
            CurrentValuePLC.position_7 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD24"));
            CurrentValuePLC.position_8 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD28"));
            CurrentValuePLC.position_9 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD32"));
            CurrentValuePLC.position_10 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD36"));
            CurrentValuePLC.position_11 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD40"));
            CurrentValuePLC.position_12 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD44"));
            CurrentValuePLC.position_13 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD48"));
            CurrentValuePLC.position_14 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD52"));
            CurrentValuePLC.position_15 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD56"));
            CurrentValuePLC.position_16 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD60"));
            CurrentValuePLC.position_17 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD64"));
            CurrentValuePLC.position_18 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD68"));
            CurrentValuePLC.position_19 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD72"));
            CurrentValuePLC.position_20 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD76"));
            CurrentValuePLC.position_21 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD80"));
            CurrentValuePLC.position_22 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD84"));
            CurrentValuePLC.position_23 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD88"));
            CurrentValuePLC.position_24 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD92"));

            CurrentValuePLC.position_absolute = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD96"));
            CurrentValuePLC.position_current = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD100"));
            CurrentValuePLC.velitical_absolute_jog = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB6.DBD104"));

            CurrentValuePLC.nhap_so_chai_lay_mau = (uint)plc.Read("DB6.DBD108");
            CurrentValuePLC.xoa_so_chai_lay_mau = (uint)plc.Read("DB6.DBD110");



            ////status_position
            CurrentValuePLC.status_position_1 = (ushort)plc.Read("DB17.DBW0");
            CurrentValuePLC.status_position_2 = (ushort)plc.Read("DB17.DBW2");
            CurrentValuePLC.status_position_3 = (ushort)plc.Read("DB17.DBW4");
            CurrentValuePLC.status_position_4 = (ushort)plc.Read("DB17.DBW6");
            CurrentValuePLC.status_position_5 = (ushort)plc.Read("DB17.DBW8");
            CurrentValuePLC.status_position_6 = (ushort)plc.Read("DB17.DBW10");
            CurrentValuePLC.status_position_7 = (ushort)plc.Read("DB17.DBW12");
            CurrentValuePLC.status_position_8 = (ushort)plc.Read("DB17.DBW14");
            CurrentValuePLC.status_position_9 = (ushort)plc.Read("DB17.DBW16");
            CurrentValuePLC.status_position_10 = (ushort)plc.Read("DB17.DBW18");
            CurrentValuePLC.status_position_11 = (ushort)plc.Read("DB17.DBW20");
            CurrentValuePLC.status_position_12 = (ushort)plc.Read("DB17.DBW22");
            CurrentValuePLC.status_position_13 = (ushort)plc.Read("DB17.DBW24");
            CurrentValuePLC.status_position_14 = (ushort)plc.Read("DB17.DBW26");
            CurrentValuePLC.status_position_15 = (ushort)plc.Read("DB17.DBW28");
            CurrentValuePLC.status_position_16 = (ushort)plc.Read("DB17.DBW30");
            CurrentValuePLC.status_position_17 = (ushort)plc.Read("DB17.DBW32");
            CurrentValuePLC.status_position_18 = (ushort)plc.Read("DB17.DBW34");
            CurrentValuePLC.status_position_19 = (ushort)plc.Read("DB17.DBW36");
            CurrentValuePLC.status_position_20 = (ushort)plc.Read("DB17.DBW38");
            CurrentValuePLC.status_position_21 = (ushort)plc.Read("DB17.DBW40");
            CurrentValuePLC.status_position_22 = (ushort)plc.Read("DB17.DBW42");
            CurrentValuePLC.status_position_23 = (ushort)plc.Read("DB17.DBW44");
            CurrentValuePLC.status_position_24 = (ushort)plc.Read("DB17.DBW46");

        }
    }
}
