﻿using ManageSalesOrderInNS;

namespace API.DTO.Request
{
    public class ProjectSalesOrderRequest
    {
        public required SalesOrderMaintainRequestBundleMessage_sync Payload { get; set; }
        public string? User { get; set; }
    }
}
