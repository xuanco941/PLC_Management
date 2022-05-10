using PLC_Management.Models.ResultModel;
using System.Timers;

namespace PLC_Management
{
    public class InsertResultInterval
    {
        public static System.Timers.Timer TimerInsertResult;
        //Time Save Result
        // mặc định 10s
        public static int timeSaveData { get; set; } = 10000;

        public static void Run()
        {
            // Create a timer and set a two second interval.
            TimerInsertResult = new System.Timers.Timer(timeSaveData);

            TimerInsertResult.Interval = timeSaveData;

            // Hook up the Elapsed event for the timer. 
            TimerInsertResult.Elapsed += InsertResult;

            // Have the timer fire repeated events (true is the default)
            TimerInsertResult.AutoReset = true;

            // Start the timer
            TimerInsertResult.Enabled = true;
        }
        public static void Clear()
        {
            if(TimerInsertResult != null && TimerInsertResult.Enabled == true)
            {
                TimerInsertResult.Stop();
                TimerInsertResult.Dispose();
            } 
 
        }



        public static void InsertResult(object sender, ElapsedEventArgs e)
        {
            foreach (var parameter in CurrentValuePLC.parameters)
            {
                double value = 0;
                if (parameter.Name == "pH")
                {
                    value = CurrentValuePLC.pH;
                }
                if (parameter.Name == "TSS")
                {
                    value = CurrentValuePLC.TSS;
                }
                if (parameter.Name == "Temp")
                {
                    value = CurrentValuePLC.Temp;
                }
                if (parameter.Name == "COD")
                {
                    value = CurrentValuePLC.COD;
                }
                Result result = new Result();
                result.Parameter_Name = parameter.Name;
                result.Parameter_ID = parameter.ID;
                result.Parameter_Unit = parameter.Unit;
                result.Value = value;
                result.Status = true;

                ResultBusiness.AddResult(result);
            }
        }
       

    }
}
