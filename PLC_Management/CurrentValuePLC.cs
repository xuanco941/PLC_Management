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
        public static Parameter P_NH4 = new Parameter("NH4", "NH4", "", "");
        public static List<Parameter> parameters = new List<Parameter>() { P_pH, P_Temp, P_TSS, P_COD };



        //button
        public static bool btn_batdau { get; set; } = false;
        public static bool btn_laymau { get; set; } = false;
        public static bool btn_luu { get; set; } = false;
        public static bool btn_xoa { get; set; } = false;
        public static bool btn_doluuluongtong { get; set; } = false;
        public static bool btn_doph { get; set; } = false;
        public static bool btn_dotss { get; set; } = false;
        public static bool btn_tudong { get; set; } = true;
        public static bool btn_docod { get; set; } = false;
        public static bool btn_donh4 { get; set; } = false;
        public static bool btn_doluuluongvao { get; set; } = false;
        public static bool btn_doluuluongra { get; set; } = false;



        //connection
        public static bool isConnected { get; set; } = false; 

        //message
        public static string? message { get; set; }
        public static string? messageErrorConnectPLC { get; set; }



        //trang thai ong dung DB17
        public static ushort status_position_DB17_1 { get; set; } = 0;
        public static ushort status_position_DB17_2 { get; set; } = 0;
        public static ushort status_position_DB17_3 { get; set; } = 0;
        public static ushort status_position_DB17_4 { get; set; } = 0;
        public static ushort status_position_DB17_5 { get; set; } = 0;
        public static ushort status_position_DB17_6 { get; set; } = 0;
        public static ushort status_position_DB17_7 { get; set; } = 0;
        public static ushort status_position_DB17_8 { get; set; } = 0;
        public static ushort status_position_DB17_9 { get; set; } = 0;
        public static ushort status_position_DB17_10 { get; set; } = 0;
        public static ushort status_position_DB17_11 { get; set; } = 0;
        public static ushort status_position_DB17_12 { get; set; } = 0;
        public static ushort status_position_DB17_13 { get; set; } = 0;
        public static ushort status_position_DB17_14 { get; set; } = 0;
        public static ushort status_position_DB17_15 { get; set; } = 0;
        public static ushort status_position_DB17_16 { get; set; } = 0;
        public static ushort status_position_DB17_17 { get; set; } = 0;
        public static ushort status_position_DB17_18 { get; set; } = 0;
        public static ushort status_position_DB17_19 { get; set; } = 0;
        public static ushort status_position_DB17_20 { get; set; } = 0;
        public static ushort status_position_DB17_21 { get; set; } = 0;
        public static ushort status_position_DB17_22 { get; set; } = 0;
        public static ushort status_position_DB17_23 { get; set; } = 0;
        public static ushort status_position_DB17_24 { get; set; } = 0;


        // trang thai ong dung DB18
        public static ushort status_position_DB18_1 { get; set; } = 0;
        public static ushort status_position_DB18_2 { get; set; } = 0;
        public static ushort status_position_DB18_3 { get; set; } = 0;
        public static ushort status_position_DB18_4 { get; set; } = 0;
        public static ushort status_position_DB18_5 { get; set; } = 0;
        public static ushort status_position_DB18_6 { get; set; } = 0;
        public static ushort status_position_DB18_7 { get; set; } = 0;
        public static ushort status_position_DB18_8 { get; set; } = 0;
        public static ushort status_position_DB18_9 { get; set; } = 0;
        public static ushort status_position_DB18_10 { get; set; } = 0;
        public static ushort status_position_DB18_11 { get; set; } = 0;
        public static ushort status_position_DB18_12 { get; set; } = 0;
        public static ushort status_position_DB18_13 { get; set; } = 0;
        public static ushort status_position_DB18_14 { get; set; } = 0;
        public static ushort status_position_DB18_15 { get; set; } = 0;
        public static ushort status_position_DB18_16 { get; set; } = 0;
        public static ushort status_position_DB18_17 { get; set; } = 0;
        public static ushort status_position_DB18_18 { get; set; } = 0;
        public static ushort status_position_DB18_19 { get; set; } = 0;
        public static ushort status_position_DB18_20 { get; set; } = 0;
        public static ushort status_position_DB18_21 { get; set; } = 0;
        public static ushort status_position_DB18_22 { get; set; } = 0;
        public static ushort status_position_DB18_23 { get; set; } = 0;
        public static ushort status_position_DB18_24 { get; set; } = 0;


        //luu luong
        public static double luuLuongTong { get; set; } = 0;
        public static double luuLuongVao { get; set; } = 0;
        public static double luuLuongRa { get; set; } = 0;



        //parameter
        public static double pH { get; set; } = 0;
        public static double COD { get; set; } = 0;
        public static double TSS { get; set; } = 0;
        public static double Temp { get; set; } = 0;
        public static double NH4 { get; set; } = 0;
    }

}
