namespace PortFolio.Domain.Entities
{
    public class StockValue
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int CurrencyId { get; set; }
        public decimal ValueInCurrency { get; set; }
    }
}