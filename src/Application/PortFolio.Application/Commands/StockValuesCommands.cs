using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PortFolio.Application.Common.Interfaces.Repositories;
using PortFolio.Application.Common.Interfaces.Responses;
using PortFolio.Domain.Entities;

namespace PortFolio.Application.Commands;

public class SaveStockValueCommand : IRequestWrapper<int>
{
    /// <summary>
    /// Initialize a new Save Stock Request
    /// </summary>
    /// <param name="stockId"></param>
    /// <param name="currencyId"></param>
    /// <param name="valueInCurrency"></param>
    public SaveStockValueCommand(int stockId, int currencyId, decimal valueInCurrency)
    {
        CurrencyId = currencyId;
        StockId = stockId;
        ValueInCurrency = valueInCurrency;
    }

    public int CurrencyId { get; }
    public int StockId { get; }
    public decimal ValueInCurrency { get; }
}

public class SaveStockValuesCommandHandler : IWrappedRequestHandler<SaveStockValueCommand, int>
{
    private readonly IStockValueRepository _stockValueRepository;

    public SaveStockValuesCommandHandler(IStockValueRepository stockValueRepository)
    {
        _stockValueRepository = stockValueRepository;
    }

    public Task<IResponse<int>> Handle(SaveStockValueCommand request, CancellationToken cancellationToken)
    {
        var saved = _stockValueRepository.Save(new[]
        {
            new StockValue()
            {
                CurrencyId = request.CurrencyId,
                StockId = request.StockId,
                ValueInCurrency = request.ValueInCurrency,
            }
        });
        return Task.FromResult(ResponseHelper.Ok(1));
    }
}