using Application.Features.Cars.Constants;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using static Application.Features.Cars.Constants.CarsOperationClaims;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommand : IRequest<CreatedCarResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid ModelId { get; set; }
    public required int Kilometer { get; set; }
    public required short ModelYear { get; set; }
    public required string Plate { get; set; }
    public required short MinFindexScore { get; set; }
    public required CarState CarState { get; set; }

    public string[] Roles => [Admin, Write, CarsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCars"];

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreatedCarResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly CarBusinessRules _carBusinessRules;

        public CreateCarCommandHandler(IMapper mapper, ICarRepository carRepository,
                                         CarBusinessRules carBusinessRules)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
        }

        public async Task<CreatedCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = _mapper.Map<Car>(request);

            await _carRepository.AddAsync(car);

            CreatedCarResponse response = _mapper.Map<CreatedCarResponse>(car);
            return response;
        }
    }
}