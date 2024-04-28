using DotnetSdkUtilities.Factory.ResponseFactory;
using InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInNS;
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
    public class InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInController : ControllerBase
    {
        private readonly ILogger<InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInController(ILogger<InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 內部後勤-專案耗用
        /// </summary>
        [ProducesResponseType(typeof(ApiOkResponse<GACDetails[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> InternalLogisticsProjectConsumption([FromBody] InternalLogisticsProjectConsumptionRequest request, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInClient(binding, endpointAddress);
            client.ClientCredentials.UserName.UserName = _setting.CurrentValue.SAP.ClientCredentials.UserName;
            client.ClientCredentials.UserName.Password = _setting.CurrentValue.SAP.ClientCredentials.Password;

            var response = await client.DoGoodsConsumptionForProjectAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.GoodsAndActivityConfirmationGoodsConsumptionForProjectResponse?.GACDetails == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.GoodsAndActivityConfirmationGoodsConsumptionForProjectResponse?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.GoodsAndActivityConfirmationGoodsConsumptionForProjectResponse.GACDetails);
            }
        }
    }
}
