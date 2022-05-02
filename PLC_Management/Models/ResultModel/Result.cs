namespace PLC_Management.Models.ResultModel
{
    public class Result
    {
        public int ID { get; set; }
        public string? Parameter_Name { get; set; }
        public string? Parameter_ID { get; set; }
        public string? Parameter_Unit { get; set; }
        public double Value { get; set; }
        public bool Status { get; set; }
        public string? Datetime { get; set; }

        public Result(int iD, string? parameter_Name, string? parameter_ID, string? parameter_Unit, double value, bool status, string? datetime)
        {
            ID = iD;
            Parameter_Name = parameter_Name;
            Parameter_ID = parameter_ID;
            Parameter_Unit = parameter_Unit;
            Value = value;
            Status = status;
            Datetime = datetime;
        }

        public Result(string? parameter_Name, string? parameter_ID, string? parameter_Unit, double value, bool status)
        {
            Parameter_Name = parameter_Name;
            Parameter_ID = parameter_ID;
            Parameter_Unit = parameter_Unit;
            Value = value;
            Status = status;
        }

        public Result()
        {
        }
    }

}
