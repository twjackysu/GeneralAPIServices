using DotnetSdkUtilities.Factory.ResponseFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAP_API.Common;
using SAP_API.DTO.Request;

namespace SAP_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManageSalesOrderInController : ControllerBase
    {
        private readonly ILogger<ManageSalesOrderInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;

        public ManageSalesOrderInController(ILogger<ManageSalesOrderInController> logger, IMyResponseFactory myResponseFactory)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
        }

        /// <summary>
        /// 銷售訂單-物料
        /// </summary>
        [ProducesResponseType(typeof(ApiOkResponse<string>), 200)]
        [HttpPost]
        public IActionResult MaterialSalesOrder([FromBody] MaterialSalesOrderRequest payload, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            return _myResponseFactory.CreateOKResponse("Hello MaterialSalesOrder");
        }
        /// <summary>
        /// 銷售訂單-專案
        /// </summary>
        [ProducesResponseType(typeof(ApiOkResponse<string>), 200)]
        [HttpPost]
        public IActionResult ProjectSalesOrder([FromBody] ProjectSalesOrderRequest payload, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            return _myResponseFactory.CreateOKResponse("Hello ProjectSalesOrder");
        }
    }
}
