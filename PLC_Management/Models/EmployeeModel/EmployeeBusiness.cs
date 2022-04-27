using System.Data.SqlClient;

namespace PLC_Management.Models.EmployeeModel
{
    public class EmployeeBusiness
    {
        SqlCommand? command;
        public bool AuthLogin(Employee employee)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            //Dung procedure co san tren db
            string sql = $"exec FindEmployeeByUsername '{employee.Username.ToString().Trim()}'";
            command = new SqlCommand(sql,sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();

            // 3 la cloumn password
            if (sqlDataReader.Read() && sqlDataReader.GetString(3).Trim() == employee.Password.ToString().Trim())
            {
                int _ID = sqlDataReader.GetInt32(0);
                string _FullName = sqlDataReader.GetString(1);
                employee.ID = _ID;
                employee.FullName = _FullName;
                sqlConnection.Close();
                return true;
            }
            else
            {
                sqlConnection.Close();
                return false;
            }
        }

        public Employee GetDataFromID(int ID)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec FindEmployeeByID {ID}";
            command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            Employee employee = new Employee();
            while (sqlDataReader.Read())
            {
                employee.ID = (int)sqlDataReader["Employee_ID"];
                employee.FullName = (string)sqlDataReader["Employee_FullName"];
                employee.Username = (string)sqlDataReader["Employee_Username"];
                employee.Password = (string)sqlDataReader["Employee_Password"];
                employee.IsAdmin = (bool)sqlDataReader["Employee_IsAdmin"];
            }
            sqlConnection.Close();
            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select * from Employee";
            command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Employee employee = new Employee((int)sqlDataReader["Employee_ID"], (string)sqlDataReader["Employee_FullName"],
                    (string)sqlDataReader["Employee_Username"], (string)sqlDataReader["Employee_Password"], (bool)sqlDataReader["Employee_IsAdmin"]);
                list.Add(employee);
            }
            sqlConnection.Close();
            return list;
        }



        // Them TK
        public bool AddEmployee(Employee employee)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            command = new SqlCommand();
            command.CommandText = $"exec AddEmployee @FullName, @Username, @Password, @IsAdmin";
            var FullName = command.Parameters.AddWithValue("FullName", employee.FullName);
            var Username = command.Parameters.AddWithValue("Username", employee.Username.ToString().Trim());
            var Password = command.Parameters.AddWithValue("Password", employee.Password.ToString().Trim());
            var IsAdmin = command.Parameters.AddWithValue("IsAdmin", employee.IsAdmin);
            command.Connection = sqlConnection;

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        // Sua TK
        public bool UpdateEmployee(Employee employee)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            command = new SqlCommand();
            command.CommandText = "exec UpdateEmployee @ID, @FullName, @Username, @Password, @IsAdmin";
            var ID = command.Parameters.AddWithValue("ID", employee.ID);
            var FullName = command.Parameters.AddWithValue("FullName", employee.FullName);
            var Username = command.Parameters.AddWithValue("Username", employee.Username.ToString().Trim());
            var Password = command.Parameters.AddWithValue("Password", employee.Password.ToString().Trim());
            var IsAdmin = command.Parameters.AddWithValue("IsAdmin", employee.IsAdmin);
            command.Connection = sqlConnection;

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool DeleteEmployee(int ID)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            command = new SqlCommand();
            command.CommandText = $"exec DeleteEmployee @ID";
            var _id = command.Parameters.AddWithValue("ID", ID);

            command.Connection = sqlConnection;

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }

}
