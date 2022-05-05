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
                    Common.Message = "Xin vui lòng nhập địa chỉ IP";
                    throw new Exception("Xin vui lòng nhập địa chỉ IP");
                }
                if (!plc.IsAvailable) {
                    Common.Message = "Không tìm thấy PLC cần kết nối!";
                    throw new Exception("Không tìm thấy PLC cần kết nối!");
                }
                errCode = plc.Open();
                if (errCode != ExceptionCode.ExceptionNo) {
                    Common.Message = "Gặp lỗi: " + plc.lastErrorString.ToString();
                    throw new Exception(plc.lastErrorString);
                } 
            }
            catch (Exception ex)
            {
                Common.Message = "Gặp lỗi: " + ex.ToString();
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
                Common.Message = "Lỗi đóng máy: " + ex.Message;
            }
        }


        // lay du lieu tu plc
        public static void GetData()
        {
            CurrentValuePLC.pH = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB7.DBD0"));
            CurrentValuePLC.Temp = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB7.DBD4"));
            CurrentValuePLC.TSS = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB7.DBD8"));
            CurrentValuePLC.COD = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB7.DBD12"));

        }
    }
}
