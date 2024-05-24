using DotnetSdkUtilities.Factory.ResponseFactory;
using MaintainGeneralizedCodeNS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SAP_API.Common;
using SAP_API.Configuration;
using SAP_API.DTO.Request;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace SAP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintainGeneralizedCodeController : ControllerBase
    {
        private readonly ILogger<MaintainGeneralizedCodeController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public MaintainGeneralizedCodeController(ILogger<MaintainGeneralizedCodeController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }
        [ProducesResponseType(typeof(ApiOkResponse<processMaintainGeneralizedCodeResponse>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> MaintainGeneralizedCode([FromBody] MaintainGeneralizedCodeRequest request, [FromHeader(Name = "SAP-API-Key")] string _)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.QAD.EndPoints.MaintainGeneralizedCode);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new QdocWebServiceClient(binding, endpointAddress);

            var response = await client.maintainGeneralizedCodeAsync(request.Header.Action, request.Header.To, request.Header.MessageID, request.Header.ReferenceParameters, request.Header.ReplyTo, request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.maintainGeneralizedCodeResponse?.dsExceptions != null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.maintainGeneralizedCodeResponse?.dsExceptions));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.maintainGeneralizedCodeResponse);
            }
        }
    }
}
