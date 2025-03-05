using UserDirectoryAPI.Domain;

namespace ServicesContracts
{
    public interface IUserActivityService
    {
        Task SaveUserActivities(List<User> user);
    }
}
