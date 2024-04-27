using DotnetSdkUtilities.Factory.ResponseFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAP_API.Common;
using SAP_API.DTO.Request;

namespace SAP_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManageGoodsAndServiceAcknowledgementInboundController : ControllerBase
    {
        private readonly ILogger<ManageGoodsAndServiceAcknowledgementInboundController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;

        public ManageGoodsAndServiceAcknowledgementInboundController(ILogger<ManageGoodsAndServiceAcknowledgementInboundController> logger, IMyResponseFactory myResponseFactory)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
        }

        /// <summary>
        /// 商品和服務確認-專案第三方
        /// </summary>
        [ProducesResponseType(typeof(ApiOkResponse<string>), 200)]
        [HttpPost]
        public IActionResult ProjectThirdPartyGoodsAndServiceAcknowledgement([FromBody] ProjectThirdPartyPurchaseOrderRequest payload, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            return _myResponseFactory.CreateOKResponse("Hello ProjectThirdPartyGoodsAndServiceAcknowledgement");
        }
    }
}
