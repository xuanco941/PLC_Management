using System.Data.SqlClient;

namespace PLC_Management.Models.ActivityModel
{
    public class ActivityBusiness
    {
        public List<Activity> GetAllActivities(int? page)
        {
            List<Activity> list = new List<Activity>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql;
            if (page != null && page != 0)
            {
                int? start = (page - 1) * Common.NUMBER_ELM_ON_PAGE;
                int? end = page * Common.NUMBER_ELM_ON_PAGE;
                sql = $"exec paginationActivity {start},{end}";
            }
            else
            {
                sql = "select * from Activity order by Activity.Activity_ID DESC";
            }
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

        public List<Activity> GetActivityByDay(string tungay, string toingay,int? page)
        {
            List<Activity> list = new List<Activity>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql;
            if (page != null && page != 0)
            {
                int? start = (page - 1) * Common.NUMBER_ELM_ON_PAGE;
                int? end = page * Common.NUMBER_ELM_ON_PAGE;
                sql = $"exec paginationActivityByDay {start},{end},'{tungay}','{toingay}'";
            }
            else
            {
                sql = $"exec FindActivityDayToDay '{tungay}', '{toingay}'";
            }
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
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

        public static int CountActivity()
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select count(*) from Activity";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }

        public static int CountActivityByDay(string tungay, string toingay)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec CountActivityDayToDay '{tungay}', '{toingay}'";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }


        public static void AddActivity(Activity activity)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = $"insert into Activity (Activity_Name) values (@Activity_Name)";
            command.Parameters.AddWithValue("Activity_Name", activity.Name);
            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
