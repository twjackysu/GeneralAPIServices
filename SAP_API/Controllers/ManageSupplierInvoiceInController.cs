using DotnetSdkUtilities.Factory.ResponseFactory;
using ManageSupplierInvoiceInNS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SAP_API.Common;
using SAP_API.Configuration;
using SAP_API.DTO.Request;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SAP_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ManageSupplierInvoiceInController : ControllerBase
    {
        private readonly ILogger<ManageSupplierInvoiceInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public ManageSupplierInvoiceInController(ILogger<ManageSupplierInvoiceInController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 供應商發票-專案第三方
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/ManageSupplierInvoiceIn/ProjectThirdPartySupplierInvoice
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<SupplierInvoiceMaintainConfirmationBundle[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> ProjectThirdPartySupplierInvoice([FromBody] ProjectThirdPartySupplierInvoiceRequestRequest request, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.ManageSupplierInvoiceIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new ManageSupplierInvoiceInClient(binding, endpointAddress);
            client.ClientCredentials.UserName.UserName = _setting.CurrentValue.SAP.ClientCredentials.UserName;
            client.ClientCredentials.UserName.Password = _setting.CurrentValue.SAP.ClientCredentials.Password;

            var response = await client.MaintainBundleAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.SupplierInvoiceBundleMaintainConfirmation_sync?.SupplierInvoice == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.SupplierInvoiceBundleMaintainConfirmation_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.SupplierInvoiceBundleMaintainConfirmation_sync.SupplierInvoice);
            }
        }
    }
}
