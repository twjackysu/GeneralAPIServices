using ManagePurchaseOrderInNS;
using System.Reflection.Metadata;
using System.Xml.Linq;

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
                    OrderPurchaseOrderActionIndicator = true,
                    OrderPurchaseOrderActionIndicatorSpecified = true,
                    FinishDeliveryPOActionIndicator = false,
                    FinishDeliveryPOActionIndicatorSpecified = true,
                    FinishInvoicePOActionIndicator = false,
                    FinishInvoicePOActionIndicatorSpecified = true,
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
                                Value = "E999916"
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
                    AttachmentFolder = new MaintenanceAttachmentFolder(){
                        ActionCode = ActionCode.Item01,
                        ActionCodeSpecified = true,
                        Document = [
                            new MaintenanceAttachmentFolderDocument(){
                                ActionCode = ActionCode.Item01,
                                ActionCodeSpecified = true,
                                VisibleIndicator = true,
                                VisibleIndicatorSpecified = true,
                                CategoryCode = "3",
                                TypeCode = new DocumentTypeCode(){
                                    Value = "10001"
                                },
                                Name = "BPM串接_NAME_240502",
                                AlternativeName = "BPM串接表頭附件_Document Title文件標題_240502",
                                Description = new Description(){
                                    languageCode = "ZF",
                                    Value = "BPM串接表頭附件_comment留言_240502",
                                },
                                ExternalLinkWebURI = "",
                            }
                        ]
                    },
                    TextCollection = new MaintenanceTextCollection(){
                        ActionCode = ActionCode.Item01,
                        ActionCodeSpecified = true,
                        Text = [
                            new MaintenanceTextCollectionText(){
                                ActionCode = ActionCode.Item01,
                                ActionCodeSpecified = true,
                                TypeCode = new TextCollectionTextTypeCode(){
                                    Value = "10011"
                                },
                                LanguageCode = "ZF",
                                TextContent = new MaintenanceTextCollectionTextTextContent(){
                                    ActionCode = ActionCode.Item01,
                                    ActionCodeSpecified = true,
                                    Text = new Text(){
                                        languageCode = "ZF",
                                        Value = "BPM串接表頭註記_描述明細_240502",
                                    }
                                }
                            }
                        ]
                    },
                    DeliveryTerms = new PurchaseOrderMaintainRequestBundleDeliveryTerms(){
                        ActionCode = ActionCode.Item01,
                        ActionCodeSpecified = true,
                        IncoTerms = new Incoterms(){
                            ClassificationCode = "EXW",
                            TransferLocationName = "TW"
                        }
                    },
                    CashDiscountTerms = new PurchaseOrderMaintenanceCashDiscountTerms(){
                        ActionCode = ActionCode.Item01,
                        ActionCodeSpecified = true,
                        Code = new CashDiscountTermsCode(){
                            Value = "Z460"
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
                                Value = 6
                            },
                            ListUnitPrice = new Price(){
                                Amount = new Amount(){
                                    currencyCode = "TWD",
                                    Value = 51000
                                },
                                BaseQuantity = new Quantity(){
                                    unitCode = "EA",
                                    Value = 1
                                },
                                BaseQuantityTypeCode = new QuantityTypeCode(){
                                    Value = "EA"
                                }
                            },
                            ThirdPartyDealIndicatorSpecified = true,
                            ThirdPartyDealIndicator = true,
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
                                        Value = "PECNPR0001"
                                    }
                                }
                            },
                            PurchaserequestSAP = "2144",
                            DeliveryPeriod = new UPPEROPEN_LOCALNORMALISED_DateTimePeriod(){
                                StartDateTime = new LOCALNORMALISED_DateTime(){
                                    timeZoneCode = "UTC+8",
                                    Value = Convert.ToDateTime("2024-05-10T10:00:00Z"),
                                },
                            },
                            ShipToLocation = new PurchaseOrderMaintainRequestBundleItemLocation(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                ObjectNodePartyTechnicalID = "7",
                                LocationID = new LocationID(){
                                    Value = "AT"
                                }
                            },
                            ProductRecipientParty = new PurchaseOrderMaintainRequestBundleItemParty(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                ObjectNodePartyTechnicalID = "8",
                                PartyKey = new PartyKey(){
                                    PartyTypeCode = new BusinessObjectTypeCode(){
                                        Value = "147"
                                    },
                                    PartyID = new PartyID(){
                                        Value = "E210802"
                                    }
                                }
                            },
                            RequestorParty = new PurchaseOrderMaintainRequestBundleItemParty(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                ObjectNodePartyTechnicalID = "9",
                                PartyKey = new PartyKey(){
                                    PartyTypeCode = new BusinessObjectTypeCode(){
                                        Value = "147"
                                    },
                                    PartyID = new PartyID(){
                                        Value = "E210902"
                                    }
                                }
                            },
                            EndBuyerParty = new PurchaseOrderMaintainRequestBundleItemParty(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                ObjectNodePartyTechnicalID = "10",
                                PartyKey = new PartyKey(){
                                    PartyTypeCode = new BusinessObjectTypeCode(){
                                        Value = "159"
                                    },
                                    PartyID = new PartyID(){
                                        Value = "E001"
                                    }
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
                                            Value = "PRO"
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
                                    }
                                ]
                            },
                            ItemAttachmentFolder = new MaintenanceAttachmentFolder(){
                                ActionCode = ActionCode.Item01,
                                ActionCodeSpecified = true,
                                Document = [
                                    new MaintenanceAttachmentFolderDocument(){
                                        ActionCode = ActionCode.Item01,
                                        ActionCodeSpecified = true,
                                        VisibleIndicator = true,
                                        VisibleIndicatorSpecified = true,
                                        CategoryCode = "3",
                                        TypeCode = new DocumentTypeCode(){
                                            Value = "10001"
                                        },
                                        Name = "BPM串接_表身NAME_2400502",
                                        AlternativeName = "BPM串接表身附件_240502",
                                        Description = new Description(){
                                            languageCode = "ZF",
                                            Value = "BPM串接表身附件_comment留言_240502"
                                        },
                                        ExternalLinkWebURI = ""
                                    },
                                ]
                            },
                            ItemTextCollection = new MaintenanceTextCollection(){
                                ActionCode = ActionCode.Item01,
                                ActionCodeSpecified = true,
                                Text = [
                                    new MaintenanceTextCollectionText(){
                                        ActionCode = ActionCode.Item01,
                                        ActionCodeSpecified = true,
                                        TypeCode = new TextCollectionTextTypeCode(){
                                            Value = "10011",
                                        },
                                        LanguageCode = "ZF",
                                        TextContent = new MaintenanceTextCollectionTextTextContent(){
                                            ActionCode = ActionCode.Item01,
                                            ActionCodeSpecified = true,
                                            Text = new Text(){
                                                languageCode = "ZF",
                                                Value = "BPM串接表身註記_描述明細_240502"
                                            }
                                        },
                                    }
                                ]
                            },
                            ItemTaxCalculation = new PurchaseOrderMaintainRequestTaxCalculationItem(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                CountryCode = "TW",
                                TaxationCharacteristicsCode = new ProductTaxationCharacteristicsCode(){
                                    listID = "TW",
                                    Value = "P21"
                                }
                            },
                        }
                    ],
                    PRJ_NAM = "BPM_POTEST_0502接續商品收貨",
                    PjName = "BPM_POTEST_0502"
                }
            ]
        };
    }
}
