using System.Data.SqlClient;

namespace PLC_Management.Models.ActivityModel
{
    public class ActivityBusiness
    {
        public List<Activity> GetAllActivities()
        {
            List<Activity> list = new List<Activity>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select * from Activity";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Activity activity = new Activity((int)sqlDataReader["Activity_ID"], (string)sqlDataReader["Activity_Name"],
                    sqlDataReader["Activity_Time"].ToString());
                list.Add(activity);
            }
            sqlConnection.Close();
            return list;
        }

        public List<Activity> GetActivityByDay(string tungay, string toingay)
        {
            List<Activity> list = new List<Activity>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec FindActivityDayToDay {tungay}, {toingay}";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Activity activity = new Activity((int)sqlDataReader["Activity_ID"], (string)sqlDataReader["Activity_Name"],
                    (string)sqlDataReader["Activity_Time"]);
                list.Add(activity);
            }
            sqlConnection.Close();
            return list;
        }
    }
}
