using Hakaton.Domain.Models;
using Hakaton.Domain.Models.Models;

namespace Hakaton.Domain.Storage
{
    public interface IUserStorage
    {
        bool Add(RegistrationVM userVm);
        User Get(string login, string password);
        User Get(string token);
    }
}