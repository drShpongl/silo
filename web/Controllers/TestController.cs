using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using igrains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace web.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<TestModel> Get(Guid uid)
        {
            var grain = SiloClient.Instance.GetGrain<ICrudGrainBase<TestModel>>(uid);
            var state = await grain.Get();
            return state;
        }

        [HttpPost]
        public async Task<bool> Save(TestModel model)
        {
            var grain = SiloClient.Instance.GetGrain<ICrudGrainBase<TestModel>>(model.Uid); ;
            var isSuccess = await grain.Save(model);
            return isSuccess;
        }
    }
}
