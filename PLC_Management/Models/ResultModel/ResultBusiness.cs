﻿using System.Data.SqlClient;

namespace PLC_Management.Models.ResultModel
{
    public class ResultBusiness
    {
        public ResultBusiness()
        {
        }

        public List<Result> GetAllResults()
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select * from Result order by Result.Result_ID DESC";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                double _value = (double)sqlDataReader["Result_Value"];
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetString(3), Math.Round(_value, 4, MidpointRounding.AwayFromZero), sqlDataReader.GetBoolean(5), sqlDataReader["Result_DateTime"].ToString()); list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        public List<Result> GetResultByDay(string tungay, string toingay)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec FindResultDayToDay '{tungay}', '{toingay}'";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                double _value = (double)sqlDataReader["Result_Value"];
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetString(3), Math.Round(_value, 4, MidpointRounding.AwayFromZero), sqlDataReader.GetBoolean(5), sqlDataReader["Result_DateTime"].ToString());
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }


        public void AddResult(Result result)
        {

            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = $"exec AddResult @Result_Parameter_Name,@Result_Parameter_ID,@Result_Parameter_Unit,@Result_Value";
            var FullName = command.Parameters.AddWithValue("Result_Parameter_Name", result.Parameter_Name);
            var Username = command.Parameters.AddWithValue("Result_Parameter_ID", result.Parameter_ID);
            var Password = command.Parameters.AddWithValue("Result_Parameter_Unit", result.Parameter_Unit);
            var IsAdmin = command.Parameters.AddWithValue("Result_Value", result.Value);
            command.Connection = sqlConnection;

            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
