using DotnetSdkUtilities.Factory.ResponseFactory;
using Microsoft.AspNetCore.Mvc;
using SAP_API.Common;
using SAP_API.DTO.Request;

namespace SAP_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ManageSupplierInvoiceInController : ControllerBase
    {
        private readonly ILogger<ManageSupplierInvoiceInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;

        public ManageSupplierInvoiceInController(ILogger<ManageSupplierInvoiceInController> logger, IMyResponseFactory myResponseFactory)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
        }

        /// <summary>
        /// 供應商發票-專案第三方
        /// </summary>
        [ProducesResponseType(typeof(ApiOkResponse<string>), 200)]
        [HttpPost]
        public IActionResult ProjectThirdPartySupplierInvoice([FromBody] ProjectThirdPartySupplierInvoiceRequestRequest payload, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            return _myResponseFactory.CreateOKResponse("Hello ProjectThirdPartySupplierInvoice");
        }
    }
}
