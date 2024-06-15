using CreateProjectNS;

namespace API.DTO.Request
{
    public class ProjectRequest
    {
        public required ZMaintainProjectAPICreateRequestMessage_sync Payload { get; set; }
        public string? User { get; set; }
    }
}
