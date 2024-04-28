using ManagePurchaseOrderInNS;

namespace SAP_WSDL_Library.Connected_Services.ManagePurchaseOrderInNS
{
    public class Sample
    {
        public static PurchaseOrderBundleMaintainRequestMessage_sync ProjectThirdPartyPurchaseOrder = new PurchaseOrderBundleMaintainRequestMessage_sync
        {
            PurchaseOrderMaintainBundle =
            [
                new PurchaseOrderMaintainRequestBundle()
                {
                    actionCodeSpecified = true,
                    actionCode = ActionCode.Item01,
                    ItemListCompleteTransmissionIndicatorSpecified = true,
                    ItemListCompleteTransmissionIndicator = true,
                    ObjectNodeSenderTechnicalID = "1",
                    BusinessTransactionDocumentTypeCode = new BusinessTransactionDocumentTypeCode(){
                        Value = "001"
                    },
                    CurrencyCode = "TWD",
                    BuyerParty = new PurchaseOrderMaintainRequestBundleParty(){
                        actionCodeSpecified = true,
                        actionCode = ActionCode.Item01,
                        ObjectNodePartyTechnicalID = "2",
                        PartyKey = new PartyKey(){
                            PartyID = new PartyID(){
                                Value = "AT"
                            }
                        }
                    },
                    SellerParty = new PurchaseOrderMaintainRequestBundleParty(){
                        actionCodeSpecified = true,
                        actionCode = ActionCode.Item01,
                        ObjectNodePartyTechnicalID = "3",
                        PartyKey = new PartyKey(){
                            PartyID = new PartyID(){
                                Value = "B02009"
                            }
                        }
                    },
                    EmployeeResponsibleParty = new PurchaseOrderMaintainRequestBundleParty(){
                        actionCodeSpecified = true,
                        actionCode = ActionCode.Item01,
                        ObjectNodePartyTechnicalID = "4",
                        PartyKey = new PartyKey(){
                            PartyID = new PartyID(){
                                Value = "E999914"
                            }
                        }
                    },
                    ResponsiblePurchasingUnitParty = new PurchaseOrderMaintainRequestBundleParty(){
                        actionCodeSpecified = true,
                        actionCode = ActionCode.Item01,
                        ObjectNodePartyTechnicalID = "5",
                        PartyKey = new PartyKey(){
                            PartyID = new PartyID(){
                                Value = "MD30"
                            }
                        }
                    },
                    Item = [
                        new PurchaseOrderMaintainRequestBundleItem(){
                            actionCodeSpecified = true,
                            actionCode = ActionCode.Item01,
                            ObjectNodeSenderTechnicalID = "6",
                            ItemID = "1",
                            BusinessTransactionDocumentItemTypeCode = "18",
                            Quantity = new Quantity(){
                                unitCode = "EA",
                                Value = 1
                            },
                            Description = new SHORT_Description(){
                                languageCode = "ZF",
                                Value = "保護電驛/SEL-700G"
                            },
                            NetUnitPrice = new Price(){
                                Amount = new Amount(){
                                    Value = 65000,
                                    currencyCode = "TWD"
                                },
                                BaseQuantity = new Quantity(){
                                    unitCode = "EA",
                                    Value = 1
                                },
                                BaseQuantityTypeCode = new QuantityTypeCode(){
                                    Value = "EA"
                                }
                            },
                            GrossUnitPrice = new Price(){
                                Amount = new Amount(){
                                    Value = 68250,
                                    currencyCode = "TWD"
                                },
                                BaseQuantity = new Quantity(){
                                    unitCode = "EA",
                                    Value = 1
                                },
                                BaseQuantityTypeCode = new QuantityTypeCode(){
                                    Value = "EA"
                                }
                            },
                            ListUnitPrice = new Price(){
                                Amount = new Amount(){
                                    Value = 65000,
                                    currencyCode = "TWD"
                                },
                                BaseQuantity = new Quantity(){
                                    unitCode = "EA",
                                    Value = 1
                                },
                                BaseQuantityTypeCode = new QuantityTypeCode(){
                                    Value = "EA"
                                }
                            },
                            DeliveryPeriod = new UPPEROPEN_LOCALNORMALISED_DateTimePeriod(){
                                StartDateTime = new LOCALNORMALISED_DateTime(){
                                    timeZoneCode = "UTC+8",
                                    Value = Convert.ToDateTime("2024-04-10T10:00:00Z"),
                                },
                                EndDateTime = new LOCALNORMALISED_DateTime(){
                                    timeZoneCode = "UTC+8",
                                    Value = Convert.ToDateTime("2024-04-15T17:00:00Z"),
                                }
                            },
                            ThirdPartyDealIndicatorSpecified = true,
                            ThirdPartyDealIndicator = true,
                            FollowUpPurchaseOrderConfirmation = new ProcurementDocumentItemFollowUpPurchaseOrderConfirmation(){
                                RequirementCode = FollowUpBusinessTransactionDocumentRequirementCode.Item04,
                                RequirementCodeSpecified = true
                            },
                            FollowUpDelivery = new ProcurementDocumentItemFollowUpDelivery(){
                                RequirementCode = FollowUpBusinessTransactionDocumentRequirementCode.Item01,
                                RequirementCodeSpecified = true
                            },
                            FollowUpInvoice = new ProcurementDocumentItemFollowUpInvoice(){
                                RequirementCode = FollowUpBusinessTransactionDocumentRequirementCode.Item01,
                                RequirementCodeSpecified = true
                            },
                            ItemProduct = new PurchaseOrderMaintainRequestBundleItemProduct(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                CashDiscountDeductibleIndicator = false,
                                ProductKey = new ProductKey(){
                                    ProductTypeCode = "1",
                                    ProductIdentifierTypeCode = "1",
                                    ProductID = new ProductID(){
                                        Value = "PECNPR0001",
                                    }
                                }
                            },
                            ItemTaxCalculation = new PurchaseOrderMaintainRequestTaxCalculationItem(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                ObjectNodeSenderTechnicalID = "1",
                                CountryCode = "TW",
                                TaxationCharacteristicsCode = new ProductTaxationCharacteristicsCode(){
                                    listID = "TW",
                                    Value = "P21"
                                }
                            },
                            ItemAccountingCodingBlockDistribution = new MaintenanceAccountingCodingBlockDistribution(){
                                ActionCode = ActionCode.Item01,
                                ActionCodeSpecified = true,
                                CompanyID = "AT",
                                AccountingCodingBlockAssignment = [
                                    new MaintenanceAccountingCodingBlockDistributionAccountingCodingBlockAssignment(){
                                        ActionCode = ActionCode.Item01,
                                        ActionCodeSpecified = true,
                                        AccountingCodingBlockTypeCode = new AccountingCodingBlockTypeCode(){
                                            Value = "PRD"
                                        },
                                        ProjectTaskKey = new MaintenanceAccountingCodingBlockDistributionAccountingCodingBlockAssignmentProjectTaskKey(){
                                            TaskID = new ProjectElementID(){
                                                Value = "AIN23013-E5"
                                            }
                                        },
                                        SalesOrderReference = new BusinessTransactionDocumentReference(){
                                            ID = new BusinessTransactionDocumentID(){
                                                Value = "1601"
                                            },
                                            ItemID = "10"
                                        },
                                        SalesOrderName = new EXTENDED_Name(){
                                            languageCode = "ZF",
                                            Value = "AIN23013"
                                        },
                                        SalesOrderItemDescription = new SHORT_Description(){
                                            languageCode = "ZF",
                                            Value = "TSMC F18P7 S2工程"
                                        },
                                    }
                                ]
                            }
                        }
                    ],
                    PRJ_NAM = "AIN23013-E5 - SEL保護電驛_test",
                    PjName = "AIN23013_test"
                }
            ]
        };
    }
}
