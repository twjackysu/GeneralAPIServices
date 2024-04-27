using DotnetSdkUtilities.Factory.ResponseFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAP_API.Common;
using SAP_API.DTO.Request;

namespace SAP_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManagePurchaseOrderInController : ControllerBase
    {
        private readonly ILogger<ManagePurchaseOrderInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;

        public ManagePurchaseOrderInController(ILogger<ManagePurchaseOrderInController> logger, IMyResponseFactory myResponseFactory)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
        }

        /// <summary>
        /// 採購單-專案第三方
        /// </summary>
        [ProducesResponseType(typeof(ApiOkResponse<string>), 200)]
        [HttpPost]
        public IActionResult ProjectThirdPartyPurchaseOrder([FromBody] ProjectThirdPartyPurchaseOrderRequest payload, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            return _myResponseFactory.CreateOKResponse("Hello ProjectThirdPartyPurchaseOrder");
        }
    }
}
