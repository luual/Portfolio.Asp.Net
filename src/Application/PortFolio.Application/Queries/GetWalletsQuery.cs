using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PortFolio.Application.Common.Interfaces.Repositories;
using PortFolio.Application.Common.Models;
using PortFolio.Application.Models;
using PortFolio.Domain.Entities;

namespace PortFolio.Application.Queries;

public class GetWalletsQuery : IRequest<ICollection<WalletModel>>
{
}

public class GetWalletsQueryHandler : IRequestHandler<GetWalletsQuery, ICollection<WalletModel>>
{
    private readonly IWalletRepository _walletRepository;
    private readonly ICurrencyRepository _currencyRepository;
    private readonly IStockRepository _stockRepository;
    private readonly IStockWalletRepository _stockWalletRepository;
    private readonly IStockValueRepository _stockValueRepository;

    public GetWalletsQueryHandler(IWalletRepository walletRepository,
        ICurrencyRepository currencyRepository,
        IStockRepository stockRepository,
        IStockWalletRepository stockWalletRepository,
        IStockValueRepository stockValueRepository)
    {
        _walletRepository = walletRepository;
        _currencyRepository = currencyRepository;
        _stockRepository = stockRepository;
        _stockWalletRepository = stockWalletRepository;
        _stockValueRepository = stockValueRepository;
    }

    public Task<ICollection<WalletModel>> Handle(GetWalletsQuery request, CancellationToken cancellationToken)
    {
        ICollection<WalletModel> walletsModel = new List<WalletModel>();
        var wallets = _walletRepository.Get(null);
        var stocks = _stockRepository.Get(null);
        var currencies = _currencyRepository.Get(null);
        foreach (var wallet in wallets)
        {
            var stocksInWallet = _stockWalletRepository.Get(x => x.WalletId == wallet.Id);
            var assetOwned = new List<IAssetOwned>();
            foreach (var stockWallet in  stocksInWallet)
            {
                var stocksValue = _stockValueRepository.Get(x => x.StockId == stockWallet.StockValueId);
                var owned = (from s in stocksValue
                    join currency in currencies on s.CurrencyId equals currency.Id
                    join stock in stocks on s.StockId equals stock.Id
                    select new StockOwned()
                    {
                        AssetId = stock.Id,
                        Currency = currency.Name,
                        AssetName = stock.Name,
                        Value = stockWallet.Value
                    }).ToList();
                assetOwned.AddRange(owned);
            } 
            walletsModel.Add(new WalletModel(wallet.Id, wallet.Name, new AssetsModel(assetOwned)));
        }
        return Task.FromResult(walletsModel);
    }
}