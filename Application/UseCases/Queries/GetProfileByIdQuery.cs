using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Queries;
/// <summary>
/// запрос на получения сущности Profile по идетификатору
/// </summary>
/// <param name="Id">идентификатор</param>
public record GetProfileByIdQuery(Guid Id) : IRequest<Profile>;