using Hakaton.Data.Repository;
using Hakaton.Domain.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hakaton.Domain.Storage
{
    public class DetailInfoStorage
    {
        private readonly IDetailIntoRepository _detailInfoRepository;
        public DetailInfoStorage(IDetailIntoRepository detailIntoRepository)
        {
            _detailInfoRepository = detailIntoRepository;
        }

        public async Task<DetailInfoVm> Get(int serviceId)
        {
            return await _detailInfoRepository.Get(serviceId);
        } 
    }
}
