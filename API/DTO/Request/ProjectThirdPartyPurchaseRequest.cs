using CreateProjectPurchaseRequestNS;

namespace API.DTO.Request
{
    public class ProjectThirdPartyPurchaseRequest
    {
        public required ZProjectPurchaseRequestAPICreateRequestMessage_sync Payload { get; set; }
        public string? User { get; set; }
    }
}
