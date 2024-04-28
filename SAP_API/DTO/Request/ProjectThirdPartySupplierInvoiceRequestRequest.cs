using ManagePurchaseRequestInNS;

namespace SAP_API.DTO.Request
{
    public class ProjectThirdPartySupplierInvoiceRequestRequest
    {
        public required PurchaseRequestMessageManuallyCreate Payload { get; set; }
        public string? User { get; set; }
    }
}
