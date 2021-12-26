namespace PortFolio.Application.Common.Models;

public interface IAssetOwned
{
    public int AssetId { get; set; }
    public string AssetName { get; set; }
    public decimal Value { get; set; }
}