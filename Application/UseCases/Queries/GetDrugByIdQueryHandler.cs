using DrugsApt.Application.Interfaces.Repositories.DrugRepositories;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Queries;
/// <summary>
/// Обработчик события GetDrugByIdQuery
/// </summary>
/// <param name="drugReadRepository">репозиторий Drug для чтения</param>
public class GetDrugByIdQueryhandler(IDrugReadRepository drugReadRepository) : IRequestHandler<GetDrugByIdQuery, Drug?>
{
    public async Task<Drug?> Handle(GetDrugByIdQuery request, CancellationToken cancellationToken)
    {
       var responce = await drugReadRepository.GetByIdAsync(request.Id,cancellationToken);
       
       return responce;
    }
}