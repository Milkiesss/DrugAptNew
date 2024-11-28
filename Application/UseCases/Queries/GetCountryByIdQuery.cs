using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Queries;
/// <summary>
/// запрос на получения сущности Country по идетификатору
/// </summary>
/// <param name="Id">идентификатор</param>
public record GetCountryByIdQuery(Guid Id): IRequest<Country>;