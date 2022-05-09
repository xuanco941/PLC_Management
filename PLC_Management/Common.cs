
namespace PLC_Management
{
    public class Common
    {

        public const string ConnectionString = @"Data Source=DESKTOP-P4IC2M8\SQLEXPRESS;Initial Catalog=PLC_MANAGEMENT;User ID=sa;Password=942001xX";

        public const string SESSION_USER_LOGIN = "SESSION_USER_LOGIN";

        public const string SESSION_USER_FULLNAME = "SESSION_USER_FULLNAME";

        public const string SESSION_USER_ISADMIN = "SESSION_USER_ISADMIN";

        public const string SESSION_ISADMIN = "SESSION_ISADMIN";

        public const int NUMBER_ELM_ON_PAGE = 50;

        public static string? Message;
        //[TempData]
        //public static string Message { get; set; } = "";
    }
}
