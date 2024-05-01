using DotnetSdkUtilities.Factory.ResponseFactory;
using ManagePurchaseOrderInNS;
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
    public class ManagePurchaseOrderInController : ControllerBase
    {
        private readonly ILogger<ManagePurchaseOrderInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public ManagePurchaseOrderInController(ILogger<ManagePurchaseOrderInController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 採購單-專案第三方
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/ManagePurchaseOrderIn/ProjectThirdPartyPurchaseOrder
        ///     {
        ///        "Payload": {
        ///           "PurchaseOrderMaintainBundle": [
        ///              {
        ///                 "actionCode": 0,
        ///                 "actionCodeSpecified": true,
        ///                 "ItemListCompleteTransmissionIndicator": true,
        ///                 "ItemListCompleteTransmissionIndicatorSpecified": true,
        ///                 "ObjectNodeSenderTechnicalID": "1",
        ///                 "BusinessTransactionDocumentTypeCode": {
        ///                    "Value": "001"
        ///                 },
        ///                 "CurrencyCode": "TWD",
        ///                 "BuyerParty": {
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true,
        ///                    "ObjectNodePartyTechnicalID": "2",
        ///                    "PartyKey": {
        ///                       "PartyID": {
        ///                          "Value": "AT"
        ///                       }
        ///                    }
        ///                 },
        ///                 "SellerParty": {
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true,
        ///                    "ObjectNodePartyTechnicalID": "3",
        ///                    "PartyKey": {
        ///                       "PartyID": {
        ///                          "Value": "B02009"
        ///                       }
        ///                    }
        ///                 },
        ///                 "EmployeeResponsibleParty": {
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true,
        ///                    "ObjectNodePartyTechnicalID": "4",
        ///                    "PartyKey": {
        ///                       "PartyID": {
        ///                          "Value": "E999914"
        ///                       }
        ///                    }
        ///                 },
        ///                 "ResponsiblePurchasingUnitParty": {
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true,
        ///                    "ObjectNodePartyTechnicalID": "5",
        ///                    "PartyKey": {
        ///                       "PartyID": {
        ///                          "Value": "MD30"
        ///                       }
        ///                    }
        ///                 },
        ///                 "Item": [
        ///                    {
        ///                       "actionCode": 0,
        ///                       "actionCodeSpecified": true,
        ///                       "ObjectNodeSenderTechnicalID": "6",
        ///                       "ItemID": "1",
        ///                       "BusinessTransactionDocumentItemTypeCode": "18",
        ///                       "Quantity": {
        ///                          "unitCode": "EA",
        ///                          "Value": 1
        ///                       },
        ///                       "Description": {
        ///                          "languageCode": "ZF",
        ///                          "Value": "保護電驛/SEL-700G"
        ///                       },
        ///                       "NetUnitPrice": {
        ///                          "Amount": {
        ///                             "currencyCode": "TWD",
        ///                             "Value": 65000
        ///                          },
        ///                          "BaseQuantity": {
        ///                             "unitCode": "EA",
        ///                             "Value": 1
        ///                          },
        ///                          "BaseQuantityTypeCode": {
        ///                             "Value": "EA"
        ///                          }
        ///                       },
        ///                       "GrossUnitPrice": {
        ///                          "Amount": {
        ///                             "currencyCode": "TWD",
        ///                             "Value": 68250
        ///                          },
        ///                          "BaseQuantity": {
        ///                             "unitCode": "EA",
        ///                             "Value": 1
        ///                          },
        ///                          "BaseQuantityTypeCode": {
        ///                             "Value": "EA"
        ///                          }
        ///                       },
        ///                       "ListUnitPrice": {
        ///                          "Amount": {
        ///                             "currencyCode": "TWD",
        ///                             "Value": 65000
        ///                          },
        ///                          "BaseQuantity": {
        ///                             "unitCode": "EA",
        ///                             "Value": 1
        ///                          },
        ///                          "BaseQuantityTypeCode": {
        ///                             "Value": "EA"
        ///                          }
        ///                       },
        ///                       "DeliveryPeriod": {
        ///                          "StartDateTime": {
        ///                             "timeZoneCode": "UTC+8",
        ///                             "Value": "2024-04-10T18:00:00+08:00"
        ///                          },
        ///                          "EndDateTime": {
        ///                             "timeZoneCode": "UTC+8",
        ///                             "Value": "2024-04-16T01:00:00+08:00"
        ///                          }
        ///                       },
        ///                       "ThirdPartyDealIndicator": true,
        ///                       "ThirdPartyDealIndicatorSpecified": true,
        ///                       "FollowUpPurchaseOrderConfirmation": {
        ///                          "RequirementCode": 4,
        ///                          "RequirementCodeSpecified": true
        ///                       },
        ///                       "FollowUpDelivery": {
        ///                          "RequirementCode": 2,
        ///                          "RequirementCodeSpecified": true
        ///                       },
        ///                       "FollowUpInvoice": {
        ///                          "RequirementCode": 2,
        ///                          "RequirementCodeSpecified": true
        ///                       },
        ///                       "ItemProduct": {
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true,
        ///                          "CashDiscountDeductibleIndicator": false,
        ///                          "ProductKey": {
        ///                             "ProductTypeCode": "1",
        ///                             "ProductIdentifierTypeCode": "1",
        ///                             "ProductID": {
        ///                                "Value": "PECNPR0001"
        ///                             }
        ///                          }
        ///                       },
        ///                       "ItemTaxCalculation": {
        ///                          "ObjectNodeSenderTechnicalID": "1",
        ///                          "CountryCode": "TW",
        ///                          "TaxationCharacteristicsCode": {
        ///                             "listID": "TW",
        ///                             "Value": "P21"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
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
        ///                                   "Value": "PRD"
        ///                                },
        ///                                "ProjectTaskKey": {
        ///                                   "TaskID": {
        ///                                      "Value": "AIN23013-E5"
        ///                                   }
        ///                                },
        ///                                "SalesOrderReference": {
        ///                                   "ID": {
        ///                                      "Value": "1601"
        ///                                   },
        ///                                   "ItemID": "10"
        ///                                },
        ///                                "SalesOrderName": {
        ///                                   "languageCode": "ZF",
        ///                                   "Value": "AIN23013"
        ///                                },
        ///                                "SalesOrderItemDescription": {
        ///                                   "languageCode": "ZF",
        ///                                   "Value": "TSMC F18P7 S2工程"
        ///                                }
        ///                             }
        ///                          ]
        ///                       }
        ///                    }
        ///                 ],
        ///                 "PRJ_NAM": "AIN23013-E5 - SEL保護電驛_test",
        ///                 "PjName": "AIN23013_test"
        ///              }
        ///           ]
        ///        },
        ///        "User": "Tony"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<PurchaseOrderMaintainConfirmationBundle[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> ProjectThirdPartyPurchaseOrder([FromBody] ProjectThirdPartyPurchaseOrderRequest request, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.ManagePurchaseOrderIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new ManagePurchaseOrderInClient(binding, endpointAddress);
            client.ClientCredentials.UserName.UserName = _setting.CurrentValue.SAP.ClientCredentials.UserName;
            client.ClientCredentials.UserName.Password = _setting.CurrentValue.SAP.ClientCredentials.Password;
            var response = await client.ManagePurchaseOrderInMaintainBundleAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.PurchaseOrderBundleMaintainConfirmation_sync?.PurchaseOrder == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.PurchaseOrderBundleMaintainConfirmation_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.PurchaseOrderBundleMaintainConfirmation_sync.PurchaseOrder);
            }
        }
    }
}
