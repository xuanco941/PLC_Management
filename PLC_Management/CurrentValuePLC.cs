using PLC_Management.Models.ParameterModel;

namespace PLC_Management
{
    public class CurrentValuePLC
    {
        //Parameter 
        public static Parameter P_pH = new Parameter("pH","pH","5/9","");
        public static Parameter P_Temp = new Parameter("Temp", "Temp", "40", "Độ C");
        public static Parameter P_TSS = new Parameter("TSS", "TSS", "100", "mg/l");
        public static Parameter P_COD = new Parameter("COD", "COD", "150", "mg/l");
        public static List<Parameter> parameters = new List<Parameter>() {P_pH,P_Temp,P_TSS,P_COD};



        //button
        public static bool btn_batdau { get; set; } = false;
        public static bool btn_laymau { get; set; } = false;
        public static bool btn_luu { get; set; } = false;
        public static bool btn_xoa { get; set; } = false;

        //message
        public static string? message { get; set; }

        //parameter
        public static double pH { get; set; } = 0;
        public static double COD { get; set; } = 0;
        public static double TSS { get; set; } = 0;
        public static double Temp { get; set; } = 0;
    }

}
