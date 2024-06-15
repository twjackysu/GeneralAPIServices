using QuerySiteLogisticsTaskInNS;

namespace API.DTO.Request
{
    public class GetWarehouseTaskDetailsRequest
    {
        public required SiteLogisticsTaskByElementsQueryMessage Payload { get; set; }
        public string? User { get; set; }
    }
}
