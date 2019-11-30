using System.Collections.Generic;
using System.Threading.Tasks;
using Hakaton.Domain.Models.Enum;
using Hakaton.Domain.Models.Models;

namespace Hakaton.Data.Repository
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetService(Category category);
        Task<Service> Update(Service service);
        void Delete(Service service);
        Task<List<Service>> GetServicesUser(int userId);
    }
}