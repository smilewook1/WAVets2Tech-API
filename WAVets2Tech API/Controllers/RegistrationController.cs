using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WAVets2Tech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace WAVets2Tech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        
        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Registration")]

        public Response Registration (Student s)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());

            Abs abs = new Abs();
            response = abs.StudentRegistration(s, connection);

            return response;
        }

        [HttpPost]
        [Route("Login")]

        public Response Login(Student s)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());

            Abs abs = new Abs();
            response = abs.StudentLogin(s, connection);

            return response;
        }

        [HttpPost]
        [Route("UserApproval")]
        public Response UserApproval(Student s)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());

            Abs abs = new Abs();
            response = abs.StudentUserApproval(s, connection);

            return response;
        }
    }
}
