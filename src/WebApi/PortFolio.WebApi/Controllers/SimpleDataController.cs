using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortFolio.Application.Queries;

namespace PortFolio.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SimpleDataController : ControllerBase
{
    private readonly IMediator _mediator;

    public SimpleDataController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetSimpleDataQuery()));
    }
}