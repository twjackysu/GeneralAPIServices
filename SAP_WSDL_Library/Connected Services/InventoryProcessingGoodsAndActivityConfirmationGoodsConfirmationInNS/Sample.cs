using InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInNS;

namespace SAP_WSDL_Library.Connected_Services.InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInNS
{
    public class Sample
    {
        public static GoodsAndActivityConfirmationConsumptionConfirmationForProject[] InternalLogisticsProjectConsumption = [
            new GoodsAndActivityConfirmationConsumptionConfirmationForProject(){
                ExternalID = new BusinessTransactionDocumentID(){
                    Value = "PJ001"
                },
                SiteID = new LocationID(){
                    Value = "AT"
                },
                TransactionDateTime = Convert.ToDateTime("2024-04-01T06:35:19.457648Z"),
                TransactionDateTimeSpecified = true,
                InventoryMovementDirectionCode = "1",
                ProjectTaskKey = new ProjectTaskKey(){
                    TaskID = new ProjectElementID(){
                        Value = "AIN21051-Z12"
                    }
                },
                InventoryChangeItemGoodsConsumptionInformationForProject = [
                    new InventoryChangeItemGoodsConsumptionInformationForProject(){
                        ExternalItemID = "PJ001",
                        MaterialInternalID = new ProductInternalID(){
                            Value = "EPKLEC0034"
                        },
                        OwnerPartyInternalID = new PartyInternalID(){
                            Value = "AT"
                        },
                        LogisticsAreaID = "CS02",
                        InventoryItemChangeQuantity = new GoodsAndActivityConfirmationInventoryChangeInventoryChangeItemInventoryItemChangeQuantity(){
                            Quantity = new Quantity(){
                                Value = 1,
                                unitCode = "EA"
                            },
                            QuantityTypeCode = new QuantityTypeCode(){
                                Value = "EA"
                            }
                        },
                        AccountingCodingBlock = new AccountingCodingBlock(){
                            AccountingCodingBlockTypeCode = new AccountingCodingBlockTypeCode(){
                                Value = "PRO"
                            },
                            GeneralLedgerAccountAliasCode = new GeneralLedgerAccountAliasCode(){
                                Value = "false"
                            },
                            ProjectReference = new ProjectReference(){
                                ProjectID = new ProjectID(){
                                    Value = "AIN21051"
                                }
                            },
                        }
                    }
                ],
            },

        ];
    }
}
