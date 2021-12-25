using System.Collections.Generic;
using System.Linq;
using PortFolio.Domain.Entities;

namespace PortFolio.Application.Models;

public class WalletModel
{
    public int WalletId { get; }
    public string WalletName { get; }
    public AssetsModel Assets { get; }
    
    public WalletModel(int walletId, string walletName, AssetsModel assets)
    {
        WalletId = walletId;
        WalletName = walletName;
        Assets = assets;
    }
}

public class AssetsModel
{
    private ICollection<AssetModel> _assets;

    public AssetsModel(IEnumerable<AssetModel> assets)
    {
        _assets = assets?.ToList() ?? new List<AssetModel>();
    }

    /// <summary>
    /// Add Asset
    /// </summary>
    /// <param name="newAsset"></param>
    /// <returns>returns false if assets can't be added. True otherwise</returns>
    public bool AddAsset(AssetModel newAsset)
    {
        return false;
    }

    /// <summary>
    /// Remove Asset
    /// </summary>
    /// <param name="newAsset"></param>
    /// <returns>returns false if assets can't be removed. True otherwise</returns>
    public bool RemoveAsset(AssetModel newAsset)
    {
        return false;
    }
}

public class AssetModel
{
    public int AssetId { get; set; }
    public string AssetName { get; set; }
    public decimal Value { get; set; }
}