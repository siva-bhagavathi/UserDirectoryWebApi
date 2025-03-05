using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using UserDirectoryAPI.Domain;
using UserDirectoryAPI.Services;

namespace UserDirectory.Tests
{
    public class UserActivityServiceTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly UserActivityService _userActivityService;

        public UserActivityServiceTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockConfiguration.Setup(config => config["UserDirectoryPath"]).Returns("..\\UserActivities");
            _userActivityService = new UserActivityService();
        }
        [Fact]
        public void SaveUserActivities_CreatesFileWithCorrectContent()
        {
            // Arrange
            var userActivities = new List<User>
            {
                new User
                {
                    ID = 64,
                    UserID = 7,
                    EmployeeID = "CLGAXO",
                    SiteName = "MULGRAVE",
                    BusinessUnitName = "Telstra Logistics - Melbourne",
                    AccountName = "IBM AUSTRALIA LTD",
                    GroupName = "Transport",
                    CategoryName = "Activity - Productive",
                    TypeName = "Transport - Freight Sorting",
                    Date = DateTime.Parse("2018-02-14"),
                    Duration = "00:30",
                    IsProcessed = false
                }
            };
            var expectedFilePath = Path.Combine("..\\UserActivities", "Users", "IN", $"UserActivities_{DateTime.Now:yyyyMMddHHmmss}.json");

            // Act
            var test =_userActivityService.SaveUserActivities(userActivities);

            // Assert
            Assert.True(File.Exists(expectedFilePath));

            var fileContent = File.ReadAllText(expectedFilePath);
            var savedActivities = JsonConvert.DeserializeObject<List<User>>(fileContent);
            Assert.Equal(userActivities.Count, savedActivities?.Count);
           

            // Clean up
            File.Delete(expectedFilePath);
        }
    }
}
