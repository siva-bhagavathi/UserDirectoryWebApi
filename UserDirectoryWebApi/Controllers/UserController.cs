using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserDirectoryWebApi.Models;

namespace UserDirectoryWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly string _basePath= "C:\\Users\\sivan\\source\\Projects\\UserDirectory_Ceva\\Users";
        //Alternatively the above path can be read from appsettings.json and configured
        public UserController()
        {
            
        }

        [HttpPost]
        public IActionResult CreateDirectory(UserRequest[] userRequests)
        {
            if(userRequests == null || userRequests.Length==0)
            {
                return BadRequest("Users cannot be null");
            }

            string usersPath = Path.Combine(_basePath, "Users");
            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }

            foreach (var request in userRequests)
            {
                if (string.IsNullOrEmpty(request.EmployeeID))
                {
                    return BadRequest("EmployeeID is required.");
                }// similarly other validations can be added or a separate validation filter can be created

                string userInPath = Path.Combine(usersPath, request.EmployeeID, "IN");
                if (!Directory.Exists(userInPath))
                {
                    Directory.CreateDirectory(userInPath);
                }

                // To Store the request as a JSON file in the "IN" directory
                string jsonFilePath = Path.Combine(userInPath, "request.json");
                System.IO.File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(request));
            }


            return Ok("Directory created and user added successfully");
        }
    }
}
