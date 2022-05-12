using PLC_Management.Models.ParameterModel;

namespace PLC_Management
{
    public class CurrentValuePLC
    {

        //Parameter 
        public static Parameter P_pH = new Parameter("pH", "pH", "5/9", "");
        public static Parameter P_Temp = new Parameter("Temp", "Temp", "40", "Độ C");
        public static Parameter P_TSS = new Parameter("TSS", "TSS", "100", "mg/L");
        public static Parameter P_COD = new Parameter("COD", "COD", "150", "mg/L");
        public static List<Parameter> parameters = new List<Parameter>() { P_pH, P_Temp, P_TSS, P_COD };



        //button
        public static bool btn_batdau { get; set; } = false;
        public static bool btn_laymau { get; set; } = false;
        public static bool btn_luu { get; set; } = false;
        public static bool btn_xoa { get; set; } = false;
        public static bool btn_doluuluong { get; set; } = false;
        public static bool btn_doph { get; set; } = false;
        public static bool btn_dotss { get; set; } = false;
        public static bool btn_tudong { get; set; } = true;
        public static bool btn_docod { get; set; } = false;


        //message
        public static string? message { get; set; }
        public static string? messageErrorBtn { get; set; }
        public static string? messageErrorConnectPLC { get; set; }



        //trang thai ong dung (bool)
        public static ushort status_position_1 { get; set; } = 0;
        public static ushort status_position_2 { get; set; } = 0;
        public static ushort status_position_3 { get; set; } = 0;
        public static ushort status_position_4 { get; set; } = 0;
        public static ushort status_position_5 { get; set; } = 0;
        public static ushort status_position_6 { get; set; } = 0;
        public static ushort status_position_7 { get; set; } = 0;
        public static ushort status_position_8 { get; set; } = 0;
        public static ushort status_position_9 { get; set; } = 0;
        public static ushort status_position_10 { get; set; } = 0;
        public static ushort status_position_11 { get; set; } = 0;
        public static ushort status_position_12 { get; set; } = 0;
        public static ushort status_position_13 { get; set; } = 0;
        public static ushort status_position_14 { get; set; } = 0;
        public static ushort status_position_15 { get; set; } = 0;
        public static ushort status_position_16 { get; set; } = 0;
        public static ushort status_position_17 { get; set; } = 0;
        public static ushort status_position_18 { get; set; } = 0;
        public static ushort status_position_19 { get; set; } = 0;
        public static ushort status_position_20 { get; set; } = 0;
        public static ushort status_position_21 { get; set; } = 0;
        public static ushort status_position_22 { get; set; } = 0;
        public static ushort status_position_23 { get; set; } = 0;
        public static ushort status_position_24 { get; set; } = 0;


        //value position
        public static double position_1 { get; set; } = 0;
        public static double position_2 { get; set; } = 0;
        public static double position_3 { get; set; } = 0;
        public static double position_4 { get; set; } = 0;
        public static double position_5 { get; set; } = 0;
        public static double position_6 { get; set; } = 0;
        public static double position_7 { get; set; } = 0;
        public static double position_8 { get; set; } = 0;
        public static double position_9 { get; set; } = 0;
        public static double position_10 { get; set; } = 0;
        public static double position_11 { get; set; } = 0;
        public static double position_12 { get; set; } = 0;
        public static double position_13 { get; set; } = 0;
        public static double position_14 { get; set; } = 0;
        public static double position_15 { get; set; } = 0;
        public static double position_16 { get; set; } = 0;
        public static double position_17 { get; set; } = 0;
        public static double position_18 { get; set; } = 0;
        public static double position_19 { get; set; } = 0;
        public static double position_20 { get; set; } = 0;
        public static double position_21 { get; set; } = 0;
        public static double position_22 { get; set; } = 0;
        public static double position_23 { get; set; } = 0;
        public static double position_24 { get; set; } = 0;
        public static double position_absolute { get; set; } = 0;
        public static uint position_current { get; set; } = 0;
        public static double velitical_absolute_jog { get; set; } = 0;
        public static uint nhap_so_chai_lay_mau { get; set; } = 0;
        public static uint xoa_so_chai_lay_mau { get; set; } = 0;



        //luu luong
        public static double luuLuong { get; set; } = 0;
        public static double luuLuongVao { get; set; } = 0;
        public static double luuLuongRa { get; set; } = 0;



        //parameter
        public static double pH { get; set; } = 0;
        public static double COD { get; set; } = 0;
        public static double TSS { get; set; } = 0;
        public static double Temp { get; set; } = 0;
    }

}
