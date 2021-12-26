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