using MediatrPlayground.Dal.Models;
using MediatrPlayground.Models;

namespace MediatrPlayground.Dal;

public interface IUserRepository
{
    Task<UserDocument?> GetUser(string userId);
    Task<UserDocument> PostUser(UserDocument user);
    Task<UserDocument?> FindUserByName(string name);
}