namespace PLC_Management.Models.ParameterModel
{
    public class Parameter
    {
        public string? ID { get; set; }
        public string? Name { get; set; }
        public string? ValueRange { get; set; }
        public string? Unit { get; set; }

        public Parameter(string? iD, string? name, string? valueRange, string? unit)
        {
            ID = iD;
            Name = name;
            ValueRange = valueRange;
            Unit = unit;
        }
    }
}
