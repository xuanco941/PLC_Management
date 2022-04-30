namespace PLC_Management.Models.ActivityModel
{
    public class Activity
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Time { get; set; }

        public Activity(int iD, string? name, string? time)
        {
            ID = iD;
            Name = name;
            Time = time;
        }

        public Activity()
        {
        }
    }
}
