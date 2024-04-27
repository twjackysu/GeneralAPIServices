using DotnetSdkUtilities.Factory.ResponseFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAP_API.Common;
using SAP_API.DTO.Request;

namespace SAP_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManagePurchaseRequestInController : ControllerBase
    {
        private readonly ILogger<ManagePurchaseRequestInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;

        public ManagePurchaseRequestInController(ILogger<ManagePurchaseRequestInController> logger, IMyResponseFactory myResponseFactory)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
        }

        /// <summary>
        /// 採購請求-專案第三方
        /// </summary>
        [ProducesResponseType(typeof(ApiOkResponse<string>), 200)]
        [HttpPost]
        public IActionResult ProjectThirdPartyPurchaseRequest([FromBody] ProjectThirdPartySupplierInvoiceRequestRequest payload, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            return _myResponseFactory.CreateOKResponse("Hello ProjectThirdPartyPurchaseRequest");
        }
        /// <summary>
        /// 採購請求-一般庫存請購
        /// </summary>
        [ProducesResponseType(typeof(ApiOkResponse<string>), 200)]
        [HttpPost]
        public IActionResult GeneralInventoryPurchaseRequest([FromBody] GeneralInventoryPurchaseRequestRequest payload, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            return _myResponseFactory.CreateOKResponse("Hello GeneralInventoryPurchaseRequest");
        }
    }
}
