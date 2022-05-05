using PROFINET_STEP_7.Profinet;
using PROFINET_STEP_7.Types;

namespace PLC_Management
{
    public class MainPLC
    {
        private static PLC plc;
        private static ExceptionCode errCode;
        public static void Start()
        {
            string ip = "192.168.0.1";
            CPU_Type cpu = CPU_Type.S71200;
            Int16 rack = 0;
            Int16 slot = 1;

            plc = new PLC(cpu,ip,rack,slot);
            try
            {
                if (string.IsNullOrEmpty(plc.IP)) {
                    Common.Message = "*Xin vui lòng nhập địa chỉ IP";
                    //throw new Exception("Xin vui lòng nhập địa chỉ IP");
                }
                if (!plc.IsAvailable) {
                    Common.Message = "(*)Không tìm thấy PLC cần kết nối!";
                    //throw new Exception("Không tìm thấy PLC cần kết nối!");
                }
                errCode = plc.Open();
                if (errCode != ExceptionCode.ExceptionNo) {
                    Common.Message = "(*)Gặp lỗi: " + plc.lastErrorString.ToString();
                    //throw new Exception(plc.lastErrorString);
                } 
            }
            catch (Exception ex)
            {
                Common.Message = "(*)Gặp lỗi: " + ex.ToString();
            }
        }


        public static void Stop()
        {
            try
            {
                plc.Close();
            }
            catch(Exception ex)
            {
                Common.Message = "(*)Lỗi đóng máy: " + ex.Message;
            }
        }


        // lay du lieu tu plc
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

            //status_position
            CurrentValuePLC.status_position_0 = (bool)plc.Read("DB17.DBx0.0");
            CurrentValuePLC.status_position_1 = (bool)plc.Read("DB17.DBx0.1");
            CurrentValuePLC.status_position_2 = (bool)plc.Read("DB17.DBx0.2");
            CurrentValuePLC.status_position_3 = (bool)plc.Read("DB17.DBx0.3");
            CurrentValuePLC.status_position_4 = (bool)plc.Read("DB17.DBx0.4");
            CurrentValuePLC.status_position_5 = (bool)plc.Read("DB17.DBx0.5");
            CurrentValuePLC.status_position_6 = (bool)plc.Read("DB17.DBx0.6");
            CurrentValuePLC.status_position_7 = (bool)plc.Read("DB17.DBx0.7");
            CurrentValuePLC.status_position_8 = (bool)plc.Read("DB17.DBx1.0");
            CurrentValuePLC.status_position_9 = (bool)plc.Read("DB17.DBx1.1");
            CurrentValuePLC.status_position_10 = (bool)plc.Read("DB17.DBx1.2");
            CurrentValuePLC.status_position_11 = (bool)plc.Read("DB17.DBx1.3");
            CurrentValuePLC.status_position_12 = (bool)plc.Read("DB17.DBx1.4");
            CurrentValuePLC.status_position_13 = (bool)plc.Read("DB17.DBx1.5");
            CurrentValuePLC.status_position_14 = (bool)plc.Read("DB17.DBx1.6");
            CurrentValuePLC.status_position_15 = (bool)plc.Read("DB17.DBx1.7");
            CurrentValuePLC.status_position_16 = (bool)plc.Read("DB17.DBx2.0");
            CurrentValuePLC.status_position_17 = (bool)plc.Read("DB17.DBx2.1");
            CurrentValuePLC.status_position_18 = (bool)plc.Read("DB17.DBx2.2");
            CurrentValuePLC.status_position_19 = (bool)plc.Read("DB17.DBx2.3");
            CurrentValuePLC.status_position_20 = (bool)plc.Read("DB17.DBx2.4");
            CurrentValuePLC.status_position_21 = (bool)plc.Read("DB17.DBx2.5");
            CurrentValuePLC.status_position_22 = (bool)plc.Read("DB17.DBx2.6");
            CurrentValuePLC.status_position_23 = (bool)plc.Read("DB17.DBx2.7");
            CurrentValuePLC.status_position_24 = (bool)plc.Read("DB17.DBx3.0");




        }
    }
}
