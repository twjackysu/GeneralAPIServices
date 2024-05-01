using DotnetSdkUtilities.Factory.ResponseFactory;
using ManageGoodsAndServiceAcknowledgementInboundNS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SAP_API.Common;
using SAP_API.Configuration;
using SAP_API.DTO.Request;
using SAP_WSDL_Library.Connected_Services.ManageGoodsAndServiceAcknowledgementInboundNS;
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
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/ManageGoodsAndServiceAcknowledgementInbound/ProjectThirdPartyGoodsAndServiceAcknowledgement
        ///     {
        ///        "Payload": {
        ///           "GoodsAndServiceAcknowledgement": [
        ///              {
        ///                 "actionCode": 0,
        ///                 "actionCodeSpecified": true,
        ///                 "BusinessTransactionDocumentTypeCode": {
        ///                    "Value": "282"
        ///                 },
        ///                 "Date": "2024-04-10",
        ///                 "PostGSAIndicator": true,
        ///                 "PostGSAIndicatorSpecified": true,
        ///                 "DeliveryNoteReference": {
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true,
        ///                    "ID": {
        ///                       "Value": "ALICE_APITEST_004"
        ///                    }
        ///                 },
        ///                 "Item": [
        ///                    {
        ///                       "actionCode": 0,
        ///                       "actionCodeSpecified": true,
        ///                       "BusinessTransactionDocumentTypeCode": {
        ///                          "Value": "18"
        ///                       },
        ///                       "Quantity": {
        ///                          "Value": 5
        ///                       },
        ///                       "QuantityTypeCode": {
        ///                          "Value": "EA"
        ///                       },
        ///                       "CustomerParty": {
        ///                          "PartyKey": {
        ///                             "PartyID": {
        ///                                "Value": "E076"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "DeliveryPeriod": {
        ///                          "StartDateTime": {
        ///                             "timeZoneCode": "UTC+8",
        ///                             "Value": "2024-04-09T17:00:00+08:00"
        ///                          },
        ///                          "EndDateTime": {
        ///                             "timeZoneCode": "UTC+8",
        ///                             "Value": "2024-04-16T02:00:00+08:00"
        ///                          }
        ///                       },
        ///                       "ItemAccountingCodingBlockDistribution": {
        ///                          "CompanyID": "AT",
        ///                          "ActionCode": 0,
        ///                          "ActionCodeSpecified": true,
        ///                          "AccountingCodingBlockAssignment": [
        ///                             {
        ///                                "ActionCode": 0,
        ///                                "ActionCodeSpecified": true,
        ///                                "AccountingCodingBlockTypeCode": {
        ///                                   "Value": "PRO"
        ///                                },
        ///                                "ProjectTaskKey": {
        ///                                   "TaskID": {
        ///                                      "Value": "AIN22032-B2-1"
        ///                                   }
        ///                                },
        ///                                "SalesOrderReference": {
        ///                                   "ID": {
        ///                                      "Value": "339"
        ///                                   },
        ///                                   "ItemID": "10"
        ///                                },
        ///                                "EmployeeID": {
        ///                                   "Value": "E999916"
        ///                                }
        ///                             }
        ///                          ]
        ///                       },
        ///                       "PurchaseOrderReference": {
        ///                          "ActionCode": 0,
        ///                          "ActionCodeSpecified": true,
        ///                          "BusinessTransactionDocumentReference": {
        ///                             "ID": {
        ///                                "Value": "2888"
        ///                             },
        ///                             "TypeCode": {
        ///                                "Value": "001"
        ///                             },
        ///                             "ItemID": "1",
        ///                             "ItemTypeCode": "18"
        ///                          }
        ///                       }
        ///                    }
        ///                 ]
        ///              }
        ///           ]
        ///        },
        ///        "User": "Tina"
        ///     }
        /// </remarks>
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
