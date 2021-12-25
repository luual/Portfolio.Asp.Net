using System.Collections;
using PortFolio.Domain.Entities;

namespace PortFolio.Application.Common.Interfaces.Repositories;

public interface IAssetPairsRepository : IRepository<AssetPairs>
{
}

public interface IWalletRepository : IRepository<Wallet>
{
}

public interface IAssetRepository : IRepository<Asset>
{
    
}

