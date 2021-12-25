namespace PortFolio.Domain.Entities
{
    public class AssetPairs
    {
        public int Id { get; set; }
        public string Asset1 { get; set; }
        public string Asset2 { get; set; }
        public decimal Value { get; set; }
    }
}