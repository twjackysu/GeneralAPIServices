namespace SAP_API.Configuration
{
    public class Settings
    {
        public required HashSet<string> ValidKeys { get; set; }
        public required SAP SAP { get; set; }
    }
    public class ClientCredentials
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
    public class SAP : ClientCredentials
    {
        public required string InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationIn { get; set; }
        public required string InventoryProcessingGoodsAndActivityConfirmationGoodsMovementIn { get; set; }
        public required string ManageGoodsAndServiceAcknowledgementInbound { get; set; }
        public required string ManagePurchaseOrderIn { get; set; }
        public required string ManagePurchaseRequestIn { get; set; }
        public required string ManageSalesOrderIn { get; set; }
        public required string ManageSupplierInvoiceIn { get; set; }
    }
}