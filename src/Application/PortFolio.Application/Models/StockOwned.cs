using PortFolio.Application.Common.Models;

namespace PortFolio.Application.Models;

public class StockOwned : IAssetOwned
{
    public int AssetId { get; set; }
    public string AssetKey => $"{AssetName}/{Currency}";
    public string Currency { get; set; }
    public string AssetName { get; set; }
    public decimal Value { get; set; }
}