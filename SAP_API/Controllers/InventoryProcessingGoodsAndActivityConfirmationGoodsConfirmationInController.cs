using DotnetSdkUtilities.Factory.ResponseFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAP_API.Common;
using SAP_API.DTO.Request;

namespace SAP_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInController : ControllerBase
    {
        private readonly ILogger<InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;

        public InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInController(ILogger<InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInController> logger, IMyResponseFactory myResponseFactory)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
        }

        /// <summary>
        /// 內部後勤-專案耗用
        /// </summary>
        [ProducesResponseType(typeof(ApiOkResponse<string>), 200)]
        [HttpPost]
        public IActionResult InternalLogisticsProjectConsumption([FromBody] InternalLogisticsProjectConsumptionRequest payload, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            return _myResponseFactory.CreateOKResponse("Hello InternalLogisticsProjectConsumption");
        }
    }
}
