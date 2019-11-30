using Hakaton.Domain.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hakaton.App.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ServiceController: ControllerBase
    {        
        public ServiceController()
        {

        }

        [Route("get")]
        public async Task<DetailInfoVm> GetDetailInfo(int serviceId)
        {

        }
    }
}
