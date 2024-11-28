using DrugsApt.Application.Interfaces.Repositories.DrugStoreRepositories;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Queries;
/// <summary>
/// обработчик запроса GetDrugStoreByIdQuery
/// </summary>
/// <param name="drugStoreReadRepository">репозиторий DrugStore для чтения</param>
public class GetDrugStoreByIdQueryHandler(IDrugStoreReadRepository drugStoreReadRepository)
    : IRequestHandler<GetDrugStoreByIdQuery, DrugStore>
{
    public async Task<DrugStore> Handle(GetDrugStoreByIdQuery request, CancellationToken cancellationToken)
    {
       var responce = await drugStoreReadRepository.GetByIdAsync(request.Id, cancellationToken);
       
       return responce;
    }
}