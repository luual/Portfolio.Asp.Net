namespace PortFolio.Domain.Entities
{
    public class StockWallet
    {
        public int Id { get; set; }
        public int StockValueId { get; set; }
        public int WalletId { get; set; }
        public decimal Value { get; set; }
    }
}