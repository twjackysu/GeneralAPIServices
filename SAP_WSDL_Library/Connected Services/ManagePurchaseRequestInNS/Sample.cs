
using ManagePurchaseRequestInNS;

namespace SAP_WSDL_Library.Connected_Services.ManagePurchaseRequestInNS
{
    internal class Sample
    {
        public Sample()
        {
            var GeneralInventoryPurchaseRequestSample = new PurchaseRequestMessageManuallyCreate()
            {
                PurchaseRequestMaintainBundle =
                [
                    new ManuallyPurchaseRequest()
                    {
                        actionCodeSpecified = true,
                        actionCode = ActionCode.Item01,
                        Item =
                        [
                            new PurchaseRequestItemManually()
                            {
                                actionCodeSpecified = true,
                                actionCode = ActionCode.Item01,
                                ItemID = "1",
                                ProductKeyItem = new PurchaseRequestMaintainRequestProductKeyItem(){
                                    ProductTypeCode = "1",
                                    ProductIdentifierTypeCode = "1",
                                    ProductID = new ProductID(){
                                        Value = "PECNMT0012"
                                    }
                                },
                                TypeCode = "18",
                                Quantity = new Quantity(){
                                    Value = 6,
                                    unitCode = "EA"
                                },
                                DeliveryPeriod = new UPPEROPEN_LOCALNORMALISED_DateTimePeriod(){
                                    StartDateTime = new LOCALNORMALISED_DateTime(){
                                        Value = Convert.ToDateTime("2024-04-20T12:00:00.1234567Z"),
                                        timeZoneCode = "UTC+8"
                                    }
                                },
                                ShipToLocationID = new LocationID(){
                                    Value = "AT"
                                },
                                ListUnitPrice = new Price(){
                                    Amount = new Amount(){
                                        Value = 1500,
                                        currencyCode = "TWD"
                                    },
                                    BaseQuantity = new Quantity(){
                                        Value = 1,
                                        unitCode = "EA"
                                    }
                                },
                                CompanyIDParty = new PurchaseRequestMaintainRequestBundleItemParty(){
                                    actionCodeSpecified = true,
                                    actionCode = ActionCode.Item01,
                                    PartyID = new PartyID(){
                                        Value = "AT"
                                    }
                                },
                                RequesterIDParty = new PurchaseRequestMaintainRequestBundleItemParty(){
                                    actionCodeSpecified = true,
                                    actionCode = ActionCode.Item01,
                                    PartyID = new PartyID(){
                                        Value = "E999967"
                                    }
                                },
                                SupplierIDParty = new PurchaseRequestMaintainRequestBundleItemParty(){
                                    actionCodeSpecified = true,
                                    actionCode = ActionCode.Item01,
                                    PartyID = new PartyID(){
                                        Value = "A01038"
                                    }
                                },
                                directMaterialIndicatorSpecified = true,
                                directMaterialIndicator = true,
                                Project_No = "ALICE-TESTAPI",
                                specnote = "產品規格_ALICE"
                            }
                        ],
                        PURCREQUNIT = "AT-CS00",
                    }
                ]
            };
        }
    }
}
