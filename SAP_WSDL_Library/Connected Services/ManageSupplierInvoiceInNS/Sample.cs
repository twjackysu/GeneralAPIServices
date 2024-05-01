using ManageSupplierInvoiceInNS;

namespace SAP_WSDL_Library.Connected_Services.ManageSupplierInvoiceInNS
{
    public class Sample
    {
        public static SupplierInvoiceBundleMaintainRequestMessage_sync ProjectThirdPartySupplierInvoice = new SupplierInvoiceBundleMaintainRequestMessage_sync()
        {
            SupplierInvoice = [
                 new SupplierInvoiceMaintainRequestBundle()
                {
                     actionCode = ActionCode.Item01,
                     actionCodeSpecified = true,
                     ObjectNodeSenderTechnicalID = "",
                     ChangeStateID = "",
                     BusinessTransactionDocumentTypeCode = new BusinessTransactionDocumentTypeCode(){
                         Value = "004"
                     },
                     MEDIUM_Name = new MEDIUM_Name(){
                         Value = "ALICE_PO#2888"
                     },
                     Date = "2024-04-09",
                     ReceiptDate = "2024-04-10",
                     TransactionDate = "2024-04-10",
                     DocumentItemGrossAmountIndicator = false,
                     GrossAmount = new Amount(){
                         currencyCode = "USD",
                         Value = 42883.12m
                     },
                     TaxAmount = new Amount(){
                         currencyCode = "USD",
                         Value = 0m
                     },
                     Status = new SupplierInvoiceMaintainRequestBundleStatus(){
                         DataEntryProcessingStatusCode = INPROCESSFINISHED_ProcessingStatusCode.Item3,
                         DataEntryProcessingStatusCodeSpecified = true
                     },
                     CustomerInvoiceReference = new SupplierInvoiceMaintainRequestBundleBusinessTransactionDocumentReference(){
                         actionCode = ActionCode.Item01,
                         actionCodeSpecified = true,
                         BusinessTransactionDocumentReference = new BusinessTransactionDocumentReference(){
                             ID = new BusinessTransactionDocumentID(){
                                 Value = "ALICE_IV20240409AAA"
                             },
                             TypeCode = new BusinessTransactionDocumentTypeCode(){
                                 Value = "28"
                             },
                         }
                     },
                     BuyerParty = new SupplierInvoiceMaintainRequestBundleParty(){
                         actionCode = ActionCode.Item01,
                         actionCodeSpecified = true,
                         PartyKey = new PartyKey(){
                             PartyID = new PartyID(){
                                 Value = "AT",
                             },
                             PartyTypeCode = new BusinessObjectTypeCode(){
                                 Value = "200"
                             }
                         }
                     },
                     SellerParty = new SupplierInvoiceMaintainRequestBundleParty(){
                         actionCode = ActionCode.Item01,
                         actionCodeSpecified = true,
                         PartyKey = new PartyKey(){
                             PartyID = new PartyID(){
                                 Value = "147"
                             },
                             PartyTypeCode = new BusinessObjectTypeCode(){
                                 Value = "B02008"
                             }
                         }
                     },
                     CashDiscountTerms = new MaintenanceCashDiscountTerms(){
                         ActionCode = ActionCode.Item01,
                         ActionCodeSpecified = true,
                         Code = new CashDiscountTermsCode(){
                             Value = "Z420"
                         },
                     },
                     ExchangeRate = [
                        new SupplierInvoiceMaintainRequestBundleExchangeRate(){
                            actionCode = ActionCode.Item01,
                            actionCodeSpecified = true,
                            ExchangeRate = new ExchangeRate(){
                                UnitCurrency = "USD",
                                QuotedCurrency = "TWD",
                                Rate = 32,
                            }
                        }
                     ],
                     Item = [
                         new SupplierInvoiceMaintainRequestBundleItem() {
                             actionCode = ActionCode.Item01,
                             actionCodeSpecified = true,
                             ItemID = "01",
                             BusinessTransactionDocumentItemTypeCode = "002",
                             Quantity = new Quantity(){
                                 Value = 73
                             },
                             QuantityTypeCode = new QuantityTypeCode(){
                                 Value = "EA"
                             },
                             NetAmount = new Amount(){
                                 Value = 42883.12m,
                                 currencyCode = "USD"
                             },
                             NetUnitPrice = new Price(){
                                 Amount = new Amount(){
                                     Value = 587.44m,
                                     currencyCode = "USD"
                                 },
                                 BaseQuantity = new Quantity(){
                                     Value = 1
                                 },
                                 BaseQuantityTypeCode = new QuantityTypeCode(){
                                     Value = "EA"
                                 }
                             },
                             Product = new SupplierInvoiceMaintainRequestBundleItemProduct(){
                                 actionCode = ActionCode.Item01,
                                 actionCodeSpecified = true,
                                 CashDiscountDeductibleIndicator = true,
                                 ProductKey = new ProductKey(){
                                     ProductTypeCode = "1",
                                     ProductIdentifierTypeCode = "1",
                                     ProductID = new ProductID(){
                                         Value = "OWKLCL0001"
                                     }
                                 }
                             },
                             AccountingCodingBlockDistribution = new MaintenanceAccountingCodingBlockDistribution(){
                                 ActionCode = ActionCode.Item01,
                                 ActionCodeSpecified = true,
                                 AccountingCodingBlockAssignment = [
                                     new MaintenanceAccountingCodingBlockDistributionAccountingCodingBlockAssignment(){
                                         ActionCode = ActionCode.Item01,
                                         ActionCodeSpecified = true,
                                         AccountingCodingBlockTypeCode = new AccountingCodingBlockTypeCode(){
                                             Value = "PRO"
                                         },
                                         ProjectTaskKey = new MaintenanceAccountingCodingBlockDistributionAccountingCodingBlockAssignmentProjectTaskKey(){
                                             TaskID = new ProjectElementID(){
                                                 Value = "AIN22032-B2-1"
                                             }
                                         },
                                         ProjectReference = new ProjectReference(){
                                             ProjectID = new ProjectID(){
                                                 Value = "AIN22032"
                                             },
                                             ProjectElementID = new ProjectElementID(){
                                                 Value = "AIN22032-B2-1"
                                             }
                                         },
                                         SalesOrderReference = new BusinessTransactionDocumentReference(){
                                             ID = new BusinessTransactionDocumentID(){
                                                 Value = "339"
                                             },
                                             ItemID = "10"
                                         },
                                     }
                                 ],
                             },
                             ProductTax = new SupplierInvoiceMaintainRequestBundleItemProductTax(){
                                 actionCode = ActionCode.Item01,
                                 actionCodeSpecified = true,
                                 ProductTaxationCharacteristicsCode = new ProductTaxationCharacteristicsCode(){
                                     listID = "",
                                     Value = "F28"
                                 }
                             },
                             PurchaseOrderReference = new SupplierInvoiceMaintainRequestBundleItemBusinessTransactionDocumentReference(){
                                 actionCode = ActionCode.Item01,
                                 actionCodeSpecified = true,
                                 BusinessTransactionDocumentReference = new BusinessTransactionDocumentReference(){
                                     ID = new BusinessTransactionDocumentID(){
                                         Value = "2888"
                                     }
                                 }
                             }
                         }
                     ],
                     APnote = "創建者備註_ALICE",
                     PRJ_NAM = "案件編號_ALICE_TEST01",
                     PjName = "案件名稱_ALICE_TEST01",
                     REQUNIT = "MD30"
                }
            ],
        };
    }
}
