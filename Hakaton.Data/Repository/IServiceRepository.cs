using System.Collections.Generic;
using System.Threading.Tasks;
using Hakaton.Domain.Models.Enum;
using Hakaton.Domain.Models.Models;

namespace Hakaton.Data.Repository
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetService(Category category);
    }
}