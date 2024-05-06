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
        ///     {
        ///        "Payload": {
        ///           "SupplierInvoice": [
        ///              {
        ///                 "actionCode": 0,
        ///                 "actionCodeSpecified": true,
        ///                 "ObjectNodeSenderTechnicalID": "",
        ///                 "ChangeStateID": "",
        ///                 "BusinessTransactionDocumentTypeCode": {
        ///                    "Value": "004"
        ///                 },
        ///                 "MEDIUM_Name": {
        ///                    "Value": "ALICE_PO#2888"
        ///                 },
        ///                 "Date": "2024-04-09",
        ///                 "ReceiptDate": "2024-04-10",
        ///                 "TransactionDate": "2024-04-10",
        ///                 "DocumentItemGrossAmountIndicator": false,
        ///                 "GrossAmount": {
        ///                    "currencyCode": "USD",
        ///                    "Value": 42883.12
        ///                 },
        ///                 "TaxAmount": {
        ///                    "currencyCode": "USD",
        ///                    "Value": 0
        ///                 },
        ///                 "Status": {
        ///                    "DataEntryProcessingStatusCode": 1,
        ///                    "DataEntryProcessingStatusCodeSpecified": true
        ///                 },
        ///                 "CustomerInvoiceReference": {
        ///                    "BusinessTransactionDocumentReference": {
        ///                       "ID": {
        ///                          "Value": "ALICE_IV20240409AAA"
        ///                       },
        ///                       "TypeCode": {
        ///                          "Value": "28"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "BuyerParty": {
        ///                    "PartyKey": {
        ///                       "PartyTypeCode": {
        ///                          "Value": "200"
        ///                       },
        ///                       "PartyID": {
        ///                          "Value": "AT"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "SellerParty": {
        ///                    "PartyKey": {
        ///                       "PartyTypeCode": {
        ///                          "Value": "B02008"
        ///                       },
        ///                       "PartyID": {
        ///                          "Value": "147"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "CashDiscountTerms": {
        ///                    "Code": {
        ///                       "Value": "Z420"
        ///                    },
        ///                    "ActionCode": 0,
        ///                    "ActionCodeSpecified": true
        ///                 },
        ///                 "ExchangeRate": [
        ///                    {
        ///                       "ExchangeRate": {
        ///                          "UnitCurrency": "USD",
        ///                          "QuotedCurrency": "TWD",
        ///                          "Rate": 32
        ///                       },
        ///                       "actionCode": 0,
        ///                       "actionCodeSpecified": true
        ///                    }
        ///                 ],
        ///                 "Item": [
        ///                    {
        ///                       "ItemID": "01",
        ///                       "BusinessTransactionDocumentItemTypeCode": "002",
        ///                       "Quantity": {
        ///                          "Value": 73
        ///                       },
        ///                       "QuantityTypeCode": {
        ///                          "Value": "EA"
        ///                       },
        ///                       "NetAmount": {
        ///                          "currencyCode": "USD",
        ///                          "Value": 42883.12
        ///                       },
        ///                       "NetUnitPrice": {
        ///                          "Amount": {
        ///                             "currencyCode": "USD",
        ///                             "Value": 587.44
        ///                          },
        ///                          "BaseQuantity": {
        ///                             "Value": 1
        ///                          },
        ///                          "BaseQuantityTypeCode": {
        ///                             "Value": "EA"
        ///                          }
        ///                       },
        ///                       "Product": {
        ///                          "CashDiscountDeductibleIndicator": true,
        ///                          "ProductKey": {
        ///                             "ProductTypeCode": "1",
        ///                             "ProductIdentifierTypeCode": "1",
        ///                             "ProductID": {
        ///                                "Value": "OWKLCL0001"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "AccountingCodingBlockDistribution": {
        ///                          "AccountingCodingBlockAssignment": [
        ///                             {
        ///                                "AccountingCodingBlockTypeCode": {
        ///                                   "Value": "PRO"
        ///                                },
        ///                                "ProjectTaskKey": {
        ///                                   "TaskID": {
        ///                                      "Value": "AIN22032-B2-1"
        ///                                   }
        ///                                },
        ///                                "ProjectReference": {
        ///                                   "ProjectID": {
        ///                                      "Value": "AIN22032"
        ///                                   },
        ///                                   "ProjectElementID": {
        ///                                      "Value": "AIN22032-B2-1"
        ///                                   }
        ///                                },
        ///                                "SalesOrderReference": {
        ///                                   "ID": {
        ///                                      "Value": "339"
        ///                                   },
        ///                                   "ItemID": "10"
        ///                                },
        ///                                "ActionCode": 0,
        ///                                "ActionCodeSpecified": true
        ///                             }
        ///                          ],
        ///                          "ActionCode": 0,
        ///                          "ActionCodeSpecified": true
        ///                       },
        ///                       "ProductTax": {
        ///                          "ProductTaxationCharacteristicsCode": {
        ///                             "listID": "",
        ///                             "Value": "F28"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "PurchaseOrderReference": {
        ///                          "BusinessTransactionDocumentReference": {
        ///                             "ID": {
        ///                                "Value": "2888"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "actionCode": 0,
        ///                       "actionCodeSpecified": true
        ///                    }
        ///                 ],
        ///                 "APnote": "創建者備註_ALICE",
        ///                 "PRJ_NAM": "案件編號_ALICE_TEST01",
        ///                 "PjName": "案件名稱_ALICE_TEST01",
        ///                 "REQUNIT": "MD30"
        ///              }
        ///           ]
        ///        },
        ///        "User": "string"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<SupplierInvoiceMaintainConfirmationBundle[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> ProjectThirdPartySupplierInvoice([FromBody] ProjectThirdPartySupplierInvoiceRequestRequest request, [FromHeader(Name = "SAP-API-Key")] string _)
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
