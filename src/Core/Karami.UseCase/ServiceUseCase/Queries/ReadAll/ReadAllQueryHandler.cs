using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Domain.Service.Contracts.Interfaces;
using Karami.UseCase.ServiceUseCase.DTOs.ViewModels;

namespace Karami.UseCase.ServiceUseCase.Queries.ReadAll;

public class ReadAllQueryHandler : IQueryHandler<ReadAllQuery, List<ServicesViewModel>>
{
    private readonly IServiceQueryRepository _serviceQueryRepository;

    public ReadAllQueryHandler(IServiceQueryRepository serviceQueryRepository)
        => _serviceQueryRepository = serviceQueryRepository;

    public async Task<List<ServicesViewModel>> HandleAsync(ReadAllQuery query,
        CancellationToken cancellationToken
    )
    {
        var result = await _serviceQueryRepository.FindAllAsync(cancellationToken);

        return result.Select(service => new ServicesViewModel {
            Name         = service.Name                  ,
            Host         = service.Host                  ,
            IPAddress    = service.IPAddress             ,
            Port         = Convert.ToInt16(service.Port) ,
            ResponseTime = service.ResponseTime          ,
            Status       = service.Status 
        }).ToList();
    }
}