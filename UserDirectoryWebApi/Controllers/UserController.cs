using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServicesContracts;
using UserDirectoryAPI.Domain;
using UserDirectoryWebApi.Models;

namespace UserDirectoryWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserActivityService _userActivityService;

        public UserController(IUserActivityService userActivityService)
        {
            _userActivityService = userActivityService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateDirectory(List<User> userActivities)
        {
            if(userActivities == null || userActivities.Count==0)
            {
                return BadRequest("Users cannot be null");
            }
            await _userActivityService.SaveUserActivities(userActivities);   
            return Ok("Directory created and user added successfully");
        }
    }
}
