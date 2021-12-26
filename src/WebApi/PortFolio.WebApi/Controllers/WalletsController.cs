using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortFolio.Application.Commands;
using PortFolio.Application.Queries;
using PortFolio.Domain.Entities;

namespace PortFolio.WebApi.Controllers;


[ApiController]
[Route("[controller]")]
public class StocksValueController : ControllerBase
{
    private readonly IMediator _mediator;

    public StocksValueController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetStockPairs()
    {
        var stocks = await _mediator.Send(new GetStockValuesQuery());
        return Ok(stocks);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> SaveStockPairs([FromBody]StockValue value)
    {
        return Ok(await _mediator.Send(new SaveStockValueCommand(value.StockId, value.CurrencyId, value.ValueInCurrency)));
    }
}

[ApiController]
[Route("[controller]")]
public class WalletsController : ControllerBase
{
    private readonly IMediator _mediator;

    public WalletsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetWallet()
    {
        var wallets = await _mediator.Send(new GetWalletsQuery());
        return Ok(wallets);
    }
}