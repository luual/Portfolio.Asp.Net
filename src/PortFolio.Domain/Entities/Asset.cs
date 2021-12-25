namespace PortFolio.Domain.Entities
{
    public class Asset
    {
        public int Id { get; set; }
        public string AssetId { get; set; }
        public int WalletId { get; set; }
        public decimal Value { get; set; }
    }
}