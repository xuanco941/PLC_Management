
namespace PLC_Management.Models.EmployeeModel
{
    public class Employee
    {
        public int ID { get; set; } = 0;
        public string FullName { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public bool IsAdmin { get; set; } = false;

        public Employee()
        {
        }

        public Employee(int iD, string fullName, string username, string password, bool isAdmin)
        {
            ID = iD;
            FullName = fullName;
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
        }

        public Employee(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public Employee(string fullName, string username, string password, bool isAdmin)
        {
            FullName = fullName;
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
