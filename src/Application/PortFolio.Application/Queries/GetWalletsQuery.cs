using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PortFolio.Application.Common.Interfaces.Repositories;
using PortFolio.Application.Models;
using PortFolio.Domain.Entities;

namespace PortFolio.Application.Queries;

public class GetWalletsQuery : IRequest<ICollection<WalletModel>>
{
}

public class GetWalletsQueryHandler : IRequestHandler<GetWalletsQuery, ICollection<WalletModel>>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IAssetRepository _assetRepository;

    public GetWalletsQueryHandler(IWalletRepository walletRepository, IAssetRepository assetRepository)
    {
        _walletRepository = walletRepository;
        _assetRepository = assetRepository;
    }

    public Task<ICollection<WalletModel>> Handle(GetWalletsQuery request, CancellationToken cancellationToken)
    {
        ICollection<WalletModel> walletsModel = new List<WalletModel>();
        var wallets = _walletRepository.Get(null);
        foreach (var wallet in wallets)
        {
            var walletAssets = _assetRepository.Get(x => x.WalletId == wallet.Id)
                .Select(x => new AssetModel()
                {
                    AssetId = x.Id,
                    Value = x.Value,
                }).ToList();
            walletsModel.Add(new WalletModel(wallet.Id, wallet.Name, new AssetsModel(walletAssets)));
        }
        return Task.FromResult(walletsModel);
    }
}