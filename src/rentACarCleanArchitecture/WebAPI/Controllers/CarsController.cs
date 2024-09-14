using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCarResponse>> Add([FromBody] CreateCarCommand command)
    {
        CreatedCarResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCarResponse>> Update([FromBody] UpdateCarCommand command)
    {
        UpdatedCarResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCarResponse>> Delete([FromRoute] Guid id)
    {
        DeleteCarCommand command = new() { Id = id };

        DeletedCarResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCarResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdCarQuery query = new() { Id = id };

        GetByIdCarResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListCarListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCarQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCarListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}