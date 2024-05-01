using ManageSalesOrderInNS;

namespace SAP_WSDL_Library.Connected_Services.ManageSalesOrderInNS
{
    public class Sample
    {
        public static SalesOrderMaintainRequestBundleMessage_sync MaterialSalesOrder = new SalesOrderMaintainRequestBundleMessage_sync()
        {
            SalesOrder = [
                new SalesOrderMaintainRequest()
                {
                    actionCode = ActionCode.Item01,
                    actionCodeSpecified = true,
                    ObjectNodeSenderTechnicalID = "S1",
                    ReleaseAllItemsToExecution = true,
                    ReleaseAllItemsToExecutionSpecified = true,
                    FinishFulfilmentProcessingOfAllItems = true,
                    FinishFulfilmentProcessingOfAllItemsSpecified = true,
                    DataOriginTypeCode = "5",
                    Name = new EXTENDED_Name(){
                        Value = "ACS112162 洲美機電-台大癌醫及質子中心高低壓測試支援",
                        languageCode = "ZF"
                    },
                    SalesUnitParty = new SalesOrderMaintainRequestPartyIDParty(){
                        actionCode = ActionCode.Item04,
                        actionCodeSpecified = true,
                        PartyID = new PartyID(){
                            Value = "CS20"
                        }
                    },
                    BuyerID = new BusinessTransactionDocumentID(){
                        Value = "ACS112162"
                    },
                    AccountParty = new SalesOrderMaintainRequestPartyParty(){
                        actionCode = ActionCode.Item04,
                        actionCodeSpecified = true,
                        PartyID = new PartyID(){
                            Value = "D178"
                        }
                    },
                    EmployeeResponsibleParty = new SalesOrderMaintainRequestPartyIDParty(){
                        PartyID = new PartyID(){
                            Value = "8000000169"
                        }
                    },
                    PricingTerms = new SalesOrderMaintainRequestPricingTerms(){
                        actionCode = ActionCode.Item04,
                        actionCodeSpecified = true,
                        CurrencyCode = "TWD",
                        PriceDateTime = new LOCALNORMALISED_DateTime1(){
                            timeZoneCode = "UTC+8",
                            Value = Convert.ToDateTime("2024-03-30T10:58:00Z")
                        },
                        GrossAmountIndicator = false,
                    },
                    Item = [
                        new SalesOrderMaintainRequestItem(){
                            actionCode = ActionCode.Item04,
                            actionCodeSpecified = true,
                            ID = "10",
                            ProcessingTypeCode = "TAN",
                            ItemProduct = new SalesOrderMaintainRequestItemProduct(){
                                actionCode = ActionCode.Item04,
                                actionCodeSpecified = true,
                                ProductInternalID = new ProductInternalID(){
                                    Value = "BWBBPU0024"
                                },
                            },
                            ItemScheduleLine = [
                                new SalesOrderMaintainRequestItemScheduleLine(){
                                    actionCode = ActionCode.Item04,
                                    actionCodeSpecified = true,
                                    ID = "1",
                                    TypeCode = "1",
                                    Quantity = new Quantity(){
                                        unitCode = "EA",
                                        Value = 1,
                                    }
                                }
                            ],
                            PriceAndTaxCalculationItem = new SalesOrderMaintainRequestPriceAndTaxCalculationItem(){
                                actionCode = ActionCode.Item04,
                                actionCodeSpecified = true,
                                ItemMainPrice = new SalesOrderMaintainRequestPriceAndTaxCalculationItemItemMainPrice(){
                                    actionCode = ActionCode.Item04,
                                    actionCodeSpecified = true,
                                    Rate = new Rate(){
                                        DecimalValue = 17776,
                                        CurrencyCode = "TWD",
                                        BaseDecimalValue = 1,
                                        BaseMeasureUnitCode = "EA"
                                    }
                                }
                            }
                        }
                    ],
                    // SendConfirmationIndicator = true, // read-only field
                    // SendConfirmationIndicatorSpecified = true,
                }
            ],
        };
    }
}
