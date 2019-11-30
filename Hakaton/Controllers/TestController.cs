using Hakaton.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hakaton.App.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class TestController
    {
        //private readonly DataSeed _dataSeed;
        //public TestController(DataSeed dataSeed)
        //{
        //    _dataSeed = dataSeed;
        //}

        //[HttpGet]
        //public bool TestSeed()
        //{
        //    return _dataSeed.AddSeed();
        //}

    }
}
