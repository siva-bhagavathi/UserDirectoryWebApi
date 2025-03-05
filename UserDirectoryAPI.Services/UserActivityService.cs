using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ServicesContracts;
using UserDirectoryAPI.Domain;

namespace UserDirectoryAPI.Services
{
    public class UserActivityService:IUserActivityService
    {
        private readonly string _userDirectoryPath="..\\UserActivities";
        public async Task SaveUserActivities(List<User> userActivities)
        {
            string userDir = Path.Combine(_userDirectoryPath, "Users");
            string inDir = Path.Combine(userDir, "IN");

            if (!Directory.Exists(userDir))
            {
                Directory.CreateDirectory(userDir);
            }

            if (!Directory.Exists(inDir))
            {
                Directory.CreateDirectory(inDir);
            }

            string filePath = Path.Combine(inDir, $"UserActivities_{DateTime.Now:yyyyMMddHHmmss}.json");
            string json = JsonConvert.SerializeObject(userActivities);
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
