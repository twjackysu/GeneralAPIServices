using DotnetSdkUtilities.Factory.ResponseFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAP_API.Common;
using SAP_API.DTO.Request;

namespace SAP_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInController : ControllerBase
    {
        private readonly ILogger<InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;

        public InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInController(ILogger<InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInController> logger, IMyResponseFactory myResponseFactory)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
        }

        /// <summary>
        /// 內部後勤-物料異動
        /// </summary>
        [ProducesResponseType(typeof(ApiOkResponse<string>), 200)]
        [HttpPost]
        public IActionResult InternalLogisticsMaterialMovement([FromBody] InternalLogisticsMaterialMovementRequest payload, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            return _myResponseFactory.CreateOKResponse("Hello InternalLogisticsMaterialMovement");
        }
    }
}
