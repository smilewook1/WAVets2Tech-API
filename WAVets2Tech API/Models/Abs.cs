
using Microsoft.Data.SqlClient;
using System.Data;

namespace WAVets2Tech_API.Models
{
    public class Abs
    {
        public Response StudentRegistration(Student std, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Student(first_name, last_name, email, password_hash)" +
                "VALUES ('"+std.FirstName+ "', '" + std.LastName + "', '" + std.Email + "', '" + std.PasswordHash + "')");

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "success";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "fail";
            }

            return response;
        }

        public Response StudentLogin(Student std, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Student WHERE email = '"+std.Email+"' AND password_hash = '" +std.PasswordHash+"'", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Response response = new Response();
            

            if(dt.Rows.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "success";

                Student student = new Student();
                student.InternalId = Convert.ToInt32(dt.Rows[0]["internal_id"]);
                student.FirstName = Convert.ToString(dt.Rows[0]["first_name"]);
                student.LastName = Convert.ToString(dt.Rows[0]["last_name"]);
                student.Email = Convert.ToString(dt.Rows[0]["email"]);
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "success";
                response.Students = null;
            }
            
            return response ;
        }

        public Response StudentUserApproval(Student std, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE Student SET isApproved = 1 WHERE internal_id = '" + std.InternalId+"'", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "success";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "fail";
            }
            return response;
        }
    }
}
