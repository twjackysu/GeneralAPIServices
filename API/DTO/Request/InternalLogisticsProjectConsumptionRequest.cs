﻿using InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInNS;

namespace API.DTO.Request
{
    public class InternalLogisticsProjectConsumptionRequest
    {
        public required GoodsAndActivityConfirmationConsumptionConfirmationForProject[] Payload { get; set; }
        public string? User { get; set; }
    }
}
