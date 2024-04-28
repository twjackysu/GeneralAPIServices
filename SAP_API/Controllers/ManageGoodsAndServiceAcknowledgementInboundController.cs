using DotnetSdkUtilities.Factory.ResponseFactory;
using ManageGoodsAndServiceAcknowledgementInboundNS;
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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManageGoodsAndServiceAcknowledgementInboundController : ControllerBase
    {
        private readonly ILogger<ManageGoodsAndServiceAcknowledgementInboundController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public ManageGoodsAndServiceAcknowledgementInboundController(ILogger<ManageGoodsAndServiceAcknowledgementInboundController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 商品和服務確認-專案第三方
        /// </summary>
        [ProducesResponseType(typeof(ApiOkResponse<GSAMaintainConfirmationBundle[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> ProjectThirdPartyGoodsAndServiceAcknowledgement([FromBody] ProjectThirdPartyGoodsAndServiceAcknowledgementRequest request, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.ManageGoodsAndServiceAcknowledgementInbound);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new ManageGoodsAndServiceAcknowledgementInboundClient(binding, endpointAddress);
            client.ClientCredentials.UserName.UserName = _setting.CurrentValue.SAP.ClientCredentials.UserName;
            client.ClientCredentials.UserName.Password = _setting.CurrentValue.SAP.ClientCredentials.Password;

            var response = await client.ManageGSAInMaintainBundleAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.GSABundleMaintainConfirmation_sync?.GoodsAndServiceAcknowledgement == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.GSABundleMaintainConfirmation_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.GSABundleMaintainConfirmation_sync.GoodsAndServiceAcknowledgement);
            }
        }
    }
}
