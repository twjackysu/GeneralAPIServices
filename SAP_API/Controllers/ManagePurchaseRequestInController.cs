using DotnetSdkUtilities.Factory.ResponseFactory;
using ManagePurchaseRequestInNS;
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
    public class ManagePurchaseRequestInController : ControllerBase
    {
        private readonly ILogger<ManagePurchaseRequestInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public ManagePurchaseRequestInController(ILogger<ManagePurchaseRequestInController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 採購請求-專案第三方
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/ManagePurchaseRequestIn/ProjectThirdPartyPurchaseRequest
        ///     {
        ///        "Payload": {
        ///           "PurchaseRequestMaintainBundle": [
        ///              {
        ///                 "Item": [
        ///                    {
        ///                       "ItemID": "1",
        ///                       "ProductKeyItem": {
        ///                          "ProductTypeCode": "1",
        ///                          "ProductIdentifierTypeCode": "1",
        ///                          "ProductID": {
        ///                             "Value": "PECNPR0001"
        ///                          }
        ///                       },
        ///                       "TypeCode": "18",
        ///                       "Quantity": {
        ///                          "unitCode": "EA",
        ///                          "Value": 12
        ///                       },
        ///                       "DeliveryPeriod": {
        ///                          "StartDateTime": {
        ///                             "timeZoneCode": "UTC+8",
        ///                             "Value": "2024-04-01T20:00:00.1234567+08:00"
        ///                          },
        ///                          "EndDateTime": {
        ///                             "timeZoneCode": "UTC+8",
        ///                             "Value": "2024-04-10T20:00:00.1234567+08:00"
        ///                          }
        ///                       },
        ///                       "ListUnitPrice": {
        ///                          "Amount": {
        ///                             "currencyCode": "TWD",
        ///                             "Value": 51000
        ///                          },
        ///                          "BaseQuantity": {
        ///                             "unitCode": "EA",
        ///                             "Value": 1
        ///                          }
        ///                       },
        ///                       "CompanyIDParty": {
        ///                          "PartyID": {
        ///                             "Value": "AT"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "RequesterIDParty": {
        ///                          "PartyID": {
        ///                             "Value": "E210902"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "SupplierIDParty": {
        ///                          "PartyID": {
        ///                             "Value": "B02009"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "ItemAccountAssignmentDistribution": {
        ///                          "AccountingCodingBlockAssignment": [
        ///                             {
        ///                                "AccountingCodingBlockTypeCode": {
        ///                                   "Value": "PRO"
        ///                                },
        ///                                "ProjectTaskKey": {
        ///                                   "TaskID": {
        ///                                      "Value": "AIN23013-E5"
        ///                                   }
        ///                                },
        ///                                "ProjectReference": {
        ///                                   "ProjectID": {
        ///                                      "Value": "AIN23013"
        ///                                   },
        ///                                   "ProjectElementID": {
        ///                                      "Value": "AIN23013-E5"
        ///                                   }
        ///                                },
        ///                                "ActionCode": 0,
        ///                                "ActionCodeSpecified": true
        ///                             }
        ///                          ],
        ///                          "AccountingCodingBlockAssignmentListCompleteTransmissionIndicator": true,
        ///                          "AccountingCodingBlockAssignmentListCompleteTransmissionIndicatorSpecified": true,
        ///                          "ActionCode": 0,
        ///                          "ActionCodeSpecified": true
        ///                       },
        ///                       "thirdPartyIndicator": true,
        ///                       "thirdPartyIndicatorSpecified": true,
        ///                       "actionCode": 0,
        ///                       "actionCodeSpecified": true
        ///                    }
        ///                 ],
        ///                 "AttachmentFolder": {
        ///                    "Document": [
        ///                       {
        ///                          "VisibleIndicator": true,
        ///                          "VisibleIndicatorSpecified": true,
        ///                          "CategoryCode": "3",
        ///                          "Name": "BPM_測試_請購003",
        ///                          "Description": {
        ///                             "languageCode": "ZF",
        ///                             "Value": "BPM串接_附件測試_003"
        ///                          },
        ///                          "ExternalLinkWebURI": "https://soetw-my.sharepoint.com/:x:/g/personal/alicefang_soetek_com_tw/Ecp2LhispUpAjzb7_Ytpok0BbW9GkslJ6Qm0L1krWUzcGQ?e=AgjfJq",
        ///                          "ActionCode": 0,
        ///                          "ActionCodeSpecified": true
        ///                       }
        ///                    ],
        ///                    "ActionCode": 0,
        ///                    "ActionCodeSpecified": true
        ///                 },
        ///                 "TextCollection": {
        ///                    "Text": [
        ///                       {
        ///                          "TypeCode": {
        ///                             "Value": "10011"
        ///                          },
        ///                          "LanguageCode": "ZF",
        ///                          "TextContent": {
        ///                             "Text": {
        ///                                "languageCode": "ZF",
        ///                                "Value": "BPM串接_測試_專案請購_003"
        ///                             },
        ///                             "ActionCode": 0,
        ///                             "ActionCodeSpecified": true
        ///                          },
        ///                          "ActionCode": 0,
        ///                          "ActionCodeSpecified": true
        ///                       }
        ///                    ],
        ///                    "ActionCode": 0,
        ///                    "ActionCodeSpecified": true
        ///                 },
        ///                 "actionCode": 0,
        ///                 "actionCodeSpecified": true
        ///              }
        ///           ]
        ///        },
        ///        "User": "Peter"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<ManuallyPurchaseRequestResponse[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> ProjectThirdPartyPurchaseRequest([FromBody] ProjectThirdPartyPurchaseRequest request, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.ManagePurchaseRequestIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new ManagePurchaseRequestInClient(binding, endpointAddress);
            client.ClientCredentials.UserName.UserName = _setting.CurrentValue.SAP.ClientCredentials.UserName;
            client.ClientCredentials.UserName.Password = _setting.CurrentValue.SAP.ClientCredentials.Password;

            var response = await client.MaintainBundleAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.PurchaseRequestMaintainBundleConfirmation?.PurchaseRequestResponse1 == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.PurchaseRequestMaintainBundleConfirmation?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.PurchaseRequestMaintainBundleConfirmation.PurchaseRequestResponse1);
            }
        }
        /// <summary>
        /// 採購請求-一般庫存請購
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/ManagePurchaseRequestIn/GeneralInventoryPurchaseRequest
        ///     {
        ///        "Payload": {
        ///           "PurchaseRequestMaintainBundle": [
        ///              {
        ///                 "Item": [
        ///                    {
        ///                       "ItemID": "1",
        ///                       "ProductKeyItem": {
        ///                          "ProductTypeCode": "1",
        ///                          "ProductIdentifierTypeCode": "1",
        ///                          "ProductID": {
        ///                             "Value": "PECNMT0012"
        ///                          }
        ///                       },
        ///                       "TypeCode": "18",
        ///                       "Quantity": {
        ///                          "unitCode": "EA",
        ///                          "Value": 6
        ///                       },
        ///                       "DeliveryPeriod": {
        ///                          "StartDateTime": {
        ///                             "timeZoneCode": "UTC+8",
        ///                             "Value": "2024-04-20T20:00:00.1234567+08:00"
        ///                          }
        ///                       },
        ///                       "ShipToLocationID": {
        ///                          "Value": "AT"
        ///                       },
        ///                       "ListUnitPrice": {
        ///                          "Amount": {
        ///                             "currencyCode": "TWD",
        ///                             "Value": 1500
        ///                          },
        ///                          "BaseQuantity": {
        ///                             "unitCode": "EA",
        ///                             "Value": 1
        ///                          }
        ///                       },
        ///                       "CompanyIDParty": {
        ///                          "PartyID": {
        ///                             "Value": "AT"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "RequesterIDParty": {
        ///                          "PartyID": {
        ///                             "Value": "E999967"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "SupplierIDParty": {
        ///                          "PartyID": {
        ///                             "Value": "A01038"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "directMaterialIndicator": true,
        ///                       "directMaterialIndicatorSpecified": true,
        ///                       "Project_No": "ALICE-TESTAPI",
        ///                       "specnote": "產品規格_ALICE",
        ///                       "actionCode": 0,
        ///                       "actionCodeSpecified": true
        ///                    }
        ///                 ],
        ///                 "PURCREQUNIT": "AT-CS00",
        ///                 "actionCode": 0,
        ///                 "actionCodeSpecified": true
        ///              }
        ///           ]
        ///        },
        ///        "User": "Jacky"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<ManuallyPurchaseRequestResponse[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> GeneralInventoryPurchaseRequest([FromBody] GeneralInventoryPurchaseRequestRequest request, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.ManagePurchaseRequestIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new ManagePurchaseRequestInClient(binding, endpointAddress);
            client.ClientCredentials.UserName.UserName = _setting.CurrentValue.SAP.ClientCredentials.UserName;
            client.ClientCredentials.UserName.Password = _setting.CurrentValue.SAP.ClientCredentials.Password;

            var response = await client.MaintainBundleAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.PurchaseRequestMaintainBundleConfirmation?.PurchaseRequestResponse1 == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.PurchaseRequestMaintainBundleConfirmation?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.PurchaseRequestMaintainBundleConfirmation.PurchaseRequestResponse1);
            }
        }
    }
}
