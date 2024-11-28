using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Queries;
/// <summary>
/// запрос на получения сущности FavoriteDrug по идетификатору
/// </summary>
/// <param name="Id">идентификатор</param>
public record GetFavoriteDrugByIdQuery(Guid id) : IRequest<FavoriteDrug>;