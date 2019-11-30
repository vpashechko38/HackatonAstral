using System.Threading.Tasks;
using Hakaton.Domain.Models.ViewModel;

namespace Hakaton.Data.Repository
{
    public interface IDetailIntoRepository
    {
        Task<DetailInfoVm> Get(int serviceId);
    }
}