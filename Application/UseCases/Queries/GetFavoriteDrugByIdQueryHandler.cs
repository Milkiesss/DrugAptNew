using DrugsApt.Application.Interfaces.Repositories.FavoriteDrugRepositories;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Queries;

/// <summary>
/// обработчик запрос GetFavoriteDrugByIdQuery
/// </summary>
/// <param name="favoriteDrugReadRepositories">репозиторий FavoriteDrug для чтения</param>
public class GetFavoriteDrugByIdQueryHandler(IFavoriteDrugReadRepositories favoriteDrugReadRepositories)
    : IRequestHandler<GetFavoriteDrugByIdQuery, FavoriteDrug>
{
    public async Task<FavoriteDrug> Handle(GetFavoriteDrugByIdQuery request, CancellationToken cancellationToken)
    {
        var responce = await favoriteDrugReadRepositories.GetByIdAsync(request.id);
        return responce;
    }
}