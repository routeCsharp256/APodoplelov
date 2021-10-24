using System;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class MerchendiseController : ControllerBase
    {
        [Route("api/v1/merchandise/request")]
        public IActionResult FetchRequest()
        {
            throw new NotImplementedException();
        }

        [Route("api/v1/merchandise/info")]
        public IActionResult GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
