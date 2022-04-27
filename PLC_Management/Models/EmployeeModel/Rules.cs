using System.Data.SqlClient;

namespace PLC_Management.Models.EmployeeModel
{
    public class Rules
    {
        public static bool IsAdmin(int MaNV)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec FindEmployeeByID {MaNV}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);

            SqlDataReader sqlDataReader = command.ExecuteReader();
            if (sqlDataReader.Read() && sqlDataReader.GetBoolean(4) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
