using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PortFolio.Application.Common.Interfaces.Repositories;
using PortFolio.Application.Models;
using PortFolio.Domain.Entities;

namespace PortFolio.Application.Queries;

public class GetStockValuesQuery : IRequest<ICollection<StockValueModel>>
{
    public GetStockValuesQuery(Expression<Func<StockValue, bool>> filter = null)
    {
        Filter = filter;
    }

    public Expression<Func<StockValue, bool>> Filter { get; }
}

public class GetStockValuesQueryHandler : IRequestHandler<GetStockValuesQuery, ICollection<StockValueModel>>
{
    private readonly IStockValueRepository _stockValueRepository;
    private readonly ICurrencyRepository _currencyRepository;
    private readonly IStockRepository _stockRepository;

    public GetStockValuesQueryHandler(IStockValueRepository stockValueRepository,
        ICurrencyRepository currencyRepository,
        IStockRepository stockRepository)
    {
        _stockValueRepository = stockValueRepository;
        _currencyRepository = currencyRepository;
        _stockRepository = stockRepository;
    }

    public Task<ICollection<StockValueModel>> Handle(GetStockValuesQuery request, CancellationToken cancellationToken)
    {
        var stockValues = _stockValueRepository.Get(request.Filter);
        var currenciesId = stockValues.Select(x => x.CurrencyId);
        var stockIds = stockValues.Select(x => x.StockId);
        var currencies = _currencyRepository.Get(x => currenciesId.Contains(x.Id))
            .ToDictionary(x => x.Id, x => x.Name);
        var stocks = _stockRepository.Get(x => stockIds.Contains(x.Id))
            .ToDictionary(x => x.Id, x => x.Name);

        ICollection<StockValueModel> stockValueModels = new List<StockValueModel>();

        foreach (var stockValue in stockValues)
        {
            currencies.TryGetValue(stockValue.CurrencyId, out var c);
            stocks.TryGetValue(stockValue.StockId, out var s);
            
            if (c is not null && s is not null)
                stockValueModels.Add(new StockValueModel(c, s, stockValue.ValueInCurrency));
        }
        return Task.FromResult(stockValueModels);
    }
}