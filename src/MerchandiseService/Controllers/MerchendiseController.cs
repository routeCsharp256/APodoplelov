using System;
using System.Threading.Tasks;
using MerchandiseService.RestModels;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public sealed class MerchendiseController : ControllerBase
    {
        [Route("api/merchandise/demand")]
        [HttpPost]
        public Task<MerchandiseDemandResponse> SendDemand([FromBody] MerchandiseDemandRequest request)
        {
            throw new NotImplementedException();
        }

        [Route("api/merchandise/info")]
        [HttpPost]
        public Task<MerchandiseInfoResponse> GetInfo([FromBody] MerchandiseInfoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
