using InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInNS;

namespace SAP_WSDL_Library.Connected_Services.InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInNS
{
    public class Sample
    {
        public static GoodsAndActivityConfirmationGoodsMoveGAC[] InternalLogisticsMaterialMovement = [
            new GoodsAndActivityConfirmationGoodsMoveGAC()
            {
                ExternalID = new BusinessTransactionDocumentID(){
                    Value = "EXT20240401"
                },
                SiteID = new LocationID(){
                    Value = "AT",
                },
                TransactionDateTime = Convert.ToDateTime("2024-04-01T06:35:19.457648Z"),
                TransactionDateTimeSpecified = true,
                InventoryChangeItemGoodsMovement = new InventoryChangeItemGoodsMovement[]{
                    new InventoryChangeItemGoodsMovement(){
                        ExternalItemID = "10",
                        MaterialInternalID = new ProductInternalID(){
                            Value = "EPKLEC0034"
                        },
                        OwnerPartyInternalID = new PartyInternalID(){
                            Value = "AT"
                        },
                        InventoryRestrictedUseIndicator = false,
                        InventoryStockStatusCode = InventoryStockStatusCode.Item1,
                        SourceLogisticsAreaID = "CS01",
                        TargetLogisticsAreaID = "CS02",
                        InventoryItemChangeQuantity = new GoodsAndActivityConfirmationInventoryChangeInventoryChangeItemInventoryItemChangeQuantity(){
                            Quantity = new Quantity(){
                                unitCode = "EA",
                                Value = 1
                            },
                            QuantityTypeCode = new QuantityTypeCode(){
                                Value = "EA"
                            }
                        }
                    }
                },
            }
        ];
    }
}
