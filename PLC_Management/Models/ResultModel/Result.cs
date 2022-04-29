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
    }
}
