using ManagePurchaseRequestInNS;

namespace SAP_API.DTO.Request
{
    public class ProjectThirdPartyPurchaseRequest
    {
        public required PurchaseRequestMessageManuallyCreate Payload { get; set; }
        public string? User { get; set; }
    }
}
