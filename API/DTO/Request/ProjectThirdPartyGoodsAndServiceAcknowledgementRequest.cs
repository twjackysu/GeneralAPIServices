using ManageGoodsAndServiceAcknowledgementInboundNS;

namespace API.DTO.Request
{
    public class ProjectThirdPartyGoodsAndServiceAcknowledgementRequest
    {
        public required GSABundleMaintainRequestMessage_sync Payload { get; set; }
        public string? User { get; set; }
    }
}
