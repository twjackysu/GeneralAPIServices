using DotnetSdkUtilities.Factory.ResponseFactory;
using InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInNS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SAP_API.Common;
using SAP_API.Configuration;
using SAP_API.DTO.Request;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace SAP_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInController : ControllerBase
    {
        private readonly ILogger<InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInController(ILogger<InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 內部後勤-物料異動
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST /InternalLogisticsMaterialMovement
        ///     {
        ///      "payload": [
        ///        {
        ///          "ExternalID": {
        ///            "Value": "EXT20240401"
        ///          },
        ///          "SiteID": {
        ///            "Value": "AT"
        ///          },
        ///          "TransactionDateTimeSpecified": false,
        ///          "InventoryChangeItemGoodsMovement": [
        ///            {
        ///              "ExternalItemID": "10",
        ///              "MaterialInternalID": {
        ///                "Value": "EPKLEC0034"
        ///              },
        ///              "OwnerPartyInternalID": {
        ///                "Value": "AT"
        ///              },
        ///              "InventoryRestrictedUseIndicator": true,
        ///              "InventoryStockStatusCodeSpecified": false,
        ///              "SourceLogisticsAreaID": "CS01",
        ///              "TargetLogisticsAreaID": "CS02",
        ///              "InventoryItemChangeQuantity": {
        ///                "Quantity": {
        ///                  "unitCode": "EA",
        ///                  "Value": 1
        ///                },
        ///                "QuantityTypeCode": {
        ///                  "Value": "EA"
        ///                }
        ///              }
        ///            }
        ///          ]
        ///        }
        ///      ]
        ///    }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<string>), 200)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> InternalLogisticsMaterialMovement([FromBody] InternalLogisticsMaterialMovementRequest request, [FromHeader(Name = "Guru-BPM-Key")] string _)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.InventoryProcessingGoodsAndActivityConfirmationGoodsMovementIn);

            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new MtomMessageEncodingBindingElement());
            binding.Elements.Add(new HttpsTransportBindingElement
            {
                AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
            });

            var https = new HttpsTransportBindingElement();
            _logger.LogInformation("api: {actionName}, request: {request}", ControllerContext.ActionDescriptor.ActionName, JsonConvert.SerializeObject(request));
            var client = new InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInClient(binding, endpointAddress);
            client.ClientCredentials.UserName.UserName = _setting.CurrentValue.SAP.UserName;
            client.ClientCredentials.UserName.Password = _setting.CurrentValue.SAP.Password;

            //var sampleRequest = new GoodsAndActivityConfirmationGoodsMoveGAC[]
            //{
            //    new GoodsAndActivityConfirmationGoodsMoveGAC()
            //    {
            //        ExternalID = new BusinessTransactionDocumentID()
            //        {
            //            Value = "EXT20240401"
            //        },
            //        SiteID = new LocationID()
            //        {
            //            Value = "AT"
            //        },
            //        TransactionDateTime = DateTime.UtcNow,
            //        InventoryChangeItemGoodsMovement =
            //        [
            //            new InventoryChangeItemGoodsMovement()
            //            {
            //                ExternalItemID = "10",
            //                MaterialInternalID = new ProductInternalID()
            //                {
            //                    Value = "EPKLEC0034"
            //                },
            //                OwnerPartyInternalID = new PartyInternalID()
            //                {
            //                    Value = "AT"
            //                },
            //                InventoryRestrictedUseIndicator = true,
            //                InventoryStockStatusCode = InventoryStockStatusCode.Item1,
            //                SourceLogisticsAreaID = "CS01",
            //                TargetLogisticsAreaID = "CS02",
            //                InventoryItemChangeQuantity = new GoodsAndActivityConfirmationInventoryChangeInventoryChangeItemInventoryItemChangeQuantity()
            //                {
            //                    Quantity = new Quantity()
            //                    {
            //                        unitCode = "EA",
            //                        Value = 1
            //                    },
            //                    QuantityTypeCode = new QuantityTypeCode()
            //                    {
            //                        Value = "EA"
            //                    }
            //                }
            //            }
            //        ]
            //    }
            //};
            var response = await client.DoGoodsMovementGoodsAndActivityConfirmationAsync(request.payload);
            _logger.LogInformation("api: {actionName}, response: {response}", ControllerContext.ActionDescriptor.ActionName, JsonConvert.SerializeObject(response));

            if(response.GoodsAndActivityConfoirmationGoodsMovementResponse?.GACDetails == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.GoodsAndActivityConfoirmationGoodsMovementResponse?.Log));
            }

            return _myResponseFactory.CreateOKResponse(response);
        }
    }
}
