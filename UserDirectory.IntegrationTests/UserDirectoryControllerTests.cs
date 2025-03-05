using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Newtonsoft.Json;
using ServicesContracts;
using System.Text;
using UserDirectoryAPI.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace UserDirectory.IntegrationTests
{
    public class UserDirectoryControllerTests: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly Mock<IUserActivityService> _mockUserActivityService;

        //private readonly WebApplicationFactory<Program> _factory;

        public UserDirectoryControllerTests(WebApplicationFactory<Program> factory)
        {
            //_factory = factory;
            _mockUserActivityService = new Mock<IUserActivityService>();
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddSingleton(_mockUserActivityService.Object);
                });
            }).CreateClient();
        }       

        [Fact]
        public async Task Post_UserActivities_ReturnsOk()
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
                    Date = System.DateTime.Parse("2018-02-14"),
                    Duration = "00:30",
                    IsProcessed = false
                }
            };

            var content = new StringContent(JsonConvert.SerializeObject(userActivities), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("http://localhost:5126/User", content);

            // Assert
            response.EnsureSuccessStatusCode();            

            _mockUserActivityService.Verify(s => s.SaveUserActivities(It.IsAny<List<User>>()), Times.Once);
        }
    }

}
