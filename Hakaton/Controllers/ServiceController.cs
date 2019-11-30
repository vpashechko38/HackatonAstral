using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hakaton.Domain.Models.Enum;
using Hakaton.Domain.Models.Models;
using Hakaton.Domain.Models.ViewModel;
using Hakaton.Domain.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Hakaton.App.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceStorage _serviceStorage;
        private readonly IDetailInfoStorage _detailInfoStorage;
        public ServiceController(IServiceStorage serviceStorage, IDetailInfoStorage detailInfoStorage)
        {
            _serviceStorage = serviceStorage;
            _detailInfoStorage = detailInfoStorage;
        }

        [Route("Get")]
        [HttpGet]
        public async Task<List<Service>> GetServices([FromQuery]Category category)
        {
            return await _serviceStorage.GetService(category);
        }

        [Route("Update")]
        [HttpPost]
        public async Task<Service> UpdateServices([FromBody]Service service)
        {
            return await _serviceStorage.UpdateService(service);
        }
        [Route("Create")]
        [HttpPost]
        public async Task<Service> Create([FromBody] Service service)
        {
            return await _serviceStorage.Create(service);
        }

        [Route("GetDetailInfo")]
        [HttpGet]
        public async Task<DetailInfoVm> GetDetailInfo([FromQuery]int serviceId)
        {
            return await _detailInfoStorage.Get(serviceId);
        }
        [Route("Delete")]
        [HttpDelete]
        public void DeleteServices([FromQuery] Service service)
        {
            _serviceStorage.Delete(service);
        }
        [Route("GetServicesUser")]
        [HttpGet]
        public async Task<List<Service>> GetServicesUser(int userId)
        {
            return await _serviceStorage.GetServicesUser(userId);
        }
    }
}
