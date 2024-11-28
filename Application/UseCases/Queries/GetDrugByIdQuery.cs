using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Queries;
/// <summary>
/// запрос на получения сущности Drug по идетификатору
/// </summary>
/// <param name="Id">идентификатор</param>
public record GetDrugByIdQuery(Guid Id) : IRequest<Drug?>;