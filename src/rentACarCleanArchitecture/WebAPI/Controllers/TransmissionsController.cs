using Application.Features.Transmissions.Commands.Create;
using Application.Features.Transmissions.Commands.Delete;
using Application.Features.Transmissions.Commands.Update;
using Application.Features.Transmissions.Queries.GetById;
using Application.Features.Transmissions.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransmissionsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedTransmissionResponse>> Add([FromBody] CreateTransmissionCommand command)
    {
        CreatedTransmissionResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedTransmissionResponse>> Update([FromBody] UpdateTransmissionCommand command)
    {
        UpdatedTransmissionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedTransmissionResponse>> Delete([FromRoute] Guid id)
    {
        DeleteTransmissionCommand command = new() { Id = id };

        DeletedTransmissionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTransmissionResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdTransmissionQuery query = new() { Id = id };

        GetByIdTransmissionResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListTransmissionListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTransmissionQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListTransmissionListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}