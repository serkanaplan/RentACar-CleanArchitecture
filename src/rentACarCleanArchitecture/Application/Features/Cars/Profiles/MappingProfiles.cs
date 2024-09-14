using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Cars.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCarCommand, Car>();
        CreateMap<Car, CreatedCarResponse>();

        CreateMap<UpdateCarCommand, Car>();
        CreateMap<Car, UpdatedCarResponse>();

        CreateMap<DeleteCarCommand, Car>();
        CreateMap<Car, DeletedCarResponse>();

        CreateMap<Car, GetByIdCarResponse>();

        CreateMap<Car, GetListCarListItemDto>();
        CreateMap<IPaginate<Car>, GetListResponse<GetListCarListItemDto>>();
    }
}