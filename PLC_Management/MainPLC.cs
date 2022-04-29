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
            string ip = "";
            CPU_Type cpu = CPU_Type.S71200;
            Int16 rack = 0;
            Int16 slot = 0;

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


        public static void GetData()
        {
            double SoThuc1 = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB7.DBD0"));
        }
    }
}
