using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hakaton.Domain.Models.Enum;
using Hakaton.Domain.Models.Models;
using Hakaton.Domain.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Hakaton.App.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceStorage _serviceStorage;
        public ServiceController(IServiceStorage serviceStorage)
        {
            _serviceStorage = serviceStorage;
        }

        [Route("Get")]
        [HttpGet]
        public async Task<List<Service>> GetServices([FromQuery]Category category)
        {
            return await _serviceStorage.GetService(category);
        }

        [Route("Update")]
        [HttpGet]
        public async Task<Service> UpdateServices([FromQuery]Service service)
        {
            return await _serviceStorage.UpdateService(service);
        }
    }
}
