using System.Collections.Generic;
using System.Linq;
using PortFolio.Application.Common.Models;

namespace PortFolio.Application.Models;

public class AssetsModel
{
    private ICollection<IAssetOwned> _assets;

    public int Count => _assets.Count;
    public StockOwned[] Stocks => _assets.OfType<StockOwned>().ToArray();
    public AssetsModel(IEnumerable<IAssetOwned> assets)
    {
        _assets = assets?.ToList() ?? new List<IAssetOwned>();
    }

    /// <summary>
    /// Add StockWallet
    /// </summary>
    /// <param name="newAsset"></param>
    /// <returns>returns false if assets can't be added. True otherwise</returns>
    public bool AddAsset(IAssetOwned newAsset)
    {
        return false;
    }

    /// <summary>
    /// Remove StockWallet
    /// </summary>
    /// <param name="newAsset"></param>
    /// <returns>returns false if assets can't be removed. True otherwise</returns>
    public bool RemoveAsset(IAssetOwned newAsset)
    {
        return false;
    }

}