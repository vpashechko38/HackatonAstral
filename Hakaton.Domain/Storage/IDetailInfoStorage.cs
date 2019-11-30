using System.Threading.Tasks;
using Hakaton.Domain.Models.ViewModel;

namespace Hakaton.Domain.Storage
{
    public interface IDetailInfoStorage
    {
        Task<DetailInfoVm> Get(int serviceId);
    }
}