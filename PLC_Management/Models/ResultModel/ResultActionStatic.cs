using System.Data.SqlClient;
using System.Timers;

namespace PLC_Management.Models.ResultModel
{
    public class ResultActionStatic
    {
        public static void Run()
        {

            // Create a timer and set a two second interval.
            var aTimer = new System.Timers.Timer();
            aTimer.Interval = 5000;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;
        }

        public static void OnTimedEvent(object sender, ElapsedEventArgs e)
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

                ResultBusiness resultBusiness = new ResultBusiness();
                resultBusiness.AddResult(result);
            }
        }
       

    }
}
