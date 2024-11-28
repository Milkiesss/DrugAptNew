using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Queries;
/// <summary>
/// запрос на получения сущности DruStore по идетификатору
/// </summary>
/// <param name="Id">идентификатор</param>
public record GetDrugStoreByIdQuery(Guid Id) : IRequest<DrugStore>;