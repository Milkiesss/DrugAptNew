using DrugsApt.Application.Interfaces.Repositories.CountryRepositories;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Queries;
/// <summary>
/// Обработчик запроса GetCountryByIdQuery
/// </summary>
/// <param name="countryReadRepository">репозиторий Country для чтения</param>
public class GetCountryByIdQueryHandler(ICountryReadRepository countryReadRepository)
    : IRequestHandler<GetCountryByIdQuery, Country>
{

    public async Task<Country> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
       var responce = await countryReadRepository.GetByIdAsync(request.Id);

       return responce;
    }
}