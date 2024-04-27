using InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInNS;

namespace SAP_API.DTO.Request
{
    public class InternalLogisticsMaterialMovementRequest
    {
        public required GoodsAndActivityConfirmationGoodsMoveGAC[] payload { get; set; }
    }
}
