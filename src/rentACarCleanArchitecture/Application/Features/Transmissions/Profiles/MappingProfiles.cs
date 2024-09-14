using Application.Features.Transmissions.Commands.Create;
using Application.Features.Transmissions.Commands.Delete;
using Application.Features.Transmissions.Commands.Update;
using Application.Features.Transmissions.Queries.GetById;
using Application.Features.Transmissions.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Transmissions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateTransmissionCommand, Transmission>();
        CreateMap<Transmission, CreatedTransmissionResponse>();

        CreateMap<UpdateTransmissionCommand, Transmission>();
        CreateMap<Transmission, UpdatedTransmissionResponse>();

        CreateMap<DeleteTransmissionCommand, Transmission>();
        CreateMap<Transmission, DeletedTransmissionResponse>();

        CreateMap<Transmission, GetByIdTransmissionResponse>();

        CreateMap<Transmission, GetListTransmissionListItemDto>();
        CreateMap<IPaginate<Transmission>, GetListResponse<GetListTransmissionListItemDto>>();
    }
}